namespace CodesTool
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDAL = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtBLL = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtAPIControler = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtListHtml = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtOperateHtml = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.txtListCtrl = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.txtOpeCtrl = new System.Windows.Forms.TextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.txtSQL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1080, 738);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Project";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 693);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.txtSource);
            this.tabPage9.Location = new System.Drawing.Point(4, 45);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1072, 644);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Source";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(3, 3);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(1066, 638);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = resources.GetString("txtSource.Text");
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtModel);
            this.tabPage1.Location = new System.Drawing.Point(4, 45);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1072, 644);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Model";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtModel.Location = new System.Drawing.Point(3, 3);
            this.txtModel.Multiline = true;
            this.txtModel.Name = "txtModel";
            this.txtModel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModel.Size = new System.Drawing.Size(1066, 638);
            this.txtModel.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDAL);
            this.tabPage2.Location = new System.Drawing.Point(4, 45);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1072, 644);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DAL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDAL
            // 
            this.txtDAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDAL.Font = new System.Drawing.Font("宋体", 24F);
            this.txtDAL.Location = new System.Drawing.Point(3, 3);
            this.txtDAL.Multiline = true;
            this.txtDAL.Name = "txtDAL";
            this.txtDAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDAL.Size = new System.Drawing.Size(1066, 638);
            this.txtDAL.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtBLL);
            this.tabPage3.Location = new System.Drawing.Point(4, 45);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1072, 644);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BLL";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtBLL
            // 
            this.txtBLL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBLL.Font = new System.Drawing.Font("宋体", 24F);
            this.txtBLL.Location = new System.Drawing.Point(3, 3);
            this.txtBLL.Multiline = true;
            this.txtBLL.Name = "txtBLL";
            this.txtBLL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBLL.Size = new System.Drawing.Size(1066, 638);
            this.txtBLL.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtAPIControler);
            this.tabPage4.Location = new System.Drawing.Point(4, 45);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1072, 644);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "APIControler";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtAPIControler
            // 
            this.txtAPIControler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAPIControler.Font = new System.Drawing.Font("宋体", 24F);
            this.txtAPIControler.Location = new System.Drawing.Point(3, 3);
            this.txtAPIControler.Multiline = true;
            this.txtAPIControler.Name = "txtAPIControler";
            this.txtAPIControler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAPIControler.Size = new System.Drawing.Size(1066, 638);
            this.txtAPIControler.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtListHtml);
            this.tabPage5.Location = new System.Drawing.Point(4, 45);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1072, 644);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ListHtmlPage";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtListHtml
            // 
            this.txtListHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtListHtml.Font = new System.Drawing.Font("宋体", 24F);
            this.txtListHtml.Location = new System.Drawing.Point(3, 3);
            this.txtListHtml.Multiline = true;
            this.txtListHtml.Name = "txtListHtml";
            this.txtListHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtListHtml.Size = new System.Drawing.Size(1066, 638);
            this.txtListHtml.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtOperateHtml);
            this.tabPage6.Location = new System.Drawing.Point(4, 45);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1072, 644);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "OperateHtmlPage";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtOperateHtml
            // 
            this.txtOperateHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOperateHtml.Font = new System.Drawing.Font("宋体", 24F);
            this.txtOperateHtml.Location = new System.Drawing.Point(3, 3);
            this.txtOperateHtml.Multiline = true;
            this.txtOperateHtml.Name = "txtOperateHtml";
            this.txtOperateHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOperateHtml.Size = new System.Drawing.Size(1066, 638);
            this.txtOperateHtml.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.txtListCtrl);
            this.tabPage7.Location = new System.Drawing.Point(4, 45);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1072, 644);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "ListCtrl";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // txtListCtrl
            // 
            this.txtListCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtListCtrl.Font = new System.Drawing.Font("宋体", 24F);
            this.txtListCtrl.Location = new System.Drawing.Point(3, 3);
            this.txtListCtrl.Multiline = true;
            this.txtListCtrl.Name = "txtListCtrl";
            this.txtListCtrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtListCtrl.Size = new System.Drawing.Size(1066, 638);
            this.txtListCtrl.TabIndex = 3;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.txtOpeCtrl);
            this.tabPage8.Location = new System.Drawing.Point(4, 45);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1072, 644);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "OpeCtrl";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // txtOpeCtrl
            // 
            this.txtOpeCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOpeCtrl.Font = new System.Drawing.Font("宋体", 24F);
            this.txtOpeCtrl.Location = new System.Drawing.Point(3, 3);
            this.txtOpeCtrl.Multiline = true;
            this.txtOpeCtrl.Name = "txtOpeCtrl";
            this.txtOpeCtrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOpeCtrl.Size = new System.Drawing.Size(1066, 638);
            this.txtOpeCtrl.TabIndex = 3;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.txtSQL);
            this.tabPage10.Location = new System.Drawing.Point(4, 45);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1072, 644);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "SQL";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("宋体", 24F);
            this.txtSQL.Location = new System.Drawing.Point(3, 3);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQL.Size = new System.Drawing.Size(1066, 638);
            this.txtSQL.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 738);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtDAL;
        private System.Windows.Forms.TextBox txtBLL;
        private System.Windows.Forms.TextBox txtAPIControler;
        private System.Windows.Forms.TextBox txtListHtml;
        private System.Windows.Forms.TextBox txtOperateHtml;
        private System.Windows.Forms.TextBox txtListCtrl;
        private System.Windows.Forms.TextBox txtOpeCtrl;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox txtSQL;

    }
}