using AdminModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Admin.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
      
        private User currentUser;
        private UserCollection userList;

        private Mediator mediator;

        public MainWindowViewModel(Mediator mediator)
        {
            this.mediator = mediator;

            DeleteCommand = new RelayCommand(DeleteExecute, CanDelete);

            userList = UserCollection.GetUsers();
            CurrentUser = new User();

            mediator.Register("UserChange", UserChanged);
        }

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public UserCollection UserList
        {
            get { return userList; }
            set
            {
                if (userList==value)
                {
                    return;
                }
                userList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserList"));
            }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                if (deleteCommand == value)
                {
                    return;
                }
                deleteCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DeleteCommand"));
            }
        }

        void DeleteExecute(object obj)
        {
            CurrentUser.DeleteUser();
            UserList.Remove(CurrentUser);
        }

        bool CanDelete(object obj)
        {

            if (CurrentUser == null) return false;

            return true;
        }



        private void UserChanged(object obj)
        {
            User user = (User)obj;

            int index = UserList.IndexOf(user);

            if (index != -1)
            {
                UserList.RemoveAt(index);
                UserList.Insert(index, user);
            }
            else
            {
                UserList.Add(user);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
