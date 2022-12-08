using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whistleblower.Commands;

namespace Whistleblower.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }    

        #region Commands
        public LoginBNTCommand  LoginBNTCommand { get; } = new LoginBNTCommand();
        #endregion



    }
}
