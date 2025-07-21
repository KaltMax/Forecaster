namespace Forecaster.Controls
{
    partial class ForecastDisplayControl
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
            lbForecast = new System.Windows.Forms.Label();
            forecastScrollPanel = new System.Windows.Forms.Panel();
            SuspendLayout();
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
            // ForecastDisplayControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lbForecast);
            Controls.Add(forecastScrollPanel);
            Name = "ForecastDisplayControl";
            Size = new System.Drawing.Size(1754, 598);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lbForecast;
        private System.Windows.Forms.Panel forecastScrollPanel;
    }
}