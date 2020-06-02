using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ByNotice
{
    public class NoticeService
    {
        public async Task NotifyAsync(NoticeOption option)
        {
            if (Notice.Instance != null)
            {
                await Notice.Instance.NotifyAsync(option);
            }
        }

        public async Task NotifyInfoAsync(NoticeOption option)
        {
            option.IconType = IconType.Info;
            await NotifyAsync(option);
        }

        public async Task NotifySuccessAsync(NoticeOption option)
        {
            option.IconType = IconType.Success;
            await NotifyAsync(option);
        }

        public async Task NotifyWarningAsync(NoticeOption option)
        {
            option.IconType = IconType.Warning;
            await NotifyAsync(option);
        }
        
        public async Task NotifyErrorAsync(NoticeOption option)
        {
            option.IconType = IconType.Error;
            await NotifyAsync(option);
        }
    }

    public static class NoticeServiceExtension
    {
        public static IServiceCollection AddByNotice(this IServiceCollection services)
        {
            services.TryAddScoped<NoticeService>();
            return services;
        }
    }
}
