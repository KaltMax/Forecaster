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
            forecastCard = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)weatherPicture).BeginInit();
            weatherCard.SuspendLayout();
            forecastCard.SuspendLayout();
            SuspendLayout();
            // 
            // tbCity
            // 
            tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            tbCity.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbCity.Location = new System.Drawing.Point(35, 42);
            tbCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbCity.Name = "tbCity";
            tbCity.Size = new System.Drawing.Size(1170, 47);
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
            searchButton.Location = new System.Drawing.Point(1239, 38);
            searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(145, 59);
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
            lbTemperature.Location = new System.Drawing.Point(323, 23);
            lbTemperature.Name = "lbTemperature";
            lbTemperature.Size = new System.Drawing.Size(149, 29);
            lbTemperature.TabIndex = 4;
            lbTemperature.Text = "Temperature:";
            // 
            // resultTemperature
            // 
            resultTemperature.AutoSize = true;
            resultTemperature.BackColor = System.Drawing.Color.Transparent;
            resultTemperature.Font = new System.Drawing.Font("Calibri", 12F);
            resultTemperature.ForeColor = System.Drawing.Color.Black;
            resultTemperature.Location = new System.Drawing.Point(323, 54);
            resultTemperature.Name = "resultTemperature";
            resultTemperature.Size = new System.Drawing.Size(51, 29);
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
            lbHumidity.Location = new System.Drawing.Point(515, 23);
            lbHumidity.Name = "lbHumidity";
            lbHumidity.Size = new System.Drawing.Size(112, 29);
            lbHumidity.TabIndex = 6;
            lbHumidity.Text = "Humidity:";
            // 
            // resultHumidity
            // 
            resultHumidity.AutoSize = true;
            resultHumidity.BackColor = System.Drawing.Color.Transparent;
            resultHumidity.Font = new System.Drawing.Font("Calibri", 12F);
            resultHumidity.ForeColor = System.Drawing.Color.Black;
            resultHumidity.Location = new System.Drawing.Point(515, 54);
            resultHumidity.Name = "resultHumidity";
            resultHumidity.Size = new System.Drawing.Size(51, 29);
            resultHumidity.TabIndex = 7;
            resultHumidity.Text = "N/A";
            // 
            // lbWindSpeed
            // 
            lbWindSpeed.AutoSize = true;
            lbWindSpeed.BackColor = System.Drawing.Color.Transparent;
            lbWindSpeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbWindSpeed.ForeColor = System.Drawing.Color.Black;
            lbWindSpeed.Location = new System.Drawing.Point(708, 23);
            lbWindSpeed.Name = "lbWindSpeed";
            lbWindSpeed.Size = new System.Drawing.Size(134, 29);
            lbWindSpeed.TabIndex = 8;
            lbWindSpeed.Text = "Windspeed:";
            // 
            // resultWindspeed
            // 
            resultWindspeed.AutoSize = true;
            resultWindspeed.BackColor = System.Drawing.Color.Transparent;
            resultWindspeed.Font = new System.Drawing.Font("Calibri", 12F);
            resultWindspeed.ForeColor = System.Drawing.Color.Black;
            resultWindspeed.Location = new System.Drawing.Point(708, 54);
            resultWindspeed.Name = "resultWindspeed";
            resultWindspeed.Size = new System.Drawing.Size(51, 29);
            resultWindspeed.TabIndex = 9;
            resultWindspeed.Text = "N/A";
            // 
            // weatherCondition
            // 
            weatherCondition.BackColor = System.Drawing.Color.Transparent;
            weatherCondition.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            weatherCondition.ForeColor = System.Drawing.Color.Black;
            weatherCondition.Location = new System.Drawing.Point(15, 250);
            weatherCondition.Name = "weatherCondition";
            weatherCondition.Size = new System.Drawing.Size(231, 36);
            weatherCondition.TabIndex = 10;
            weatherCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weatherPicture
            // 
            weatherPicture.BackColor = System.Drawing.Color.Transparent;
            weatherPicture.Location = new System.Drawing.Point(15, 12);
            weatherPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            weatherPicture.Name = "weatherPicture";
            weatherPicture.Size = new System.Drawing.Size(231, 234);
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
            lbSunrise.Location = new System.Drawing.Point(900, 23);
            lbSunrise.Name = "lbSunrise";
            lbSunrise.Size = new System.Drawing.Size(94, 29);
            lbSunrise.TabIndex = 13;
            lbSunrise.Text = "Sunrise:";
            // 
            // lbSunset
            // 
            lbSunset.AutoSize = true;
            lbSunset.BackColor = System.Drawing.Color.Transparent;
            lbSunset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            lbSunset.ForeColor = System.Drawing.Color.Black;
            lbSunset.Location = new System.Drawing.Point(1092, 23);
            lbSunset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbSunset.Name = "lbSunset";
            lbSunset.Size = new System.Drawing.Size(87, 29);
            lbSunset.TabIndex = 14;
            lbSunset.Text = "Sunset:";
            // 
            // resultSunrise
            // 
            resultSunrise.AutoSize = true;
            resultSunrise.BackColor = System.Drawing.Color.Transparent;
            resultSunrise.Font = new System.Drawing.Font("Calibri", 12F);
            resultSunrise.ForeColor = System.Drawing.Color.Black;
            resultSunrise.Location = new System.Drawing.Point(900, 54);
            resultSunrise.Name = "resultSunrise";
            resultSunrise.Size = new System.Drawing.Size(51, 29);
            resultSunrise.TabIndex = 15;
            resultSunrise.Text = "N/A";
            // 
            // resultSunset
            // 
            resultSunset.AutoSize = true;
            resultSunset.BackColor = System.Drawing.Color.Transparent;
            resultSunset.Font = new System.Drawing.Font("Calibri", 12F);
            resultSunset.ForeColor = System.Drawing.Color.Black;
            resultSunset.Location = new System.Drawing.Point(1092, 54);
            resultSunset.Name = "resultSunset";
            resultSunset.Size = new System.Drawing.Size(51, 29);
            resultSunset.TabIndex = 16;
            resultSunset.Text = "N/A";
            // 
            // lbForecast
            // 
            lbForecast.AutoSize = true;
            lbForecast.BackColor = System.Drawing.Color.Transparent;
            lbForecast.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbForecast.ForeColor = System.Drawing.Color.Black;
            lbForecast.Location = new System.Drawing.Point(15, 8);
            lbForecast.Name = "lbForecast";
            lbForecast.Size = new System.Drawing.Size(129, 39);
            lbForecast.TabIndex = 17;
            lbForecast.Text = "Forecast";
            // 
            // forecastScrollPanel
            // 
            forecastScrollPanel.AutoScroll = true;
            forecastScrollPanel.BackColor = System.Drawing.Color.Transparent;
            forecastScrollPanel.Location = new System.Drawing.Point(15, 53);
            forecastScrollPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            forecastScrollPanel.Name = "forecastScrollPanel";
            forecastScrollPanel.Size = new System.Drawing.Size(1318, 399);
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
            weatherCard.Location = new System.Drawing.Point(35, 109);
            weatherCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            weatherCard.Name = "weatherCard";
            weatherCard.Size = new System.Drawing.Size(1350, 297);
            weatherCard.TabIndex = 18;
            // 
            // forecastCard
            // 
            forecastCard.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            forecastCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            forecastCard.Controls.Add(lbForecast);
            forecastCard.Controls.Add(forecastScrollPanel);
            forecastCard.Location = new System.Drawing.Point(35, 422);
            forecastCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            forecastCard.Name = "forecastCard";
            forecastCard.Size = new System.Drawing.Size(1350, 468);
            forecastCard.TabIndex = 19;
            // 
            // WeatherForecastForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1422, 920);
            Controls.Add(weatherCard);
            Controls.Add(forecastCard);
            Controls.Add(searchButton);
            Controls.Add(tbCity);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "WeatherForecastForm";
            Text = "Forecaster";
            Load += WeatherForecastForm_Load;
            ((System.ComponentModel.ISupportInitialize)weatherPicture).EndInit();
            weatherCard.ResumeLayout(false);
            weatherCard.PerformLayout();
            forecastCard.ResumeLayout(false);
            forecastCard.PerformLayout();
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
        private System.Windows.Forms.Panel forecastCard;
    }
}