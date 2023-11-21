using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Dtos.Emails;

namespace rpg.Services.Emails
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}