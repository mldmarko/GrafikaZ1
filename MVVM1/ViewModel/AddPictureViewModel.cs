using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM1.ViewModel
{
    public class AddPictureViewModel : BindableBase
    {
        public AddPictureViewModel()
        {
            BrowseCommand = new MyICommand(OnBrowse);
            AddCommand = new MyICommand(OnAdd);
            MyPicture = new Picture();
        }

        public MyICommand BrowseCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public Picture MyPicture { get; set; }
        public ImageSource MyPictureSource { get; set; }

        void OnBrowse()

        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string imagePath = dlg.FileName;


                MyPictureSource = Picture.ConvertPathToImage(imagePath);
                OnPropertyChanged("MyPictureSource");

                MyPicture.PicturePath = imagePath;
            }

        }

        void OnAdd()
        {
            DataBase.AddPicture(MyPicture);
            LoginViewModel.m.OnNav("pictures");
        }

    }
}
