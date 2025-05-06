namespace WebServer
{
    partial class Form1
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
      button1 = new Button();
      label1 = new Label();
      button2 = new Button();
      textBox1 = new TextBox();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(417, 270);
      button1.Name = "button1";
      button1.Size = new Size(113, 35);
      button1.TabIndex = 0;
      button1.Text = "Connecting";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(111, 94);
      label1.Name = "label1";
      label1.Size = new Size(51, 19);
      label1.TabIndex = 1;
      label1.Text = "label1";
      // 
      // button2
      // 
      button2.Location = new Point(417, 212);
      button2.Name = "button2";
      button2.Size = new Size(113, 44);
      button2.TabIndex = 2;
      button2.Text = "Get IP";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // textBox1
      // 
      textBox1.Enabled = false;
      textBox1.Location = new Point(111, 116);
      textBox1.Multiline = true;
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(279, 295);
      textBox1.TabIndex = 3;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(9F, 19F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(textBox1);
      Controls.Add(button2);
      Controls.Add(label1);
      Controls.Add(button1);
      Name = "Form1";
      Text = "Form1";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private Button button2;
    private TextBox textBox1;
  }
}
