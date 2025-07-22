using System.Windows.Forms;
using Forecaster.Controls;

namespace Test.Controls
{
    public class SearchControlTests
    {
        [Fact]
        public void SetLoadingState_ShouldUpdateUIState()
        {
            // Arrange
            var control = new SearchControl();
            var searchButton = control.Controls["searchButton"] as Button;
            var tbCity = control.Controls["tbCity"] as TextBox;

            // Act
            control.SetLoadingState(true);

            // Assert
            Assert.False(searchButton!.Enabled);
            Assert.Equal("Loading...", searchButton.Text);
            Assert.False(tbCity!.Enabled);

            // Act
            control.SetLoadingState(false);

            // Assert
            Assert.True(searchButton.Enabled);
            Assert.Equal("Search", searchButton.Text);
            Assert.True(tbCity.Enabled);
        }

        [Fact]
        public void PerformSearch_ShouldRaiseSearchRequestedEvent()
        {
            // Arrange
            var control = new SearchControl();
            var tbCity = control.Controls["tbCity"] as TextBox;
            tbCity!.Text = @"New York";

            string raisedCityName = null!;
            control.SearchRequested += cityName => raisedCityName = cityName;

            // Act
            var searchButton = control.Controls["searchButton"] as Button;
            searchButton!.PerformClick();

            // Assert
            Assert.Equal("New York", raisedCityName);
        }

        [Fact]
        public void PerformSearch_ShouldNotRaiseEvent_WhenCityNameIsEmpty()
        {
            // Arrange
            var control = new SearchControl();
            var tbCity = control.Controls["tbCity"] as TextBox;
            tbCity!.Text = string.Empty;

            var eventRaised = false;
            control.SearchRequested += _ => eventRaised = true;

            // Act
            var searchButton = control.Controls["searchButton"] as Button;
            searchButton!.PerformClick();

            // Assert
            Assert.False(eventRaised);
        }
    }
}