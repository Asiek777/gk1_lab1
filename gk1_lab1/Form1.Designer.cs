namespace gk1_lab1
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exampleBut = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.pictureBoxVisible = new System.Windows.Forms.PictureBox();
            this.pictureBoxPicker = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.drawingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.exampleBut, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawingPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 716);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // exampleBut
            // 
            this.exampleBut.Location = new System.Drawing.Point(817, 3);
            this.exampleBut.Name = "exampleBut";
            this.exampleBut.Size = new System.Drawing.Size(144, 59);
            this.exampleBut.TabIndex = 0;
            this.exampleBut.Text = "Example polyghon";
            this.exampleBut.UseVisualStyleBackColor = true;
            this.exampleBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.pictureBoxVisible);
            this.drawingPanel.Controls.Add(this.pictureBoxPicker);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(808, 710);
            this.drawingPanel.TabIndex = 2;
            // 
            // pictureBoxVisible
            // 
            this.pictureBoxVisible.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVisible.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxVisible.Name = "pictureBoxVisible";
            this.pictureBoxVisible.Size = new System.Drawing.Size(808, 710);
            this.pictureBoxVisible.TabIndex = 2;
            this.pictureBoxVisible.TabStop = false;
            this.pictureBoxVisible.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxVisible_Paint);
            this.pictureBoxVisible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisible_MouseDown);
            // 
            // pictureBoxPicker
            // 
            this.pictureBoxPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPicker.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPicker.Name = "pictureBoxPicker";
            this.pictureBoxPicker.Size = new System.Drawing.Size(808, 710);
            this.pictureBoxPicker.TabIndex = 3;
            this.pictureBoxPicker.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 716);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.drawingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exampleBut;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.PictureBox pictureBoxVisible;
        private System.Windows.Forms.PictureBox pictureBoxPicker;
    }
}

