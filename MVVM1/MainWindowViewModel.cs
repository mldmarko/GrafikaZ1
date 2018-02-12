using MVVM1.Model;
using MVVM1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVVM1
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private AddPictureViewModel addPictureViewModel = new AddPictureViewModel();
        private PicturesViewModel picturesViewModel = new PicturesViewModel();
        private LoginViewModel loginViewModel = new LoginViewModel();
        private ChangeProfilViewModel changeProfilViewModel = new ChangeProfilViewModel();
        private BindableBase currentViewModel;

        ObservableCollection<User> users = new ObservableCollection<User>();
        public MainWindowViewModel()
        {
           /* XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            using (TextWriter textWriter = new StreamWriter("baza.xml"))
            {
                serializer.Serialize(textWriter, users);
            }*/
            NavCommand = new MyICommand<string>(OnNav, CanOnNav);
            CurrentViewModel = loginViewModel;
            LoginViewModel.m = this;
        }


        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }


        public void OnNav(string destination)
        {
            switch(destination)
            {
                case "pictures":
                    CurrentViewModel = picturesViewModel;
                    break;
                case "addPicture":
                    CurrentViewModel = addPictureViewModel;
                    break;
                case "changeProfil":
                    CurrentViewModel = changeProfilViewModel;
                    changeProfilViewModel.Username = DataBase.LoggedUser.UserName;
                    changeProfilViewModel.Password = DataBase.LoggedUser.Password;
                    break;
            }
        }


        private bool CanOnNav(string s)
        {
            return true;
            return loginViewModel.IsLogged;
        }
    }
}
