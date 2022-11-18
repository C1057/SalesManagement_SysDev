
namespace SalesManagement_SysDev
{
    partial class FormSalesOfficeMana
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
            this.labelSOManaTitle = new System.Windows.Forms.Label();
            this.buttonSOManaList = new System.Windows.Forms.Button();
            this.buttonSOManaAdd = new System.Windows.Forms.Button();
            this.buttonSOManaUpdate = new System.Windows.Forms.Button();
            this.buttonSOManaSearch = new System.Windows.Forms.Button();
            this.buttonSOManaReturn = new System.Windows.Forms.Button();
            this.textBoxProSelectOrderID = new System.Windows.Forms.TextBox();
            this.labelSOManaSOID = new System.Windows.Forms.Label();
            this.comboBoxSOManaSOID = new System.Windows.Forms.ComboBox();
            this.labelSOManaSOName = new System.Windows.Forms.Label();
            this.labelSOManaAddress = new System.Windows.Forms.Label();
            this.textBoxSOManaAddress = new System.Windows.Forms.TextBox();
            this.labelSOManaPhone = new System.Windows.Forms.Label();
            this.textBoxSOManaPhone = new System.Windows.Forms.TextBox();
            this.labelSOManaPostal = new System.Windows.Forms.Label();
            this.textBoxSOManaPostal = new System.Windows.Forms.TextBox();
            this.labelSOManaFAX = new System.Windows.Forms.Label();
            this.textBoxSOManaFAX = new System.Windows.Forms.TextBox();
            this.labelSOManaHIdden = new System.Windows.Forms.Label();
            this.textBoxSOManaHidden = new System.Windows.Forms.TextBox();
            this.dataGridViewSOMana = new System.Windows.Forms.DataGridView();
            this.maruibuttonSOManaDeleteList = new SalesManagement_SysDev.maruibutton();
            this.maruibuttonSOManaDelete = new SalesManagement_SysDev.maruibutton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSOMana)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSOManaTitle
            // 
            this.labelSOManaTitle.Font = new System.Drawing.Font("Meiryo UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaTitle.Location = new System.Drawing.Point(428, 26);
            this.labelSOManaTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSOManaTitle.Name = "labelSOManaTitle";
            this.labelSOManaTitle.Size = new System.Drawing.Size(363, 89);
            this.labelSOManaTitle.TabIndex = 0;
            this.labelSOManaTitle.Text = "営業所管理";
            // 
            // buttonSOManaList
            // 
            this.buttonSOManaList.BackColor = System.Drawing.Color.LightCyan;
            this.buttonSOManaList.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSOManaList.Location = new System.Drawing.Point(627, 133);
            this.buttonSOManaList.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSOManaList.Name = "buttonSOManaList";
            this.buttonSOManaList.Size = new System.Drawing.Size(164, 74);
            this.buttonSOManaList.TabIndex = 218;
            this.buttonSOManaList.Text = "一覧表示";
            this.buttonSOManaList.UseVisualStyleBackColor = false;
            // 
            // buttonSOManaAdd
            // 
            this.buttonSOManaAdd.BackColor = System.Drawing.Color.LightCyan;
            this.buttonSOManaAdd.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSOManaAdd.Location = new System.Drawing.Point(38, 133);
            this.buttonSOManaAdd.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSOManaAdd.Name = "buttonSOManaAdd";
            this.buttonSOManaAdd.Size = new System.Drawing.Size(164, 74);
            this.buttonSOManaAdd.TabIndex = 217;
            this.buttonSOManaAdd.Text = "登録";
            this.buttonSOManaAdd.UseVisualStyleBackColor = false;
            // 
            // buttonSOManaUpdate
            // 
            this.buttonSOManaUpdate.BackColor = System.Drawing.Color.LightCyan;
            this.buttonSOManaUpdate.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSOManaUpdate.Location = new System.Drawing.Point(230, 133);
            this.buttonSOManaUpdate.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSOManaUpdate.Name = "buttonSOManaUpdate";
            this.buttonSOManaUpdate.Size = new System.Drawing.Size(164, 74);
            this.buttonSOManaUpdate.TabIndex = 216;
            this.buttonSOManaUpdate.Text = "更新";
            this.buttonSOManaUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonSOManaSearch
            // 
            this.buttonSOManaSearch.BackColor = System.Drawing.Color.LightCyan;
            this.buttonSOManaSearch.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSOManaSearch.Location = new System.Drawing.Point(427, 133);
            this.buttonSOManaSearch.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSOManaSearch.Name = "buttonSOManaSearch";
            this.buttonSOManaSearch.Size = new System.Drawing.Size(164, 74);
            this.buttonSOManaSearch.TabIndex = 219;
            this.buttonSOManaSearch.Text = "検索";
            this.buttonSOManaSearch.UseVisualStyleBackColor = false;
            // 
            // buttonSOManaReturn
            // 
            this.buttonSOManaReturn.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonSOManaReturn.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSOManaReturn.Location = new System.Drawing.Point(1045, 26);
            this.buttonSOManaReturn.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSOManaReturn.Name = "buttonSOManaReturn";
            this.buttonSOManaReturn.Size = new System.Drawing.Size(168, 72);
            this.buttonSOManaReturn.TabIndex = 230;
            this.buttonSOManaReturn.Text = "戻る";
            this.buttonSOManaReturn.UseVisualStyleBackColor = false;
            // 
            // textBoxProSelectOrderID
            // 
            this.textBoxProSelectOrderID.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxProSelectOrderID.Location = new System.Drawing.Point(502, 235);
            this.textBoxProSelectOrderID.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProSelectOrderID.Multiline = true;
            this.textBoxProSelectOrderID.Name = "textBoxProSelectOrderID";
            this.textBoxProSelectOrderID.Size = new System.Drawing.Size(190, 37);
            this.textBoxProSelectOrderID.TabIndex = 232;
            // 
            // labelSOManaSOID
            // 
            this.labelSOManaSOID.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaSOID.Location = new System.Drawing.Point(33, 235);
            this.labelSOManaSOID.Name = "labelSOManaSOID";
            this.labelSOManaSOID.Size = new System.Drawing.Size(116, 33);
            this.labelSOManaSOID.TabIndex = 231;
            this.labelSOManaSOID.Text = "営業所ID";
            // 
            // comboBoxSOManaSOID
            // 
            this.comboBoxSOManaSOID.Font = new System.Drawing.Font("Meiryo UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxSOManaSOID.FormattingEnabled = true;
            this.comboBoxSOManaSOID.ItemHeight = 24;
            this.comboBoxSOManaSOID.Location = new System.Drawing.Point(147, 239);
            this.comboBoxSOManaSOID.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSOManaSOID.Name = "comboBoxSOManaSOID";
            this.comboBoxSOManaSOID.Size = new System.Drawing.Size(213, 32);
            this.comboBoxSOManaSOID.TabIndex = 233;
            // 
            // labelSOManaSOName
            // 
            this.labelSOManaSOName.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaSOName.Location = new System.Drawing.Point(382, 237);
            this.labelSOManaSOName.Name = "labelSOManaSOName";
            this.labelSOManaSOName.Size = new System.Drawing.Size(115, 33);
            this.labelSOManaSOName.TabIndex = 234;
            this.labelSOManaSOName.Text = "営業所名";
            // 
            // labelSOManaAddress
            // 
            this.labelSOManaAddress.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaAddress.Location = new System.Drawing.Point(33, 287);
            this.labelSOManaAddress.Name = "labelSOManaAddress";
            this.labelSOManaAddress.Size = new System.Drawing.Size(102, 33);
            this.labelSOManaAddress.TabIndex = 236;
            this.labelSOManaAddress.Text = "住所";
            // 
            // textBoxSOManaAddress
            // 
            this.textBoxSOManaAddress.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSOManaAddress.Location = new System.Drawing.Point(147, 287);
            this.textBoxSOManaAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSOManaAddress.Multiline = true;
            this.textBoxSOManaAddress.Name = "textBoxSOManaAddress";
            this.textBoxSOManaAddress.Size = new System.Drawing.Size(545, 37);
            this.textBoxSOManaAddress.TabIndex = 235;
            // 
            // labelSOManaPhone
            // 
            this.labelSOManaPhone.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaPhone.Location = new System.Drawing.Point(33, 341);
            this.labelSOManaPhone.Name = "labelSOManaPhone";
            this.labelSOManaPhone.Size = new System.Drawing.Size(109, 33);
            this.labelSOManaPhone.TabIndex = 238;
            this.labelSOManaPhone.Text = "電話番号";
            // 
            // textBoxSOManaPhone
            // 
            this.textBoxSOManaPhone.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSOManaPhone.Location = new System.Drawing.Point(147, 338);
            this.textBoxSOManaPhone.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSOManaPhone.Multiline = true;
            this.textBoxSOManaPhone.Name = "textBoxSOManaPhone";
            this.textBoxSOManaPhone.Size = new System.Drawing.Size(213, 37);
            this.textBoxSOManaPhone.TabIndex = 237;
            // 
            // labelSOManaPostal
            // 
            this.labelSOManaPostal.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaPostal.Location = new System.Drawing.Point(382, 342);
            this.labelSOManaPostal.Name = "labelSOManaPostal";
            this.labelSOManaPostal.Size = new System.Drawing.Size(115, 33);
            this.labelSOManaPostal.TabIndex = 240;
            this.labelSOManaPostal.Text = "郵便番号";
            // 
            // textBoxSOManaPostal
            // 
            this.textBoxSOManaPostal.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSOManaPostal.Location = new System.Drawing.Point(502, 341);
            this.textBoxSOManaPostal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSOManaPostal.Multiline = true;
            this.textBoxSOManaPostal.Name = "textBoxSOManaPostal";
            this.textBoxSOManaPostal.Size = new System.Drawing.Size(190, 37);
            this.textBoxSOManaPostal.TabIndex = 239;
            // 
            // labelSOManaFAX
            // 
            this.labelSOManaFAX.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaFAX.Location = new System.Drawing.Point(33, 394);
            this.labelSOManaFAX.Name = "labelSOManaFAX";
            this.labelSOManaFAX.Size = new System.Drawing.Size(102, 33);
            this.labelSOManaFAX.TabIndex = 242;
            this.labelSOManaFAX.Text = "FAX";
            // 
            // textBoxSOManaFAX
            // 
            this.textBoxSOManaFAX.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSOManaFAX.Location = new System.Drawing.Point(147, 394);
            this.textBoxSOManaFAX.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSOManaFAX.Multiline = true;
            this.textBoxSOManaFAX.Name = "textBoxSOManaFAX";
            this.textBoxSOManaFAX.Size = new System.Drawing.Size(213, 37);
            this.textBoxSOManaFAX.TabIndex = 241;
            // 
            // labelSOManaHIdden
            // 
            this.labelSOManaHIdden.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSOManaHIdden.Location = new System.Drawing.Point(730, 318);
            this.labelSOManaHIdden.Name = "labelSOManaHIdden";
            this.labelSOManaHIdden.Size = new System.Drawing.Size(138, 33);
            this.labelSOManaHIdden.TabIndex = 244;
            this.labelSOManaHIdden.Text = "非表示理由";
            // 
            // textBoxSOManaHidden
            // 
            this.textBoxSOManaHidden.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSOManaHidden.Location = new System.Drawing.Point(873, 234);
            this.textBoxSOManaHidden.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSOManaHidden.Multiline = true;
            this.textBoxSOManaHidden.Name = "textBoxSOManaHidden";
            this.textBoxSOManaHidden.Size = new System.Drawing.Size(340, 193);
            this.textBoxSOManaHidden.TabIndex = 243;
            // 
            // dataGridViewSOMana
            // 
            this.dataGridViewSOMana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSOMana.Location = new System.Drawing.Point(38, 473);
            this.dataGridViewSOMana.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSOMana.Name = "dataGridViewSOMana";
            this.dataGridViewSOMana.RowHeadersWidth = 62;
            this.dataGridViewSOMana.RowTemplate.Height = 27;
            this.dataGridViewSOMana.Size = new System.Drawing.Size(1175, 252);
            this.dataGridViewSOMana.TabIndex = 245;
            // 
            // maruibuttonSOManaDeleteList
            // 
            this.maruibuttonSOManaDeleteList.BackColor = System.Drawing.Color.Red;
            this.maruibuttonSOManaDeleteList.FlatAppearance.BorderSize = 0;
            this.maruibuttonSOManaDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maruibuttonSOManaDeleteList.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.maruibuttonSOManaDeleteList.Location = new System.Drawing.Point(1028, 119);
            this.maruibuttonSOManaDeleteList.Name = "maruibuttonSOManaDeleteList";
            this.maruibuttonSOManaDeleteList.Size = new System.Drawing.Size(140, 107);
            this.maruibuttonSOManaDeleteList.TabIndex = 247;
            this.maruibuttonSOManaDeleteList.Text = "非表示リスト";
            this.maruibuttonSOManaDeleteList.UseVisualStyleBackColor = false;
            // 
            // maruibuttonSOManaDelete
            // 
            this.maruibuttonSOManaDelete.BackColor = System.Drawing.Color.Red;
            this.maruibuttonSOManaDelete.FlatAppearance.BorderSize = 0;
            this.maruibuttonSOManaDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maruibuttonSOManaDelete.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.maruibuttonSOManaDelete.Location = new System.Drawing.Point(873, 119);
            this.maruibuttonSOManaDelete.Name = "maruibuttonSOManaDelete";
            this.maruibuttonSOManaDelete.Size = new System.Drawing.Size(140, 107);
            this.maruibuttonSOManaDelete.TabIndex = 246;
            this.maruibuttonSOManaDelete.Text = "非表示";
            this.maruibuttonSOManaDelete.UseVisualStyleBackColor = false;
            // 
            // FormSalesOfficeMana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1259, 755);
            this.Controls.Add(this.maruibuttonSOManaDeleteList);
            this.Controls.Add(this.maruibuttonSOManaDelete);
            this.Controls.Add(this.dataGridViewSOMana);
            this.Controls.Add(this.labelSOManaHIdden);
            this.Controls.Add(this.textBoxSOManaHidden);
            this.Controls.Add(this.labelSOManaFAX);
            this.Controls.Add(this.textBoxSOManaFAX);
            this.Controls.Add(this.labelSOManaPostal);
            this.Controls.Add(this.textBoxSOManaPostal);
            this.Controls.Add(this.labelSOManaPhone);
            this.Controls.Add(this.textBoxSOManaPhone);
            this.Controls.Add(this.labelSOManaAddress);
            this.Controls.Add(this.textBoxSOManaAddress);
            this.Controls.Add(this.labelSOManaSOName);
            this.Controls.Add(this.comboBoxSOManaSOID);
            this.Controls.Add(this.textBoxProSelectOrderID);
            this.Controls.Add(this.labelSOManaSOID);
            this.Controls.Add(this.buttonSOManaReturn);
            this.Controls.Add(this.buttonSOManaSearch);
            this.Controls.Add(this.buttonSOManaList);
            this.Controls.Add(this.buttonSOManaAdd);
            this.Controls.Add(this.buttonSOManaUpdate);
            this.Controls.Add(this.labelSOManaTitle);
            this.Name = "FormSalesOfficeMana";
            this.Text = "FormSalesOfficeMana";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSOMana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSOManaTitle;
        private System.Windows.Forms.Button buttonSOManaList;
        private System.Windows.Forms.Button buttonSOManaAdd;
        private System.Windows.Forms.Button buttonSOManaUpdate;
        private System.Windows.Forms.Button buttonSOManaSearch;
        private System.Windows.Forms.Button buttonSOManaReturn;
        private System.Windows.Forms.TextBox textBoxProSelectOrderID;
        private System.Windows.Forms.Label labelSOManaSOID;
        private System.Windows.Forms.ComboBox comboBoxSOManaSOID;
        private System.Windows.Forms.Label labelSOManaSOName;
        private System.Windows.Forms.Label labelSOManaAddress;
        private System.Windows.Forms.TextBox textBoxSOManaAddress;
        private System.Windows.Forms.Label labelSOManaPhone;
        private System.Windows.Forms.TextBox textBoxSOManaPhone;
        private System.Windows.Forms.Label labelSOManaPostal;
        private System.Windows.Forms.TextBox textBoxSOManaPostal;
        private System.Windows.Forms.Label labelSOManaFAX;
        private System.Windows.Forms.TextBox textBoxSOManaFAX;
        private System.Windows.Forms.Label labelSOManaHIdden;
        private System.Windows.Forms.TextBox textBoxSOManaHidden;
        private System.Windows.Forms.DataGridView dataGridViewSOMana;
        private maruibutton maruibuttonSOManaDeleteList;
        private maruibutton maruibuttonSOManaDelete;
    }
}