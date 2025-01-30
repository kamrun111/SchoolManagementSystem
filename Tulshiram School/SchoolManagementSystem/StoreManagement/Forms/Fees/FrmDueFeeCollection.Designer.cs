namespace SchoolManagementSystem.Forms.Fees
{
    partial class FrmDueFeeCollection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnfresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtFineAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNetPayable = new System.Windows.Forms.Label();
            this.txtNetPayable = new System.Windows.Forms.TextBox();
            this.lvwDueList = new System.Windows.Forms.ListView();
            this.fee_collection_id = new System.Windows.Forms.ColumnHeader();
            this.Reg = new System.Windows.Forms.ColumnHeader();
            this.Class = new System.Windows.Forms.ColumnHeader();
            this.Roll = new System.Windows.Forms.ColumnHeader();
            this.Student_Name = new System.Windows.Forms.ColumnHeader();
            this.Invoice = new System.Windows.Forms.ColumnHeader();
            this.fee_month = new System.Windows.Forms.ColumnHeader();
            this.Paid_amount = new System.Windows.Forms.ColumnHeader();
            this.balance = new System.Windows.Forms.ColumnHeader();
            this.grpPatient = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdFeeCollection = new System.Windows.Forms.DataGridView();
            this.FeeCollectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_catagory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fees_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.grpPatient.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeCollection)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSalmon;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(-3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1227, 30);
            this.label7.TabIndex = 124;
            this.label7.Text = "Due Collection";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.btnfresh);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(589, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 75);
            this.groupBox3.TabIndex = 140;
            this.groupBox3.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::SchoolManagementSystem.Properties.Resources.PrintPreviewSmall;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(153, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 33);
            this.btnPrint.TabIndex = 139;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnfresh
            // 
            this.btnfresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfresh.ForeColor = System.Drawing.Color.Black;
            this.btnfresh.Image = global::SchoolManagementSystem.Properties.Resources.RefreshSmall;
            this.btnfresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfresh.Location = new System.Drawing.Point(31, 23);
            this.btnfresh.Name = "btnfresh";
            this.btnfresh.Size = new System.Drawing.Size(71, 33);
            this.btnfresh.TabIndex = 98;
            this.btnfresh.Text = "Refresh";
            this.btnfresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfresh.UseVisualStyleBackColor = true;
            this.btnfresh.Click += new System.EventHandler(this.btnfresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SchoolManagementSystem.Properties.Resources.CloseSmall;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(505, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SchoolManagementSystem.Properties.Resources.SaveSmall;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(389, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 33);
            this.btnSave.TabIndex = 137;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtTotalAmount.Location = new System.Drawing.Point(977, 214);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(86, 22);
            this.txtTotalAmount.TabIndex = 130;
            this.txtTotalAmount.Tag = "";
            this.txtTotalAmount.Text = "00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDue
            // 
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.Location = new System.Drawing.Point(388, 336);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(86, 22);
            this.txtDue.TabIndex = 133;
            this.txtDue.Text = "00";
            this.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFineAmount
            // 
            this.txtFineAmount.Enabled = false;
            this.txtFineAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFineAmount.Location = new System.Drawing.Point(389, 232);
            this.txtFineAmount.Name = "txtFineAmount";
            this.txtFineAmount.Size = new System.Drawing.Size(85, 22);
            this.txtFineAmount.TabIndex = 135;
            this.txtFineAmount.Text = "00";
            this.txtFineAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(283, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 127;
            this.label5.Text = "Due Amount :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAdvance
            // 
            this.txtAdvance.Enabled = false;
            this.txtAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvance.Location = new System.Drawing.Point(388, 301);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(87, 22);
            this.txtAdvance.TabIndex = 134;
            this.txtAdvance.Text = "00";
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(282, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 129;
            this.label6.Text = "Fine Amount :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetPayable
            // 
            this.lblNetPayable.AutoSize = true;
            this.lblNetPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetPayable.ForeColor = System.Drawing.Color.Maroon;
            this.lblNetPayable.Location = new System.Drawing.Point(285, 270);
            this.lblNetPayable.Name = "lblNetPayable";
            this.lblNetPayable.Size = new System.Drawing.Size(98, 16);
            this.lblNetPayable.TabIndex = 132;
            this.lblNetPayable.Text = "Net Payable:";
            // 
            // txtNetPayable
            // 
            this.txtNetPayable.BackColor = System.Drawing.Color.White;
            this.txtNetPayable.Enabled = false;
            this.txtNetPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetPayable.Location = new System.Drawing.Point(389, 267);
            this.txtNetPayable.Name = "txtNetPayable";
            this.txtNetPayable.ReadOnly = true;
            this.txtNetPayable.Size = new System.Drawing.Size(86, 22);
            this.txtNetPayable.TabIndex = 131;
            this.txtNetPayable.Text = "00";
            this.txtNetPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvwDueList
            // 
            this.lvwDueList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lvwDueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fee_collection_id,
            this.Reg,
            this.Class,
            this.Roll,
            this.Student_Name,
            this.Invoice,
            this.fee_month,
            this.Paid_amount,
            this.balance});
            this.lvwDueList.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDueList.ForeColor = System.Drawing.Color.Black;
            this.lvwDueList.FullRowSelect = true;
            this.lvwDueList.GridLines = true;
            this.lvwDueList.HideSelection = false;
            this.lvwDueList.Location = new System.Drawing.Point(9, 59);
            this.lvwDueList.Name = "lvwDueList";
            this.lvwDueList.Size = new System.Drawing.Size(554, 388);
            this.lvwDueList.TabIndex = 141;
            this.lvwDueList.UseCompatibleStateImageBehavior = false;
            this.lvwDueList.View = System.Windows.Forms.View.Details;
            this.lvwDueList.Click += new System.EventHandler(this.lvwDueList_Click);
            // 
            // fee_collection_id
            // 
            this.fee_collection_id.Text = "fee_collection_id";
            this.fee_collection_id.Width = 0;
            // 
            // Reg
            // 
            this.Reg.Text = "Reg.";
            this.Reg.Width = 50;
            // 
            // Class
            // 
            this.Class.Text = "Class";
            this.Class.Width = 70;
            // 
            // Roll
            // 
            this.Roll.Text = "Roll";
            this.Roll.Width = 45;
            // 
            // Student_Name
            // 
            this.Student_Name.Text = "Name";
            this.Student_Name.Width = 180;
            // 
            // Invoice
            // 
            this.Invoice.Text = "Invoice No";
            this.Invoice.Width = 124;
            // 
            // fee_month
            // 
            this.fee_month.Text = "Month";
            // 
            // Paid_amount
            // 
            this.Paid_amount.Text = "Paid_amount";
            this.Paid_amount.Width = 0;
            // 
            // balance
            // 
            this.balance.Text = "balance";
            this.balance.Width = 0;
            // 
            // grpPatient
            // 
            this.grpPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPatient.Controls.Add(this.label3);
            this.grpPatient.Controls.Add(this.lvwDueList);
            this.grpPatient.Controls.Add(this.txtRegSearch);
            this.grpPatient.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPatient.ForeColor = System.Drawing.Color.Red;
            this.grpPatient.Location = new System.Drawing.Point(17, 58);
            this.grpPatient.Name = "grpPatient";
            this.grpPatient.Size = new System.Drawing.Size(573, 453);
            this.grpPatient.TabIndex = 125;
            this.grpPatient.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Reg No";
            // 
            // txtRegSearch
            // 
            this.txtRegSearch.BackColor = System.Drawing.Color.White;
            this.txtRegSearch.Location = new System.Drawing.Point(126, 24);
            this.txtRegSearch.MaxLength = 100;
            this.txtRegSearch.Name = "txtRegSearch";
            this.txtRegSearch.Size = new System.Drawing.Size(365, 23);
            this.txtRegSearch.TabIndex = 2;
            this.txtRegSearch.Tag = "patient_name";
            this.txtRegSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(877, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 128;
            this.label4.Text = "Grand Total:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdFeeCollection);
            this.groupBox2.Controls.Add(this.txtDue);
            this.groupBox2.Controls.Add(this.txtFineAmount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtAdvance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblNetPayable);
            this.groupBox2.Controls.Add(this.txtNetPayable);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(589, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 373);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            // 
            // grdFeeCollection
            // 
            this.grdFeeCollection.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rupee Foradian", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFeeCollection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFeeCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFeeCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeeCollectionID,
            this.fee_name,
            this.payment_catagory,
            this.fees_type,
            this.amount,
            this.month});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rupee Foradian", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFeeCollection.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdFeeCollection.Location = new System.Drawing.Point(11, 18);
            this.grdFeeCollection.Name = "grdFeeCollection";
            this.grdFeeCollection.Size = new System.Drawing.Size(578, 169);
            this.grdFeeCollection.TabIndex = 136;
            // 
            // FeeCollectionID
            // 
            this.FeeCollectionID.HeaderText = "FeeCollectionDetailsID";
            this.FeeCollectionID.Name = "FeeCollectionID";
            this.FeeCollectionID.Width = 5;
            // 
            // fee_name
            // 
            this.fee_name.HeaderText = "Fee Name";
            this.fee_name.Name = "fee_name";
            this.fee_name.Width = 150;
            // 
            // payment_catagory
            // 
            this.payment_catagory.HeaderText = "Payment";
            this.payment_catagory.Name = "payment_catagory";
            this.payment_catagory.Width = 120;
            // 
            // fees_type
            // 
            this.fees_type.HeaderText = "Type";
            this.fees_type.Name = "fees_type";
            this.fees_type.Width = 75;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 80;
            // 
            // month
            // 
            this.month.HeaderText = "Month";
            this.month.Name = "month";
            this.month.Width = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(281, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 126;
            this.label2.Text = "Already Paid:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(7, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1201, 479);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            // 
            // FrmDueFeeCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1220, 534);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpPatient);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDueFeeCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Due Fees Collection";
            this.Load += new System.EventHandler(this.FrmDueFeeCollection_Load);
            this.groupBox3.ResumeLayout(false);
            this.grpPatient.ResumeLayout(false);
            this.grpPatient.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeCollection)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnfresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.TextBox txtFineAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNetPayable;
        private System.Windows.Forms.TextBox txtNetPayable;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListView lvwDueList;
        private System.Windows.Forms.GroupBox grpPatient;
        private System.Windows.Forms.TextBox txtRegSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdFeeCollection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader Reg;
        private System.Windows.Forms.ColumnHeader Class;
        private System.Windows.Forms.ColumnHeader Roll;
        private System.Windows.Forms.ColumnHeader Student_Name;
        private System.Windows.Forms.ColumnHeader Invoice;
        private System.Windows.Forms.ColumnHeader fee_collection_id;
        private System.Windows.Forms.ColumnHeader fee_month;
        private System.Windows.Forms.ColumnHeader Paid_amount;
        private System.Windows.Forms.ColumnHeader balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeCollectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_catagory;
        private System.Windows.Forms.DataGridViewTextBoxColumn fees_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
    }
}