using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using Iconiz.Boilerplate.IconizFinance.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Iconiz.Boilerplate.IconizFinance;
using Microsoft.AspNetCore.Http;

namespace Iconiz.Boilerplate.IconizFinance
{
    [AbpAllowAnonymous]
    public class IconizFinanceAppService : BoilerplateAppServiceBase, IIconizFinanceAppService
    {
        private readonly IRepository<IconizTopic> _iconizTopicRepository;
        private readonly IRepository<IconizTopicComment> _iconizTopicCommentRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly ICacheManager _cacheManager;

        public IconizFinanceAppService(
            IRepository<IconizTopic> iconizTopicRepository,
            IRepository<IconizTopicComment> iconizTopicCommentRepository,
            IHttpContextAccessor accessor,
            ICacheManager cacheManager
        )
        {
            _iconizTopicRepository = iconizTopicRepository;
            _iconizTopicCommentRepository = iconizTopicCommentRepository;
            _accessor = accessor;
            _cacheManager = cacheManager;
        }

        public async Task<PagedResultDto<GetIconizTopicOutput>> GetJinseTopic(GetIconizTopicInput input)
        {
            try
            {
                var query = _iconizTopicRepository.GetAll()
                    .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Title.Contains(input.Keyword) || t.Summary.Contains(input.Keyword))
                    .Where(t => t.Source == "jinse");
                var resultCount = await query.CountAsync();
                var results = await query
                    .OrderByDescending(t => t.SourceId)
                    .PageBy(input)
                    .ToListAsync();

                var topics = ObjectMapper.Map<List<GetIconizTopicOutput>>(results);

                return new PagedResultDto<GetIconizTopicOutput>(resultCount, topics);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        public async Task<List<JinseTicker>> GetJinseTickers()
        {
            var cacheitem = await _cacheManager.GetCache("JinseTickers").GetOrDefaultAsync("JinseTickers");
            if (cacheitem != null)
                return cacheitem as List<JinseTicker>;

            if (JinseSymbolsSyncWorker.SymbolCache == null)
                return null;
            var symbols = JinseSymbolsSyncWorker.SymbolCache.OrderBy(e => Guid.NewGuid()).Take(24).ToList();
            var jinseTickers = new List<JinseTicker>();
            foreach (var ticker in symbols)
            {
                var url = "http://market.jinse.com/api/v1/tick/" + ticker.ticker + "?unit=cny";
                var json = await new HttpClient().GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<JinseTicker>(json);
                jinseTickers.Add(result);
            }

            await _cacheManager.GetCache("JinseTickers").SetAsync("JinseTickers", jinseTickers, null, TimeSpan.FromMinutes(10));

            return jinseTickers;
        }

        public async Task<IconizTopicOneDto> GetOneJinseTopic(int id)
        {
            try
            {
                var topic = await _iconizTopicRepository.GetAllIncluding(f => f.IconizTopicComments).FirstOrDefaultAsync(t => t.Id == id);
                topic.ReadCount++;
                await _iconizTopicRepository.UpdateAsync(topic);

                var topicr = ObjectMapper.Map<IconizTopicOneDto>(topic);
                return topicr;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        public async Task<JinseLiveOutput> GetJinseLive()
        {
            var url = "http://api.jinse.com/live/list";
            var json = await new HttpClient().GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<JinseLiveOutput>(json);
            return result;
        }

        [AbpAuthorize]
        public async Task PostUpOrDown(string type, int topicId)
        {
            var key = AbpSession.GetUserId().ToString();
            var cacheitem = await _cacheManager.GetCache("TopicUpDown").GetOrDefaultAsync(key);
            if (cacheitem != null)
                throw new UserFriendlyException("您投票太频繁了,请1小时后再试!");
            await _cacheManager.GetCache("TopicUpDown").SetAsync(key, "", null, TimeSpan.FromHours(1));

            var topic = await _iconizTopicRepository.FirstOrDefaultAsync(t => t.Id == topicId);
            if (topic == null)
                throw new UserFriendlyException("文章不存在!");
            if (type == "up")
                topic.UpCount++;
            else if (type == "down")
                topic.DownCount++;
            else
                throw new UserFriendlyException("不支持的操作 " + type);
            await _iconizTopicRepository.UpdateAsync(topic);
        }

        [AbpAuthorize]
        public async Task PostNewComment(IconizTopicNewCommentInput input)
        {
            var topic = await _iconizTopicRepository.FirstOrDefaultAsync(t => t.Id == input.TopicId);
            if (topic == null)
                throw new UserFriendlyException("文章不存在!");
            topic.CommitCount++;
            await _iconizTopicRepository.UpdateAsync(topic);

            var newComment = new IconizTopicComment();
            newComment.Content = Regex.Replace(input.Content, "<.*?>", "").Replace("&nbsp;", "");
            newComment.AuthorId = GetCurrentUser().Id;
            newComment.AuthorName = GetCurrentUser().Name;
            newComment.TopicId = input.TopicId;
            newComment.AuthorIP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            await _iconizTopicCommentRepository.InsertAsync(newComment);
        }
    }
}