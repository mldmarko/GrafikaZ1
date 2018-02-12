using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace MVVM1
{

    public class DataBase
    {
        public static bool userLogged = false;
        public static User LoggedUser = new User();
        public static ObservableCollection<User> users;

        static DataBase()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<User>));
            using (TextReader reader = new StreamReader("baza.xml"))
            {
                users = (ObservableCollection<User>)deserializer.Deserialize(reader);
            }
        }


        public static bool LoginUser(string username, string password)
        {
            foreach (var item in users)
            {
                if (item.UserName == username)
                {
                    if (item.Password == password)
                    {
                        LoggedUser = item;
                        return true;
                    }
                }
            }
            MessageBox.Show("Invalid username or password");
            return false;
        }

        public static bool AddUser(string username, string password)
        {
            foreach (var item in users)
            {
                if (item.UserName == username)
                {
                    MessageBox.Show("Username not unique.");
                    return false;
                }
            }

            users.Add(new User() { UserName = username, Password = password });
            SaveChanges();
            return true;
        }

        internal static void AddPicture(Picture myPicture)
        {
            LoggedUser.Pictures.Add(myPicture);
            SaveChanges();
        }

        public static bool ChangeUserData(string username, string password)
        {
            foreach (var item in users)
            {
                if (item.UserName == username && username != LoggedUser.UserName)
                {
                    MessageBox.Show("Username not unique.");
                    return false;
                }
            }

            foreach (var item in users)
            {
                if (item.UserName == LoggedUser.UserName)
                {
                    item.UserName = username;
                    item.Password = password;
                    SaveChanges();
                    return true;
                }
            }


            return false;
        }


        static void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            using (TextWriter textWriter = new StreamWriter("baza.xml"))
            {
                serializer.Serialize(textWriter, users);
            }
        }
    }
}

