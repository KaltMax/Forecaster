namespace Forecaster.Controls
{
    partial class WeatherDisplayControl
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
            resultPressure = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            resultMeasurementTime = new System.Windows.Forms.Label();
            resultCity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)weatherPicture).BeginInit();
            SuspendLayout();
            // 
            // lbTemperature
            // 
            lbTemperature.AutoSize = true;
            lbTemperature.BackColor = System.Drawing.Color.Transparent;
            lbTemperature.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            lbTemperature.ForeColor = System.Drawing.Color.Black;
            lbTemperature.Location = new System.Drawing.Point(330, 239);
            lbTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbTemperature.Name = "lbTemperature";
            lbTemperature.Size = new System.Drawing.Size(204, 42);
            lbTemperature.TabIndex = 4;
            lbTemperature.Text = "Temperature";
            // 
            // resultTemperature
            // 
            resultTemperature.AutoSize = true;
            resultTemperature.BackColor = System.Drawing.Color.Transparent;
            resultTemperature.Font = new System.Drawing.Font("Calibri", 13F);
            resultTemperature.ForeColor = System.Drawing.Color.Black;
            resultTemperature.Location = new System.Drawing.Point(330, 288);
            resultTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultTemperature.Name = "resultTemperature";
            resultTemperature.Size = new System.Drawing.Size(74, 42);
            resultTemperature.TabIndex = 5;
            resultTemperature.Text = "N/A";
            resultTemperature.UseMnemonic = false;
            // 
            // lbHumidity
            // 
            lbHumidity.AutoSize = true;
            lbHumidity.BackColor = System.Drawing.Color.Transparent;
            lbHumidity.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            lbHumidity.ForeColor = System.Drawing.Color.Black;
            lbHumidity.Location = new System.Drawing.Point(580, 239);
            lbHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbHumidity.Name = "lbHumidity";
            lbHumidity.Size = new System.Drawing.Size(153, 42);
            lbHumidity.TabIndex = 6;
            lbHumidity.Text = "Humidity";
            // 
            // resultHumidity
            // 
            resultHumidity.AutoSize = true;
            resultHumidity.BackColor = System.Drawing.Color.Transparent;
            resultHumidity.Font = new System.Drawing.Font("Calibri", 13F);
            resultHumidity.ForeColor = System.Drawing.Color.Black;
            resultHumidity.Location = new System.Drawing.Point(580, 288);
            resultHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultHumidity.Name = "resultHumidity";
            resultHumidity.Size = new System.Drawing.Size(74, 42);
            resultHumidity.TabIndex = 7;
            resultHumidity.Text = "N/A";
            // 
            // lbWindSpeed
            // 
            lbWindSpeed.AutoSize = true;
            lbWindSpeed.BackColor = System.Drawing.Color.Transparent;
            lbWindSpeed.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            lbWindSpeed.ForeColor = System.Drawing.Color.Black;
            lbWindSpeed.Location = new System.Drawing.Point(830, 239);
            lbWindSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbWindSpeed.Name = "lbWindSpeed";
            lbWindSpeed.Size = new System.Drawing.Size(185, 42);
            lbWindSpeed.TabIndex = 8;
            lbWindSpeed.Text = "Windspeed";
            // 
            // resultWindspeed
            // 
            resultWindspeed.AutoSize = true;
            resultWindspeed.BackColor = System.Drawing.Color.Transparent;
            resultWindspeed.Font = new System.Drawing.Font("Calibri", 13F);
            resultWindspeed.ForeColor = System.Drawing.Color.Black;
            resultWindspeed.Location = new System.Drawing.Point(830, 288);
            resultWindspeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultWindspeed.Name = "resultWindspeed";
            resultWindspeed.Size = new System.Drawing.Size(74, 42);
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
            lbSunrise.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            lbSunrise.ForeColor = System.Drawing.Color.Black;
            lbSunrise.Location = new System.Drawing.Point(1330, 239);
            lbSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbSunrise.Name = "lbSunrise";
            lbSunrise.Size = new System.Drawing.Size(126, 42);
            lbSunrise.TabIndex = 13;
            lbSunrise.Text = "Sunrise";
            // 
            // lbSunset
            // 
            lbSunset.AutoSize = true;
            lbSunset.BackColor = System.Drawing.Color.Transparent;
            lbSunset.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            lbSunset.ForeColor = System.Drawing.Color.Black;
            lbSunset.Location = new System.Drawing.Point(1580, 239);
            lbSunset.Name = "lbSunset";
            lbSunset.Size = new System.Drawing.Size(117, 42);
            lbSunset.TabIndex = 14;
            lbSunset.Text = "Sunset";
            // 
            // resultSunrise
            // 
            resultSunrise.AutoSize = true;
            resultSunrise.BackColor = System.Drawing.Color.Transparent;
            resultSunrise.Font = new System.Drawing.Font("Calibri", 13F);
            resultSunrise.ForeColor = System.Drawing.Color.Black;
            resultSunrise.Location = new System.Drawing.Point(1330, 288);
            resultSunrise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultSunrise.Name = "resultSunrise";
            resultSunrise.Size = new System.Drawing.Size(74, 42);
            resultSunrise.TabIndex = 15;
            resultSunrise.Text = "N/A";
            // 
            // resultSunset
            // 
            resultSunset.AutoSize = true;
            resultSunset.BackColor = System.Drawing.Color.Transparent;
            resultSunset.Font = new System.Drawing.Font("Calibri", 13F);
            resultSunset.ForeColor = System.Drawing.Color.Black;
            resultSunset.Location = new System.Drawing.Point(1580, 288);
            resultSunset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultSunset.Name = "resultSunset";
            resultSunset.Size = new System.Drawing.Size(74, 42);
            resultSunset.TabIndex = 16;
            resultSunset.Text = "N/A";
            // 
            // resultPressure
            // 
            resultPressure.AutoSize = true;
            resultPressure.BackColor = System.Drawing.Color.Transparent;
            resultPressure.Font = new System.Drawing.Font("Calibri", 13F);
            resultPressure.Location = new System.Drawing.Point(1080, 288);
            resultPressure.Name = "resultPressure";
            resultPressure.Size = new System.Drawing.Size(74, 42);
            resultPressure.TabIndex = 20;
            resultPressure.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(1080, 239);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(144, 42);
            label1.TabIndex = 19;
            label1.Text = "Pressure";
            // 
            // resultMeasurementTime
            // 
            resultMeasurementTime.AutoSize = true;
            resultMeasurementTime.BackColor = System.Drawing.Color.Transparent;
            resultMeasurementTime.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            resultMeasurementTime.Location = new System.Drawing.Point(330, 110);
            resultMeasurementTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultMeasurementTime.Name = "resultMeasurementTime";
            resultMeasurementTime.Size = new System.Drawing.Size(82, 46);
            resultMeasurementTime.TabIndex = 18;
            resultMeasurementTime.Text = "N/A";
            // 
            // resultCity
            // 
            resultCity.AutoSize = true;
            resultCity.BackColor = System.Drawing.Color.Transparent;
            resultCity.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            resultCity.Location = new System.Drawing.Point(330, 40);
            resultCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resultCity.Name = "resultCity";
            resultCity.Size = new System.Drawing.Size(105, 59);
            resultCity.TabIndex = 17;
            resultCity.Text = "N/A";
            // 
            // WeatherDisplayControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(resultPressure);
            Controls.Add(label1);
            Controls.Add(resultMeasurementTime);
            Controls.Add(resultCity);
            Controls.Add(lbTemperature);
            Controls.Add(resultTemperature);
            Controls.Add(lbHumidity);
            Controls.Add(resultHumidity);
            Controls.Add(lbWindSpeed);
            Controls.Add(resultWindspeed);
            Controls.Add(weatherCondition);
            Controls.Add(weatherPicture);
            Controls.Add(lbSunrise);
            Controls.Add(lbSunset);
            Controls.Add(resultSunrise);
            Controls.Add(resultSunset);
            Name = "WeatherDisplayControl";
            Size = new System.Drawing.Size(1754, 380);
            ((System.ComponentModel.ISupportInitialize)weatherPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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
        private System.Windows.Forms.Label resultPressure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resultMeasurementTime;
        private System.Windows.Forms.Label resultCity;
    }
}