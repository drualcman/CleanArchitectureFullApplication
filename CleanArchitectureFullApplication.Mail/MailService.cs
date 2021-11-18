using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Mail
{
    public class MailService : IMailService
    {
        readonly IApplicationStatusLogger Logger;
        public MailService(IApplicationStatusLogger logger) => Logger = logger;

        public ValueTask Send(string message)
        {
            Logger.Log($"*** Mail service: {message}");
            Logger.Log($"*** Mail service: Servidor de correo no configurado.");
            return ValueTask.CompletedTask;
        }
    }
}
