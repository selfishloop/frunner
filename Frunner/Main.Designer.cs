namespace R2
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.searchtext = new System.Windows.Forms.RichTextBox();
            this.settingsbutton = new System.Windows.Forms.ImageButton();
            this.resultlistview = new Vista_Api.ListView();
            this.frunnertray = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.settingsbutton)).BeginInit();
            this.SuspendLayout();
            // 
            // searchtext
            // 
            this.searchtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchtext.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchtext.Location = new System.Drawing.Point(25, 62);
            this.searchtext.Multiline = false;
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(386, 21);
            this.searchtext.TabIndex = 4;
            this.searchtext.Text = "Azureus";
            // 
            // settingsbutton
            // 
            this.settingsbutton.BackColor = System.Drawing.Color.Transparent;
            this.settingsbutton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.settingsbutton.DownImage = null;
            this.settingsbutton.HoverImage = ((System.Drawing.Image)(resources.GetObject("settingsbutton.HoverImage")));
            this.settingsbutton.Location = new System.Drawing.Point(403, 15);
            this.settingsbutton.Name = "settingsbutton";
            this.settingsbutton.NormalImage = ((System.Drawing.Image)(resources.GetObject("settingsbutton.NormalImage")));
            this.settingsbutton.Size = new System.Drawing.Size(20, 20);
            this.settingsbutton.TabIndex = 5;
            this.settingsbutton.TabStop = false;
            // 
            // resultlistview
            // 
            this.resultlistview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultlistview.Location = new System.Drawing.Point(25, 106);
            this.resultlistview.Name = "resultlistview";
            this.resultlistview.Size = new System.Drawing.Size(386, 244);
            this.resultlistview.TabIndex = 0;
            this.resultlistview.UseCompatibleStateImageBehavior = false;
            // 
            // frunnertray
            // 
            this.frunnertray.Icon = ((System.Drawing.Icon)(resources.GetObject("frunnertray.Icon")));
            this.frunnertray.Text = "Frunner";
            this.frunnertray.Visible = true;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(427, 362);
            this.Controls.Add(this.resultlistview);
            this.Controls.Add(this.settingsbutton);
            this.Controls.Add(this.searchtext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainform";
            this.Opacity = 0.98;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frunner";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.settingsbutton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox searchtext;
        private System.Windows.Forms.ImageButton settingsbutton;
        private Vista_Api.ListView resultlistview;
        private System.Windows.Forms.NotifyIcon frunnertray;


    }
}

