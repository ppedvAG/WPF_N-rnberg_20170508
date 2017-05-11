namespace HalloMVVM.ViewModels
{
    public class ViewModelLocator
    {
        private MainWindowViewModel _main;
        public MainWindowViewModel Main
        {
            get { return _main; }
        }

        public ViewModelLocator()
        {
            _main = new MainWindowViewModel();
        }
    }
}
