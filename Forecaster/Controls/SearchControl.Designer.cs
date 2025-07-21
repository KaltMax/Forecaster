namespace Forecaster.Controls
{
    partial class SearchControl
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
            tbCity = new System.Windows.Forms.TextBox();
            searchButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // tbCity
            // 
            tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            tbCity.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbCity.Location = new System.Drawing.Point(0, 5);
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
            searchButton.Location = new System.Drawing.Point(1565, 0);
            searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(188, 76);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // SearchControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(tbCity);
            Controls.Add(searchButton);
            Name = "SearchControl";
            Size = new System.Drawing.Size(1753, 76);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Button searchButton;
    }
}