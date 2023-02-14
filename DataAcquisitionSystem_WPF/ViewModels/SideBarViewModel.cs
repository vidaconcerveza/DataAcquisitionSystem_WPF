using GalaSoft.MvvmLight.Messaging;
using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataAcquisitionSystem_WPF.ViewModels
{
    public class SideBarViewModel
    {

        public ICommand GoToMainCommand { get;}
        public ICommand GoToConfigCommand { get; }
        public SideBarViewModel()
        {
            GoToMainCommand = new RelayCommand(GoToMain);
            GoToConfigCommand = new RelayCommand(GoToConfig);
        }

        private void GoToMain()
        {
            Messenger.Default.Send(new SwitchToVm(typeof(MainViewModel)));
        }

        private void GoToConfig()
        {
            Messenger.Default.Send(new SwitchToVm(typeof(Plc1ViewModel)));

        }
    }
}
