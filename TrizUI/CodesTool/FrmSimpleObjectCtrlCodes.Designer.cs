namespace CodesTool
{
    partial class FrmSimpleObjectCtrlCodes
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
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.tabCtrl = new System.Windows.Forms.TabPage();
            this.txtCtrl = new System.Windows.Forms.RichTextBox();
            this.txtHTML = new System.Windows.Forms.RichTextBox();
            this.tabHtml = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnGo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSimpleObjectCtrlCodes = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage9.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabHtml.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.txtSource);
            this.tabPage9.Location = new System.Drawing.Point(4, 45);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1269, 611);
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
            this.txtSource.Size = new System.Drawing.Size(1263, 605);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = "ComponentParamInfo\r\nComponentName\r\nParamName\r\nParamType";
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.txtCtrl);
            this.tabCtrl.Location = new System.Drawing.Point(4, 45);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.Padding = new System.Windows.Forms.Padding(3);
            this.tabCtrl.Size = new System.Drawing.Size(1269, 611);
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.Text = "Ctrl";
            this.tabCtrl.UseVisualStyleBackColor = true;
            // 
            // txtCtrl
            // 
            this.txtCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCtrl.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCtrl.Location = new System.Drawing.Point(3, 3);
            this.txtCtrl.Name = "txtCtrl";
            this.txtCtrl.Size = new System.Drawing.Size(1263, 605);
            this.txtCtrl.TabIndex = 3;
            this.txtCtrl.Text = "";
            // 
            // txtHTML
            // 
            this.txtHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHTML.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHTML.Location = new System.Drawing.Point(3, 3);
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.Size = new System.Drawing.Size(1263, 605);
            this.txtHTML.TabIndex = 4;
            this.txtHTML.Text = "";
            // 
            // tabHtml
            // 
            this.tabHtml.Controls.Add(this.txtHTML);
            this.tabHtml.Location = new System.Drawing.Point(4, 45);
            this.tabHtml.Name = "tabHtml";
            this.tabHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabHtml.Size = new System.Drawing.Size(1269, 611);
            this.tabHtml.TabIndex = 1;
            this.tabHtml.Text = "HTML";
            this.tabHtml.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabCtrl);
            this.tabControl1.Controls.Add(this.tabHtml);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1277, 660);
            this.tabControl1.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(24, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 39);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Files";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(231, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "OpenDir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSimpleObjectCtrlCodes
            // 
            this.btnSimpleObjectCtrlCodes.Location = new System.Drawing.Point(341, 5);
            this.btnSimpleObjectCtrlCodes.Name = "btnSimpleObjectCtrlCodes";
            this.btnSimpleObjectCtrlCodes.Size = new System.Drawing.Size(178, 29);
            this.btnSimpleObjectCtrlCodes.TabIndex = 4;
            this.btnSimpleObjectCtrlCodes.Text = "SimpleObjectCtrlCodes";
            this.btnSimpleObjectCtrlCodes.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.btnSimpleObjectCtrlCodes);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.btnGo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1277, 702);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 2;
            // 
            // FrmSimpleObjectCtrlCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 702);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSimpleObjectCtrlCodes";
            this.Text = "FrmSimpleObjectCtrlCodes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabCtrl.ResumeLayout(false);
            this.tabHtml.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TabPage tabCtrl;
        private System.Windows.Forms.RichTextBox txtCtrl;
        private System.Windows.Forms.RichTextBox txtHTML;
        private System.Windows.Forms.TabPage tabHtml;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSimpleObjectCtrlCodes;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}