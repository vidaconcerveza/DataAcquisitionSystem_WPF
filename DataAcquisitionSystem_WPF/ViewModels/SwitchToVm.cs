using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.ViewModels
{

    //MVVM Light Message Service를 이용해 Page 전환 하는 기능입니다. 
    public class SwitchToVm
    {
        public Type ViewModel { get; private set; }

        public SwitchToVm(Type viewModel)
        {
            ViewModel = viewModel;
        }

    }
}
