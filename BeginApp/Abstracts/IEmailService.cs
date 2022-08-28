using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginApp.Abstracts
{
    public interface IEmailService
    {
        void Send(Message message);
    }
}
