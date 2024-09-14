using Ocean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Service.PipelineManager
{
    public class PipelineManagerService
    {
        private readonly IPipelineFactory _piplineFactory;

        public PipelineManagerService(IPipelineFactory piplineFactory)
        {
            _piplineFactory = piplineFactory;

        }

        public async Task<object> ExecutePipelineAsync(List<JobDefinition> jobs, object initialData)
        {
            // Tüm job'ları BaseID ile ilişkilendiriyoruz
            var jobMap = jobs.ToDictionary(j => j.BaseID);

            // ParentId'si 0 olan root job'ları buluyoruz (başlangıç job'ları)
            var rootJobs = jobs.Where(j => j.ParentId == 0).ToList();

            object result = initialData;

            // Root job'ları sırasıyla işleyelim
            foreach (var rootJob in rootJobs)
            {
                result = await ExecuteJobAsync(rootJob, jobMap, result);
            }

            return result;
        }
        private async Task<object> ExecuteJobAsync(JobDefinition currentJob, Dictionary<int, JobDefinition> jobMap, object input)
        {
            // İşlenecek middleware'i oluştur
            var middleware = _piplineFactory.CreateJob(currentJob.JobType);

            // Middleware'i çalıştır ve input'u güncelle
            input = await middleware.InvokeAsync(input, () => Task.FromResult(input), currentJob.Parameters);

            // Bu job'un child'larını bulalım
            var childJobs = jobMap.Values.Where(j => j.ParentId == currentJob.BaseID).ToList();

            // Child job'ları sırayla çalıştıralım
            foreach (var childJob in childJobs)
            {
                input = await ExecuteJobAsync(childJob, jobMap, input);
            }

            return input;
        }

    }
}
