using Movies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IReportService
    {
        public void PublishDailyReport(DailyReportDTO report);
    }
}
