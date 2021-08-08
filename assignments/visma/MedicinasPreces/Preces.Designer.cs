namespace MedicinasPreces
{
    partial class Preces
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
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Ingredients", System.Windows.Forms.HorizontalAlignment.Left);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xmlRecCount = new System.Windows.Forms.TextBox();
            this.xmlSizeLabel = new System.Windows.Forms.Label();
            this.dbRecCount = new System.Windows.Forms.TextBox();
            this.dbSizeLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.task1 = new System.Windows.Forms.TabPage();
            this.buttonTask1 = new System.Windows.Forms.Button();
            this.textBoxAnswerTask1 = new System.Windows.Forms.TextBox();
            this.textBoxPreceTask1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.task2 = new System.Windows.Forms.TabPage();
            this.buttonTask2 = new System.Windows.Forms.Button();
            this.textBoxAnswerTask2 = new System.Windows.Forms.TextBox();
            this.textBoxProductsTask2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewIngredientsTask3 = new System.Windows.Forms.ListView();
            this.ColOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxIngredientTask3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.task1.SuspendLayout();
            this.task2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xmlRecCount);
            this.groupBox1.Controls.Add(this.xmlSizeLabel);
            this.groupBox1.Controls.Add(this.dbRecCount);
            this.groupBox1.Controls.Add(this.dbSizeLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 95);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vides tests";
            // 
            // xmlRecCount
            // 
            this.xmlRecCount.Location = new System.Drawing.Point(174, 57);
            this.xmlRecCount.Name = "xmlRecCount";
            this.xmlRecCount.ReadOnly = true;
            this.xmlRecCount.Size = new System.Drawing.Size(100, 20);
            this.xmlRecCount.TabIndex = 6;
            // 
            // xmlSizeLabel
            // 
            this.xmlSizeLabel.AutoSize = true;
            this.xmlSizeLabel.Location = new System.Drawing.Point(17, 60);
            this.xmlSizeLabel.Name = "xmlSizeLabel";
            this.xmlSizeLabel.Size = new System.Drawing.Size(142, 13);
            this.xmlSizeLabel.TabIndex = 5;
            this.xmlSizeLabel.Text = "XML datu bāzes pieslēgums:";
            // 
            // dbRecCount
            // 
            this.dbRecCount.Location = new System.Drawing.Point(174, 27);
            this.dbRecCount.Name = "dbRecCount";
            this.dbRecCount.ReadOnly = true;
            this.dbRecCount.Size = new System.Drawing.Size(100, 20);
            this.dbRecCount.TabIndex = 4;
            // 
            // dbSizeLabel
            // 
            this.dbSizeLabel.AutoSize = true;
            this.dbSizeLabel.Location = new System.Drawing.Point(17, 34);
            this.dbSizeLabel.Name = "dbSizeLabel";
            this.dbSizeLabel.Size = new System.Drawing.Size(141, 13);
            this.dbSizeLabel.TabIndex = 3;
            this.dbSizeLabel.Text = "SQL datu bāzes pieslēgums:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.task1);
            this.tabControl1.Controls.Add(this.task2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 364);
            this.tabControl1.TabIndex = 6;
            // 
            // task1
            // 
            this.task1.Controls.Add(this.buttonTask1);
            this.task1.Controls.Add(this.textBoxAnswerTask1);
            this.task1.Controls.Add(this.textBoxPreceTask1);
            this.task1.Controls.Add(this.label5);
            this.task1.Controls.Add(this.label6);
            this.task1.Controls.Add(this.label1);
            this.task1.Location = new System.Drawing.Point(4, 22);
            this.task1.Name = "task1";
            this.task1.Padding = new System.Windows.Forms.Padding(3);
            this.task1.Size = new System.Drawing.Size(534, 338);
            this.task1.TabIndex = 0;
            this.task1.Text = "1. Uzdevums";
            this.task1.UseVisualStyleBackColor = true;
            // 
            // buttonTask1
            // 
            this.buttonTask1.Location = new System.Drawing.Point(341, 59);
            this.buttonTask1.Name = "buttonTask1";
            this.buttonTask1.Size = new System.Drawing.Size(75, 23);
            this.buttonTask1.TabIndex = 10;
            this.buttonTask1.Text = "Noteikt";
            this.buttonTask1.UseVisualStyleBackColor = true;
            this.buttonTask1.Click += new System.EventHandler(this.buttonTask1_Click);
            // 
            // textBoxAnswerTask1
            // 
            this.textBoxAnswerTask1.Location = new System.Drawing.Point(122, 99);
            this.textBoxAnswerTask1.Name = "textBoxAnswerTask1";
            this.textBoxAnswerTask1.Size = new System.Drawing.Size(100, 20);
            this.textBoxAnswerTask1.TabIndex = 9;
            // 
            // textBoxPreceTask1
            // 
            this.textBoxPreceTask1.Location = new System.Drawing.Point(122, 62);
            this.textBoxPreceTask1.Name = "textBoxPreceTask1";
            this.textBoxPreceTask1.Size = new System.Drawing.Size(196, 20);
            this.textBoxPreceTask1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Atbilde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Preces nosaukums:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jānosaka, cik ir vidējā norādītās preces cena (ar šo pašu nosaukumu)";
            // 
            // task2
            // 
            this.task2.Controls.Add(this.buttonTask2);
            this.task2.Controls.Add(this.textBoxAnswerTask2);
            this.task2.Controls.Add(this.textBoxProductsTask2);
            this.task2.Controls.Add(this.label4);
            this.task2.Controls.Add(this.label3);
            this.task2.Controls.Add(this.label2);
            this.task2.Location = new System.Drawing.Point(4, 22);
            this.task2.Name = "task2";
            this.task2.Padding = new System.Windows.Forms.Padding(3);
            this.task2.Size = new System.Drawing.Size(534, 338);
            this.task2.TabIndex = 1;
            this.task2.Text = "2. Uzdevums";
            this.task2.UseVisualStyleBackColor = true;
            // 
            // buttonTask2
            // 
            this.buttonTask2.Location = new System.Drawing.Point(217, 66);
            this.buttonTask2.Name = "buttonTask2";
            this.buttonTask2.Size = new System.Drawing.Size(75, 23);
            this.buttonTask2.TabIndex = 5;
            this.buttonTask2.Text = "Noteikt";
            this.buttonTask2.UseVisualStyleBackColor = true;
            this.buttonTask2.Click += new System.EventHandler(this.buttonTask2_Click);
            // 
            // textBoxAnswerTask2
            // 
            this.textBoxAnswerTask2.Location = new System.Drawing.Point(90, 103);
            this.textBoxAnswerTask2.Name = "textBoxAnswerTask2";
            this.textBoxAnswerTask2.Size = new System.Drawing.Size(100, 20);
            this.textBoxAnswerTask2.TabIndex = 4;
            // 
            // textBoxProductsTask2
            // 
            this.textBoxProductsTask2.Location = new System.Drawing.Point(90, 66);
            this.textBoxProductsTask2.Name = "textBoxProductsTask2";
            this.textBoxProductsTask2.Size = new System.Drawing.Size(100, 20);
            this.textBoxProductsTask2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Atbilde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Preču skaits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Jānosaka, cik ir tādi piegādātāji, kuri piegādā vairāk par norādīto preču skaitu";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewIngredientsTask3);
            this.tabPage1.Controls.Add(this.textBoxIngredientTask3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(534, 338);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "3. Uzdevums";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewIngredientsTask3
            // 
            this.listViewIngredientsTask3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColOne});
            this.listViewIngredientsTask3.GridLines = true;
            listViewGroup2.Header = "Ingredients";
            listViewGroup2.Name = "listViewGroup1";
            this.listViewIngredientsTask3.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.listViewIngredientsTask3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewIngredientsTask3.Location = new System.Drawing.Point(82, 103);
            this.listViewIngredientsTask3.Name = "listViewIngredientsTask3";
            this.listViewIngredientsTask3.Size = new System.Drawing.Size(334, 214);
            this.listViewIngredientsTask3.TabIndex = 11;
            this.listViewIngredientsTask3.UseCompatibleStateImageBehavior = false;
            this.listViewIngredientsTask3.View = System.Windows.Forms.View.List;
            // 
            // ColOne
            // 
            this.ColOne.Text = "Ingredients";
            this.ColOne.Width = 500;
            // 
            // textBoxIngredientTask3
            // 
            this.textBoxIngredientTask3.Location = new System.Drawing.Point(82, 77);
            this.textBoxIngredientTask3.Name = "textBoxIngredientTask3";
            this.textBoxIngredientTask3.Size = new System.Drawing.Size(334, 20);
            this.textBoxIngredientTask3.TabIndex = 10;
            this.textBoxIngredientTask3.Text = "vit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(344, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Produktu sastāvdaļas atrodamas ingredients.xml failā.  Zemāk ir piemērs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sastāvdaļa:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(461, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Jāizveido dinamisks produkta sastāvdaļu meklēšanas saraksts ar unikālām sastāvdaļ" +
    "u vērtībām. ";
            // 
            // Preces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 502);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Preces";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicīnas Preces";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.task1.ResumeLayout(false);
            this.task1.PerformLayout();
            this.task2.ResumeLayout(false);
            this.task2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dbRecCount;
        private System.Windows.Forms.Label dbSizeLabel;
        private System.Windows.Forms.TextBox xmlRecCount;
        private System.Windows.Forms.Label xmlSizeLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage task1;
        private System.Windows.Forms.TabPage task2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTask2;
        private System.Windows.Forms.TextBox textBoxAnswerTask2;
        private System.Windows.Forms.TextBox textBoxProductsTask2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTask1;
        private System.Windows.Forms.TextBox textBoxAnswerTask1;
        private System.Windows.Forms.TextBox textBoxPreceTask1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewIngredientsTask3;
        private System.Windows.Forms.TextBox textBoxIngredientTask3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader ColOne;
    }
}

