using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using Abp.UI;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.Configuration;
using Iconiz.Boilerplate.IconizFinance.Dto;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iconiz.Boilerplate.IconizFinance
{
    public class JinseTopicSyncWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IRepository<IconizTopic> _iconizTopicRepository;
        private const int CheckTopicAsMilliseconds = 60 * 1000; //1 minutes


        public JinseTopicSyncWorker(
            IRepository<IconizTopic> iconizTopicRepository,
            AbpTimer timer) : base(timer)
        {
            _iconizTopicRepository = iconizTopicRepository;

            Timer.Period = CheckTopicAsMilliseconds;
            Timer.RunOnStart = true;
        }

        protected override void DoWork()
        {
            var accessKey = SettingManager.GetSettingValue(AppSettings.JinseManagement.AccessKey);
            var secretKey = SettingManager.GetSettingValue(AppSettings.JinseManagement.SecretKey);

            var httpParams = new Dictionary<string, string>
            {
                {"access_key", accessKey},
                {"date", NowDateTimeToUnixTimestamp().ToString()},
                {"secret_key", secretKey}
            };

            var signString = http_build_query(httpParams);

            httpParams.Add("sign", GetMd5Hash(signString));
            try
            {
                var url = "http://api.jinse.com/topic/list?" + http_build_query(httpParams);
                var json = new HttpClient().GetStringAsync(url).Result;
                var result = JsonConvert.DeserializeObject<JinseTopicListOutput[]>(json);

                foreach (var jinsetopic in result)
                {
                    if (_iconizTopicRepository.FirstOrDefault(t => t.Source == "jinse" && t.SourceId == jinsetopic.id) == null)
                    {
                        var newtopic = new IconizTopic
                        {
                            Source = "jinse",
                            SourceId = jinsetopic.id,
                            Url = jinsetopic.url,
                            Title = jinsetopic.title,
                            Summary = jinsetopic.summary,
                            Content = jinsetopic.content,
                            PublishTime = jinsetopic.published_time,
                            Resource = jinsetopic.resource,
                            ResourceUrl = jinsetopic.resource_url,
                            Author = jinsetopic.author,
                            Thumbnail = jinsetopic.thumbnail,
                            TopicStatus = TopicStatusEnum.正常
                        };
                        _iconizTopicRepository.Insert(newtopic);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
            }
        }

        private static long NowDateTimeToUnixTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
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