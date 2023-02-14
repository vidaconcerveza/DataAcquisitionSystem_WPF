using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.ViewModels
{
    public class SwitchToVm
    {
        public Type ViewModel { get; private set; }

        public SwitchToVm(Type viewModel)
        {
            ViewModel = viewModel;
        }

    }
}
