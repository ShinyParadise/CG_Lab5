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
            addImageBtn = new Button();
            loadImagesBtn = new Button();
            button1 = new Button();
            analyzeBtn = new Button();
            findByKeyBtn = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            findByHashBtn = new Button();
            label5 = new Label();
            textBox5 = new TextBox();
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
            choosePhotoBtn.Location = new Point(1239, 737);
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
            monochromeBtn.Location = new Point(1239, 188);
            monochromeBtn.Name = "monochromeBtn";
            monochromeBtn.Size = new Size(241, 36);
            monochromeBtn.TabIndex = 3;
            monochromeBtn.Text = "Monochrome filter";
            monochromeBtn.UseVisualStyleBackColor = true;
            monochromeBtn.Click += monochromeBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1395, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(85, 27);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1239, 57);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 5;
            label1.Text = "Размер фильтра";
            // 
            // applyMinimumFilterBtn
            // 
            applyMinimumFilterBtn.Location = new Point(1239, 87);
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
            label2.Location = new Point(1239, 236);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 8;
            label2.Text = "Размер ядра";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1395, 233);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(85, 27);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // dilationBtn
            // 
            dilationBtn.Location = new Point(1239, 266);
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
            label3.Location = new Point(1239, 158);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 11;
            label3.Text = "Граница для чб";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1395, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(85, 27);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // addImageBtn
            // 
            addImageBtn.BackColor = Color.IndianRed;
            addImageBtn.FlatAppearance.BorderSize = 0;
            addImageBtn.ForeColor = SystemColors.ButtonHighlight;
            addImageBtn.Location = new Point(1239, 663);
            addImageBtn.Name = "addImageBtn";
            addImageBtn.Size = new Size(241, 54);
            addImageBtn.TabIndex = 12;
            addImageBtn.Text = "Добавить образ в базу";
            addImageBtn.UseVisualStyleBackColor = false;
            addImageBtn.Click += addImageBtn_Click;
            // 
            // loadImagesBtn
            // 
            loadImagesBtn.BackColor = Color.IndianRed;
            loadImagesBtn.FlatAppearance.BorderSize = 0;
            loadImagesBtn.ForeColor = SystemColors.ButtonHighlight;
            loadImagesBtn.Location = new Point(1239, 603);
            loadImagesBtn.Name = "loadImagesBtn";
            loadImagesBtn.Size = new Size(241, 54);
            loadImagesBtn.TabIndex = 13;
            loadImagesBtn.Text = "Загрузить хеши";
            loadImagesBtn.UseVisualStyleBackColor = false;
            loadImagesBtn.Click += loadImagesBtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1239, 543);
            button1.Name = "button1";
            button1.Size = new Size(241, 54);
            button1.TabIndex = 14;
            button1.Text = "Сохранить хеши";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // analyzeBtn
            // 
            analyzeBtn.BackColor = Color.ForestGreen;
            analyzeBtn.FlatAppearance.BorderSize = 0;
            analyzeBtn.ForeColor = SystemColors.ButtonHighlight;
            analyzeBtn.Location = new Point(1239, 797);
            analyzeBtn.Name = "analyzeBtn";
            analyzeBtn.Size = new Size(241, 54);
            analyzeBtn.TabIndex = 15;
            analyzeBtn.Text = "Анализ";
            analyzeBtn.UseVisualStyleBackColor = false;
            analyzeBtn.Click += analyzeBtn_Click;
            // 
            // findByKeyBtn
            // 
            findByKeyBtn.Location = new Point(1239, 356);
            findByKeyBtn.Name = "findByKeyBtn";
            findByKeyBtn.Size = new Size(241, 36);
            findByKeyBtn.TabIndex = 18;
            findByKeyBtn.Text = "Найти образ";
            findByKeyBtn.UseVisualStyleBackColor = true;
            findByKeyBtn.Click += findByKeyBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1239, 326);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 17;
            label4.Text = "Ключ";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1395, 323);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(85, 27);
            textBox4.TabIndex = 16;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // findByHashBtn
            // 
            findByHashBtn.Location = new Point(1239, 437);
            findByHashBtn.Name = "findByHashBtn";
            findByHashBtn.Size = new Size(241, 36);
            findByHashBtn.TabIndex = 21;
            findByHashBtn.Text = "Найти образ по хешу";
            findByHashBtn.UseVisualStyleBackColor = true;
            findByHashBtn.Click += findByHashBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1239, 407);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 20;
            label5.Text = "Хеш";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1283, 404);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(197, 27);
            textBox5.TabIndex = 19;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 863);
            Controls.Add(findByHashBtn);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(findByKeyBtn);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(analyzeBtn);
            Controls.Add(button1);
            Controls.Add(loadImagesBtn);
            Controls.Add(addImageBtn);
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
        private Button addImageBtn;
        private Button loadImagesBtn;
        private Button button1;
        private Button analyzeBtn;
        private Button findByKeyBtn;
        private Label label4;
        private TextBox textBox4;
        private Button findByHashBtn;
        private Label label5;
        private TextBox textBox5;
    }
}