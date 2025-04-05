namespace DDSW_L_1
{
    partial class CargoApprovalWindow
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
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            listBox3 = new ListBox();
            label2 = new Label();
            label1 = new Label();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(618, 386);
            button2.Name = "button2";
            button2.Size = new Size(107, 39);
            button2.TabIndex = 15;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(343, 386);
            button1.Name = "button1";
            button1.Size = new Size(107, 39);
            button1.TabIndex = 14;
            button1.Text = "Approve";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(618, 26);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 13;
            label3.Text = "Current storage";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(547, 61);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(242, 304);
            listBox3.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 26);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 11;
            label2.Text = "Сontents";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 26);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 10;
            label1.Text = "Delivery";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(264, 61);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(257, 304);
            listBox2.TabIndex = 9;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 61);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(225, 364);
            listBox1.TabIndex = 8;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(488, 380);
            button3.Name = "button3";
            button3.Size = new Size(107, 51);
            button3.TabIndex = 16;
            button3.Text = "Add New Item";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CargoApprovalWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(listBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "CargoApprovalWindow";
            Text = "CargoApprovalWindow";
            Load += CargoAcceptanceWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label3;
        private ListBox listBox3;
        private Label label2;
        private Label label1;
        private ListBox listBox2;
        private ListBox listBox1;
        private Button button3;
    }
}