namespace SchoolManagementSystem.Forms.Exam
{
    partial class FrmExamMarksAssign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExamMarksAssign));
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvwStudentInformation = new System.Windows.Forms.ListView();
            this.exam_marks_assign_id = new System.Windows.Forms.ColumnHeader();
            this.exam_id = new System.Windows.Forms.ColumnHeader();
            this.class_id = new System.Windows.Forms.ColumnHeader();
            this.subject_id = new System.Windows.Forms.ColumnHeader();
            this.Class = new System.Windows.Forms.ColumnHeader();
            this.Subject = new System.Windows.Forms.ColumnHeader();
            this.exam_total_marks = new System.Windows.Forms.ColumnHeader();
            this.theory_marks = new System.Windows.Forms.ColumnHeader();
            this.theory_pass_marks = new System.Windows.Forms.ColumnHeader();
            this.objective_marks = new System.Windows.Forms.ColumnHeader();
            this.objective_pass_marks = new System.Windows.Forms.ColumnHeader();
            this.practical_marks = new System.Windows.Forms.ColumnHeader();
            this.practical_pass_marks = new System.Windows.Forms.ColumnHeader();
            this.result_marks = new System.Windows.Forms.ColumnHeader();
            this.class_test_marks = new System.Windows.Forms.ColumnHeader();
            this.class_test_pass_marks = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPracticalPassNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPracticalTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObjectivePassNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObjectiveTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTheoryPassNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTheoryTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExamTotalNo = new System.Windows.Forms.TextBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtResultMarks = new System.Windows.Forms.TextBox();
            this.txtClassTestPassMarks = new System.Windows.Forms.TextBox();
            this.textClassTestTotal = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSalmon;
            this.label7.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(-1, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1296, 30);
            this.label7.TabIndex = 126;
            this.label7.Text = "Exam Marks Assign";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1272, 507);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.btnRefresh);
            this.groupBox5.Location = new System.Drawing.Point(12, 434);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(447, 61);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(333, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 32);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(192, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 32);
            this.btnSave.TabIndex = 124;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(17, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 32);
            this.btnRefresh.TabIndex = 125;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwStudentInformation);
            this.groupBox3.Location = new System.Drawing.Point(465, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(801, 484);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // lvwStudentInformation
            // 
            this.lvwStudentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwStudentInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lvwStudentInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.exam_marks_assign_id,
            this.exam_id,
            this.class_id,
            this.subject_id,
            this.Class,
            this.Subject,
            this.exam_total_marks,
            this.theory_marks,
            this.theory_pass_marks,
            this.objective_marks,
            this.objective_pass_marks,
            this.practical_marks,
            this.practical_pass_marks,
            this.result_marks,
            this.class_test_marks,
            this.class_test_pass_marks});
            this.lvwStudentInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwStudentInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lvwStudentInformation.FullRowSelect = true;
            this.lvwStudentInformation.GridLines = true;
            this.lvwStudentInformation.HideSelection = false;
            this.lvwStudentInformation.Location = new System.Drawing.Point(6, 19);
            this.lvwStudentInformation.Name = "lvwStudentInformation";
            this.lvwStudentInformation.Size = new System.Drawing.Size(789, 455);
            this.lvwStudentInformation.TabIndex = 164;
            this.lvwStudentInformation.UseCompatibleStateImageBehavior = false;
            this.lvwStudentInformation.View = System.Windows.Forms.View.Details;
            this.lvwStudentInformation.Click += new System.EventHandler(this.lvwStudentInformation_Click);
            // 
            // exam_marks_assign_id
            // 
            this.exam_marks_assign_id.Text = "exam_marks_assign_id";
            this.exam_marks_assign_id.Width = 0;
            // 
            // exam_id
            // 
            this.exam_id.Text = "exam_id";
            this.exam_id.Width = 0;
            // 
            // class_id
            // 
            this.class_id.Text = "class_id";
            this.class_id.Width = 0;
            // 
            // subject_id
            // 
            this.subject_id.Text = "subject_id";
            this.subject_id.Width = 0;
            // 
            // Class
            // 
            this.Class.Text = "Class";
            // 
            // Subject
            // 
            this.Subject.Text = "Subject";
            this.Subject.Width = 120;
            // 
            // exam_total_marks
            // 
            this.exam_total_marks.Text = "Total";
            this.exam_total_marks.Width = 61;
            // 
            // theory_marks
            // 
            this.theory_marks.Text = "T M";
            this.theory_marks.Width = 55;
            // 
            // theory_pass_marks
            // 
            this.theory_pass_marks.Text = "T P M";
            this.theory_pass_marks.Width = 56;
            // 
            // objective_marks
            // 
            this.objective_marks.Text = "O M";
            this.objective_marks.Width = 58;
            // 
            // objective_pass_marks
            // 
            this.objective_pass_marks.Text = "O P M";
            // 
            // practical_marks
            // 
            this.practical_marks.Text = "P M";
            this.practical_marks.Width = 53;
            // 
            // practical_pass_marks
            // 
            this.practical_pass_marks.Text = "P P M";
            // 
            // result_marks
            // 
            this.result_marks.Text = "Result";
            this.result_marks.Width = 61;
            // 
            // class_test_marks
            // 
            this.class_test_marks.Text = "CT";
            this.class_test_marks.Width = 52;
            // 
            // class_test_pass_marks
            // 
            this.class_test_pass_marks.Text = "CT P M";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtPracticalPassNo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtPracticalTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtObjectivePassNo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtObjectiveTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTheoryPassNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTheoryTotal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtExamTotalNo);
            this.groupBox2.Controls.Add(this.cmbSubject);
            this.groupBox2.Controls.Add(this.cmbClass);
            this.groupBox2.Controls.Add(this.cmbExam);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 419);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Result Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(238, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 16);
            this.label12.TabIndex = 40;
            this.label12.Text = "Practical Pass No";
            // 
            // txtPracticalPassNo
            // 
            this.txtPracticalPassNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPracticalPassNo.Location = new System.Drawing.Point(361, 273);
            this.txtPracticalPassNo.Name = "txtPracticalPassNo";
            this.txtPracticalPassNo.Size = new System.Drawing.Size(67, 22);
            this.txtPracticalPassNo.TabIndex = 39;
            this.txtPracticalPassNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 16);
            this.label13.TabIndex = 38;
            this.label13.Text = "Practical Total";
            // 
            // txtPracticalTotal
            // 
            this.txtPracticalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPracticalTotal.Location = new System.Drawing.Point(126, 272);
            this.txtPracticalTotal.Name = "txtPracticalTotal";
            this.txtPracticalTotal.Size = new System.Drawing.Size(88, 22);
            this.txtPracticalTotal.TabIndex = 37;
            this.txtPracticalTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(234, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 16);
            this.label10.TabIndex = 36;
            this.label10.Text = "Objective Pass No";
            // 
            // txtObjectivePassNo
            // 
            this.txtObjectivePassNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectivePassNo.Location = new System.Drawing.Point(361, 230);
            this.txtObjectivePassNo.Name = "txtObjectivePassNo";
            this.txtObjectivePassNo.Size = new System.Drawing.Size(67, 22);
            this.txtObjectivePassNo.TabIndex = 35;
            this.txtObjectivePassNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Objective Total";
            // 
            // txtObjectiveTotal
            // 
            this.txtObjectiveTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectiveTotal.Location = new System.Drawing.Point(126, 230);
            this.txtObjectiveTotal.Name = "txtObjectiveTotal";
            this.txtObjectiveTotal.Size = new System.Drawing.Size(88, 22);
            this.txtObjectiveTotal.TabIndex = 33;
            this.txtObjectiveTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(250, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Theory Pass No";
            // 
            // txtTheoryPassNo
            // 
            this.txtTheoryPassNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheoryPassNo.Location = new System.Drawing.Point(361, 188);
            this.txtTheoryPassNo.Name = "txtTheoryPassNo";
            this.txtTheoryPassNo.Size = new System.Drawing.Size(67, 22);
            this.txtTheoryPassNo.TabIndex = 31;
            this.txtTheoryPassNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Theory Total";
            // 
            // txtTheoryTotal
            // 
            this.txtTheoryTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheoryTotal.Location = new System.Drawing.Point(126, 187);
            this.txtTheoryTotal.Name = "txtTheoryTotal";
            this.txtTheoryTotal.Size = new System.Drawing.Size(88, 22);
            this.txtTheoryTotal.TabIndex = 29;
            this.txtTheoryTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Total Number";
            // 
            // txtExamTotalNo
            // 
            this.txtExamTotalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExamTotalNo.Location = new System.Drawing.Point(126, 146);
            this.txtExamTotalNo.Name = "txtExamTotalNo";
            this.txtExamTotalNo.Size = new System.Drawing.Size(88, 22);
            this.txtExamTotalNo.TabIndex = 27;
            this.txtExamTotalNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // cmbSubject
            // 
            this.cmbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(126, 98);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(302, 24);
            this.cmbSubject.TabIndex = 17;
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(126, 57);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(105, 24);
            this.cmbClass.TabIndex = 16;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // cmbExam
            // 
            this.cmbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Location = new System.Drawing.Point(126, 19);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(105, 24);
            this.cmbExam.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Subject Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Class Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Exam Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtResultMarks);
            this.groupBox4.Controls.Add(this.txtClassTestPassMarks);
            this.groupBox4.Controls.Add(this.textClassTestTotal);
            this.groupBox4.Location = new System.Drawing.Point(8, 310);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 100);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "CT Number";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(268, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 16);
            this.label14.TabIndex = 40;
            this.label14.Text = "CT Pass No";
            // 
            // txtResultMarks
            // 
            this.txtResultMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultMarks.Location = new System.Drawing.Point(118, 23);
            this.txtResultMarks.Name = "txtResultMarks";
            this.txtResultMarks.Size = new System.Drawing.Size(88, 22);
            this.txtResultMarks.TabIndex = 41;
            this.txtResultMarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // txtClassTestPassMarks
            // 
            this.txtClassTestPassMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassTestPassMarks.Location = new System.Drawing.Point(353, 64);
            this.txtClassTestPassMarks.Name = "txtClassTestPassMarks";
            this.txtClassTestPassMarks.Size = new System.Drawing.Size(67, 22);
            this.txtClassTestPassMarks.TabIndex = 39;
            this.txtClassTestPassMarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // textClassTestTotal
            // 
            this.textClassTestTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClassTestTotal.Location = new System.Drawing.Point(118, 64);
            this.textClassTestTotal.Name = "textClassTestTotal";
            this.textClassTestTotal.Size = new System.Drawing.Size(88, 22);
            this.textClassTestTotal.TabIndex = 43;
            this.textClassTestTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamTotalNo_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(8, 129);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(431, 178);
            this.groupBox6.TabIndex = 46;
            this.groupBox6.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(298, 23);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 47;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // FrmExamMarksAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1296, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExamMarksAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Marks Assign";
            this.Load += new System.EventHandler(this.FrmExamMarksAssign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPracticalPassNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPracticalTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtObjectivePassNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObjectiveTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTheoryPassNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTheoryTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExamTotalNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResultMarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textClassTestTotal;
        private System.Windows.Forms.ListView lvwStudentInformation;
        private System.Windows.Forms.ColumnHeader exam_marks_assign_id;
        private System.Windows.Forms.ColumnHeader exam_id;
        private System.Windows.Forms.ColumnHeader class_id;
        private System.Windows.Forms.ColumnHeader subject_id;
        private System.Windows.Forms.ColumnHeader Class;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtClassTestPassMarks;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader exam_total_marks;
        private System.Windows.Forms.ColumnHeader theory_marks;
        private System.Windows.Forms.ColumnHeader theory_pass_marks;
        private System.Windows.Forms.ColumnHeader objective_marks;
        private System.Windows.Forms.ColumnHeader objective_pass_marks;
        private System.Windows.Forms.ColumnHeader practical_marks;
        private System.Windows.Forms.ColumnHeader practical_pass_marks;
        private System.Windows.Forms.ColumnHeader result_marks;
        private System.Windows.Forms.ColumnHeader class_test_marks;
        private System.Windows.Forms.ColumnHeader class_test_pass_marks;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnView;
    }
}