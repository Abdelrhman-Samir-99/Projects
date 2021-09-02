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
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(331, 12);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(331, 41);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(331, 70);
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
            this.meals_Combo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.meals_Combo.FormattingEnabled = true;
            this.meals_Combo.Location = new System.Drawing.Point(12, 12);
            this.meals_Combo.Name = "meals_Combo";
            this.meals_Combo.Size = new System.Drawing.Size(121, 21);
            this.meals_Combo.TabIndex = 3;
            this.meals_Combo.SelectedIndexChanged += new System.EventHandler(this.meals_Combo_SelectedIndexChanged);
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(152, 13);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(50, 20);
            this.Count.TabIndex = 4;
            this.Count.TextChanged += new System.EventHandler(this.Count_TextChanged);
            // 
            // tot
            // 
            this.tot.Location = new System.Drawing.Point(227, 15);
            this.tot.Name = "tot";
            this.tot.ReadOnly = true;
            this.tot.Size = new System.Drawing.Size(50, 20);
            this.tot.TabIndex = 5;
            this.tot.Text = "0";
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(12, 44);
            this.Order.Multiline = true;
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.Size = new System.Drawing.Size(313, 178);
            this.Order.TabIndex = 6;
            // 
            // tot2
            // 
            this.tot2.Location = new System.Drawing.Point(166, 230);
            this.tot2.Multiline = true;
            this.tot2.Name = "tot2";
            this.tot2.ReadOnly = true;
            this.tot2.Size = new System.Drawing.Size(52, 23);
            this.tot2.TabIndex = 7;
            this.tot2.Text = "0";
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Done.Location = new System.Drawing.Point(331, 231);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total price";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Order ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(331, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 82);
            this.button1.TabIndex = 12;
            this.button1.Text = "Report of today";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Log out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(415, 270);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.tot2);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.tot);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.meals_Combo);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Cashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}