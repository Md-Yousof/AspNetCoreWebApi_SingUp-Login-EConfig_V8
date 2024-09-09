using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentService.Models;

namespace UserManagmentService.Services
{
    public interface IEmailServices
    {
        void SendEmail(Message message);
    }
}
