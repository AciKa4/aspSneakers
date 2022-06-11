using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.Emails
{
    public interface IEmailSender
    {
        void Send(EmailDto message);
    }


}
