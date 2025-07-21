using System;
using System.Windows.Forms;

namespace Forecaster.Controls
{
    public partial class SearchControl : UserControl
    {
        public event Action<string> SearchRequested;

        public SearchControl()
        {
            InitializeComponent();
        }

        public void SetLoadingState(bool isLoading)
        {
            searchButton.Enabled = !isLoading;
            searchButton.Text = isLoading ? "Loading..." : "Search";
            tbCity.Enabled = !isLoading;
        }

        public void FocusInput()
        {
            tbCity.Focus();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void tbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(tbCity.Text))
            {
                PerformSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void PerformSearch()
        {
            var cityName = tbCity.Text.Trim();
            if (!string.IsNullOrEmpty(cityName))
            {
                SearchRequested?.Invoke(cityName);
            }
        }
    }
}