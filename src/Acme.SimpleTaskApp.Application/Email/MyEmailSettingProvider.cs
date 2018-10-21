using Abp.Configuration;
using System.Collections.Generic;

namespace Acme.SimpleTaskApp.Email
{
    public class MyEmailSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                    {
                    new SettingDefinition(
                        "Abp.Net.Mail.DefaultFromAddress",
                        "sample@domain.com"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.DefaultFromDisplayName",
                        "simpletaskapp"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.Host",
                        "smtp.qq.com"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.Port",
                        "587"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.UserName",
                        "sample@domain.com"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.Password",
                        "xxxxxxxxxxxxxxx"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.Domain",
                        ""
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.EnableSsl",
                        "true"
                        ),

                    new SettingDefinition(
                        "Abp.Net.Mail.Smtp.UseDefaultCredentials",
                        "false"
                        ),
                };
        }
    }
}
