using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM1.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            LoginCommand = new MyICommand(Login, CanLogin);
            RegisterCommand = new MyICommand(Register, CanRegister);
        }

        public MyICommand LoginCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static MainWindowViewModel m;

        public bool CanLogin()
        {
            return true;
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        public bool CanRegister()
        {
            return CanLogin();
        }

        public void Login()
        {
            if (DataBase.LoginUser(Username, Password))
            {
                m.OnNav("pictures");
                isLogged = true;
            }
        }

        public void Register()
        {
            if (DataBase.AddUser(Username, Password))
            {
                m.OnNav("addPicture");
                isRegistred = true;
            }
        }


        private bool isLogged = false;
        private bool isRegistred = false;
        
        public bool IsLogged { get { return isLogged || isRegistred; } }

    }
}
