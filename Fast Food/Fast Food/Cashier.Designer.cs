namespace first_Attemp
{
    partial class Cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier));
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.meals_Combo = new System.Windows.Forms.ComboBox();
            this.Count = new System.Windows.Forms.TextBox();
            this.tot = new System.Windows.Forms.TextBox();
            this.Order = new System.Windows.Forms.TextBox();
            this.tot2 = new System.Windows.Forms.TextBox();
            this.Done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Add.Location = new System.Drawing.Point(331, 29);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Edit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Edit.Location = new System.Drawing.Point(331, 58);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Delete.Location = new System.Drawing.Point(331, 87);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // meals_Combo
            // 
            this.meals_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meals_Combo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.meals_Combo.FormattingEnabled = true;
            this.meals_Combo.Location = new System.Drawing.Point(12, 29);
            this.meals_Combo.Name = "meals_Combo";
            this.meals_Combo.Size = new System.Drawing.Size(121, 24);
            this.meals_Combo.TabIndex = 3;
            this.meals_Combo.SelectedIndexChanged += new System.EventHandler(this.meals_Combo_SelectedIndexChanged);
            // 
            // Count
            // 
            this.Count.BackColor = System.Drawing.SystemColors.Control;
            this.Count.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Count.Location = new System.Drawing.Point(152, 30);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(50, 24);
            this.Count.TabIndex = 4;
            this.Count.TextChanged += new System.EventHandler(this.Count_TextChanged);
            // 
            // tot
            // 
            this.tot.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tot.Location = new System.Drawing.Point(213, 31);
            this.tot.Name = "tot";
            this.tot.ReadOnly = true;
            this.tot.Size = new System.Drawing.Size(50, 24);
            this.tot.TabIndex = 5;
            this.tot.Text = "0";
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(12, 61);
            this.Order.Multiline = true;
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.Size = new System.Drawing.Size(313, 178);
            this.Order.TabIndex = 6;
            // 
            // tot2
            // 
            this.tot2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tot2.Location = new System.Drawing.Point(110, 254);
            this.tot2.Multiline = true;
            this.tot2.Name = "tot2";
            this.tot2.ReadOnly = true;
            this.tot2.Size = new System.Drawing.Size(52, 23);
            this.tot2.TabIndex = 7;
            this.tot2.Text = "0";
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Done.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Done.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Done.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Done.Location = new System.Drawing.Point(331, 245);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 8;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = false;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(9, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total price";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBox1.Location = new System.Drawing.Point(283, 253);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(42, 24);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(202, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Order ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(331, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 82);
            this.button1.TabIndex = 12;
            this.button1.Text = "Report of today";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(331, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Log out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.meals_Combo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Done);
            this.panel1.Controls.Add(this.Count);
            this.panel1.Controls.Add(this.tot2);
            this.panel1.Controls.Add(this.tot);
            this.panel1.Controls.Add(this.Order);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 354);
            this.panel1.TabIndex = 15;
            // 
            // button14
            // 
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.Location = new System.Drawing.Point(3, 546);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(36, 34);
            this.button14.TabIndex = 4;
            this.button14.Text = "?";
            this.button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button14.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(424, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 143);
            this.panel3.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Restourents";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Fast Foods";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 354);
            this.Controls.Add(this.panel1);
            this.Name = "Cashier";
            this.Text = "Cashier";
            this.Load += new System.EventHandler(this.Cashier_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox meals_Combo;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.TextBox tot;
        private System.Windows.Forms.TextBox Order;
        private System.Windows.Forms.TextBox tot2;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}