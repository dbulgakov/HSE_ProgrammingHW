using System.Windows;
using BookSearch.Model.Interfaces;

namespace BookSearch.Model
{
    class SimpleDialogProvider : IDialogProvider
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }
    }
}
