using ESD.IDP.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESD.IDP
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddESDUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IESDUserRepository, ESDUserRepository>();
            builder.AddProfileService<ESDUserProfileService>();
            return builder;
        }
    }
}
