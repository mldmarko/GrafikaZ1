using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM1.ViewModel
{
    class ChangeProfilViewModel : BindableBase
    {
        public ChangeProfilViewModel()
        {
            ChangeCommand = new MyICommand(Change, CanChange);
           
        }

        private string username, password;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public MyICommand ChangeCommand { get; set; }

        void Change()
        {
            if(DataBase.ChangeUserData(Username, Password))
            {
                MessageBox.Show("Succesfully changed data.");
            }
            else
            {
                MessageBox.Show("Error, data not changed.");
            }
        }

        bool CanChange()
        {
            return true;
        }
    }
}
