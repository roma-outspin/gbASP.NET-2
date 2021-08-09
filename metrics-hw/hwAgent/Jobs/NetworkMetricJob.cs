using hwAgent.DAL;
using hwAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace hwAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", performanceCounterCategory.GetInstanceNames()[0]);
        }

        public Task Execute(IJobExecutionContext context)
        {
            var networkPerfomance = Convert.ToInt32(_networkCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            // теперь можно записать что-то при помощи репозитория

            _repository.Create(new NetworkMetric { Time = time, Value = networkPerfomance });

            return Task.CompletedTask;
        }
    }
}
