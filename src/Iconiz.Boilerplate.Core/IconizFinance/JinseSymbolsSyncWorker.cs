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
    public class JinseSymbolsSyncWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private const int CheckTopicAsMilliseconds = 60 * 60 * 1000; //1 hours
        public static List<JinseSymbol> SymbolCache;

        public JinseSymbolsSyncWorker(
            AbpTimer timer) : base(timer)
        {
            Timer.Period = CheckTopicAsMilliseconds;
            Timer.RunOnStart = true;
        }

        protected override void DoWork()
        {
            try
            {
                var url = "http://market.jinse.com/api/v1/symbols";
                var json = new HttpClient().GetStringAsync(url).Result;
                SymbolCache = JsonConvert.DeserializeObject<List<JinseSymbol>>(json);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
            }
        }
    }
}