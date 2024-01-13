namespace RVP_Lab2_Yurl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonStyleBackground = new System.Windows.Forms.Button();
            this.buttonRandomFunc = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.buttonStyleBackground);
            this.groupBox1.Controls.Add(this.buttonRandomFunc);
            this.groupBox1.Controls.Add(this.buttonColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(500, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Элементы управления";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(66, 368);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(108, 40);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonStyleBackground
            // 
            this.buttonStyleBackground.Location = new System.Drawing.Point(74, 264);
            this.buttonStyleBackground.Name = "buttonStyleBackground";
            this.buttonStyleBackground.Size = new System.Drawing.Size(98, 55);
            this.buttonStyleBackground.TabIndex = 2;
            this.buttonStyleBackground.Text = "Стиль фона";
            this.buttonStyleBackground.UseVisualStyleBackColor = true;
            this.buttonStyleBackground.Click += new System.EventHandler(this.buttonStyleBackground_Click);
            // 
            // buttonRandomFunc
            // 
            this.buttonRandomFunc.Location = new System.Drawing.Point(66, 41);
            this.buttonRandomFunc.Name = "buttonRandomFunc";
            this.buttonRandomFunc.Size = new System.Drawing.Size(124, 78);
            this.buttonRandomFunc.TabIndex = 0;
            this.buttonRandomFunc.Text = "Случайная функция";
            this.buttonRandomFunc.UseVisualStyleBackColor = true;
            this.buttonRandomFunc.Click += new System.EventHandler(this.buttonRandomFunc_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(82, 145);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(90, 62);
            this.buttonColor.TabIndex = 1;
            this.buttonColor.Text = "Выбрать цвет";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // panelPaint
            // 
            this.panelPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaint.Location = new System.Drawing.Point(0, 0);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(500, 450);
            this.panelPaint.TabIndex = 3;
            this.panelPaint.SizeChanged += new System.EventHandler(this.panelPaint_SizeChanged);
            this.panelPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPaint_Paint);
            this.panelPaint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseClick);
            this.panelPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseDown);
            this.panelPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseMove);
            this.panelPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPaint);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRandomFunc;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonStyleBackground;
        private System.Windows.Forms.Panel panelPaint;
    }
}

