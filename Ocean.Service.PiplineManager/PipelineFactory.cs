using Microsoft.Extensions.DependencyInjection;
using Ocean.Activity.HttpClientService.Middleware;
using Ocean.Activity.HttpClientService.Options;
using Ocean.Activity.ResponseService.Middleware;
using Ocean.Activity.SmtpClientService.Middleware;
using Ocean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Service.PipelineManager
{
    public enum JobType
    {
        HttpClientService,
        SmtpClientService,
        ResponseService,
        ProcessJob
    }
    public class PipelineFactory : IPipelineFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public PipelineFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IPipelineMiddleware CreateJob(string jobType) => jobType switch
        {
            nameof(JobType.HttpClientService) => _serviceProvider.GetRequiredService<HttpClientJob>(),
            nameof(JobType.SmtpClientService) => _serviceProvider.GetRequiredService<SmtpClientJob>(),
            nameof(JobType.ResponseService) => _serviceProvider.GetRequiredService<ResponseJob>(),
            //"ProcessJob" => _serviceProvider.GetRequiredService<ProcessJob>(),
            _ => throw new InvalidOperationException($"Unknown job type: {jobType}")
        };

    }
}

