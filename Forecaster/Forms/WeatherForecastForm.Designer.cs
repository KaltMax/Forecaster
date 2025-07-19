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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherForecastForm));
            tbCity = new System.Windows.Forms.TextBox();
            searchButton = new System.Windows.Forms.Button();
            lbTemperature = new System.Windows.Forms.Label();
            resultTemperature = new System.Windows.Forms.Label();
            lbHumidity = new System.Windows.Forms.Label();
            resultHumidity = new System.Windows.Forms.Label();
            lbWindSpeed = new System.Windows.Forms.Label();
            resultWindspeed = new System.Windows.Forms.Label();
            weatherCondition = new System.Windows.Forms.Label();
            weatherPicture = new System.Windows.Forms.PictureBox();
            lbSunrise = new System.Windows.Forms.Label();
            lbSunset = new System.Windows.Forms.Label();
            resultSunrise = new System.Windows.Forms.Label();
            resultSunset = new System.Windows.Forms.Label();
            lbForecast = new System.Windows.Forms.Label();
            forecastScrollPanel = new System.Windows.Forms.Panel();
            weatherCard = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)weatherPicture).BeginInit();
            weatherCard.SuspendLayout();
            SuspendLayout();
            // 
            // tbCity
            // 
            tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            tbCity.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbCity.Location = new System.Drawing.Point(45, 54);
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
            searchButton.Location = new System.Drawing.Point(1611, 48);
            searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(188, 75);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // lbTemperature
            // 
            lbTemperature.AutoSize = true;
            lbTemperature.BackColor = System.Drawing.Color.Transparent;
            lbTemperature.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbTemperature.ForeColor = System.Drawing.Color.Black;
            lbTemperature.Location = new System.Drawing.Point(420, 30);
            lbTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTemperature.Name = "lbTemperature";
            lbTemperature.Size = new System.Drawing.Size(195, 39);
            lbTemperature.TabIndex = 4;
            lbTemperature.Text = "Temperature:";
            // 
            // resultTemperature
            // 
            resultTemperature.AutoSize = true;
            resultTemperature.BackColor = System.Drawing.Color.Transparent;
            resultTemperature.Font = new System.Drawing.Font("Calibri", 12F);
            resultTemperature.ForeColor = System.Drawing.Color.Black;
            resultTemperature.Location = new System.Drawing.Point(420, 69);
            resultTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultTemperature.Name = "resultTemperature";
            resultTemperature.Size = new System.Drawing.Size(68, 39);
            resultTemperature.TabIndex = 5;
            resultTemperature.Text = "N/A";
            resultTemperature.UseMnemonic = false;
            // 
            // lbHumidity
            // 
            lbHumidity.AutoSize = true;
            lbHumidity.BackColor = System.Drawing.Color.Transparent;
            lbHumidity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbHumidity.ForeColor = System.Drawing.Color.Black;
            lbHumidity.Location = new System.Drawing.Point(670, 30);
            lbHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbHumidity.Name = "lbHumidity";
            lbHumidity.Size = new System.Drawing.Size(148, 39);
            lbHumidity.TabIndex = 6;
            lbHumidity.Text = "Humidity:";
            // 
            // resultHumidity
            // 
            resultHumidity.AutoSize = true;
            resultHumidity.BackColor = System.Drawing.Color.Transparent;
            resultHumidity.Font = new System.Drawing.Font("Calibri", 12F);
            resultHumidity.ForeColor = System.Drawing.Color.Black;
            resultHumidity.Location = new System.Drawing.Point(670, 69);
            resultHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultHumidity.Name = "resultHumidity";
            resultHumidity.Size = new System.Drawing.Size(68, 39);
            resultHumidity.TabIndex = 7;
            resultHumidity.Text = "N/A";
            // 
            // lbWindSpeed
            // 
            lbWindSpeed.AutoSize = true;
            lbWindSpeed.BackColor = System.Drawing.Color.Transparent;
            lbWindSpeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbWindSpeed.ForeColor = System.Drawing.Color.Black;
            lbWindSpeed.Location = new System.Drawing.Point(920, 30);
            lbWindSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbWindSpeed.Name = "lbWindSpeed";
            lbWindSpeed.Size = new System.Drawing.Size(176, 39);
            lbWindSpeed.TabIndex = 8;
            lbWindSpeed.Text = "Windspeed:";
            // 
            // resultWindspeed
            // 
            resultWindspeed.AutoSize = true;
            resultWindspeed.BackColor = System.Drawing.Color.Transparent;
            resultWindspeed.Font = new System.Drawing.Font("Calibri", 12F);
            resultWindspeed.ForeColor = System.Drawing.Color.Black;
            resultWindspeed.Location = new System.Drawing.Point(920, 69);
            resultWindspeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultWindspeed.Name = "resultWindspeed";
            resultWindspeed.Size = new System.Drawing.Size(68, 39);
            resultWindspeed.TabIndex = 9;
            resultWindspeed.Text = "N/A";
            // 
            // weatherCondition
            // 
            weatherCondition.BackColor = System.Drawing.Color.Transparent;
            weatherCondition.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            weatherCondition.ForeColor = System.Drawing.Color.Black;
            weatherCondition.Location = new System.Drawing.Point(20, 320);
            weatherCondition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            weatherCondition.Name = "weatherCondition";
            weatherCondition.Size = new System.Drawing.Size(300, 46);
            weatherCondition.TabIndex = 10;
            weatherCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weatherPicture
            // 
            weatherPicture.BackColor = System.Drawing.Color.Transparent;
            weatherPicture.Location = new System.Drawing.Point(20, 15);
            weatherPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            weatherPicture.Name = "weatherPicture";
            weatherPicture.Size = new System.Drawing.Size(300, 300);
            weatherPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            weatherPicture.TabIndex = 12;
            weatherPicture.TabStop = false;
            // 
            // lbSunrise
            // 
            lbSunrise.AutoSize = true;
            lbSunrise.BackColor = System.Drawing.Color.Transparent;
            lbSunrise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbSunrise.ForeColor = System.Drawing.Color.Black;
            lbSunrise.Location = new System.Drawing.Point(1170, 30);
            lbSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbSunrise.Name = "lbSunrise";
            lbSunrise.Size = new System.Drawing.Size(123, 39);
            lbSunrise.TabIndex = 13;
            lbSunrise.Text = "Sunrise:";
            // 
            // lbSunset
            // 
            lbSunset.AutoSize = true;
            lbSunset.BackColor = System.Drawing.Color.Transparent;
            lbSunset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbSunset.ForeColor = System.Drawing.Color.Black;
            lbSunset.Location = new System.Drawing.Point(1420, 30);
            lbSunset.Name = "lbSunset";
            lbSunset.Size = new System.Drawing.Size(115, 39);
            lbSunset.TabIndex = 14;
            lbSunset.Text = "Sunset:";
            // 
            // resultSunrise
            // 
            resultSunrise.AutoSize = true;
            resultSunrise.BackColor = System.Drawing.Color.Transparent;
            resultSunrise.Font = new System.Drawing.Font("Calibri", 12F);
            resultSunrise.ForeColor = System.Drawing.Color.Black;
            resultSunrise.Location = new System.Drawing.Point(1170, 69);
            resultSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultSunrise.Name = "resultSunrise";
            resultSunrise.Size = new System.Drawing.Size(68, 39);
            resultSunrise.TabIndex = 15;
            resultSunrise.Text = "N/A";
            // 
            // resultSunset
            // 
            resultSunset.AutoSize = true;
            resultSunset.BackColor = System.Drawing.Color.Transparent;
            resultSunset.Font = new System.Drawing.Font("Calibri", 12F);
            resultSunset.ForeColor = System.Drawing.Color.Black;
            resultSunset.Location = new System.Drawing.Point(1420, 69);
            resultSunset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultSunset.Name = "resultSunset";
            resultSunset.Size = new System.Drawing.Size(68, 39);
            resultSunset.TabIndex = 16;
            resultSunset.Text = "N/A";
            // 
            // lbForecast
            // 
            lbForecast.AutoSize = true;
            lbForecast.BackColor = System.Drawing.Color.Transparent;
            lbForecast.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbForecast.ForeColor = System.Drawing.Color.Black;
            lbForecast.Location = new System.Drawing.Point(45, 572);
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
            forecastScrollPanel.Location = new System.Drawing.Point(45, 630);
            forecastScrollPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            forecastScrollPanel.Name = "forecastScrollPanel";
            forecastScrollPanel.Size = new System.Drawing.Size(1754, 511);
            forecastScrollPanel.TabIndex = 66;
            // 
            // weatherCard
            // 
            weatherCard.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            weatherCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            weatherCard.Controls.Add(lbTemperature);
            weatherCard.Controls.Add(resultTemperature);
            weatherCard.Controls.Add(lbHumidity);
            weatherCard.Controls.Add(resultHumidity);
            weatherCard.Controls.Add(lbWindSpeed);
            weatherCard.Controls.Add(resultWindspeed);
            weatherCard.Controls.Add(weatherCondition);
            weatherCard.Controls.Add(weatherPicture);
            weatherCard.Controls.Add(lbSunrise);
            weatherCard.Controls.Add(lbSunset);
            weatherCard.Controls.Add(resultSunrise);
            weatherCard.Controls.Add(resultSunset);
            weatherCard.Location = new System.Drawing.Point(45, 140);
            weatherCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            weatherCard.Name = "weatherCard";
            weatherCard.Size = new System.Drawing.Size(1754, 380);
            weatherCard.TabIndex = 18;
            // 
            // WeatherForecastForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1849, 1152);
            Controls.Add(weatherCard);
            Controls.Add(forecastScrollPanel);
            Controls.Add(lbForecast);
            Controls.Add(searchButton);
            Controls.Add(tbCity);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "WeatherForecastForm";
            Text = "Forecaster";
            Load += WeatherForecastForm_Load;
            ((System.ComponentModel.ISupportInitialize)weatherPicture).EndInit();
            weatherCard.ResumeLayout(false);
            weatherCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.Label resultTemperature;
        private System.Windows.Forms.Label lbHumidity;
        private System.Windows.Forms.Label resultHumidity;
        private System.Windows.Forms.Label lbWindSpeed;
        private System.Windows.Forms.Label resultWindspeed;
        private System.Windows.Forms.Label weatherCondition;
        private System.Windows.Forms.PictureBox weatherPicture;
        private System.Windows.Forms.Label lbSunrise;
        private System.Windows.Forms.Label lbSunset;
        private System.Windows.Forms.Label resultSunrise;
        private System.Windows.Forms.Label resultSunset;
        private System.Windows.Forms.Label lbForecast;
        private System.Windows.Forms.Panel forecastScrollPanel;
        private System.Windows.Forms.Panel weatherCard;
    }
}