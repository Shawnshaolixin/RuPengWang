namespace RpCater
{
    partial class FrmRoomAndDesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomAndDesk));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.msgRoom = new MsgDiv();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.msgDesk = new MsgDiv();
            this.btnDeleteDesk = new System.Windows.Forms.Button();
            this.btnUpdateDesk = new System.Windows.Forms.Button();
            this.btnAddDesk = new System.Windows.Forms.Button();
            this.dgvDesk = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesk)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage1.Controls.Add(this.msgRoom);
            this.tabPage1.Controls.Add(this.btnDeleteRoom);
            this.tabPage1.Controls.Add(this.btnUpdateRoom);
            this.tabPage1.Controls.Add(this.btnAddRoom);
            this.tabPage1.Controls.Add(this.dgvRoom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "房间信息";
            // 
            // msgRoom
            // 
            this.msgRoom.AutoSize = true;
            this.msgRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgRoom.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgRoom.ForeColor = System.Drawing.Color.Red;
            this.msgRoom.Location = new System.Drawing.Point(383, 16);
            this.msgRoom.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgRoom.Name = "msgRoom";
            this.msgRoom.Padding = new System.Windows.Forms.Padding(7);
            this.msgRoom.Size = new System.Drawing.Size(86, 31);
            this.msgRoom.TabIndex = 1;
            this.msgRoom.Text = "msgRoom";
            this.msgRoom.Visible = false;
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(246, 16);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRoom.TabIndex = 1;
            this.btnDeleteRoom.Text = "删除房间";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.Location = new System.Drawing.Point(135, 16);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRoom.TabIndex = 1;
            this.btnUpdateRoom.Text = "修改房间";
            this.btnUpdateRoom.UseVisualStyleBackColor = true;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(30, 16);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "添加房间";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9});
            this.dgvRoom.Location = new System.Drawing.Point(0, 50);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowTemplate.Height = 23;
            this.dgvRoom.Size = new System.Drawing.Size(694, 333);
            this.dgvRoom.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RoomId";
            this.Column1.HeaderText = "RoomId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.HeaderText = "名字";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RoomType";
            this.Column3.HeaderText = "类型";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoomMinMoney";
            this.Column4.HeaderText = "最小金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "RoomMaxNum";
            this.Column5.HeaderText = "最大人数";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "IsDefault";
            this.Column6.HeaderText = "是否默认";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "SubTime";
            this.Column8.HeaderText = "提交时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "SubBy";
            this.Column9.HeaderText = "提交人";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage2.Controls.Add(this.msgDesk);
            this.tabPage2.Controls.Add(this.btnDeleteDesk);
            this.tabPage2.Controls.Add(this.btnUpdateDesk);
            this.tabPage2.Controls.Add(this.btnAddDesk);
            this.tabPage2.Controls.Add(this.dgvDesk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "餐桌信息";
            // 
            // msgDesk
            // 
            this.msgDesk.AutoSize = true;
            this.msgDesk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgDesk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgDesk.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgDesk.ForeColor = System.Drawing.Color.Red;
            this.msgDesk.Location = new System.Drawing.Point(373, 17);
            this.msgDesk.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgDesk.Name = "msgDesk";
            this.msgDesk.Padding = new System.Windows.Forms.Padding(7);
            this.msgDesk.Size = new System.Drawing.Size(86, 31);
            this.msgDesk.TabIndex = 1;
            this.msgDesk.Text = "msgDesk";
            this.msgDesk.Visible = false;
            // 
            // btnDeleteDesk
            // 
            this.btnDeleteDesk.Location = new System.Drawing.Point(235, 17);
            this.btnDeleteDesk.Name = "btnDeleteDesk";
            this.btnDeleteDesk.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDesk.TabIndex = 1;
            this.btnDeleteDesk.Text = "删除餐桌";
            this.btnDeleteDesk.UseVisualStyleBackColor = true;
            this.btnDeleteDesk.Click += new System.EventHandler(this.btnDeleteDesk_Click);
            // 
            // btnUpdateDesk
            // 
            this.btnUpdateDesk.Location = new System.Drawing.Point(142, 17);
            this.btnUpdateDesk.Name = "btnUpdateDesk";
            this.btnUpdateDesk.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDesk.TabIndex = 1;
            this.btnUpdateDesk.Text = "修改餐桌";
            this.btnUpdateDesk.UseVisualStyleBackColor = true;
            this.btnUpdateDesk.Click += new System.EventHandler(this.btnUpdateDesk_Click);
            // 
            // btnAddDesk
            // 
            this.btnAddDesk.Location = new System.Drawing.Point(35, 17);
            this.btnAddDesk.Name = "btnAddDesk";
            this.btnAddDesk.Size = new System.Drawing.Size(75, 23);
            this.btnAddDesk.TabIndex = 1;
            this.btnAddDesk.Text = "添加餐桌";
            this.btnAddDesk.UseVisualStyleBackColor = true;
            this.btnAddDesk.Click += new System.EventHandler(this.btnAddDesk_Click);
            // 
            // dgvDesk
            // 
            this.dgvDesk.AllowUserToAddRows = false;
            this.dgvDesk.AllowUserToDeleteRows = false;
            this.dgvDesk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column16,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dgvDesk.Location = new System.Drawing.Point(0, 54);
            this.dgvDesk.Name = "dgvDesk";
            this.dgvDesk.ReadOnly = true;
            this.dgvDesk.RowTemplate.Height = 23;
            this.dgvDesk.Size = new System.Drawing.Size(698, 325);
            this.dgvDesk.TabIndex = 0;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DeskId";
            this.Column7.HeaderText = "DeskId";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "RoomId";
            this.Column16.HeaderText = "RoomId";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DeskName";
            this.Column10.HeaderText = "名字";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DeskRemark";
            this.Column11.HeaderText = "备注";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DeskRegion";
            this.Column12.HeaderText = "区域";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "DeskState";
            this.Column13.HeaderText = "状态";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "SubTime";
            this.Column14.HeaderText = "创建时间";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "SubBy";
            this.Column15.HeaderText = "创建人";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // FrmRoomAndDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(701, 418);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRoomAndDesk";
            this.Text = "房间和餐桌信息";
            this.Load += new System.EventHandler(this.FrmRoomAndDesk_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvRoom;
        private MsgDiv msgRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnUpdateRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private MsgDiv msgDesk;
        private System.Windows.Forms.Button btnDeleteDesk;
        private System.Windows.Forms.Button btnUpdateDesk;
        private System.Windows.Forms.Button btnAddDesk;
        private System.Windows.Forms.DataGridView dgvDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}