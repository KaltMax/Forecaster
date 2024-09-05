namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbCity = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.resultTemperature = new System.Windows.Forms.Label();
            this.lbHumidity = new System.Windows.Forms.Label();
            this.resultHumidity = new System.Windows.Forms.Label();
            this.lbWindSpeed = new System.Windows.Forms.Label();
            this.resultWindspeed = new System.Windows.Forms.Label();
            this.weatherCondition = new System.Windows.Forms.Label();
            this.weatherPicture = new System.Windows.Forms.PictureBox();
            this.lbSunrise = new System.Windows.Forms.Label();
            this.lbSunset = new System.Windows.Forms.Label();
            this.resultSunrise = new System.Windows.Forms.Label();
            this.resultSunset = new System.Windows.Forms.Label();
            this.lbForecast = new System.Windows.Forms.Label();
            this.pictureForecast1 = new System.Windows.Forms.PictureBox();
            this.pictureForecast2 = new System.Windows.Forms.PictureBox();
            this.pictureForecast3 = new System.Windows.Forms.PictureBox();
            this.v = new System.Windows.Forms.Label();
            this.weatherConditionForecast1 = new System.Windows.Forms.Label();
            this.lbForecastHumidity1 = new System.Windows.Forms.Label();
            this.lbForecastWindspeed1 = new System.Windows.Forms.Label();
            this.weatherConditionForecast2 = new System.Windows.Forms.Label();
            this.weatherConditionForecast3 = new System.Windows.Forms.Label();
            this.forecastResultTemperature1 = new System.Windows.Forms.Label();
            this.forecastResultHumidity1 = new System.Windows.Forms.Label();
            this.forecastResultWindspeed1 = new System.Windows.Forms.Label();
            this.forecastResultWindspeed2 = new System.Windows.Forms.Label();
            this.forecastResultHumidity2 = new System.Windows.Forms.Label();
            this.forecastResultTemperature2 = new System.Windows.Forms.Label();
            this.lbForecastWindspeed2 = new System.Windows.Forms.Label();
            this.lbForecastHumidity2 = new System.Windows.Forms.Label();
            this.lbForecastTemperature2 = new System.Windows.Forms.Label();
            this.forecastResultWindspeed3 = new System.Windows.Forms.Label();
            this.forecastResultHumidity3 = new System.Windows.Forms.Label();
            this.forecastResultTemperature3 = new System.Windows.Forms.Label();
            this.lbForecastWindspeed3 = new System.Windows.Forms.Label();
            this.lbForecastHumidity3 = new System.Windows.Forms.Label();
            this.lbForecastTemperature3 = new System.Windows.Forms.Label();
            this.lbForecastTime1 = new System.Windows.Forms.Label();
            this.resultForecastTime1 = new System.Windows.Forms.Label();
            this.resultForecastTime2 = new System.Windows.Forms.Label();
            this.lbForecastTime2 = new System.Windows.Forms.Label();
            this.resultForecastTime3 = new System.Windows.Forms.Label();
            this.lbForecastTime3 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.resultForecastDate3 = new System.Windows.Forms.Label();
            this.lbForecastDate3 = new System.Windows.Forms.Label();
            this.resultForecastDate2 = new System.Windows.Forms.Label();
            this.lbForecastDate2 = new System.Windows.Forms.Label();
            this.resultForecastDate1 = new System.Windows.Forms.Label();
            this.lbForecastDate1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.forecasterFont = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecasterFont)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.BackColor = System.Drawing.Color.Transparent;
            this.lbCity.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCity.ForeColor = System.Drawing.Color.Black;
            this.lbCity.Location = new System.Drawing.Point(184, 42);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(84, 39);
            this.lbCity.TabIndex = 0;
            this.lbCity.Text = "City: ";
            // 
            // tbCity
            // 
            this.tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbCity.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCity.Location = new System.Drawing.Point(293, 34);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(588, 47);
            this.tbCity.TabIndex = 1;
            this.tbCity.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.tbCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCity_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonBackground;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.Black;
            this.searchButton.Location = new System.Drawing.Point(922, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(130, 47);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lbTemperature.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemperature.ForeColor = System.Drawing.Color.Black;
            this.lbTemperature.Location = new System.Drawing.Point(714, 115);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(195, 39);
            this.lbTemperature.TabIndex = 4;
            this.lbTemperature.Text = "Temperature:";
            // 
            // resultTemperature
            // 
            this.resultTemperature.AutoSize = true;
            this.resultTemperature.BackColor = System.Drawing.Color.Transparent;
            this.resultTemperature.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTemperature.ForeColor = System.Drawing.Color.Black;
            this.resultTemperature.Location = new System.Drawing.Point(915, 115);
            this.resultTemperature.Name = "resultTemperature";
            this.resultTemperature.Size = new System.Drawing.Size(70, 39);
            this.resultTemperature.TabIndex = 5;
            this.resultTemperature.Text = "N/A";
            this.resultTemperature.UseMnemonic = false;
            // 
            // lbHumidity
            // 
            this.lbHumidity.AutoSize = true;
            this.lbHumidity.BackColor = System.Drawing.Color.Transparent;
            this.lbHumidity.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHumidity.ForeColor = System.Drawing.Color.Black;
            this.lbHumidity.Location = new System.Drawing.Point(714, 165);
            this.lbHumidity.Name = "lbHumidity";
            this.lbHumidity.Size = new System.Drawing.Size(148, 39);
            this.lbHumidity.TabIndex = 6;
            this.lbHumidity.Text = "Humidity:";
            // 
            // resultHumidity
            // 
            this.resultHumidity.AutoSize = true;
            this.resultHumidity.BackColor = System.Drawing.Color.Transparent;
            this.resultHumidity.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultHumidity.ForeColor = System.Drawing.Color.Black;
            this.resultHumidity.Location = new System.Drawing.Point(915, 165);
            this.resultHumidity.Name = "resultHumidity";
            this.resultHumidity.Size = new System.Drawing.Size(70, 39);
            this.resultHumidity.TabIndex = 7;
            this.resultHumidity.Text = "N/A";
            // 
            // lbWindSpeed
            // 
            this.lbWindSpeed.AutoSize = true;
            this.lbWindSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lbWindSpeed.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWindSpeed.ForeColor = System.Drawing.Color.Black;
            this.lbWindSpeed.Location = new System.Drawing.Point(714, 215);
            this.lbWindSpeed.Name = "lbWindSpeed";
            this.lbWindSpeed.Size = new System.Drawing.Size(176, 39);
            this.lbWindSpeed.TabIndex = 8;
            this.lbWindSpeed.Text = "Windspeed:";
            // 
            // resultWindspeed
            // 
            this.resultWindspeed.AutoSize = true;
            this.resultWindspeed.BackColor = System.Drawing.Color.Transparent;
            this.resultWindspeed.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultWindspeed.ForeColor = System.Drawing.Color.Black;
            this.resultWindspeed.Location = new System.Drawing.Point(915, 215);
            this.resultWindspeed.Name = "resultWindspeed";
            this.resultWindspeed.Size = new System.Drawing.Size(70, 39);
            this.resultWindspeed.TabIndex = 9;
            this.resultWindspeed.Text = "N/A";
            // 
            // weatherCondition
            // 
            this.weatherCondition.AutoSize = true;
            this.weatherCondition.BackColor = System.Drawing.Color.Transparent;
            this.weatherCondition.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherCondition.ForeColor = System.Drawing.Color.Black;
            this.weatherCondition.Location = new System.Drawing.Point(212, 315);
            this.weatherCondition.Name = "weatherCondition";
            this.weatherCondition.Size = new System.Drawing.Size(268, 39);
            this.weatherCondition.TabIndex = 10;
            this.weatherCondition.Text = "Weather Condition";
            this.weatherCondition.Click += new System.EventHandler(this.weatherDescription_Click);
            // 
            // weatherPicture
            // 
            this.weatherPicture.BackColor = System.Drawing.Color.Transparent;
            this.weatherPicture.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.iconBackground;
            this.weatherPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.weatherPicture.Location = new System.Drawing.Point(219, 115);
            this.weatherPicture.Name = "weatherPicture";
            this.weatherPicture.Size = new System.Drawing.Size(200, 200);
            this.weatherPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.weatherPicture.TabIndex = 12;
            this.weatherPicture.TabStop = false;
            // 
            // lbSunrise
            // 
            this.lbSunrise.AutoSize = true;
            this.lbSunrise.BackColor = System.Drawing.Color.Transparent;
            this.lbSunrise.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSunrise.ForeColor = System.Drawing.Color.Black;
            this.lbSunrise.Location = new System.Drawing.Point(714, 265);
            this.lbSunrise.Name = "lbSunrise";
            this.lbSunrise.Size = new System.Drawing.Size(123, 39);
            this.lbSunrise.TabIndex = 13;
            this.lbSunrise.Text = "Sunrise:";
            // 
            // lbSunset
            // 
            this.lbSunset.AutoSize = true;
            this.lbSunset.BackColor = System.Drawing.Color.Transparent;
            this.lbSunset.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSunset.ForeColor = System.Drawing.Color.Black;
            this.lbSunset.Location = new System.Drawing.Point(714, 315);
            this.lbSunset.Name = "lbSunset";
            this.lbSunset.Size = new System.Drawing.Size(115, 39);
            this.lbSunset.TabIndex = 14;
            this.lbSunset.Text = "Sunset:";
            // 
            // resultSunrise
            // 
            this.resultSunrise.AutoSize = true;
            this.resultSunrise.BackColor = System.Drawing.Color.Transparent;
            this.resultSunrise.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultSunrise.ForeColor = System.Drawing.Color.Black;
            this.resultSunrise.Location = new System.Drawing.Point(915, 265);
            this.resultSunrise.Name = "resultSunrise";
            this.resultSunrise.Size = new System.Drawing.Size(70, 39);
            this.resultSunrise.TabIndex = 15;
            this.resultSunrise.Text = "N/A";
            // 
            // resultSunset
            // 
            this.resultSunset.AutoSize = true;
            this.resultSunset.BackColor = System.Drawing.Color.Transparent;
            this.resultSunset.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultSunset.ForeColor = System.Drawing.Color.Black;
            this.resultSunset.Location = new System.Drawing.Point(915, 315);
            this.resultSunset.Name = "resultSunset";
            this.resultSunset.Size = new System.Drawing.Size(70, 39);
            this.resultSunset.TabIndex = 16;
            this.resultSunset.Text = "N/A";
            this.resultSunset.Click += new System.EventHandler(this.resulstSunset_Click);
            // 
            // lbForecast
            // 
            this.lbForecast.AutoSize = true;
            this.lbForecast.BackColor = System.Drawing.Color.Transparent;
            this.lbForecast.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForecast.ForeColor = System.Drawing.Color.Black;
            this.lbForecast.Location = new System.Drawing.Point(210, 367);
            this.lbForecast.Name = "lbForecast";
            this.lbForecast.Size = new System.Drawing.Size(138, 39);
            this.lbForecast.TabIndex = 17;
            this.lbForecast.Text = "Forecast:";
            this.lbForecast.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // pictureForecast1
            // 
            this.pictureForecast1.BackColor = System.Drawing.Color.Transparent;
            this.pictureForecast1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.iconBackgroundSmall;
            this.pictureForecast1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureForecast1.Location = new System.Drawing.Point(219, 469);
            this.pictureForecast1.Name = "pictureForecast1";
            this.pictureForecast1.Size = new System.Drawing.Size(100, 100);
            this.pictureForecast1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureForecast1.TabIndex = 18;
            this.pictureForecast1.TabStop = false;
            // 
            // pictureForecast2
            // 
            this.pictureForecast2.BackColor = System.Drawing.Color.Transparent;
            this.pictureForecast2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.iconBackgroundSmall;
            this.pictureForecast2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureForecast2.Location = new System.Drawing.Point(552, 469);
            this.pictureForecast2.Name = "pictureForecast2";
            this.pictureForecast2.Size = new System.Drawing.Size(100, 100);
            this.pictureForecast2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureForecast2.TabIndex = 19;
            this.pictureForecast2.TabStop = false;
            // 
            // pictureForecast3
            // 
            this.pictureForecast3.BackColor = System.Drawing.Color.Transparent;
            this.pictureForecast3.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.iconBackgroundSmall;
            this.pictureForecast3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureForecast3.Location = new System.Drawing.Point(885, 469);
            this.pictureForecast3.Name = "pictureForecast3";
            this.pictureForecast3.Size = new System.Drawing.Size(100, 100);
            this.pictureForecast3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureForecast3.TabIndex = 20;
            this.pictureForecast3.TabStop = false;
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.BackColor = System.Drawing.Color.Transparent;
            this.v.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.v.ForeColor = System.Drawing.Color.Black;
            this.v.Location = new System.Drawing.Point(216, 613);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(149, 29);
            this.v.TabIndex = 21;
            this.v.Text = "Temperature:";
            // 
            // weatherConditionForecast1
            // 
            this.weatherConditionForecast1.AutoSize = true;
            this.weatherConditionForecast1.BackColor = System.Drawing.Color.Transparent;
            this.weatherConditionForecast1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.weatherConditionForecast1.ForeColor = System.Drawing.Color.Black;
            this.weatherConditionForecast1.Location = new System.Drawing.Point(214, 572);
            this.weatherConditionForecast1.Name = "weatherConditionForecast1";
            this.weatherConditionForecast1.Size = new System.Drawing.Size(203, 29);
            this.weatherConditionForecast1.TabIndex = 22;
            this.weatherConditionForecast1.Text = "Weather Condition";
            // 
            // lbForecastHumidity1
            // 
            this.lbForecastHumidity1.AutoSize = true;
            this.lbForecastHumidity1.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastHumidity1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastHumidity1.ForeColor = System.Drawing.Color.Black;
            this.lbForecastHumidity1.Location = new System.Drawing.Point(216, 642);
            this.lbForecastHumidity1.Name = "lbForecastHumidity1";
            this.lbForecastHumidity1.Size = new System.Drawing.Size(112, 29);
            this.lbForecastHumidity1.TabIndex = 23;
            this.lbForecastHumidity1.Text = "Humidity:";
            // 
            // lbForecastWindspeed1
            // 
            this.lbForecastWindspeed1.AutoSize = true;
            this.lbForecastWindspeed1.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastWindspeed1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastWindspeed1.ForeColor = System.Drawing.Color.Black;
            this.lbForecastWindspeed1.Location = new System.Drawing.Point(216, 671);
            this.lbForecastWindspeed1.Name = "lbForecastWindspeed1";
            this.lbForecastWindspeed1.Size = new System.Drawing.Size(134, 29);
            this.lbForecastWindspeed1.TabIndex = 24;
            this.lbForecastWindspeed1.Text = "Windspeed:";
            // 
            // weatherConditionForecast2
            // 
            this.weatherConditionForecast2.AutoSize = true;
            this.weatherConditionForecast2.BackColor = System.Drawing.Color.Transparent;
            this.weatherConditionForecast2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.weatherConditionForecast2.ForeColor = System.Drawing.Color.Black;
            this.weatherConditionForecast2.Location = new System.Drawing.Point(549, 572);
            this.weatherConditionForecast2.Name = "weatherConditionForecast2";
            this.weatherConditionForecast2.Size = new System.Drawing.Size(203, 29);
            this.weatherConditionForecast2.TabIndex = 26;
            this.weatherConditionForecast2.Text = "Weather Condition";
            // 
            // weatherConditionForecast3
            // 
            this.weatherConditionForecast3.AutoSize = true;
            this.weatherConditionForecast3.BackColor = System.Drawing.Color.Transparent;
            this.weatherConditionForecast3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.weatherConditionForecast3.ForeColor = System.Drawing.Color.Black;
            this.weatherConditionForecast3.Location = new System.Drawing.Point(882, 572);
            this.weatherConditionForecast3.Name = "weatherConditionForecast3";
            this.weatherConditionForecast3.Size = new System.Drawing.Size(203, 29);
            this.weatherConditionForecast3.TabIndex = 30;
            this.weatherConditionForecast3.Text = "Weather Condition";
            // 
            // forecastResultTemperature1
            // 
            this.forecastResultTemperature1.AutoSize = true;
            this.forecastResultTemperature1.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultTemperature1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultTemperature1.ForeColor = System.Drawing.Color.Black;
            this.forecastResultTemperature1.Location = new System.Drawing.Point(371, 613);
            this.forecastResultTemperature1.Name = "forecastResultTemperature1";
            this.forecastResultTemperature1.Size = new System.Drawing.Size(53, 29);
            this.forecastResultTemperature1.TabIndex = 33;
            this.forecastResultTemperature1.Text = "N/A";
            this.forecastResultTemperature1.UseMnemonic = false;
            // 
            // forecastResultHumidity1
            // 
            this.forecastResultHumidity1.AutoSize = true;
            this.forecastResultHumidity1.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultHumidity1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultHumidity1.ForeColor = System.Drawing.Color.Black;
            this.forecastResultHumidity1.Location = new System.Drawing.Point(371, 642);
            this.forecastResultHumidity1.Name = "forecastResultHumidity1";
            this.forecastResultHumidity1.Size = new System.Drawing.Size(53, 29);
            this.forecastResultHumidity1.TabIndex = 34;
            this.forecastResultHumidity1.Text = "N/A";
            this.forecastResultHumidity1.UseMnemonic = false;
            // 
            // forecastResultWindspeed1
            // 
            this.forecastResultWindspeed1.AutoSize = true;
            this.forecastResultWindspeed1.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultWindspeed1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultWindspeed1.ForeColor = System.Drawing.Color.Black;
            this.forecastResultWindspeed1.Location = new System.Drawing.Point(371, 671);
            this.forecastResultWindspeed1.Name = "forecastResultWindspeed1";
            this.forecastResultWindspeed1.Size = new System.Drawing.Size(53, 29);
            this.forecastResultWindspeed1.TabIndex = 35;
            this.forecastResultWindspeed1.Text = "N/A";
            this.forecastResultWindspeed1.UseMnemonic = false;
            // 
            // forecastResultWindspeed2
            // 
            this.forecastResultWindspeed2.AutoSize = true;
            this.forecastResultWindspeed2.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultWindspeed2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultWindspeed2.ForeColor = System.Drawing.Color.Black;
            this.forecastResultWindspeed2.Location = new System.Drawing.Point(704, 671);
            this.forecastResultWindspeed2.Name = "forecastResultWindspeed2";
            this.forecastResultWindspeed2.Size = new System.Drawing.Size(53, 29);
            this.forecastResultWindspeed2.TabIndex = 41;
            this.forecastResultWindspeed2.Text = "N/A";
            this.forecastResultWindspeed2.UseMnemonic = false;
            // 
            // forecastResultHumidity2
            // 
            this.forecastResultHumidity2.AutoSize = true;
            this.forecastResultHumidity2.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultHumidity2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultHumidity2.ForeColor = System.Drawing.Color.Black;
            this.forecastResultHumidity2.Location = new System.Drawing.Point(704, 642);
            this.forecastResultHumidity2.Name = "forecastResultHumidity2";
            this.forecastResultHumidity2.Size = new System.Drawing.Size(53, 29);
            this.forecastResultHumidity2.TabIndex = 40;
            this.forecastResultHumidity2.Text = "N/A";
            this.forecastResultHumidity2.UseMnemonic = false;
            // 
            // forecastResultTemperature2
            // 
            this.forecastResultTemperature2.AutoSize = true;
            this.forecastResultTemperature2.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultTemperature2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultTemperature2.ForeColor = System.Drawing.Color.Black;
            this.forecastResultTemperature2.Location = new System.Drawing.Point(704, 613);
            this.forecastResultTemperature2.Name = "forecastResultTemperature2";
            this.forecastResultTemperature2.Size = new System.Drawing.Size(53, 29);
            this.forecastResultTemperature2.TabIndex = 39;
            this.forecastResultTemperature2.Text = "N/A";
            this.forecastResultTemperature2.UseMnemonic = false;
            // 
            // lbForecastWindspeed2
            // 
            this.lbForecastWindspeed2.AutoSize = true;
            this.lbForecastWindspeed2.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastWindspeed2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastWindspeed2.ForeColor = System.Drawing.Color.Black;
            this.lbForecastWindspeed2.Location = new System.Drawing.Point(549, 671);
            this.lbForecastWindspeed2.Name = "lbForecastWindspeed2";
            this.lbForecastWindspeed2.Size = new System.Drawing.Size(134, 29);
            this.lbForecastWindspeed2.TabIndex = 38;
            this.lbForecastWindspeed2.Text = "Windspeed:";
            // 
            // lbForecastHumidity2
            // 
            this.lbForecastHumidity2.AutoSize = true;
            this.lbForecastHumidity2.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastHumidity2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastHumidity2.ForeColor = System.Drawing.Color.Black;
            this.lbForecastHumidity2.Location = new System.Drawing.Point(549, 642);
            this.lbForecastHumidity2.Name = "lbForecastHumidity2";
            this.lbForecastHumidity2.Size = new System.Drawing.Size(112, 29);
            this.lbForecastHumidity2.TabIndex = 37;
            this.lbForecastHumidity2.Text = "Humidity:";
            // 
            // lbForecastTemperature2
            // 
            this.lbForecastTemperature2.AutoSize = true;
            this.lbForecastTemperature2.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastTemperature2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastTemperature2.ForeColor = System.Drawing.Color.Black;
            this.lbForecastTemperature2.Location = new System.Drawing.Point(549, 613);
            this.lbForecastTemperature2.Name = "lbForecastTemperature2";
            this.lbForecastTemperature2.Size = new System.Drawing.Size(149, 29);
            this.lbForecastTemperature2.TabIndex = 36;
            this.lbForecastTemperature2.Text = "Temperature:";
            // 
            // forecastResultWindspeed3
            // 
            this.forecastResultWindspeed3.AutoSize = true;
            this.forecastResultWindspeed3.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultWindspeed3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultWindspeed3.ForeColor = System.Drawing.Color.Black;
            this.forecastResultWindspeed3.Location = new System.Drawing.Point(1037, 671);
            this.forecastResultWindspeed3.Name = "forecastResultWindspeed3";
            this.forecastResultWindspeed3.Size = new System.Drawing.Size(53, 29);
            this.forecastResultWindspeed3.TabIndex = 47;
            this.forecastResultWindspeed3.Text = "N/A";
            this.forecastResultWindspeed3.UseMnemonic = false;
            // 
            // forecastResultHumidity3
            // 
            this.forecastResultHumidity3.AutoSize = true;
            this.forecastResultHumidity3.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultHumidity3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultHumidity3.ForeColor = System.Drawing.Color.Black;
            this.forecastResultHumidity3.Location = new System.Drawing.Point(1037, 642);
            this.forecastResultHumidity3.Name = "forecastResultHumidity3";
            this.forecastResultHumidity3.Size = new System.Drawing.Size(53, 29);
            this.forecastResultHumidity3.TabIndex = 46;
            this.forecastResultHumidity3.Text = "N/A";
            this.forecastResultHumidity3.UseMnemonic = false;
            // 
            // forecastResultTemperature3
            // 
            this.forecastResultTemperature3.AutoSize = true;
            this.forecastResultTemperature3.BackColor = System.Drawing.Color.Transparent;
            this.forecastResultTemperature3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.forecastResultTemperature3.ForeColor = System.Drawing.Color.Black;
            this.forecastResultTemperature3.Location = new System.Drawing.Point(1037, 613);
            this.forecastResultTemperature3.Name = "forecastResultTemperature3";
            this.forecastResultTemperature3.Size = new System.Drawing.Size(53, 29);
            this.forecastResultTemperature3.TabIndex = 45;
            this.forecastResultTemperature3.Text = "N/A";
            this.forecastResultTemperature3.UseMnemonic = false;
            // 
            // lbForecastWindspeed3
            // 
            this.lbForecastWindspeed3.AutoSize = true;
            this.lbForecastWindspeed3.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastWindspeed3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastWindspeed3.ForeColor = System.Drawing.Color.Black;
            this.lbForecastWindspeed3.Location = new System.Drawing.Point(882, 671);
            this.lbForecastWindspeed3.Name = "lbForecastWindspeed3";
            this.lbForecastWindspeed3.Size = new System.Drawing.Size(134, 29);
            this.lbForecastWindspeed3.TabIndex = 44;
            this.lbForecastWindspeed3.Text = "Windspeed:";
            // 
            // lbForecastHumidity3
            // 
            this.lbForecastHumidity3.AutoSize = true;
            this.lbForecastHumidity3.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastHumidity3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastHumidity3.ForeColor = System.Drawing.Color.Black;
            this.lbForecastHumidity3.Location = new System.Drawing.Point(882, 642);
            this.lbForecastHumidity3.Name = "lbForecastHumidity3";
            this.lbForecastHumidity3.Size = new System.Drawing.Size(112, 29);
            this.lbForecastHumidity3.TabIndex = 43;
            this.lbForecastHumidity3.Text = "Humidity:";
            // 
            // lbForecastTemperature3
            // 
            this.lbForecastTemperature3.AutoSize = true;
            this.lbForecastTemperature3.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastTemperature3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastTemperature3.ForeColor = System.Drawing.Color.Black;
            this.lbForecastTemperature3.Location = new System.Drawing.Point(882, 613);
            this.lbForecastTemperature3.Name = "lbForecastTemperature3";
            this.lbForecastTemperature3.Size = new System.Drawing.Size(149, 29);
            this.lbForecastTemperature3.TabIndex = 42;
            this.lbForecastTemperature3.Text = "Temperature:";
            // 
            // lbForecastTime1
            // 
            this.lbForecastTime1.AutoSize = true;
            this.lbForecastTime1.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastTime1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastTime1.ForeColor = System.Drawing.Color.Black;
            this.lbForecastTime1.Location = new System.Drawing.Point(212, 438);
            this.lbForecastTime1.Name = "lbForecastTime1";
            this.lbForecastTime1.Size = new System.Drawing.Size(75, 29);
            this.lbForecastTime1.TabIndex = 48;
            this.lbForecastTime1.Text = "Time: ";
            // 
            // resultForecastTime1
            // 
            this.resultForecastTime1.AutoSize = true;
            this.resultForecastTime1.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastTime1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastTime1.ForeColor = System.Drawing.Color.Black;
            this.resultForecastTime1.Location = new System.Drawing.Point(295, 438);
            this.resultForecastTime1.Name = "resultForecastTime1";
            this.resultForecastTime1.Size = new System.Drawing.Size(53, 29);
            this.resultForecastTime1.TabIndex = 49;
            this.resultForecastTime1.Text = "N/A";
            // 
            // resultForecastTime2
            // 
            this.resultForecastTime2.AutoSize = true;
            this.resultForecastTime2.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastTime2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastTime2.ForeColor = System.Drawing.Color.Black;
            this.resultForecastTime2.Location = new System.Drawing.Point(628, 438);
            this.resultForecastTime2.Name = "resultForecastTime2";
            this.resultForecastTime2.Size = new System.Drawing.Size(53, 29);
            this.resultForecastTime2.TabIndex = 51;
            this.resultForecastTime2.Text = "N/A";
            // 
            // lbForecastTime2
            // 
            this.lbForecastTime2.AutoSize = true;
            this.lbForecastTime2.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastTime2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastTime2.ForeColor = System.Drawing.Color.Black;
            this.lbForecastTime2.Location = new System.Drawing.Point(545, 438);
            this.lbForecastTime2.Name = "lbForecastTime2";
            this.lbForecastTime2.Size = new System.Drawing.Size(75, 29);
            this.lbForecastTime2.TabIndex = 50;
            this.lbForecastTime2.Text = "Time: ";
            // 
            // resultForecastTime3
            // 
            this.resultForecastTime3.AutoSize = true;
            this.resultForecastTime3.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastTime3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastTime3.ForeColor = System.Drawing.Color.Black;
            this.resultForecastTime3.Location = new System.Drawing.Point(961, 438);
            this.resultForecastTime3.Name = "resultForecastTime3";
            this.resultForecastTime3.Size = new System.Drawing.Size(53, 29);
            this.resultForecastTime3.TabIndex = 53;
            this.resultForecastTime3.Text = "N/A";
            // 
            // lbForecastTime3
            // 
            this.lbForecastTime3.AutoSize = true;
            this.lbForecastTime3.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastTime3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastTime3.ForeColor = System.Drawing.Color.Black;
            this.lbForecastTime3.Location = new System.Drawing.Point(878, 438);
            this.lbForecastTime3.Name = "lbForecastTime3";
            this.lbForecastTime3.Size = new System.Drawing.Size(75, 29);
            this.lbForecastTime3.TabIndex = 52;
            this.lbForecastTime3.Text = "Time: ";
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonBackground;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.ForeColor = System.Drawing.Color.Black;
            this.nextButton.Location = new System.Drawing.Point(1121, 493);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(130, 47);
            this.nextButton.TabIndex = 54;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.Color.Transparent;
            this.prevButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttonBackground;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prevButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevButton.ForeColor = System.Drawing.Color.Black;
            this.prevButton.Location = new System.Drawing.Point(29, 493);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(130, 47);
            this.prevButton.TabIndex = 55;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // resultForecastDate3
            // 
            this.resultForecastDate3.AutoSize = true;
            this.resultForecastDate3.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastDate3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastDate3.ForeColor = System.Drawing.Color.Black;
            this.resultForecastDate3.Location = new System.Drawing.Point(963, 406);
            this.resultForecastDate3.Name = "resultForecastDate3";
            this.resultForecastDate3.Size = new System.Drawing.Size(53, 29);
            this.resultForecastDate3.TabIndex = 61;
            this.resultForecastDate3.Text = "N/A";
            // 
            // lbForecastDate3
            // 
            this.lbForecastDate3.AutoSize = true;
            this.lbForecastDate3.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastDate3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastDate3.ForeColor = System.Drawing.Color.Black;
            this.lbForecastDate3.Location = new System.Drawing.Point(880, 406);
            this.lbForecastDate3.Name = "lbForecastDate3";
            this.lbForecastDate3.Size = new System.Drawing.Size(72, 29);
            this.lbForecastDate3.TabIndex = 60;
            this.lbForecastDate3.Text = "Date: ";
            // 
            // resultForecastDate2
            // 
            this.resultForecastDate2.AutoSize = true;
            this.resultForecastDate2.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastDate2.ForeColor = System.Drawing.Color.Black;
            this.resultForecastDate2.Location = new System.Drawing.Point(630, 406);
            this.resultForecastDate2.Name = "resultForecastDate2";
            this.resultForecastDate2.Size = new System.Drawing.Size(53, 29);
            this.resultForecastDate2.TabIndex = 59;
            this.resultForecastDate2.Text = "N/A";
            this.resultForecastDate2.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbForecastDate2
            // 
            this.lbForecastDate2.AutoSize = true;
            this.lbForecastDate2.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastDate2.ForeColor = System.Drawing.Color.Black;
            this.lbForecastDate2.Location = new System.Drawing.Point(547, 406);
            this.lbForecastDate2.Name = "lbForecastDate2";
            this.lbForecastDate2.Size = new System.Drawing.Size(72, 29);
            this.lbForecastDate2.TabIndex = 58;
            this.lbForecastDate2.Text = "Date: ";
            // 
            // resultForecastDate1
            // 
            this.resultForecastDate1.AutoSize = true;
            this.resultForecastDate1.BackColor = System.Drawing.Color.Transparent;
            this.resultForecastDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.resultForecastDate1.ForeColor = System.Drawing.Color.Black;
            this.resultForecastDate1.Location = new System.Drawing.Point(297, 406);
            this.resultForecastDate1.Name = "resultForecastDate1";
            this.resultForecastDate1.Size = new System.Drawing.Size(53, 29);
            this.resultForecastDate1.TabIndex = 57;
            this.resultForecastDate1.Text = "N/A";
            // 
            // lbForecastDate1
            // 
            this.lbForecastDate1.AutoSize = true;
            this.lbForecastDate1.BackColor = System.Drawing.Color.Transparent;
            this.lbForecastDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbForecastDate1.ForeColor = System.Drawing.Color.Black;
            this.lbForecastDate1.Location = new System.Drawing.Point(214, 406);
            this.lbForecastDate1.Name = "lbForecastDate1";
            this.lbForecastDate1.Size = new System.Drawing.Size(72, 29);
            this.lbForecastDate1.TabIndex = 56;
            this.lbForecastDate1.Text = "Date: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // forecasterFont
            // 
            this.forecasterFont.BackColor = System.Drawing.Color.Transparent;
            this.forecasterFont.Image = global::WindowsFormsApp1.Properties.Resources.forecaster;
            this.forecasterFont.Location = new System.Drawing.Point(1, 141);
            this.forecasterFont.Name = "forecasterFont";
            this.forecasterFont.Size = new System.Drawing.Size(170, 27);
            this.forecasterFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.forecasterFont.TabIndex = 65;
            this.forecasterFont.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.forecasterFont);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.resultForecastDate3);
            this.Controls.Add(this.lbForecastDate3);
            this.Controls.Add(this.resultForecastDate2);
            this.Controls.Add(this.lbForecastDate2);
            this.Controls.Add(this.resultForecastDate1);
            this.Controls.Add(this.lbForecastDate1);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.resultForecastTime3);
            this.Controls.Add(this.lbForecastTime3);
            this.Controls.Add(this.resultForecastTime2);
            this.Controls.Add(this.lbForecastTime2);
            this.Controls.Add(this.resultForecastTime1);
            this.Controls.Add(this.lbForecastTime1);
            this.Controls.Add(this.forecastResultWindspeed3);
            this.Controls.Add(this.forecastResultHumidity3);
            this.Controls.Add(this.forecastResultTemperature3);
            this.Controls.Add(this.lbForecastWindspeed3);
            this.Controls.Add(this.lbForecastHumidity3);
            this.Controls.Add(this.lbForecastTemperature3);
            this.Controls.Add(this.forecastResultWindspeed2);
            this.Controls.Add(this.forecastResultHumidity2);
            this.Controls.Add(this.forecastResultTemperature2);
            this.Controls.Add(this.lbForecastWindspeed2);
            this.Controls.Add(this.lbForecastHumidity2);
            this.Controls.Add(this.lbForecastTemperature2);
            this.Controls.Add(this.forecastResultWindspeed1);
            this.Controls.Add(this.forecastResultHumidity1);
            this.Controls.Add(this.forecastResultTemperature1);
            this.Controls.Add(this.weatherConditionForecast3);
            this.Controls.Add(this.weatherConditionForecast2);
            this.Controls.Add(this.lbForecastWindspeed1);
            this.Controls.Add(this.lbForecastHumidity1);
            this.Controls.Add(this.weatherConditionForecast1);
            this.Controls.Add(this.v);
            this.Controls.Add(this.pictureForecast3);
            this.Controls.Add(this.pictureForecast2);
            this.Controls.Add(this.pictureForecast1);
            this.Controls.Add(this.lbForecast);
            this.Controls.Add(this.resultSunset);
            this.Controls.Add(this.resultSunrise);
            this.Controls.Add(this.lbSunset);
            this.Controls.Add(this.lbSunrise);
            this.Controls.Add(this.weatherPicture);
            this.Controls.Add(this.weatherCondition);
            this.Controls.Add(this.resultWindspeed);
            this.Controls.Add(this.lbWindSpeed);
            this.Controls.Add(this.resultHumidity);
            this.Controls.Add(this.lbHumidity);
            this.Controls.Add(this.resultTemperature);
            this.Controls.Add(this.lbTemperature);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.lbCity);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Forecaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weatherPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureForecast3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecasterFont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCity;
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
        private System.Windows.Forms.PictureBox pictureForecast1;
        private System.Windows.Forms.PictureBox pictureForecast2;
        private System.Windows.Forms.PictureBox pictureForecast3;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.Label weatherConditionForecast1;
        private System.Windows.Forms.Label lbForecastHumidity1;
        private System.Windows.Forms.Label lbForecastWindspeed1;
        private System.Windows.Forms.Label weatherConditionForecast2;
        private System.Windows.Forms.Label weatherConditionForecast3;
        private System.Windows.Forms.Label forecastResultTemperature1;
        private System.Windows.Forms.Label forecastResultHumidity1;
        private System.Windows.Forms.Label forecastResultWindspeed1;
        private System.Windows.Forms.Label forecastResultWindspeed2;
        private System.Windows.Forms.Label forecastResultHumidity2;
        private System.Windows.Forms.Label forecastResultTemperature2;
        private System.Windows.Forms.Label lbForecastWindspeed2;
        private System.Windows.Forms.Label lbForecastHumidity2;
        private System.Windows.Forms.Label lbForecastTemperature2;
        private System.Windows.Forms.Label forecastResultWindspeed3;
        private System.Windows.Forms.Label forecastResultHumidity3;
        private System.Windows.Forms.Label forecastResultTemperature3;
        private System.Windows.Forms.Label lbForecastWindspeed3;
        private System.Windows.Forms.Label lbForecastHumidity3;
        private System.Windows.Forms.Label lbForecastTemperature3;
        private System.Windows.Forms.Label lbForecastTime1;
        private System.Windows.Forms.Label resultForecastTime1;
        private System.Windows.Forms.Label resultForecastTime2;
        private System.Windows.Forms.Label lbForecastTime2;
        private System.Windows.Forms.Label resultForecastTime3;
        private System.Windows.Forms.Label lbForecastTime3;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label resultForecastDate3;
        private System.Windows.Forms.Label lbForecastDate3;
        private System.Windows.Forms.Label resultForecastDate2;
        private System.Windows.Forms.Label lbForecastDate2;
        private System.Windows.Forms.Label resultForecastDate1;
        private System.Windows.Forms.Label lbForecastDate1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox forecasterFont;
    }
}
