using System.Windows.Forms;

namespace Forecaster.Services.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowInfo(string message, string title = "Information");
        void ShowWarning(string message, string title = "Warning");
        void ShowError(string message, string title = "Error");
        DialogResult ShowConfirmation(string message, string title = "Confirm");
    }
}