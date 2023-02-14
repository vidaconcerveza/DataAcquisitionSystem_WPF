using GalaSoft.MvvmLight.Messaging;
using MvvmFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataAcquisitionSystem_WPF.ViewModels
{
    public class ShellViewModel:INotifyPropertyChanged//,IHandle<SwitchToVm>
    {
        private Window _window;
        #region Constructor
        public ShellViewModel(Window window)
        {
            _window = window;
            CurrentViewModel = IoC.Get<MainViewModel>();
            StatusBarViewModel = IoC.Get<StatusBarViewModel>();
            SideBarViewModel = IoC.Get<SideBarViewModel>();

            MinimizeCommand = new RelayCommand(() => MessageBox.Show(_window.WindowState.ToString())) ;
            MaximizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Maximized);
            CloseCommand = new RelayCommand(()=> _window.Close());

            Messenger.Default.Register<SwitchToVm>(this, Handle);
        }
        #endregion


        //Command
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        
        public void Minimize()
        {

            MessageBox.Show(_window.WindowState.ToString());
            _window.WindowState = WindowState.Minimized;
        }
        

        private object currentViewModel;
        private object statusBarViewModel;
        private object sideBarViewModel;

        public object SideBarViewModel
        {
            get { return sideBarViewModel; }
            private set
            {
                sideBarViewModel = value;
                OnPropertyChanged();
            }
        }
        public object StatusBarViewModel
        {
            get { return statusBarViewModel; }
            private set
            {
                statusBarViewModel = value;
                OnPropertyChanged();
            }
        }

        public object CurrentViewModel
        {
            get { return currentViewModel; }
            private set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public void Handle(SwitchToVm message)
        {
            CurrentViewModel = IoC.Get(message.ViewModel);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MessageAggregator(string test)
        {
            MessageBox.Show(test);
        }

    }
}
