namespace BookSearch.Model.Interfaces
{
    public interface IDialogProvider
    {
        void ShowMessage(string message);
        void ShowMessage(string message, string caption);
    }
}
