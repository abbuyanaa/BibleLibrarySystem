namespace BibleLibrarySystem
{
    partial class Main
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
            this.dataGridBook = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bookCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnLang = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnCbasic = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnBookMain = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bookYear = new System.Windows.Forms.ComboBox();
            this.bookName = new System.Windows.Forms.TextBox();
            this.bookBible = new System.Windows.Forms.CheckBox();
            this.bookCbasic = new System.Windows.Forms.ComboBox();
            this.bookAuthor = new System.Windows.Forms.ComboBox();
            this.bookCompany = new System.Windows.Forms.ComboBox();
            this.bookCsub = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBook)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBook
            // 
            this.dataGridBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBook.Location = new System.Drawing.Point(9, 423);
            this.dataGridBook.MultiSelect = false;
            this.dataGridBook.Name = "dataGridBook";
            this.dataGridBook.ReadOnly = true;
            this.dataGridBook.RowTemplate.Height = 24;
            this.dataGridBook.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBook.Size = new System.Drawing.Size(1958, 518);
            this.dataGridBook.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Хэвлэсэн огноо :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(471, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Төлөв :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Номны нэр :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(891, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "Үндсэн категори :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(891, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Зохиолч :";
            // 
            // bookCode
            // 
            this.bookCode.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCode.Location = new System.Drawing.Point(217, 312);
            this.bookCode.Name = "bookCode";
            this.bookCode.Size = new System.Drawing.Size(200, 34);
            this.bookCode.TabIndex = 1;
            this.bookCode.TextChanged += new System.EventHandler(this.bookCode_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(737, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(508, 37);
            this.label7.TabIndex = 8;
            this.label7.Text = "Библийн номын сангын систем :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnLang);
            this.panel1.Controls.Add(this.btnRent);
            this.panel1.Controls.Add(this.btnAuthor);
            this.panel1.Controls.Add(this.btnCbasic);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCompany);
            this.panel1.Controls.Add(this.btnBookMain);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1958, 257);
            this.panel1.TabIndex = 9;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Blue;
            this.btnReturn.Image = global::BibleLibrarySystem.Properties.Resources.icon_return_48;
            this.btnReturn.Location = new System.Drawing.Point(1220, 144);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(240, 80);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "Буцаалт";
            this.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLang
            // 
            this.btnLang.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLang.ForeColor = System.Drawing.Color.Blue;
            this.btnLang.Image = global::BibleLibrarySystem.Properties.Resources.icon_language_48;
            this.btnLang.Location = new System.Drawing.Point(1220, 27);
            this.btnLang.Name = "btnLang";
            this.btnLang.Size = new System.Drawing.Size(240, 80);
            this.btnLang.TabIndex = 11;
            this.btnLang.Text = "Хэл";
            this.btnLang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLang.UseVisualStyleBackColor = true;
            this.btnLang.Click += new System.EventHandler(this.btnLang_Click);
            // 
            // btnRent
            // 
            this.btnRent.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.ForeColor = System.Drawing.Color.Blue;
            this.btnRent.Image = global::BibleLibrarySystem.Properties.Resources.icon_rent_48;
            this.btnRent.Location = new System.Drawing.Point(788, 144);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(240, 80);
            this.btnRent.TabIndex = 10;
            this.btnRent.Text = "Түрээс";
            this.btnRent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthor.ForeColor = System.Drawing.Color.Blue;
            this.btnAuthor.Image = global::BibleLibrarySystem.Properties.Resources.icon_author_48;
            this.btnAuthor.Location = new System.Drawing.Point(788, 27);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(240, 80);
            this.btnAuthor.TabIndex = 9;
            this.btnAuthor.Text = "Зохиолч";
            this.btnAuthor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuthor.UseVisualStyleBackColor = true;
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            // 
            // btnCbasic
            // 
            this.btnCbasic.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCbasic.ForeColor = System.Drawing.Color.Blue;
            this.btnCbasic.Image = global::BibleLibrarySystem.Properties.Resources.icon_category_48;
            this.btnCbasic.Location = new System.Drawing.Point(419, 144);
            this.btnCbasic.Name = "btnCbasic";
            this.btnCbasic.Size = new System.Drawing.Size(240, 80);
            this.btnCbasic.TabIndex = 8;
            this.btnCbasic.Text = "Ангилал";
            this.btnCbasic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCbasic.UseVisualStyleBackColor = true;
            this.btnCbasic.Click += new System.EventHandler(this.btnCbasic_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Blue;
            this.btnUsers.Image = global::BibleLibrarySystem.Properties.Resources.icon_users_48;
            this.btnUsers.Location = new System.Drawing.Point(419, 27);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(240, 80);
            this.btnUsers.TabIndex = 7;
            this.btnUsers.Text = "Гишүүд";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BibleLibrarySystem.Properties.Resources.home_image;
            this.pictureBox1.Location = new System.Drawing.Point(1555, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnCompany
            // 
            this.btnCompany.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.ForeColor = System.Drawing.Color.Blue;
            this.btnCompany.Image = global::BibleLibrarySystem.Properties.Resources.icon_organization_48;
            this.btnCompany.Location = new System.Drawing.Point(21, 144);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(240, 80);
            this.btnCompany.TabIndex = 1;
            this.btnCompany.Text = "Байгууллага";
            this.btnCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnBookMain
            // 
            this.btnBookMain.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookMain.ForeColor = System.Drawing.Color.Blue;
            this.btnBookMain.Image = global::BibleLibrarySystem.Properties.Resources.icon_book_48;
            this.btnBookMain.Location = new System.Drawing.Point(21, 27);
            this.btnBookMain.Name = "btnBookMain";
            this.btnBookMain.Size = new System.Drawing.Size(240, 80);
            this.btnBookMain.TabIndex = 0;
            this.btnBookMain.Text = "Ном";
            this.btnBookMain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBookMain.UseVisualStyleBackColor = true;
            this.btnBookMain.Click += new System.EventHandler(this.btnBookMain_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1467, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "Байгууллага :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1467, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 26);
            this.label9.TabIndex = 10;
            this.label9.Text = "Дэд категори :";
            // 
            // bookYear
            // 
            this.bookYear.DropDownHeight = 150;
            this.bookYear.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookYear.FormattingEnabled = true;
            this.bookYear.IntegralHeight = false;
            this.bookYear.ItemHeight = 25;
            this.bookYear.Location = new System.Drawing.Point(217, 368);
            this.bookYear.Name = "bookYear";
            this.bookYear.Size = new System.Drawing.Size(200, 33);
            this.bookYear.TabIndex = 12;
            this.bookYear.SelectedIndexChanged += new System.EventHandler(this.bookYear_SelectedIndexChanged);
            // 
            // bookName
            // 
            this.bookName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookName.Location = new System.Drawing.Point(644, 312);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(200, 34);
            this.bookName.TabIndex = 13;
            this.bookName.TextChanged += new System.EventHandler(this.bookName_TextChanged);
            // 
            // bookBible
            // 
            this.bookBible.AutoSize = true;
            this.bookBible.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookBible.Location = new System.Drawing.Point(699, 369);
            this.bookBible.Name = "bookBible";
            this.bookBible.Size = new System.Drawing.Size(102, 30);
            this.bookBible.TabIndex = 14;
            this.bookBible.Text = "Библи";
            this.bookBible.UseVisualStyleBackColor = true;
            // 
            // bookCbasic
            // 
            this.bookCbasic.DropDownHeight = 150;
            this.bookCbasic.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCbasic.FormattingEnabled = true;
            this.bookCbasic.IntegralHeight = false;
            this.bookCbasic.Location = new System.Drawing.Point(1126, 313);
            this.bookCbasic.Name = "bookCbasic";
            this.bookCbasic.Size = new System.Drawing.Size(320, 33);
            this.bookCbasic.TabIndex = 15;
            this.bookCbasic.SelectedIndexChanged += new System.EventHandler(this.bookCbasic_SelectedIndexChanged);
            // 
            // bookAuthor
            // 
            this.bookAuthor.DropDownHeight = 150;
            this.bookAuthor.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookAuthor.FormattingEnabled = true;
            this.bookAuthor.IntegralHeight = false;
            this.bookAuthor.Location = new System.Drawing.Point(1126, 368);
            this.bookAuthor.Name = "bookAuthor";
            this.bookAuthor.Size = new System.Drawing.Size(320, 33);
            this.bookAuthor.TabIndex = 16;
            this.bookAuthor.SelectedIndexChanged += new System.EventHandler(this.bookAuthor_SelectedIndexChanged);
            // 
            // bookCompany
            // 
            this.bookCompany.DropDownHeight = 150;
            this.bookCompany.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCompany.FormattingEnabled = true;
            this.bookCompany.IntegralHeight = false;
            this.bookCompany.Location = new System.Drawing.Point(1650, 368);
            this.bookCompany.Name = "bookCompany";
            this.bookCompany.Size = new System.Drawing.Size(320, 33);
            this.bookCompany.TabIndex = 18;
            this.bookCompany.SelectedIndexChanged += new System.EventHandler(this.bookCompany_SelectedIndexChanged);
            // 
            // bookCsub
            // 
            this.bookCsub.DropDownHeight = 150;
            this.bookCsub.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCsub.FormattingEnabled = true;
            this.bookCsub.IntegralHeight = false;
            this.bookCsub.Location = new System.Drawing.Point(1650, 313);
            this.bookCsub.Name = "bookCsub";
            this.bookCsub.Size = new System.Drawing.Size(320, 33);
            this.bookCsub.TabIndex = 17;
            this.bookCsub.SelectedIndexChanged += new System.EventHandler(this.bookCsub_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1982, 953);
            this.Controls.Add(this.bookCompany);
            this.Controls.Add(this.bookCsub);
            this.Controls.Add(this.bookAuthor);
            this.Controls.Add(this.bookCbasic);
            this.Controls.Add(this.bookBible);
            this.Controls.Add(this.bookName);
            this.Controls.Add(this.bookYear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bookCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridBook);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нүүр хуудас";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBook)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bookCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnBookMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnLang;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnCbasic;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox bookYear;
        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.CheckBox bookBible;
        private System.Windows.Forms.ComboBox bookCbasic;
        private System.Windows.Forms.ComboBox bookAuthor;
        private System.Windows.Forms.ComboBox bookCompany;
        private System.Windows.Forms.ComboBox bookCsub;
    }
}