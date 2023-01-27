
namespace SalesManagement_SysDev
{
    partial class MakerMana
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
            this.labelManaMakerTitle = new System.Windows.Forms.Label();
            this.buttonManaMakerReturn = new System.Windows.Forms.Button();
            this.buttonAddMaker = new System.Windows.Forms.Button();
            this.buttonUpdateMaker = new System.Windows.Forms.Button();
            this.buttonListMaker = new System.Windows.Forms.Button();
            this.buttonSearchMaker = new System.Windows.Forms.Button();
            this.labelManaMakerID = new System.Windows.Forms.Label();
            this.textBoxManaMakerHidden = new System.Windows.Forms.TextBox();
            this.labelManaMakerName = new System.Windows.Forms.Label();
            this.textBoxManaMakerAdress = new System.Windows.Forms.TextBox();
            this.labelManaMakerAdress = new System.Windows.Forms.Label();
            this.textBoxManaMakerPhone = new System.Windows.Forms.TextBox();
            this.labelManaMakerPhone = new System.Windows.Forms.Label();
            this.textBoxManaMakerFax = new System.Windows.Forms.TextBox();
            this.labelManaMakerFax = new System.Windows.Forms.Label();
            this.textBoxManaMakerPostal = new System.Windows.Forms.TextBox();
            this.labelManaMakerPostal = new System.Windows.Forms.Label();
            this.labelManaMakerHidden = new System.Windows.Forms.Label();
            this.dataGridViewManaMaker = new System.Windows.Forms.DataGridView();
            this.labelMaSearchTitle = new System.Windows.Forms.Label();
            this.textBoxManaMakerName = new System.Windows.Forms.TextBox();
            this.comboBoxManaMakerID = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonManaMakerDeleteList = new SalesManagement_SysDev.maruibutton();
            this.buttonManaMakerDelete = new SalesManagement_SysDev.maruibutton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManaMaker)).BeginInit();
            this.SuspendLayout();
            // 
            // labelManaMakerTitle
            // 
            this.labelManaMakerTitle.Font = new System.Drawing.Font("Meiryo UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerTitle.Location = new System.Drawing.Point(445, 9);
            this.labelManaMakerTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerTitle.Name = "labelManaMakerTitle";
            this.labelManaMakerTitle.Size = new System.Drawing.Size(324, 87);
            this.labelManaMakerTitle.TabIndex = 76;
            this.labelManaMakerTitle.Text = "メーカ管理";
            // 
            // buttonManaMakerReturn
            // 
            this.buttonManaMakerReturn.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonManaMakerReturn.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonManaMakerReturn.Location = new System.Drawing.Point(1029, 24);
            this.buttonManaMakerReturn.Margin = new System.Windows.Forms.Padding(1);
            this.buttonManaMakerReturn.Name = "buttonManaMakerReturn";
            this.buttonManaMakerReturn.Size = new System.Drawing.Size(168, 72);
            this.buttonManaMakerReturn.TabIndex = 207;
            this.buttonManaMakerReturn.TabStop = false;
            this.buttonManaMakerReturn.Text = "戻る";
            this.buttonManaMakerReturn.UseVisualStyleBackColor = false;
            this.buttonManaMakerReturn.Click += new System.EventHandler(this.buttonManaMakerReturn_Click);
            // 
            // buttonAddMaker
            // 
            this.buttonAddMaker.BackColor = System.Drawing.Color.White;
            this.buttonAddMaker.Font = new System.Drawing.Font("Meiryo UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonAddMaker.Location = new System.Drawing.Point(12, 117);
            this.buttonAddMaker.Margin = new System.Windows.Forms.Padding(1);
            this.buttonAddMaker.Name = "buttonAddMaker";
            this.buttonAddMaker.Size = new System.Drawing.Size(200, 74);
            this.buttonAddMaker.TabIndex = 208;
            this.buttonAddMaker.TabStop = false;
            this.buttonAddMaker.Text = "登録";
            this.buttonAddMaker.UseVisualStyleBackColor = false;
            this.buttonAddMaker.Click += new System.EventHandler(this.buttonAddMaker_Click);
            // 
            // buttonUpdateMaker
            // 
            this.buttonUpdateMaker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.buttonUpdateMaker.Enabled = false;
            this.buttonUpdateMaker.Font = new System.Drawing.Font("Meiryo UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdateMaker.Location = new System.Drawing.Point(229, 117);
            this.buttonUpdateMaker.Margin = new System.Windows.Forms.Padding(1);
            this.buttonUpdateMaker.Name = "buttonUpdateMaker";
            this.buttonUpdateMaker.Size = new System.Drawing.Size(200, 74);
            this.buttonUpdateMaker.TabIndex = 209;
            this.buttonUpdateMaker.TabStop = false;
            this.buttonUpdateMaker.Text = "更新";
            this.buttonUpdateMaker.UseVisualStyleBackColor = false;
            this.buttonUpdateMaker.Click += new System.EventHandler(this.buttonUpdateMaker_Click);
            // 
            // buttonListMaker
            // 
            this.buttonListMaker.BackColor = System.Drawing.Color.White;
            this.buttonListMaker.Font = new System.Drawing.Font("Meiryo UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonListMaker.Location = new System.Drawing.Point(441, 117);
            this.buttonListMaker.Margin = new System.Windows.Forms.Padding(1);
            this.buttonListMaker.Name = "buttonListMaker";
            this.buttonListMaker.Size = new System.Drawing.Size(200, 74);
            this.buttonListMaker.TabIndex = 210;
            this.buttonListMaker.TabStop = false;
            this.buttonListMaker.Text = "一覧表示";
            this.buttonListMaker.UseVisualStyleBackColor = false;
            this.buttonListMaker.Click += new System.EventHandler(this.buttonListMaker_Click);
            // 
            // buttonSearchMaker
            // 
            this.buttonSearchMaker.BackColor = System.Drawing.Color.White;
            this.buttonSearchMaker.Font = new System.Drawing.Font("Meiryo UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearchMaker.Location = new System.Drawing.Point(658, 117);
            this.buttonSearchMaker.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSearchMaker.Name = "buttonSearchMaker";
            this.buttonSearchMaker.Size = new System.Drawing.Size(200, 74);
            this.buttonSearchMaker.TabIndex = 211;
            this.buttonSearchMaker.TabStop = false;
            this.buttonSearchMaker.Text = "検索";
            this.buttonSearchMaker.UseVisualStyleBackColor = false;
            this.buttonSearchMaker.Click += new System.EventHandler(this.buttonSearchMaker_Click);
            // 
            // labelManaMakerID
            // 
            this.labelManaMakerID.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerID.Location = new System.Drawing.Point(7, 227);
            this.labelManaMakerID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerID.Name = "labelManaMakerID";
            this.labelManaMakerID.Size = new System.Drawing.Size(87, 36);
            this.labelManaMakerID.TabIndex = 212;
            this.labelManaMakerID.Text = "メーカID";
            // 
            // textBoxManaMakerHidden
            // 
            this.textBoxManaMakerHidden.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerHidden.Location = new System.Drawing.Point(745, 227);
            this.textBoxManaMakerHidden.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerHidden.Multiline = true;
            this.textBoxManaMakerHidden.Name = "textBoxManaMakerHidden";
            this.textBoxManaMakerHidden.Size = new System.Drawing.Size(452, 139);
            this.textBoxManaMakerHidden.TabIndex = 7;
            // 
            // labelManaMakerName
            // 
            this.labelManaMakerName.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerName.Location = new System.Drawing.Point(309, 227);
            this.labelManaMakerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerName.Name = "labelManaMakerName";
            this.labelManaMakerName.Size = new System.Drawing.Size(87, 36);
            this.labelManaMakerName.TabIndex = 214;
            this.labelManaMakerName.Text = "メーカ名";
            // 
            // textBoxManaMakerAdress
            // 
            this.textBoxManaMakerAdress.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerAdress.Location = new System.Drawing.Point(105, 277);
            this.textBoxManaMakerAdress.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerAdress.Multiline = true;
            this.textBoxManaMakerAdress.Name = "textBoxManaMakerAdress";
            this.textBoxManaMakerAdress.Size = new System.Drawing.Size(190, 37);
            this.textBoxManaMakerAdress.TabIndex = 3;
            // 
            // labelManaMakerAdress
            // 
            this.labelManaMakerAdress.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerAdress.Location = new System.Drawing.Point(7, 277);
            this.labelManaMakerAdress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerAdress.Name = "labelManaMakerAdress";
            this.labelManaMakerAdress.Size = new System.Drawing.Size(79, 36);
            this.labelManaMakerAdress.TabIndex = 217;
            this.labelManaMakerAdress.Text = "住所";
            // 
            // textBoxManaMakerPhone
            // 
            this.textBoxManaMakerPhone.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerPhone.Location = new System.Drawing.Point(400, 277);
            this.textBoxManaMakerPhone.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerPhone.Multiline = true;
            this.textBoxManaMakerPhone.Name = "textBoxManaMakerPhone";
            this.textBoxManaMakerPhone.Size = new System.Drawing.Size(190, 37);
            this.textBoxManaMakerPhone.TabIndex = 4;
            // 
            // labelManaMakerPhone
            // 
            this.labelManaMakerPhone.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerPhone.Location = new System.Drawing.Point(302, 277);
            this.labelManaMakerPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerPhone.Name = "labelManaMakerPhone";
            this.labelManaMakerPhone.Size = new System.Drawing.Size(103, 36);
            this.labelManaMakerPhone.TabIndex = 219;
            this.labelManaMakerPhone.Text = "電話番号";
            // 
            // textBoxManaMakerFax
            // 
            this.textBoxManaMakerFax.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerFax.Location = new System.Drawing.Point(400, 329);
            this.textBoxManaMakerFax.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerFax.Multiline = true;
            this.textBoxManaMakerFax.Name = "textBoxManaMakerFax";
            this.textBoxManaMakerFax.Size = new System.Drawing.Size(190, 37);
            this.textBoxManaMakerFax.TabIndex = 6;
            // 
            // labelManaMakerFax
            // 
            this.labelManaMakerFax.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerFax.Location = new System.Drawing.Point(317, 330);
            this.labelManaMakerFax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerFax.Name = "labelManaMakerFax";
            this.labelManaMakerFax.Size = new System.Drawing.Size(79, 36);
            this.labelManaMakerFax.TabIndex = 221;
            this.labelManaMakerFax.Text = "FAX";
            // 
            // textBoxManaMakerPostal
            // 
            this.textBoxManaMakerPostal.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerPostal.Location = new System.Drawing.Point(105, 329);
            this.textBoxManaMakerPostal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerPostal.Multiline = true;
            this.textBoxManaMakerPostal.Name = "textBoxManaMakerPostal";
            this.textBoxManaMakerPostal.Size = new System.Drawing.Size(190, 37);
            this.textBoxManaMakerPostal.TabIndex = 5;
            // 
            // labelManaMakerPostal
            // 
            this.labelManaMakerPostal.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerPostal.Location = new System.Drawing.Point(7, 330);
            this.labelManaMakerPostal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerPostal.Name = "labelManaMakerPostal";
            this.labelManaMakerPostal.Size = new System.Drawing.Size(103, 36);
            this.labelManaMakerPostal.TabIndex = 223;
            this.labelManaMakerPostal.Text = "郵便番号";
            // 
            // labelManaMakerHidden
            // 
            this.labelManaMakerHidden.Font = new System.Drawing.Font("Meiryo UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelManaMakerHidden.Location = new System.Drawing.Point(614, 277);
            this.labelManaMakerHidden.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManaMakerHidden.Name = "labelManaMakerHidden";
            this.labelManaMakerHidden.Size = new System.Drawing.Size(127, 36);
            this.labelManaMakerHidden.TabIndex = 225;
            this.labelManaMakerHidden.Text = "非表示理由";
            // 
            // dataGridViewManaMaker
            // 
            this.dataGridViewManaMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManaMaker.Location = new System.Drawing.Point(28, 390);
            this.dataGridViewManaMaker.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewManaMaker.Name = "dataGridViewManaMaker";
            this.dataGridViewManaMaker.RowHeadersWidth = 62;
            this.dataGridViewManaMaker.RowTemplate.Height = 27;
            this.dataGridViewManaMaker.Size = new System.Drawing.Size(1205, 324);
            this.dataGridViewManaMaker.TabIndex = 226;
            this.dataGridViewManaMaker.TabStop = false;
            this.dataGridViewManaMaker.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManaMaker_CellClick);
            this.dataGridViewManaMaker.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManaMaker_CellContentClick);
            // 
            // labelMaSearchTitle
            // 
            this.labelMaSearchTitle.Location = new System.Drawing.Point(466, 89);
            this.labelMaSearchTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaSearchTitle.Name = "labelMaSearchTitle";
            this.labelMaSearchTitle.Size = new System.Drawing.Size(233, 27);
            this.labelMaSearchTitle.TabIndex = 250;
            // 
            // textBoxManaMakerName
            // 
            this.textBoxManaMakerName.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxManaMakerName.Location = new System.Drawing.Point(400, 227);
            this.textBoxManaMakerName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxManaMakerName.Multiline = true;
            this.textBoxManaMakerName.Name = "textBoxManaMakerName";
            this.textBoxManaMakerName.Size = new System.Drawing.Size(190, 37);
            this.textBoxManaMakerName.TabIndex = 2;
            // 
            // comboBoxManaMakerID
            // 
            this.comboBoxManaMakerID.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxManaMakerID.FormattingEnabled = true;
            this.comboBoxManaMakerID.Location = new System.Drawing.Point(105, 227);
            this.comboBoxManaMakerID.Name = "comboBoxManaMakerID";
            this.comboBoxManaMakerID.Size = new System.Drawing.Size(190, 34);
            this.comboBoxManaMakerID.TabIndex = 1;
            this.comboBoxManaMakerID.SelectedIndexChanged += new System.EventHandler(this.comboBoxManaMakerID_SelectedIndexChanged);
            this.comboBoxManaMakerID.TextChanged += new System.EventHandler(this.comboBoxManaMakerID_TextChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Aqua;
            this.buttonClear.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(891, 45);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(114, 47);
            this.buttonClear.TabIndex = 253;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "クリア";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonManaMakerDeleteList
            // 
            this.buttonManaMakerDeleteList.BackColor = System.Drawing.Color.Red;
            this.buttonManaMakerDeleteList.FlatAppearance.BorderSize = 0;
            this.buttonManaMakerDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManaMakerDeleteList.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonManaMakerDeleteList.Location = new System.Drawing.Point(1070, 104);
            this.buttonManaMakerDeleteList.Name = "buttonManaMakerDeleteList";
            this.buttonManaMakerDeleteList.Size = new System.Drawing.Size(172, 111);
            this.buttonManaMakerDeleteList.TabIndex = 249;
            this.buttonManaMakerDeleteList.TabStop = false;
            this.buttonManaMakerDeleteList.Text = "非表示リスト";
            this.buttonManaMakerDeleteList.UseVisualStyleBackColor = false;
            this.buttonManaMakerDeleteList.Click += new System.EventHandler(this.buttonManaMakerDeleteList_Click);
            // 
            // buttonManaMakerDelete
            // 
            this.buttonManaMakerDelete.BackColor = System.Drawing.Color.Red;
            this.buttonManaMakerDelete.FlatAppearance.BorderSize = 0;
            this.buttonManaMakerDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManaMakerDelete.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonManaMakerDelete.Location = new System.Drawing.Point(891, 104);
            this.buttonManaMakerDelete.Name = "buttonManaMakerDelete";
            this.buttonManaMakerDelete.Size = new System.Drawing.Size(172, 111);
            this.buttonManaMakerDelete.TabIndex = 248;
            this.buttonManaMakerDelete.TabStop = false;
            this.buttonManaMakerDelete.Text = "非表示";
            this.buttonManaMakerDelete.UseVisualStyleBackColor = false;
            this.buttonManaMakerDelete.Click += new System.EventHandler(this.buttonManaMakerDelete_Click);
            // 
            // MakerMana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1284, 731);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.comboBoxManaMakerID);
            this.Controls.Add(this.textBoxManaMakerName);
            this.Controls.Add(this.labelMaSearchTitle);
            this.Controls.Add(this.buttonManaMakerDeleteList);
            this.Controls.Add(this.buttonManaMakerDelete);
            this.Controls.Add(this.dataGridViewManaMaker);
            this.Controls.Add(this.labelManaMakerHidden);
            this.Controls.Add(this.textBoxManaMakerPostal);
            this.Controls.Add(this.labelManaMakerPostal);
            this.Controls.Add(this.textBoxManaMakerFax);
            this.Controls.Add(this.labelManaMakerFax);
            this.Controls.Add(this.textBoxManaMakerPhone);
            this.Controls.Add(this.labelManaMakerPhone);
            this.Controls.Add(this.textBoxManaMakerAdress);
            this.Controls.Add(this.labelManaMakerAdress);
            this.Controls.Add(this.textBoxManaMakerHidden);
            this.Controls.Add(this.labelManaMakerName);
            this.Controls.Add(this.labelManaMakerID);
            this.Controls.Add(this.buttonSearchMaker);
            this.Controls.Add(this.buttonListMaker);
            this.Controls.Add(this.buttonUpdateMaker);
            this.Controls.Add(this.buttonAddMaker);
            this.Controls.Add(this.buttonManaMakerReturn);
            this.Controls.Add(this.labelManaMakerTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MakerMana";
            this.Text = "メーカ管理";
            this.Load += new System.EventHandler(this.MakerMana_Load);
            this.VisibleChanged += new System.EventHandler(this.MakerMana_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManaMaker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelManaMakerTitle;
        private System.Windows.Forms.Button buttonManaMakerReturn;
        private System.Windows.Forms.Button buttonAddMaker;
        private System.Windows.Forms.Button buttonUpdateMaker;
        private System.Windows.Forms.Button buttonListMaker;
        private System.Windows.Forms.Button buttonSearchMaker;
        private System.Windows.Forms.Label labelManaMakerID;
        private System.Windows.Forms.TextBox textBoxManaMakerHidden;
        private System.Windows.Forms.Label labelManaMakerName;
        private System.Windows.Forms.TextBox textBoxManaMakerAdress;
        private System.Windows.Forms.Label labelManaMakerAdress;
        private System.Windows.Forms.TextBox textBoxManaMakerPhone;
        private System.Windows.Forms.Label labelManaMakerPhone;
        private System.Windows.Forms.TextBox textBoxManaMakerFax;
        private System.Windows.Forms.Label labelManaMakerFax;
        private System.Windows.Forms.TextBox textBoxManaMakerPostal;
        private System.Windows.Forms.Label labelManaMakerPostal;
        private System.Windows.Forms.Label labelManaMakerHidden;
        private System.Windows.Forms.DataGridView dataGridViewManaMaker;
        private maruibutton buttonManaMakerDeleteList;
        private maruibutton buttonManaMakerDelete;
        private System.Windows.Forms.Label labelMaSearchTitle;
        private System.Windows.Forms.TextBox textBoxManaMakerName;
        private System.Windows.Forms.ComboBox comboBoxManaMakerID;
        private System.Windows.Forms.Button buttonClear;
    }
}