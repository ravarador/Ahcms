
namespace AutomatedHumanContactMonitorySystemApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEditAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAddAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEditAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAddPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEditPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeletePlace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAttendance,
            this.toolStripMenuItemAttendee,
            this.toolStripMenuItemPlace});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemAttendance
            // 
            this.toolStripMenuItemAttendance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddAttendance,
            this.toolStripMenuEditAttendance,
            this.toolStripMenuDeleteAttendance});
            this.toolStripMenuItemAttendance.Name = "toolStripMenuItemAttendance";
            this.toolStripMenuItemAttendance.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItemAttendance.Text = "Attendance";
            // 
            // toolStripMenuItemAddAttendance
            // 
            this.toolStripMenuItemAddAttendance.Name = "toolStripMenuItemAddAttendance";
            this.toolStripMenuItemAddAttendance.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItemAddAttendance.Text = "Add Attendance";
            this.toolStripMenuItemAddAttendance.Click += new System.EventHandler(this.toolStripMenuItemAddAttendance_Click);
            // 
            // toolStripMenuEditAttendance
            // 
            this.toolStripMenuEditAttendance.Name = "toolStripMenuEditAttendance";
            this.toolStripMenuEditAttendance.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuEditAttendance.Text = "Edit Attendance";
            this.toolStripMenuEditAttendance.Visible = false;
            this.toolStripMenuEditAttendance.Click += new System.EventHandler(this.toolStripMenuEditAttendance_Click);
            // 
            // toolStripMenuDeleteAttendance
            // 
            this.toolStripMenuDeleteAttendance.Name = "toolStripMenuDeleteAttendance";
            this.toolStripMenuDeleteAttendance.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuDeleteAttendance.Text = "Delete Attendance";
            this.toolStripMenuDeleteAttendance.Visible = false;
            this.toolStripMenuDeleteAttendance.Click += new System.EventHandler(this.toolStripMenuDeleteAttendance_Click);
            // 
            // toolStripMenuItemAttendee
            // 
            this.toolStripMenuItemAttendee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddAttendee,
            this.toolStripMenuEditAttendee,
            this.toolStripMenuDeleteAttendee});
            this.toolStripMenuItemAttendee.Name = "toolStripMenuItemAttendee";
            this.toolStripMenuItemAttendee.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemAttendee.Text = "Attendee";
            this.toolStripMenuItemAttendee.Visible = false;
            // 
            // toolStripMenuAddAttendee
            // 
            this.toolStripMenuAddAttendee.Name = "toolStripMenuAddAttendee";
            this.toolStripMenuAddAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuAddAttendee.Text = "Add Attendee";
            this.toolStripMenuAddAttendee.Click += new System.EventHandler(this.toolStripMenuAddAttendee_Click);
            // 
            // toolStripMenuEditAttendee
            // 
            this.toolStripMenuEditAttendee.Name = "toolStripMenuEditAttendee";
            this.toolStripMenuEditAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuEditAttendee.Text = "Edit Attendee";
            this.toolStripMenuEditAttendee.Click += new System.EventHandler(this.toolStripMenuEditAttendee_Click);
            // 
            // toolStripMenuDeleteAttendee
            // 
            this.toolStripMenuDeleteAttendee.Name = "toolStripMenuDeleteAttendee";
            this.toolStripMenuDeleteAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuDeleteAttendee.Text = "Delete Attendee";
            this.toolStripMenuDeleteAttendee.Click += new System.EventHandler(this.toolStripMenuDeleteAttendee_Click);
            // 
            // toolStripMenuItemPlace
            // 
            this.toolStripMenuItemPlace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddPlace,
            this.toolStripMenuEditPlace,
            this.toolStripMenuDeletePlace});
            this.toolStripMenuItemPlace.Name = "toolStripMenuItemPlace";
            this.toolStripMenuItemPlace.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItemPlace.Text = "Place";
            this.toolStripMenuItemPlace.Visible = false;
            // 
            // toolStripMenuAddPlace
            // 
            this.toolStripMenuAddPlace.Name = "toolStripMenuAddPlace";
            this.toolStripMenuAddPlace.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuAddPlace.Text = "Add Place";
            this.toolStripMenuAddPlace.Click += new System.EventHandler(this.toolStripMenuAddPlace_Click);
            // 
            // toolStripMenuEditPlace
            // 
            this.toolStripMenuEditPlace.Name = "toolStripMenuEditPlace";
            this.toolStripMenuEditPlace.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuEditPlace.Text = "Edit Place";
            this.toolStripMenuEditPlace.Click += new System.EventHandler(this.toolStripMenuEditPlace_Click);
            // 
            // toolStripMenuDeletePlace
            // 
            this.toolStripMenuDeletePlace.Name = "toolStripMenuDeletePlace";
            this.toolStripMenuDeletePlace.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuDeletePlace.Text = "Delete Place";
            this.toolStripMenuDeletePlace.Click += new System.EventHandler(this.toolStripMenuDeletePlace_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddAttendance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddPlace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditPlace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeletePlace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditAttendance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteAttendance;
    }
}

