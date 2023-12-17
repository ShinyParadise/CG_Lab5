namespace CG_Lab5
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            choosePhotoBtn = new Button();
            grayscaleBtn = new Button();
            monochromeBtn = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            applyMinimumFilterBtn = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            dilationBtn = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1221, 839);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // choosePhotoBtn
            // 
            choosePhotoBtn.BackColor = SystemColors.HotTrack;
            choosePhotoBtn.FlatAppearance.BorderSize = 0;
            choosePhotoBtn.ForeColor = SystemColors.ButtonHighlight;
            choosePhotoBtn.Location = new Point(1239, 797);
            choosePhotoBtn.Name = "choosePhotoBtn";
            choosePhotoBtn.Size = new Size(241, 54);
            choosePhotoBtn.TabIndex = 1;
            choosePhotoBtn.Text = "Выбрать фото";
            choosePhotoBtn.UseVisualStyleBackColor = false;
            choosePhotoBtn.Click += choosePhotoBtn_Click;
            // 
            // grayscaleBtn
            // 
            grayscaleBtn.Location = new Point(1239, 12);
            grayscaleBtn.Name = "grayscaleBtn";
            grayscaleBtn.Size = new Size(241, 36);
            grayscaleBtn.TabIndex = 2;
            grayscaleBtn.Text = "Grayscale filter";
            grayscaleBtn.UseVisualStyleBackColor = true;
            grayscaleBtn.Click += grayscaleBtn_Click;
            // 
            // monochromeBtn
            // 
            monochromeBtn.Location = new Point(1239, 270);
            monochromeBtn.Name = "monochromeBtn";
            monochromeBtn.Size = new Size(241, 36);
            monochromeBtn.TabIndex = 3;
            monochromeBtn.Text = "Monochrome filter";
            monochromeBtn.UseVisualStyleBackColor = true;
            monochromeBtn.Click += monochromeBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1395, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(85, 27);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1239, 67);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 5;
            label1.Text = "Размер фильтра";
            // 
            // applyMinimumFilterBtn
            // 
            applyMinimumFilterBtn.Location = new Point(1239, 104);
            applyMinimumFilterBtn.Name = "applyMinimumFilterBtn";
            applyMinimumFilterBtn.Size = new Size(241, 36);
            applyMinimumFilterBtn.TabIndex = 6;
            applyMinimumFilterBtn.Text = "Apply mininum filter";
            applyMinimumFilterBtn.UseVisualStyleBackColor = true;
            applyMinimumFilterBtn.Click += applyMininumFilterBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1239, 329);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 8;
            label2.Text = "Размер ядра";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1395, 326);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(85, 27);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // dilationBtn
            // 
            dilationBtn.Location = new Point(1239, 372);
            dilationBtn.Name = "dilationBtn";
            dilationBtn.Size = new Size(241, 36);
            dilationBtn.TabIndex = 9;
            dilationBtn.Text = "Apply dilation filter";
            dilationBtn.UseVisualStyleBackColor = true;
            dilationBtn.Click += dilationBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1239, 233);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 11;
            label3.Text = "Граница для чб";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1395, 230);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(85, 27);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 863);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(dilationBtn);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(applyMinimumFilterBtn);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(monochromeBtn);
            Controls.Add(grayscaleBtn);
            Controls.Add(choosePhotoBtn);
            Controls.Add(pictureBox1);
            Name = "MainScreen";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button choosePhotoBtn;
        private Button grayscaleBtn;
        private Button monochromeBtn;
        private TextBox textBox1;
        private Label label1;
        private Button applyMinimumFilterBtn;
        private Label label2;
        private TextBox textBox2;
        private Button dilationBtn;
        private Label label3;
        private TextBox textBox3;
    }
}