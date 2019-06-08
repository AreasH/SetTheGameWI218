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
            public void ShowNotification(string information)
            {
                string setCount = information.Substring(information.IndexOf('.')+1);
                string reason = information.Remove(information.IndexOf('.') + 1);
                MessageBox.Show("Du hast dieses Spiel "+ setCount + " Sets gefunden.", "Spiel beendet: " + reason, MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

    
}
