namespace Forecaster.Forms
{
    partial class WeatherForecastForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherForecastForm));
            tbCity = new System.Windows.Forms.TextBox();
            searchButton = new System.Windows.Forms.Button();
            lbForecast = new System.Windows.Forms.Label();
            forecastScrollPanel = new System.Windows.Forms.Panel();
            forecastCard = new System.Windows.Forms.Panel();
            weatherDisplayControl = new Forecaster.Controls.WeatherDisplayControl();
            forecastCard.SuspendLayout();
            SuspendLayout();

            // 
            // tbCity
            // 
            tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            tbCity.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbCity.Location = new System.Drawing.Point(46, 54);
            tbCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbCity.Name = "tbCity";
            tbCity.Size = new System.Drawing.Size(1520, 60);
            tbCity.TabIndex = 1;
            tbCity.KeyDown += tbCity_KeyDown;

            // 
            // searchButton
            // 
            searchButton.BackColor = System.Drawing.Color.Transparent;
            searchButton.BackgroundImage = Properties.Resources.buttonBackground;
            searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            searchButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            searchButton.ForeColor = System.Drawing.Color.Black;
            searchButton.Location = new System.Drawing.Point(1611, 49);
            searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(188, 76);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;

            // 
            // lbForecast
            // 
            lbForecast.AutoSize = true;
            lbForecast.BackColor = System.Drawing.Color.Transparent;
            lbForecast.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbForecast.ForeColor = System.Drawing.Color.Black;
            lbForecast.Location = new System.Drawing.Point(20, 10);
            lbForecast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbForecast.Name = "lbForecast";
            lbForecast.Size = new System.Drawing.Size(173, 53);
            lbForecast.TabIndex = 17;
            lbForecast.Text = "Forecast";

            // 
            // forecastScrollPanel
            // 
            forecastScrollPanel.AutoScroll = true;
            forecastScrollPanel.BackColor = System.Drawing.Color.Transparent;
            forecastScrollPanel.Location = new System.Drawing.Point(20, 68);
            forecastScrollPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            forecastScrollPanel.Name = "forecastScrollPanel";
            forecastScrollPanel.Size = new System.Drawing.Size(1713, 511);
            forecastScrollPanel.TabIndex = 66;

            // 
            // forecastCard
            // 
            forecastCard.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            forecastCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            forecastCard.Controls.Add(lbForecast);
            forecastCard.Controls.Add(forecastScrollPanel);
            forecastCard.Location = new System.Drawing.Point(46, 540);
            forecastCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            forecastCard.Name = "forecastCard";
            forecastCard.Size = new System.Drawing.Size(1754, 598);
            forecastCard.TabIndex = 19;

            // 
            // weatherDisplayControl
            // 
            weatherDisplayControl.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            weatherDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            weatherDisplayControl.Location = new System.Drawing.Point(46, 140);
            weatherDisplayControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            weatherDisplayControl.Name = "weatherDisplayControl";
            weatherDisplayControl.Size = new System.Drawing.Size(1754, 380);
            weatherDisplayControl.TabIndex = 20;

            // 
            // WeatherForecastForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1849, 1178);
            Controls.Add(weatherDisplayControl);
            Controls.Add(forecastCard);
            Controls.Add(searchButton);
            Controls.Add(tbCity);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "WeatherForecastForm";
            Text = "Forecaster";
            Load += WeatherForecastForm_Load;
            forecastCard.ResumeLayout(false);
            forecastCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label lbForecast;
        private System.Windows.Forms.Panel forecastScrollPanel;
        private System.Windows.Forms.Panel forecastCard;
        private Forecaster.Controls.WeatherDisplayControl weatherDisplayControl;
    }
}