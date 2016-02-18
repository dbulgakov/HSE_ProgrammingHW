using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookSearch.Model
{
    class SimpleDialogProvider : IDialogProvider
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void StartProgressRing()
        {

        }
    }
}
