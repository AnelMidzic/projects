using AdminModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Admin.ViewModel.NewEditWindowViewModel;

namespace Admin.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginWindowViewModel()
        {
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Password"));
            }
        }

        public bool IsUserAdmin
        {
            get
            {
                var loggedUser = new User(UserName, Password);
                return loggedUser.IsUserAdmin();
            }
        }

        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set
            {
                if (loginCommand == value)
                {
                    return;
                }
                loginCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoginCommand"));
            }
        }

        private bool CanUserLogin(object sender)
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password));
        }

    }
}



