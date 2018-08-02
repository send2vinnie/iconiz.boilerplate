using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iconiz.Boilerplate.MultiTenancy.HostDashboard.Dto;

namespace Iconiz.Boilerplate.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}