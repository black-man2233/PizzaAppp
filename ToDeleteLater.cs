using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace WPFAPP
{
    class MainWindowViewModel : BindableBase
    {

        private bool _isButtonClicked;

        public bool IsButtonClicked
        {
            get { return _isButtonClicked; }
            set { SetProperty(ref _isButtonClicked, value); }
        }


        #region Constructor  
        public MainWindowViewModel()
        {
            RegisterButtonClicked = new RelayCommand(RegisterUser, CanUserRegister);
            ResetButtonClicked = new RelayCommand(ResetPage, CanResetPage);
        }

        #region ICommands  
        public ICommand RegisterButtonClicked { get; set; }
        public ICommand ResetButtonClicked { get; set; }
        #endregion

        #endregion

        #region Event Methods  
        private void RegisterUser(object value)
        {
            IsButtonClicked = true;
        }

        private bool CanUserRegister(object value)
        {

            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ResetPage(object value)
        {
            IsButtonClicked = false;
            UserName = Age = EmailId = "";
        }

        private bool CanResetPage(object value)
        {
            if (string.IsNullOrEmpty(UserName)
                || string.IsNullOrEmpty(EmailId)
                || string.IsNullOrEmpty(Age))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}