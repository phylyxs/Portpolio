
namespace Felix_s_Overall_App
{
    partial class outputType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(outputType));
            this.enterID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeOfAnimal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataCol = new System.Windows.Forms.TextBox();
            this.showReport1 = new System.Windows.Forms.Button();
            this.fieldNameCol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.displayReportNo = new System.Windows.Forms.Button();
            this.reportNo = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ageThreshold = new System.Windows.Forms.TextBox();
            this.displayReport = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterID
            // 
            this.enterID.Location = new System.Drawing.Point(21, 56);
            this.enterID.Name = "enterID";
            this.enterID.Size = new System.Drawing.Size(100, 20);
            this.enterID.TabIndex = 0;
            this.enterID.TextChanged += new System.EventHandler(this.enterID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type of Animal:";
            // 
            // typeOfAnimal
            // 
            this.typeOfAnimal.BackColor = System.Drawing.SystemColors.Window;
            this.typeOfAnimal.Location = new System.Drawing.Point(21, 104);
            this.typeOfAnimal.Name = "typeOfAnimal";
            this.typeOfAnimal.ReadOnly = true;
            this.typeOfAnimal.Size = new System.Drawing.Size(100, 20);
            this.typeOfAnimal.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataCol);
            this.groupBox1.Controls.Add(this.showReport1);
            this.groupBox1.Controls.Add(this.fieldNameCol);
            this.groupBox1.Controls.Add(this.typeOfAnimal);
            this.groupBox1.Controls.Add(this.enterID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 268);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report 1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataCol
            // 
            this.dataCol.ForeColor = System.Drawing.SystemColors.Info;
            this.dataCol.Location = new System.Drawing.Point(131, 141);
            this.dataCol.Multiline = true;
            this.dataCol.Name = "dataCol";
            this.dataCol.ReadOnly = true;
            this.dataCol.Size = new System.Drawing.Size(81, 115);
            this.dataCol.TabIndex = 13;
            // 
            // showReport1
            // 
            this.showReport1.Location = new System.Drawing.Point(135, 55);
            this.showReport1.Name = "showReport1";
            this.showReport1.Size = new System.Drawing.Size(75, 23);
            this.showReport1.TabIndex = 7;
            this.showReport1.Text = "Search ID";
            this.showReport1.UseVisualStyleBackColor = true;
            this.showReport1.Click += new System.EventHandler(this.showReport1_Click);
            // 
            // fieldNameCol
            // 
            this.fieldNameCol.ForeColor = System.Drawing.SystemColors.Info;
            this.fieldNameCol.Location = new System.Drawing.Point(15, 141);
            this.fieldNameCol.Multiline = true;
            this.fieldNameCol.Name = "fieldNameCol";
            this.fieldNameCol.ReadOnly = true;
            this.fieldNameCol.Size = new System.Drawing.Size(117, 115);
            this.fieldNameCol.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Enter Report No:";
            // 
            // displayReportNo
            // 
            this.displayReportNo.Location = new System.Drawing.Point(170, 97);
            this.displayReportNo.Name = "displayReportNo";
            this.displayReportNo.Size = new System.Drawing.Size(75, 23);
            this.displayReportNo.TabIndex = 15;
            this.displayReportNo.Text = "Display";
            this.displayReportNo.UseVisualStyleBackColor = true;
            this.displayReportNo.Click += new System.EventHandler(this.displayReportNo_Click);
            // 
            // reportNo
            // 
            this.reportNo.Location = new System.Drawing.Point(125, 38);
            this.reportNo.Name = "reportNo";
            this.reportNo.Size = new System.Drawing.Size(34, 20);
            this.reportNo.TabIndex = 12;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.richTextBox1.Location = new System.Drawing.Point(15, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(474, 247);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Location = new System.Drawing.Point(12, 286);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(502, 290);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Report Menu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ageThreshold);
            this.groupBox2.Controls.Add(this.displayReport);
            this.groupBox2.Controls.Add(this.reportNo);
            this.groupBox2.Controls.Add(this.displayReportNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(255, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 268);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report 2-10, 12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Enter Age Threshold:";
            // 
            // ageThreshold
            // 
            this.ageThreshold.Location = new System.Drawing.Point(125, 70);
            this.ageThreshold.Name = "ageThreshold";
            this.ageThreshold.Size = new System.Drawing.Size(34, 20);
            this.ageThreshold.TabIndex = 19;
            // 
            // displayReport
            // 
            this.displayReport.ForeColor = System.Drawing.SystemColors.Info;
            this.displayReport.Location = new System.Drawing.Point(14, 126);
            this.displayReport.Multiline = true;
            this.displayReport.Name = "displayReport";
            this.displayReport.ReadOnly = true;
            this.displayReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayReport.Size = new System.Drawing.Size(232, 130);
            this.displayReport.TabIndex = 14;
            // 
            // outputType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "outputType";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox enterID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox typeOfAnimal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button showReport1;
        private System.Windows.Forms.TextBox fieldNameCol;
        private System.Windows.Forms.TextBox dataCol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button displayReportNo;
        private System.Windows.Forms.TextBox reportNo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageThreshold;
        private System.Windows.Forms.TextBox displayReport;
    }
}

