using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Set
{
        public class MsgBoxService : IMsgBoxService
        {
            public void ShowNotification(string message)
            {
                MessageBox.Show("Du hast dieses Spiel "+ message + " Sets gefunden.", "Spiel beendet", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

    
}
