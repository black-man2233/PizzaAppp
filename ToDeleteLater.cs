using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using PIzzaApp_WPF

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
            
            ResetButtonClicked = new RelayCommand(AddToCart, CanAddToCart);
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

        private void AddToCart(object value)
        {
            IsButtonClicked = false;
            UserName = Age = EmailId = "";
        }

        private bool CanAddToCart(object value)
        {
            if (CartSelectedIndex < 0)
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