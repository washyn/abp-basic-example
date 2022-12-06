﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;
using Volo.Abp.Uow;

namespace Washyn.Tests
{
    public class TestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
        where TStartupModule : IAbpModule
    {
        #region Overrides

        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }

        protected override void BeforeAddApplication(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false);
            builder.AddJsonFile("appsettings.secrets.json", true);
            services.ReplaceConfiguration(builder.Build());
        }

        #endregion


        #region Methods

        
        protected virtual Task WithUnitOfWorkAsync(Func<Task> func)
        {
            return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);
        }

        protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
                using (var uow = uowManager.Begin(options))
                {
                    await action();
                    await uow.CompleteAsync();
                }
            }
        }
        
        
        protected virtual Task<TResult> WithUnitOfWorkAsync<TResult>(Func<Task<TResult>> func)
        {
            return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);
        }

        protected virtual async Task<TResult> WithUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options, Func<Task<TResult>> func)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
                using (var uow = uowManager.Begin(options))
                {
                    var result = await func();
                    await uow.CompleteAsync();
                    return result;
                }
            }
        }

        #endregion
    }
}