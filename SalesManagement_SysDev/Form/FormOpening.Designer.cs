
namespace SalesManagement_SysDev
{
    partial class FormOpening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpening));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maruibutton1 = new SalesManagement_SysDev.maruibutton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "タイトaaqqルなし.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.Image = global::SalesManagement_SysDev.Properties.Resources.dffaaaaaqaqadfa;
            this.pictureBox1.Location = new System.Drawing.Point(418, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 204);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // maruibutton1
            // 
            this.maruibutton1.FlatAppearance.BorderSize = 0;
            this.maruibutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maruibutton1.ImageIndex = 0;
            this.maruibutton1.ImageList = this.imageList1;
            this.maruibutton1.Location = new System.Drawing.Point(219, 221);
            this.maruibutton1.Name = "maruibutton1";
            this.maruibutton1.Size = new System.Drawing.Size(193, 184);
            this.maruibutton1.TabIndex = 1;
            this.maruibutton1.UseVisualStyleBackColor = true;
            this.maruibutton1.Click += new System.EventHandler(this.maruibutton1_Click);
            // 
            // FormOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 616);
            this.Controls.Add(this.maruibutton1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormOpening";
            this.Text = "FormOpening";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private maruibutton maruibutton1;
    }
}