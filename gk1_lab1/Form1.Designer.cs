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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.pictureBoxVisible = new System.Windows.Forms.PictureBox();
            this.pictureBoxPicker = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearBut = new System.Windows.Forms.Button();
            this.swapBoxBut = new System.Windows.Forms.Button();
            this.exampleBut = new System.Windows.Forms.Button();
            this.changeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.drawingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).BeginInit();
            this.panel1.SuspendLayout();
            this.changeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.drawingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 716);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.pictureBoxVisible);
            this.drawingPanel.Controls.Add(this.pictureBoxPicker);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(828, 710);
            this.drawingPanel.TabIndex = 2;
            // 
            // pictureBoxVisible
            // 
            this.pictureBoxVisible.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxVisible.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxVisible.Name = "pictureBoxVisible";
            this.pictureBoxVisible.Size = new System.Drawing.Size(828, 710);
            this.pictureBoxVisible.TabIndex = 2;
            this.pictureBoxVisible.TabStop = false;
            this.pictureBoxVisible.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxVisible_Paint);
            this.pictureBoxVisible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisible_MouseDown);
            this.pictureBoxVisible.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxVisible_MouseUp);
            // 
            // pictureBoxPicker
            // 
            this.pictureBoxPicker.BackColor = System.Drawing.Color.White;
            this.pictureBoxPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPicker.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPicker.Name = "pictureBoxPicker";
            this.pictureBoxPicker.Size = new System.Drawing.Size(828, 710);
            this.pictureBoxPicker.TabIndex = 3;
            this.pictureBoxPicker.TabStop = false;
            this.pictureBoxPicker.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPicker_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clearBut);
            this.panel1.Controls.Add(this.swapBoxBut);
            this.panel1.Controls.Add(this.exampleBut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(837, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 710);
            this.panel1.TabIndex = 3;
            // 
            // clearBut
            // 
            this.clearBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clearBut.Location = new System.Drawing.Point(22, 134);
            this.clearBut.Name = "clearBut";
            this.clearBut.Size = new System.Drawing.Size(103, 55);
            this.clearBut.TabIndex = 2;
            this.clearBut.Text = "Clear";
            this.clearBut.UseVisualStyleBackColor = true;
            this.clearBut.Click += new System.EventHandler(this.clearBut_Click);
            // 
            // swapBoxBut
            // 
            this.swapBoxBut.Location = new System.Drawing.Point(30, 68);
            this.swapBoxBut.Name = "swapBoxBut";
            this.swapBoxBut.Size = new System.Drawing.Size(84, 51);
            this.swapBoxBut.TabIndex = 1;
            this.swapBoxBut.Text = "Swap Picture Boxex";
            this.swapBoxBut.UseVisualStyleBackColor = true;
            this.swapBoxBut.Click += new System.EventHandler(this.swapBoxBut_Click);
            // 
            // exampleBut
            // 
            this.exampleBut.Location = new System.Drawing.Point(3, 3);
            this.exampleBut.Name = "exampleBut";
            this.exampleBut.Size = new System.Drawing.Size(138, 59);
            this.exampleBut.TabIndex = 0;
            this.exampleBut.Text = "Example polyghon";
            this.exampleBut.UseVisualStyleBackColor = true;
            this.exampleBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // changeContextMenu
            // 
            this.changeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteVertexToolStripMenuItem,
            this.toolStripSeparator1,
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.constLengthToolStripMenuItem});
            this.changeContextMenu.Name = "changeContextMenu";
            this.changeContextMenu.Size = new System.Drawing.Size(181, 120);
            this.changeContextMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.changeContextMenu_Closed);
            // 
            // deleteVertexToolStripMenuItem
            // 
            this.deleteVertexToolStripMenuItem.Enabled = false;
            this.deleteVertexToolStripMenuItem.Name = "deleteVertexToolStripMenuItem";
            this.deleteVertexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteVertexToolStripMenuItem.Text = "Delete";
            this.deleteVertexToolStripMenuItem.Click += new System.EventHandler(this.deleteVertexToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Enabled = false;
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Enabled = false;
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // constLengthToolStripMenuItem
            // 
            this.constLengthToolStripMenuItem.Enabled = false;
            this.constLengthToolStripMenuItem.Name = "constLengthToolStripMenuItem";
            this.constLengthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.constLengthToolStripMenuItem.Text = "Const length";
            this.constLengthToolStripMenuItem.Click += new System.EventHandler(this.constLengthToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(984, 716);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.drawingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).EndInit();
            this.panel1.ResumeLayout(false);
            this.changeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exampleBut;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.PictureBox pictureBoxVisible;
        private System.Windows.Forms.PictureBox pictureBoxPicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button swapBoxBut;
        private System.Windows.Forms.Button clearBut;
        private System.Windows.Forms.ContextMenuStrip changeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constLengthToolStripMenuItem;
    }
}

