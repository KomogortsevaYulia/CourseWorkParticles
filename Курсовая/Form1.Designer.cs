namespace Курсовая
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.RandomColorParticles = new System.Windows.Forms.Button();
            this.RandomColorPictures = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbForm = new System.Windows.Forms.ComboBox();
            this.ColorPictures = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ColorParticles = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLife = new System.Windows.Forms.TrackBar();
            this.StepBack = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(216, 185);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(186, 45);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Value = 1;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_ValueChanged);
            // 
            // RandomColorParticles
            // 
            this.RandomColorParticles.Location = new System.Drawing.Point(66, 60);
            this.RandomColorParticles.Name = "RandomColorParticles";
            this.RandomColorParticles.Size = new System.Drawing.Size(126, 53);
            this.RandomColorParticles.TabIndex = 15;
            this.RandomColorParticles.Text = "Случайный \r\nцвет частиц";
            this.RandomColorParticles.UseVisualStyleBackColor = true;
            this.RandomColorParticles.Click += new System.EventHandler(this.RandomColorParticles_Click);
            // 
            // RandomColorPictures
            // 
            this.RandomColorPictures.Location = new System.Drawing.Point(216, 60);
            this.RandomColorPictures.Name = "RandomColorPictures";
            this.RandomColorPictures.Size = new System.Drawing.Size(126, 53);
            this.RandomColorPictures.TabIndex = 16;
            this.RandomColorPictures.Text = "Случайный\r\nцвет фона";
            this.RandomColorPictures.UseVisualStyleBackColor = true;
            this.RandomColorPictures.Click += new System.EventHandler(this.RandomColorPictures_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.LargeChange = 1;
            this.tbNumber.Location = new System.Drawing.Point(216, 94);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(183, 45);
            this.tbNumber.TabIndex = 17;
            this.tbNumber.Value = 1;
            this.tbNumber.Scroll += new System.EventHandler(this.tbNumber_Scroll_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Количество частиц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Скорость частиц в %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(6, 94);
            this.tbSize.Maximum = 11;
            this.tbSize.Minimum = 2;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(204, 45);
            this.tbSize.TabIndex = 3;
            this.tbSize.Value = 5;
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Размер частиц";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(6, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "10  15   20   25   30   35   40  45   50   55";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(221, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "0                       50                      100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Продолжительность жизни частиц в %";
            // 
            // cmbForm
            // 
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.Items.AddRange(new object[] {
            "Круг",
            "Квадрат",
            "Звезда",
            "Снежинки"});
            this.cmbForm.Location = new System.Drawing.Point(151, 38);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.Size = new System.Drawing.Size(121, 21);
            this.cmbForm.TabIndex = 30;
            this.cmbForm.Tag = "";
            this.cmbForm.Text = "Круг";
            this.cmbForm.SelectedIndexChanged += new System.EventHandler(this.cmbForm_SelectedIndexChanged);
            // 
            // ColorPictures
            // 
            this.ColorPictures.Location = new System.Drawing.Point(216, 139);
            this.ColorPictures.Name = "ColorPictures";
            this.ColorPictures.Size = new System.Drawing.Size(126, 53);
            this.ColorPictures.TabIndex = 31;
            this.ColorPictures.Text = "Выбрать цвет фона";
            this.ColorPictures.UseVisualStyleBackColor = true;
            this.ColorPictures.Click += new System.EventHandler(this.ColorPictures_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(654, 240);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 278);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ColorParticles);
            this.tabPage1.Controls.Add(this.RandomColorParticles);
            this.tabPage1.Controls.Add(this.ColorPictures);
            this.tabPage1.Controls.Add(this.RandomColorPictures);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(405, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Цвет";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ColorParticles
            // 
            this.ColorParticles.Location = new System.Drawing.Point(66, 139);
            this.ColorParticles.Name = "ColorParticles";
            this.ColorParticles.Size = new System.Drawing.Size(126, 53);
            this.ColorParticles.TabIndex = 32;
            this.ColorParticles.Text = "Выбрать цвет частиц";
            this.ColorParticles.UseVisualStyleBackColor = true;
            this.ColorParticles.Click += new System.EventHandler(this.ColorParticles_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmbForm);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbSize);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbSpeed);
            this.tabPage2.Controls.Add(this.tbLife);
            this.tabPage2.Controls.Add(this.tbNumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Частицы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(337, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "0                        50                      100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(16, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "0                        50                      100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Форма частиц:";
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(9, 185);
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(186, 45);
            this.tbLife.TabIndex = 32;
            this.tbLife.Value = 7;
            this.tbLife.Scroll += new System.EventHandler(this.tbLife_Scroll);
            // 
            // StepBack
            // 
            this.StepBack.BackColor = System.Drawing.SystemColors.Window;
            this.StepBack.BackgroundImage = global::Курсовая.Properties.Resources.undo_black_arrow_pointing_to_left_icon_icons_com_56880;
            this.StepBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StepBack.Location = new System.Drawing.Point(874, 12);
            this.StepBack.Name = "StepBack";
            this.StepBack.Size = new System.Drawing.Size(94, 90);
            this.StepBack.TabIndex = 5;
            this.StepBack.UseVisualStyleBackColor = false;
            this.StepBack.Click += new System.EventHandler(this.StepBack_Click);
            // 
            // Step
            // 
            this.Step.BackgroundImage = global::Курсовая.Properties.Resources._1;
            this.Step.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Step.Location = new System.Drawing.Point(973, 12);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(94, 90);
            this.Step.TabIndex = 4;
            this.Step.Text = "Шаг";
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.SystemColors.Window;
            this.Stop.BackgroundImage = global::Курсовая.Properties.Resources._1486348534_music_pause_stop_control_play_80459;
            this.Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Stop.Location = new System.Drawing.Point(774, 12);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(94, 90);
            this.Stop.TabIndex = 3;
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.Window;
            this.Start.BackgroundImage = global::Курсовая.Properties.Resources._1486348532_music_play_pause_control_go_arrow_80458;
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start.Location = new System.Drawing.Point(674, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(94, 90);
            this.Start.TabIndex = 2;
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(636, 506);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Простой",
            "Окрашивание"});
            this.comboBox1.Location = new System.Drawing.Point(809, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "Простой";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(826, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Режим работы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 530);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StepBack);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Система управления частицами";
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.Button StepBack;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Button RandomColorParticles;
        private System.Windows.Forms.Button RandomColorPictures;
        private System.Windows.Forms.TrackBar tbNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbForm;
        private System.Windows.Forms.Button ColorPictures;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ColorParticles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbLife;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
    }
}

