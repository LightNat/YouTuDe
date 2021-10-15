
namespace YouTuDe
{
    partial class PendingDriverUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelMore = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btndeny = new System.Windows.Forms.Button();
            this.btnaccept = new System.Windows.Forms.Button();
            this.lblphonenumber = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblfullname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbprofile = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbprofile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 103);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.linkLabelMore);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btndeny);
            this.panel2.Controls.Add(this.btnaccept);
            this.panel2.Controls.Add(this.lblphonenumber);
            this.panel2.Controls.Add(this.lblage);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblfullname);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pbprofile);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 93);
            this.panel2.TabIndex = 0;
            // 
            // linkLabelMore
            // 
            this.linkLabelMore.AutoSize = true;
            this.linkLabelMore.Location = new System.Drawing.Point(118, 74);
            this.linkLabelMore.Name = "linkLabelMore";
            this.linkLabelMore.Size = new System.Drawing.Size(50, 13);
            this.linkLabelMore.TabIndex = 12;
            this.linkLabelMore.TabStop = true;
            this.linkLabelMore.Text = "License>";
            this.linkLabelMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMore_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Accept:";
            // 
            // btndeny
            // 
            this.btndeny.ForeColor = System.Drawing.Color.Red;
            this.btndeny.Location = new System.Drawing.Point(271, 70);
            this.btndeny.Name = "btndeny";
            this.btndeny.Size = new System.Drawing.Size(19, 20);
            this.btndeny.TabIndex = 10;
            this.btndeny.Text = "✖";
            this.btndeny.UseVisualStyleBackColor = true;
            this.btndeny.Click += new System.EventHandler(this.btndeny_Click);
            // 
            // btnaccept
            // 
            this.btnaccept.ForeColor = System.Drawing.Color.Green;
            this.btnaccept.Location = new System.Drawing.Point(246, 70);
            this.btnaccept.Name = "btnaccept";
            this.btnaccept.Size = new System.Drawing.Size(19, 20);
            this.btnaccept.TabIndex = 9;
            this.btnaccept.Text = "✔";
            this.btnaccept.UseVisualStyleBackColor = true;
            this.btnaccept.Click += new System.EventHandler(this.btnaccept_Click);
            // 
            // lblphonenumber
            // 
            this.lblphonenumber.AutoSize = true;
            this.lblphonenumber.Location = new System.Drawing.Point(155, 54);
            this.lblphonenumber.Name = "lblphonenumber";
            this.lblphonenumber.Size = new System.Drawing.Size(13, 13);
            this.lblphonenumber.TabIndex = 8;
            this.lblphonenumber.Text = "+";
            // 
            // lblage
            // 
            this.lblage.AutoSize = true;
            this.lblage.Location = new System.Drawing.Point(133, 32);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(13, 13);
            this.lblage.TabIndex = 7;
            this.lblage.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phone #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Age:";
            // 
            // lblfullname
            // 
            this.lblfullname.AutoSize = true;
            this.lblfullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfullname.Location = new System.Drawing.Point(157, 10);
            this.lblfullname.Name = "lblfullname";
            this.lblfullname.Size = new System.Drawing.Size(71, 16);
            this.lblfullname.TabIndex = 3;
            this.lblfullname.Text = "Fullname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // pbprofile
            // 
            this.pbprofile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbprofile.Location = new System.Drawing.Point(10, 10);
            this.pbprofile.Name = "pbprofile";
            this.pbprofile.Size = new System.Drawing.Size(82, 72);
            this.pbprofile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbprofile.TabIndex = 1;
            this.pbprofile.TabStop = false;
            // 
            // PendingDriverUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.panel1);
            this.Name = "PendingDriverUserControl";
            this.Size = new System.Drawing.Size(313, 113);
            this.Load += new System.EventHandler(this.PendingDriverUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbprofile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbprofile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblfullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblage;
        private System.Windows.Forms.Label lblphonenumber;
        private System.Windows.Forms.Button btndeny;
        private System.Windows.Forms.Button btnaccept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelMore;
    }
}
