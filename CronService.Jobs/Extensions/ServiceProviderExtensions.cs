using System;
using CronService.Jobs.Constants;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace CronService.Jobs.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IJob GetJobOrThrow(this IServiceProvider provider, Type jobType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (jobType == null)
            {
                throw new ArgumentNullException(nameof(jobType));
            }

            var result = provider.GetRequiredService(jobType) as IJob;
            if (result == null)
            {
                throw new ArgumentException(string.Format(ExceptionConstants.Formats.CantResolveJob, jobType.FullName));
            }

            return result;
        }
    }
}