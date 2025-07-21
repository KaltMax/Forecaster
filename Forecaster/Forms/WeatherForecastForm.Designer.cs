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
            weatherDisplayControl = new Forecaster.Controls.WeatherDisplayControl();
            forecastDisplayControl = new Forecaster.Controls.ForecastDisplayControl();
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
            // forecastDisplayControl
            // 
            forecastDisplayControl.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            forecastDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            forecastDisplayControl.Location = new System.Drawing.Point(46, 540);
            forecastDisplayControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            forecastDisplayControl.Name = "forecastDisplayControl";
            forecastDisplayControl.Size = new System.Drawing.Size(1754, 598);
            forecastDisplayControl.TabIndex = 21;
            // 
            // WeatherForecastForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1849, 1178);
            Controls.Add(forecastDisplayControl);
            Controls.Add(weatherDisplayControl);
            Controls.Add(searchButton);
            Controls.Add(tbCity);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "WeatherForecastForm";
            Text = "Forecaster";
            Load += WeatherForecastForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Button searchButton;
        private Forecaster.Controls.WeatherDisplayControl weatherDisplayControl;
        private Forecaster.Controls.ForecastDisplayControl forecastDisplayControl;
    }
}