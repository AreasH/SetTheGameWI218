using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class OptionsViewModel: ObservableObject, PageViewModel
    {
        public OptionsViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
        }

        #region Fields
        MainWindowViewModel mwvm;
        #endregion
    }
}
