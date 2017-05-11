using System;

namespace HalloMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private string _welcomeText = "Hallo MVVM";
        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                SetProperty(ref _welcomeText, value);
            }
        }

        private RelayCommand<string> _changeTextCommand;
        public RelayCommand<string> ChangeTextCommand
        {
            get
            {
                return _changeTextCommand ??
                    (_changeTextCommand = new RelayCommand<string>(
                        s => WelcomeText = $"Hallo aus dem Command vom {s}",
                        s => WelcomeText.Length < 10));
            }
        }

        public MainWindowViewModel()
        {
        }

        //private bool KannIchWasMachen()
        //{
        //    return WelcomeText.Length < 10;
        //}
        //private void MachWas()
        //{
        //    WelcomeText = "Hallo aus dem Command";
        //}
    }
}
