using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.ViewModel
{
    public class PicturesViewModel : BindableBase
    {
        public ObservableCollection<Picture> UserPictures
        {
            get
            {
                return DataBase.LoggedUser.Pictures;
            }
        }
    }
}
