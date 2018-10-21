using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.SimpleTaskApp.Email;

namespace Acme.SimpleTaskApp
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleTaskAppApplicationModule : AbpModule
    {

        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<MyEmailSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppApplicationModule).GetAssembly());
        }
    }
}