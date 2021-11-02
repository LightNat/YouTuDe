
namespace YouTuDe
{
    partial class ContainerUserControl
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
            this.flowLayoutPanelSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.lblcategory = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 210);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblcategory);
            this.panel2.Controls.Add(this.flowLayoutPanelSelected);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 200);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanelSelected
            // 
            this.flowLayoutPanelSelected.AutoScroll = true;
            this.flowLayoutPanelSelected.Location = new System.Drawing.Point(21, 33);
            this.flowLayoutPanelSelected.Name = "flowLayoutPanelSelected";
            this.flowLayoutPanelSelected.Size = new System.Drawing.Size(269, 105);
            this.flowLayoutPanelSelected.TabIndex = 0;
            // 
            // lblcategory
            // 
            this.lblcategory.AutoSize = true;
            this.lblcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcategory.ForeColor = System.Drawing.Color.Red;
            this.lblcategory.Location = new System.Drawing.Point(122, 10);
            this.lblcategory.Name = "lblcategory";
            this.lblcategory.Size = new System.Drawing.Size(83, 20);
            this.lblcategory.TabIndex = 1;
            this.lblcategory.Text = "Southern";
            // 
            // ContainerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.panel1);
            this.Name = "ContainerUserControl";
            this.Size = new System.Drawing.Size(330, 220);
            this.Load += new System.EventHandler(this.UserControlContainer_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblcategory;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSelected;
    }
}
