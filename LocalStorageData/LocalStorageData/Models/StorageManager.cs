using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LocalStorageData.Models
{
    public class StorageManager
    {
        private List<ViewModels.User> users;

        public List<ViewModels.User> Users
        {
            get
            {
                if (users == null)
                {
                    users = (List<ViewModels.User>)ApplicationData.Current.LocalSettings.Values["Users"]
                        ?? new List<ViewModels.User>();
                }
                return users;
            }
            set
            {
                users = value;
                ApplicationData.Current.LocalSettings.Values["Users"] = users;
            }
        }

        public bool Add(ViewModels.User user)
        {
            if (!IsExists(user.Username))
            {
                Users.Add(user);
                return true;
            }
            return false;
        }

        public bool IsExists(string Username)
        {
            return Users.Select(user => user.Username).Contains(Username);
        }

        public void Save()
        {
            ApplicationData.Current.LocalSettings.Values["Users"] = Users;
        }
    }
}
