using Abp.Net.Mail.Smtp;
using Acme.SimpleTaskApp.Tasks.Dtos;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Email
{
    public class EmailManager : SimpleTaskAppAppServiceBase, IEmailManager
    {
        private readonly ISmtpEmailSender _emailSender;

        public EmailManager(ISmtpEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Assign(TaskListDto task, string emailAddress)
        {

            //Send a notification email
            await _emailSender.SendAsync(
                to: emailAddress,
                subject: $"hello {task.AssignedPersonName} You have a new task!",
                body: $"A new task is assigned for you: <b>{task.Title}</b>",
                isBodyHtml: true
            );
        }
    }
}
