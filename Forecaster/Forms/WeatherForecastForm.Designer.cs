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
            searchControl = new Forecaster.Controls.SearchControl();
            weatherDisplayControl = new Forecaster.Controls.WeatherDisplayControl();
            forecastDisplayControl = new Forecaster.Controls.ForecastDisplayControl();
            SuspendLayout();
            // 
            // searchControl
            // 
            searchControl.BackColor = System.Drawing.Color.Transparent;
            searchControl.Location = new System.Drawing.Point(46, 49);
            searchControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            searchControl.Name = "searchControl";
            searchControl.Size = new System.Drawing.Size(1753, 76);
            searchControl.TabIndex = 0;
            searchControl.SearchRequested += searchControl_SearchRequested;
            // 
            // weatherDisplayControl
            // 
            weatherDisplayControl.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            weatherDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            weatherDisplayControl.Location = new System.Drawing.Point(46, 140);
            weatherDisplayControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            weatherDisplayControl.Name = "weatherDisplayControl";
            weatherDisplayControl.Size = new System.Drawing.Size(1754, 380);
            weatherDisplayControl.TabIndex = 1;
            // 
            // forecastDisplayControl
            // 
            forecastDisplayControl.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            forecastDisplayControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            forecastDisplayControl.Location = new System.Drawing.Point(46, 540);
            forecastDisplayControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            forecastDisplayControl.Name = "forecastDisplayControl";
            forecastDisplayControl.Size = new System.Drawing.Size(1754, 598);
            forecastDisplayControl.TabIndex = 2;
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
            Controls.Add(searchControl);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "WeatherForecastForm";
            Text = "Forecaster";
            Load += WeatherForecastForm_Load;
            ResumeLayout(false);
        }

        private Forecaster.Controls.SearchControl searchControl;
        private Forecaster.Controls.WeatherDisplayControl weatherDisplayControl;
        private Forecaster.Controls.ForecastDisplayControl forecastDisplayControl;
    }
}