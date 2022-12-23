
namespace SalesManagement_SysDev
{
    partial class FormPositionMana
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
            this.buttonPositionManaSrarch = new System.Windows.Forms.Button();
            this.buttonPositionManaList = new System.Windows.Forms.Button();
            this.buttonPositionManaAdd = new System.Windows.Forms.Button();
            this.buttonPositionManaUpdate = new System.Windows.Forms.Button();
            this.labelPositionManaTitle = new System.Windows.Forms.Label();
            this.labelPositionManaPositionName = new System.Windows.Forms.Label();
            this.comboBoxPositionManaPositionID = new System.Windows.Forms.ComboBox();
            this.textBoxPositionManaPositionName = new System.Windows.Forms.TextBox();
            this.labelPositionManaPositionID = new System.Windows.Forms.Label();
            this.labelPositionManaHidden = new System.Windows.Forms.Label();
            this.textBoxPositionManaHidden = new System.Windows.Forms.TextBox();
            this.buttonPositionManaReturn = new System.Windows.Forms.Button();
            this.dataGridViewPositionMana = new System.Windows.Forms.DataGridView();
            this.labelPoSearchTitle = new System.Windows.Forms.Label();
            this.buttonPositionManaDeleteList = new SalesManagement_SysDev.maruibutton();
            this.buttonPositionManaDelete = new SalesManagement_SysDev.maruibutton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionMana)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPositionManaSrarch
            // 
            this.buttonPositionManaSrarch.BackColor = System.Drawing.Color.LightCyan;
            this.buttonPositionManaSrarch.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaSrarch.Location = new System.Drawing.Point(423, 126);
            this.buttonPositionManaSrarch.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPositionManaSrarch.Name = "buttonPositionManaSrarch";
            this.buttonPositionManaSrarch.Size = new System.Drawing.Size(164, 74);
            this.buttonPositionManaSrarch.TabIndex = 224;
            this.buttonPositionManaSrarch.Text = "検索";
            this.buttonPositionManaSrarch.UseVisualStyleBackColor = false;
            this.buttonPositionManaSrarch.Click += new System.EventHandler(this.buttonPositionManaSrarch_Click);
            // 
            // buttonPositionManaList
            // 
            this.buttonPositionManaList.BackColor = System.Drawing.Color.LightCyan;
            this.buttonPositionManaList.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaList.Location = new System.Drawing.Point(623, 126);
            this.buttonPositionManaList.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPositionManaList.Name = "buttonPositionManaList";
            this.buttonPositionManaList.Size = new System.Drawing.Size(164, 74);
            this.buttonPositionManaList.TabIndex = 223;
            this.buttonPositionManaList.Text = "一覧表示";
            this.buttonPositionManaList.UseVisualStyleBackColor = false;
            this.buttonPositionManaList.Click += new System.EventHandler(this.buttonPositionManaList_Click);
            // 
            // buttonPositionManaAdd
            // 
            this.buttonPositionManaAdd.BackColor = System.Drawing.Color.LightCyan;
            this.buttonPositionManaAdd.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaAdd.Location = new System.Drawing.Point(34, 126);
            this.buttonPositionManaAdd.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPositionManaAdd.Name = "buttonPositionManaAdd";
            this.buttonPositionManaAdd.Size = new System.Drawing.Size(164, 74);
            this.buttonPositionManaAdd.TabIndex = 222;
            this.buttonPositionManaAdd.Text = "登録";
            this.buttonPositionManaAdd.UseVisualStyleBackColor = false;
            this.buttonPositionManaAdd.Click += new System.EventHandler(this.buttonPositionManaAdd_Click);
            // 
            // buttonPositionManaUpdate
            // 
            this.buttonPositionManaUpdate.BackColor = System.Drawing.Color.LightCyan;
            this.buttonPositionManaUpdate.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaUpdate.Location = new System.Drawing.Point(226, 126);
            this.buttonPositionManaUpdate.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPositionManaUpdate.Name = "buttonPositionManaUpdate";
            this.buttonPositionManaUpdate.Size = new System.Drawing.Size(164, 74);
            this.buttonPositionManaUpdate.TabIndex = 221;
            this.buttonPositionManaUpdate.Text = "更新";
            this.buttonPositionManaUpdate.UseVisualStyleBackColor = false;
            this.buttonPositionManaUpdate.Click += new System.EventHandler(this.buttonPositionManaUpdate_Click);
            // 
            // labelPositionManaTitle
            // 
            this.labelPositionManaTitle.Font = new System.Drawing.Font("Meiryo UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPositionManaTitle.Location = new System.Drawing.Point(461, 19);
            this.labelPositionManaTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPositionManaTitle.Name = "labelPositionManaTitle";
            this.labelPositionManaTitle.Size = new System.Drawing.Size(296, 89);
            this.labelPositionManaTitle.TabIndex = 220;
            this.labelPositionManaTitle.Text = "役職管理";
            // 
            // labelPositionManaPositionName
            // 
            this.labelPositionManaPositionName.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPositionManaPositionName.Location = new System.Drawing.Point(422, 220);
            this.labelPositionManaPositionName.Name = "labelPositionManaPositionName";
            this.labelPositionManaPositionName.Size = new System.Drawing.Size(115, 33);
            this.labelPositionManaPositionName.TabIndex = 238;
            this.labelPositionManaPositionName.Text = "役職名";
            // 
            // comboBoxPositionManaPositionID
            // 
            this.comboBoxPositionManaPositionID.Font = new System.Drawing.Font("Meiryo UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxPositionManaPositionID.FormattingEnabled = true;
            this.comboBoxPositionManaPositionID.ItemHeight = 24;
            this.comboBoxPositionManaPositionID.Location = new System.Drawing.Point(173, 220);
            this.comboBoxPositionManaPositionID.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPositionManaPositionID.Name = "comboBoxPositionManaPositionID";
            this.comboBoxPositionManaPositionID.Size = new System.Drawing.Size(213, 32);
            this.comboBoxPositionManaPositionID.TabIndex = 237;
            // 
            // textBoxPositionManaPositionName
            // 
            this.textBoxPositionManaPositionName.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPositionManaPositionName.Location = new System.Drawing.Point(542, 218);
            this.textBoxPositionManaPositionName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPositionManaPositionName.Multiline = true;
            this.textBoxPositionManaPositionName.Name = "textBoxPositionManaPositionName";
            this.textBoxPositionManaPositionName.Size = new System.Drawing.Size(245, 37);
            this.textBoxPositionManaPositionName.TabIndex = 236;
            // 
            // labelPositionManaPositionID
            // 
            this.labelPositionManaPositionID.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPositionManaPositionID.Location = new System.Drawing.Point(30, 216);
            this.labelPositionManaPositionID.Name = "labelPositionManaPositionID";
            this.labelPositionManaPositionID.Size = new System.Drawing.Size(116, 33);
            this.labelPositionManaPositionID.TabIndex = 235;
            this.labelPositionManaPositionID.Text = "役職ID";
            // 
            // labelPositionManaHidden
            // 
            this.labelPositionManaHidden.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPositionManaHidden.Location = new System.Drawing.Point(29, 267);
            this.labelPositionManaHidden.Name = "labelPositionManaHidden";
            this.labelPositionManaHidden.Size = new System.Drawing.Size(138, 33);
            this.labelPositionManaHidden.TabIndex = 246;
            this.labelPositionManaHidden.Text = "非表示理由";
            // 
            // textBoxPositionManaHidden
            // 
            this.textBoxPositionManaHidden.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPositionManaHidden.Location = new System.Drawing.Point(173, 267);
            this.textBoxPositionManaHidden.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPositionManaHidden.Multiline = true;
            this.textBoxPositionManaHidden.Name = "textBoxPositionManaHidden";
            this.textBoxPositionManaHidden.Size = new System.Drawing.Size(835, 101);
            this.textBoxPositionManaHidden.TabIndex = 245;
            // 
            // buttonPositionManaReturn
            // 
            this.buttonPositionManaReturn.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonPositionManaReturn.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaReturn.Location = new System.Drawing.Point(1039, 26);
            this.buttonPositionManaReturn.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPositionManaReturn.Name = "buttonPositionManaReturn";
            this.buttonPositionManaReturn.Size = new System.Drawing.Size(168, 72);
            this.buttonPositionManaReturn.TabIndex = 247;
            this.buttonPositionManaReturn.Text = "戻る";
            this.buttonPositionManaReturn.UseVisualStyleBackColor = false;
            this.buttonPositionManaReturn.Click += new System.EventHandler(this.buttonPositionManaReturn_Click);
            // 
            // dataGridViewPositionMana
            // 
            this.dataGridViewPositionMana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPositionMana.Location = new System.Drawing.Point(35, 395);
            this.dataGridViewPositionMana.Name = "dataGridViewPositionMana";
            this.dataGridViewPositionMana.RowHeadersWidth = 62;
            this.dataGridViewPositionMana.RowTemplate.Height = 21;
            this.dataGridViewPositionMana.Size = new System.Drawing.Size(1190, 331);
            this.dataGridViewPositionMana.TabIndex = 248;
            // 
            // labelPoSearchTitle
            // 
            this.labelPoSearchTitle.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPoSearchTitle.Location = new System.Drawing.Point(422, 99);
            this.labelPoSearchTitle.Name = "labelPoSearchTitle";
            this.labelPoSearchTitle.Size = new System.Drawing.Size(211, 23);
            this.labelPoSearchTitle.TabIndex = 251;
            // 
            // buttonPositionManaDeleteList
            // 
            this.buttonPositionManaDeleteList.BackColor = System.Drawing.Color.Red;
            this.buttonPositionManaDeleteList.FlatAppearance.BorderSize = 0;
            this.buttonPositionManaDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPositionManaDeleteList.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaDeleteList.Location = new System.Drawing.Point(1029, 142);
            this.buttonPositionManaDeleteList.Name = "buttonPositionManaDeleteList";
            this.buttonPositionManaDeleteList.Size = new System.Drawing.Size(140, 107);
            this.buttonPositionManaDeleteList.TabIndex = 250;
            this.buttonPositionManaDeleteList.Text = "非表示リスト";
            this.buttonPositionManaDeleteList.UseVisualStyleBackColor = false;
            this.buttonPositionManaDeleteList.Click += new System.EventHandler(this.buttonPositionManaDeleteList_Click);
            // 
            // buttonPositionManaDelete
            // 
            this.buttonPositionManaDelete.BackColor = System.Drawing.Color.Red;
            this.buttonPositionManaDelete.FlatAppearance.BorderSize = 0;
            this.buttonPositionManaDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPositionManaDelete.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPositionManaDelete.Location = new System.Drawing.Point(874, 142);
            this.buttonPositionManaDelete.Name = "buttonPositionManaDelete";
            this.buttonPositionManaDelete.Size = new System.Drawing.Size(140, 107);
            this.buttonPositionManaDelete.TabIndex = 249;
            this.buttonPositionManaDelete.Text = "非表示";
            this.buttonPositionManaDelete.UseVisualStyleBackColor = false;
            this.buttonPositionManaDelete.Click += new System.EventHandler(this.buttonPositionManaDelete_Click);
            // 
            // FormPositionMana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1243, 771);
            this.Controls.Add(this.labelPoSearchTitle);
            this.Controls.Add(this.buttonPositionManaDeleteList);
            this.Controls.Add(this.buttonPositionManaDelete);
            this.Controls.Add(this.dataGridViewPositionMana);
            this.Controls.Add(this.buttonPositionManaReturn);
            this.Controls.Add(this.labelPositionManaHidden);
            this.Controls.Add(this.textBoxPositionManaHidden);
            this.Controls.Add(this.labelPositionManaPositionName);
            this.Controls.Add(this.comboBoxPositionManaPositionID);
            this.Controls.Add(this.textBoxPositionManaPositionName);
            this.Controls.Add(this.labelPositionManaPositionID);
            this.Controls.Add(this.buttonPositionManaSrarch);
            this.Controls.Add(this.buttonPositionManaList);
            this.Controls.Add(this.buttonPositionManaAdd);
            this.Controls.Add(this.buttonPositionManaUpdate);
            this.Controls.Add(this.labelPositionManaTitle);
            this.Name = "FormPositionMana";
            this.Text = "FormPositionMana";
            this.Load += new System.EventHandler(this.FormPositionMana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionMana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPositionManaSrarch;
        private System.Windows.Forms.Button buttonPositionManaList;
        private System.Windows.Forms.Button buttonPositionManaAdd;
        private System.Windows.Forms.Button buttonPositionManaUpdate;
        private System.Windows.Forms.Label labelPositionManaTitle;
        private System.Windows.Forms.Label labelPositionManaPositionName;
        private System.Windows.Forms.ComboBox comboBoxPositionManaPositionID;
        private System.Windows.Forms.TextBox textBoxPositionManaPositionName;
        private System.Windows.Forms.Label labelPositionManaPositionID;
        private System.Windows.Forms.Label labelPositionManaHidden;
        private System.Windows.Forms.TextBox textBoxPositionManaHidden;
        private System.Windows.Forms.Button buttonPositionManaReturn;
        private System.Windows.Forms.DataGridView dataGridViewPositionMana;
        private maruibutton buttonPositionManaDeleteList;
        private maruibutton buttonPositionManaDelete;
        private System.Windows.Forms.Label labelPoSearchTitle;
    }
}