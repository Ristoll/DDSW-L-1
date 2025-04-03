namespace DDSW_L_1
{
    partial class CargoAcceptanceWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button3 = new Button();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(352, 388);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(487, 33);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(301, 384);
            listBox2.TabIndex = 14;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(301, 344);
            listBox1.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(109, 388);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Accept";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 16;
            label1.Text = "New cargo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(591, 9);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 17;
            label2.Text = "Current items";
            // 
            // button2
            // 
            button2.Location = new Point(352, 33);
            button2.Name = "button2";
            button2.Size = new Size(94, 60);
            button2.TabIndex = 18;
            button2.Text = "Add item manually";
            button2.UseVisualStyleBackColor = true;
            // 
            // CargoAcceptanceWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "CargoAcceptanceWindow";
            Text = "CargoAcceptanceWindow";
            Load += CargoAcceptanceWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private ListBox listBox2;
        private ListBox listBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
    }
}