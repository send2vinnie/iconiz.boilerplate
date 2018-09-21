using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Caching;
using Iconiz.Boilerplate.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Abp.Collections.Extensions;
using Abp.UI;
using Iconiz.Boilerplate.IconizFinance.Dto;
using Newtonsoft.Json;

namespace Iconiz.Boilerplate.IconizFinance
{
    public class IconizFinanceAppService : BoilerplateAppServiceBase, IIconizFinanceAppService
    {
        private readonly ICacheManager _cacheManager;

        public IconizFinanceAppService(
            ICacheManager cacheManager
        )
        {
            _cacheManager = cacheManager;
        }

        public async Task<JinseTopicListOutput[]> GetJinseTopic(string last_id = null)
        {
            var cacheitem = _cacheManager.GetCache("jinseapi").GetOrDefault<string, JinseTopicListOutput[]>("topiclist" + last_id);
            if (cacheitem != null)
                return cacheitem;

            var accessKey = await SettingManager.GetSettingValueAsync(AppSettings.JinseManagement.AccessKey);
            var secretKey = await SettingManager.GetSettingValueAsync(AppSettings.JinseManagement.SecretKey);
            var httpParams = new Dictionary<string, string>
            {
                {"access_key", accessKey},
                {"date", DateTimeToUnixTimestamp(DateTime.Now)},
                {"secret_key", secretKey}
            };
            if (last_id != null)
                httpParams.Add("last_id", last_id);
            
            var signString = http_build_query(httpParams);

            httpParams.Add("sign", GetMd5Hash(signString));
            try
            {
                var url = "http://api.jinse.com/topic/list?" + http_build_query(httpParams);
                var json = await new HttpClient().GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<JinseTopicListOutput[]>(json);
                _cacheManager.GetCache("jinseapi").Set("topiclist" + last_id, result, null, TimeSpan.FromMinutes(3));
                return result;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        public async Task<JinseLiveOutput> GetJinseLive()
        {
            var url = " http://api.jinse.com/live/list";
            var json = await new HttpClient().GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<JinseLiveOutput>(json);
            return result;
        }

        private static string DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds.ToString();
        }

        private static string http_build_query(Dictionary<string, string> httpParams)
        {
            var sort = from httpParam in httpParams orderby httpParam.Key select httpParam;
            return string.Join("&", sort.Select(h => h.Key + "=" + h.Value));
        }

        static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString().ToLower();
        }
    }
}