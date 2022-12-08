using Whistleblower.Commands;

namespace Whistleblower.MVVM.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }    

        #region Commands
        public TryLoginCommand  LoginBNTCommand { get; } = new TryLoginCommand();
        #endregion
    }
}
