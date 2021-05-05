
namespace AutomatedHumanContactMonitorySystemApp.UserControls
{
    partial class AdminUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAttendances = new System.Windows.Forms.DataGridView();
            this.AttendeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendeeRFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.comboSearchBy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetAttendeeStatusByDate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendances)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAttendances);
            this.panel1.Location = new System.Drawing.Point(19, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 284);
            this.panel1.TabIndex = 0;
            // 
            // dgvAttendances
            // 
            this.dgvAttendances.AllowUserToAddRows = false;
            this.dgvAttendances.AllowUserToDeleteRows = false;
            this.dgvAttendances.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAttendances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendances.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendances.ColumnHeadersHeight = 50;
            this.dgvAttendances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttendances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendeeName,
            this.VisitedDateTime,
            this.Temperature,
            this.PlaceName,
            this.AttendeeRFID,
            this.Status,
            this.Id,
            this.AttendeeId,
            this.PlaceId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendances.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAttendances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendances.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAttendances.Location = new System.Drawing.Point(0, 0);
            this.dgvAttendances.Name = "dgvAttendances";
            this.dgvAttendances.ReadOnly = true;
            this.dgvAttendances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendances.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAttendances.RowHeadersVisible = false;
            this.dgvAttendances.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(67)))), ((int)(((byte)(255)))));
            this.dgvAttendances.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAttendances.RowTemplate.Height = 25;
            this.dgvAttendances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendances.Size = new System.Drawing.Size(577, 284);
            this.dgvAttendances.TabIndex = 1;
            this.dgvAttendances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendances_CellClick);
            // 
            // AttendeeName
            // 
            this.AttendeeName.HeaderText = "Name";
            this.AttendeeName.Name = "AttendeeName";
            this.AttendeeName.ReadOnly = true;
            // 
            // VisitedDateTime
            // 
            this.VisitedDateTime.HeaderText = "Date and Time";
            this.VisitedDateTime.Name = "VisitedDateTime";
            this.VisitedDateTime.ReadOnly = true;
            // 
            // Temperature
            // 
            this.Temperature.HeaderText = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            // 
            // PlaceName
            // 
            this.PlaceName.HeaderText = "Location";
            this.PlaceName.Name = "PlaceName";
            this.PlaceName.ReadOnly = true;
            // 
            // AttendeeRFID
            // 
            this.AttendeeRFID.HeaderText = "RFID";
            this.AttendeeRFID.Name = "AttendeeRFID";
            this.AttendeeRFID.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // AttendeeId
            // 
            this.AttendeeId.HeaderText = "AttendeeId";
            this.AttendeeId.Name = "AttendeeId";
            this.AttendeeId.ReadOnly = true;
            this.AttendeeId.Visible = false;
            // 
            // PlaceId
            // 
            this.PlaceId.HeaderText = "PlaceId";
            this.PlaceId.Name = "PlaceId";
            this.PlaceId.ReadOnly = true;
            this.PlaceId.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSearchText);
            this.panel3.Controls.Add(this.comboSearchBy);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Location = new System.Drawing.Point(326, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 132);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(117, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 10);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(117, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 10);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search By";
            // 
            // txtSearchText
            // 
            this.txtSearchText.BackColor = System.Drawing.SystemColors.Control;
            this.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchText.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchText.Location = new System.Drawing.Point(30, 69);
            this.txtSearchText.MaxLength = 20;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(216, 18);
            this.txtSearchText.TabIndex = 1;
            this.txtSearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboSearchBy
            // 
            this.comboSearchBy.BackColor = System.Drawing.SystemColors.Control;
            this.comboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSearchBy.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboSearchBy.FormattingEnabled = true;
            this.comboSearchBy.Items.AddRange(new object[] {
            "Name",
            "RFID",
            "Location"});
            this.comboSearchBy.Location = new System.Drawing.Point(30, 16);
            this.comboSearchBy.Name = "comboSearchBy";
            this.comboSearchBy.Size = new System.Drawing.Size(216, 24);
            this.comboSearchBy.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(67)))), ((int)(((byte)(255)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(0, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(270, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtRfid);
            this.panel4.Controls.Add(this.comboStatus);
            this.panel4.Controls.Add(this.btnSetStatus);
            this.panel4.Location = new System.Drawing.Point(19, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(301, 132);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(149, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 10);
            this.label3.TabIndex = 4;
            this.label3.Text = "RFID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(147, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 10);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status";
            // 
            // txtRfid
            // 
            this.txtRfid.BackColor = System.Drawing.SystemColors.Control;
            this.txtRfid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRfid.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRfid.Location = new System.Drawing.Point(30, 69);
            this.txtRfid.MaxLength = 20;
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(255, 18);
            this.txtRfid.TabIndex = 1;
            this.txtRfid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.SystemColors.Control;
            this.comboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "NORMAL",
            "PUI",
            "POSITIVE"});
            this.comboStatus.Location = new System.Drawing.Point(30, 16);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(255, 23);
            this.comboStatus.TabIndex = 0;
            this.comboStatus.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboStatus_DrawItem);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(67)))), ((int)(((byte)(255)))));
            this.btnSetStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSetStatus.FlatAppearance.BorderSize = 0;
            this.btnSetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetStatus.ForeColor = System.Drawing.Color.White;
            this.btnSetStatus.Location = new System.Drawing.Point(0, 109);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(301, 23);
            this.btnSetStatus.TabIndex = 2;
            this.btnSetStatus.Text = "Set Status";
            this.btnSetStatus.UseVisualStyleBackColor = false;
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(253, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Attendance not found? ";
            // 
            // btnSetAttendeeStatusByDate
            // 
            this.btnSetAttendeeStatusByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(67)))), ((int)(((byte)(255)))));
            this.btnSetAttendeeStatusByDate.FlatAppearance.BorderSize = 0;
            this.btnSetAttendeeStatusByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetAttendeeStatusByDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetAttendeeStatusByDate.ForeColor = System.Drawing.Color.White;
            this.btnSetAttendeeStatusByDate.Location = new System.Drawing.Point(391, 466);
            this.btnSetAttendeeStatusByDate.Name = "btnSetAttendeeStatusByDate";
            this.btnSetAttendeeStatusByDate.Size = new System.Drawing.Size(205, 23);
            this.btnSetAttendeeStatusByDate.TabIndex = 4;
            this.btnSetAttendeeStatusByDate.Text = "Set Attendee Status By Date";
            this.btnSetAttendeeStatusByDate.UseVisualStyleBackColor = false;
            this.btnSetAttendeeStatusByDate.Click += new System.EventHandler(this.btnSetAttendeeStatusByDate_Click);
            // 
            // AdminUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetAttendeeStatusByDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "AdminUserControl";
            this.Size = new System.Drawing.Size(614, 531);
            this.Load += new System.EventHandler(this.AdminUserControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendances)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAttendances;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.ComboBox comboSearchBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRfid;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Button btnSetStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeRFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetAttendeeStatusByDate;
    }
}
