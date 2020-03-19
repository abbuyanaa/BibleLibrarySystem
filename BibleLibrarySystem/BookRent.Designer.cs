namespace BibleLibrarySystem
{
    partial class BookRent
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
            this.lbFname = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.userRegid = new System.Windows.Forms.TextBox();
            this.dataGridRent = new System.Windows.Forms.DataGridView();
            this.lbBookCount = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.bookCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.lbReturnTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(630, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ном түрээс";
            // 
            // lbRegid
            // 
            this.lbRegid.AutoSize = true;
            this.lbRegid.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegid.ForeColor = System.Drawing.Color.Blue;
            this.lbRegid.Location = new System.Drawing.Point(12, 66);
            this.lbRegid.Name = "lbRegid";
            this.lbRegid.Size = new System.Drawing.Size(120, 26);
            this.lbRegid.TabIndex = 3;
            this.lbRegid.Text = "Р/дугаар :";
            // 
            // lbLname
            // 
            this.lbLname.AutoSize = true;
            this.lbLname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLname.ForeColor = System.Drawing.Color.Blue;
            this.lbLname.Location = new System.Drawing.Point(450, 66);
            this.lbLname.Name = "lbLname";
            this.lbLname.Size = new System.Drawing.Size(81, 26);
            this.lbLname.TabIndex = 4;
            this.lbLname.Text = "Овог :";
            // 
            // lbFname
            // 
            this.lbFname.AutoSize = true;
            this.lbFname.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFname.ForeColor = System.Drawing.Color.Blue;
            this.lbFname.Location = new System.Drawing.Point(780, 66);
            this.lbFname.Name = "lbFname";
            this.lbFname.Size = new System.Drawing.Size(68, 26);
            this.lbFname.TabIndex = 5;
            this.lbFname.Text = "Нэр :";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.Blue;
            this.lbPhone.Location = new System.Drawing.Point(1121, 66);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(78, 26);
            this.lbPhone.TabIndex = 6;
            this.lbPhone.Text = "Утас :";
            // 
            // userRegid
            // 
            this.userRegid.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegid.Location = new System.Drawing.Point(177, 63);
            this.userRegid.Name = "userRegid";
            this.userRegid.Size = new System.Drawing.Size(250, 34);
            this.userRegid.TabIndex = 0;
            this.userRegid.TextChanged += new System.EventHandler(this.userRegid_TextChanged);
            // 
            // dataGridRent
            // 
            this.dataGridRent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRent.Location = new System.Drawing.Point(12, 192);
            this.dataGridRent.Name = "dataGridRent";
            this.dataGridRent.RowTemplate.Height = 24;
            this.dataGridRent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRent.Size = new System.Drawing.Size(1458, 499);
            this.dataGridRent.TabIndex = 7;
            // 
            // lbBookCount
            // 
            this.lbBookCount.AutoSize = true;
            this.lbBookCount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookCount.ForeColor = System.Drawing.Color.Blue;
            this.lbBookCount.Location = new System.Drawing.Point(12, 159);
            this.lbBookCount.Name = "lbBookCount";
            this.lbBookCount.Size = new System.Drawing.Size(250, 26);
            this.lbBookCount.TabIndex = 2;
            this.lbBookCount.Text = "Сонгосон номны тоо :";
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.Blue;
            this.lbDateTime.Location = new System.Drawing.Point(12, 9);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(126, 26);
            this.lbDateTime.TabIndex = 2;
            this.lbDateTime.Text = "DateTime :";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // bookCode
            // 
            this.bookCode.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookCode.Location = new System.Drawing.Point(177, 112);
            this.bookCode.Name = "bookCode";
            this.bookCode.Size = new System.Drawing.Size(250, 34);
            this.bookCode.TabIndex = 1;
            this.bookCode.TextChanged += new System.EventHandler(this.bookCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Номны код :";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.Blue;
            this.lbType.Location = new System.Drawing.Point(450, 115);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(91, 26);
            this.lbType.TabIndex = 10;
            this.lbType.Text = "Төлөв :";
            // 
            // btnRent
            // 
            this.btnRent.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.ForeColor = System.Drawing.Color.Blue;
            this.btnRent.Location = new System.Drawing.Point(1313, 147);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(150, 39);
            this.btnRent.TabIndex = 11;
            this.btnRent.Text = "Түрээслэх";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // lbReturnTime
            // 
            this.lbReturnTime.AutoSize = true;
            this.lbReturnTime.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReturnTime.ForeColor = System.Drawing.Color.Blue;
            this.lbReturnTime.Location = new System.Drawing.Point(450, 159);
            this.lbReturnTime.Name = "lbReturnTime";
            this.lbReturnTime.Size = new System.Drawing.Size(193, 26);
            this.lbReturnTime.TabIndex = 12;
            this.lbReturnTime.Text = "Буцаах хугацаа :";
            // 
            // BookRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 703);
            this.Controls.Add(this.lbReturnTime);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.bookCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDateTime);
            this.Controls.Add(this.lbBookCount);
            this.Controls.Add(this.dataGridRent);
            this.Controls.Add(this.userRegid);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbFname);
            this.Controls.Add(this.lbLname);
            this.Controls.Add(this.lbRegid);
            this.Controls.Add(this.label1);
            this.Name = "BookRent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ном түрээслэх";
            this.Load += new System.EventHandler(this.BookRent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRegid;
        private System.Windows.Forms.Label lbLname;
        private System.Windows.Forms.Label lbFname;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox userRegid;
        private System.Windows.Forms.DataGridView dataGridRent;
        private System.Windows.Forms.Label lbBookCount;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox bookCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Label lbReturnTime;
    }
}