namespace BibleLibrarySystem
{
    partial class BookReturn
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRegid = new System.Windows.Forms.Label();
            this.lbLname = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbFname = new System.Windows.Forms.Label();
            this.userRegid = new System.Windows.Forms.TextBox();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookMoney = new System.Windows.Forms.Label();
            this.bookQty = new System.Windows.Forms.Label();
            this.bookOverdue = new System.Windows.Forms.Label();
            this.bookGiving = new System.Windows.Forms.Label();
            this.bookName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookCode = new System.Windows.Forms.TextBox();
            this.dataGridBook = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBook)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(608, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ном буцаалт";
            // 
            // lbRegid
            // 
            this.lbRegid.AutoSize = true;
            this.lbRegid.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegid.ForeColor = System.Drawing.Color.Blue;
            this.lbRegid.Location = new System.Drawing.Point(6, 27);
            this.lbRegid.Name = "lbRegid";
            this.lbRegid.Size = new System.Drawing.Size(120, 26);
            this.lbRegid.TabIndex = 1;
            this.lbRegid.Text = "Р/дугаар :";
            // 
            // lbLname
            // 
            this.lbLname.AutoSize = true;
            this.lbLname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLname.ForeColor = System.Drawing.Color.Blue;
            this.lbLname.Location = new System.Drawing.Point(596, 27);
            this.lbLname.Name = "lbLname";
            this.lbLname.Size = new System.Drawing.Size(107, 26);
            this.lbLname.TabIndex = 2;
            this.lbLname.Text = "Эцэг, эх :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPhone);
            this.groupBox1.Controls.Add(this.lbEmail);
            this.groupBox1.Controls.Add(this.lbGender);
            this.groupBox1.Controls.Add(this.lbFname);
            this.groupBox1.Controls.Add(this.userRegid);
            this.groupBox1.Controls.Add(this.lbRegid);
            this.groupBox1.Controls.Add(this.lbLname);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1358, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Хэрэглэгчийн мэдээлэл";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.Blue;
            this.lbPhone.Location = new System.Drawing.Point(1070, 85);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(78, 26);
            this.lbPhone.TabIndex = 7;
            this.lbPhone.Text = "Утас :";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.Blue;
            this.lbEmail.Location = new System.Drawing.Point(6, 85);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(153, 26);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Цахим хаяг :";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGender.ForeColor = System.Drawing.Color.Blue;
            this.lbGender.Location = new System.Drawing.Point(596, 85);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(79, 26);
            this.lbGender.TabIndex = 6;
            this.lbGender.Text = "Хүйс :";
            // 
            // lbFname
            // 
            this.lbFname.AutoSize = true;
            this.lbFname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFname.ForeColor = System.Drawing.Color.Blue;
            this.lbFname.Location = new System.Drawing.Point(1070, 27);
            this.lbFname.Name = "lbFname";
            this.lbFname.Size = new System.Drawing.Size(68, 26);
            this.lbFname.TabIndex = 4;
            this.lbFname.Text = "Нэр :";
            // 
            // userRegid
            // 
            this.userRegid.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegid.Location = new System.Drawing.Point(190, 24);
            this.userRegid.Name = "userRegid";
            this.userRegid.Size = new System.Drawing.Size(300, 34);
            this.userRegid.TabIndex = 0;
            this.userRegid.TextChanged += new System.EventHandler(this.userRegid_TextChanged);
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.Blue;
            this.lbDateTime.Location = new System.Drawing.Point(12, 9);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(114, 26);
            this.lbDateTime.TabIndex = 8;
            this.lbDateTime.Text = "Хугацаа :";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.bookMoney);
            this.groupBox2.Controls.Add(this.bookQty);
            this.groupBox2.Controls.Add(this.bookOverdue);
            this.groupBox2.Controls.Add(this.bookGiving);
            this.groupBox2.Controls.Add(this.bookName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bookCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1358, 187);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Номны мэдээлэл";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(596, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "Хугацаа хэтэрсэн хоног :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(596, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "Хугацаа хэтэрсэн эсэх :";
            // 
            // bookMoney
            // 
            this.bookMoney.AutoSize = true;
            this.bookMoney.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookMoney.ForeColor = System.Drawing.Color.Blue;
            this.bookMoney.Location = new System.Drawing.Point(1070, 89);
            this.bookMoney.Name = "bookMoney";
            this.bookMoney.Size = new System.Drawing.Size(103, 26);
            this.bookMoney.TabIndex = 14;
            this.bookMoney.Text = "Төлбөр :";
            // 
            // bookQty
            // 
            this.bookQty.AutoSize = true;
            this.bookQty.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookQty.ForeColor = System.Drawing.Color.Blue;
            this.bookQty.Location = new System.Drawing.Point(1070, 31);
            this.bookQty.Name = "bookQty";
            this.bookQty.Size = new System.Drawing.Size(147, 26);
            this.bookQty.TabIndex = 13;
            this.bookQty.Text = "Номны тоо :";
            // 
            // bookOverdue
            // 
            this.bookOverdue.AutoSize = true;
            this.bookOverdue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookOverdue.ForeColor = System.Drawing.Color.Blue;
            this.bookOverdue.Location = new System.Drawing.Point(6, 140);
            this.bookOverdue.Name = "bookOverdue";
            this.bookOverdue.Size = new System.Drawing.Size(212, 26);
            this.bookOverdue.TabIndex = 12;
            this.bookOverdue.Text = "Хугацаа хэтэрсэн :";
            // 
            // bookGiving
            // 
            this.bookGiving.AutoSize = true;
            this.bookGiving.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookGiving.ForeColor = System.Drawing.Color.Blue;
            this.bookGiving.Location = new System.Drawing.Point(6, 90);
            this.bookGiving.Name = "bookGiving";
            this.bookGiving.Size = new System.Drawing.Size(194, 26);
            this.bookGiving.TabIndex = 11;
            this.bookGiving.Text = "Ном өгсөн өдөр :";
            // 
            // bookName
            // 
            this.bookName.AutoSize = true;
            this.bookName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookName.ForeColor = System.Drawing.Color.Blue;
            this.bookName.Location = new System.Drawing.Point(596, 31);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(68, 26);
            this.bookName.TabIndex = 9;
            this.bookName.Text = "Нэр :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Код :";
            // 
            // bookCode
            // 
            this.bookCode.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCode.Location = new System.Drawing.Point(190, 28);
            this.bookCode.Name = "bookCode";
            this.bookCode.Size = new System.Drawing.Size(300, 34);
            this.bookCode.TabIndex = 8;
            this.bookCode.TextChanged += new System.EventHandler(this.bookCode_TextChanged);
            // 
            // dataGridBook
            // 
            this.dataGridBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBook.Location = new System.Drawing.Point(12, 481);
            this.dataGridBook.MultiSelect = false;
            this.dataGridBook.Name = "dataGridBook";
            this.dataGridBook.ReadOnly = true;
            this.dataGridBook.RowTemplate.Height = 24;
            this.dataGridBook.Size = new System.Drawing.Size(1358, 360);
            this.dataGridBook.TabIndex = 10;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Blue;
            this.btnReturn.Location = new System.Drawing.Point(1193, 411);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(177, 44);
            this.btnReturn.TabIndex = 11;
            this.btnReturn.Text = "Буцаалт хийх";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // BookReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 853);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dataGridBook);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbDateTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "BookReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ном буцаалт";
            this.Load += new System.EventHandler(this.BookReturn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRegid;
        private System.Windows.Forms.Label lbLname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbFname;
        private System.Windows.Forms.TextBox userRegid;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bookCode;
        private System.Windows.Forms.Label bookGiving;
        private System.Windows.Forms.Label bookName;
        private System.Windows.Forms.DataGridView dataGridBook;
        private System.Windows.Forms.Label bookMoney;
        private System.Windows.Forms.Label bookQty;
        private System.Windows.Forms.Label bookOverdue;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}