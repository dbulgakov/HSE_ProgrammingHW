using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearch.Model
{
    public interface IDialogProvider
    {
        void ShowMessage(string message);
    }
}
