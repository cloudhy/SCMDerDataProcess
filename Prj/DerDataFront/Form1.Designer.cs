namespace DerDataFront
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonAddOP = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonGetAllList = new System.Windows.Forms.Button();
            this.buttonDeleteOPara = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetList
            // 
            this.buttonGetList.Location = new System.Drawing.Point(36, 12);
            this.buttonGetList.Name = "buttonGetList";
            this.buttonGetList.Size = new System.Drawing.Size(176, 23);
            this.buttonGetList.TabIndex = 0;
            this.buttonGetList.Text = "获取无输出参数衍生品";
            this.buttonGetList.UseVisualStyleBackColor = true;
            this.buttonGetList.Click += new System.EventHandler(this.buttonGetList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSelect});
            this.dataGridView1.Location = new System.Drawing.Point(51, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(744, 319);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ColumnSelect
            // 
            this.ColumnSelect.HeaderText = "全选";
            this.ColumnSelect.Name = "ColumnSelect";
            // 
            // buttonAddOP
            // 
            this.buttonAddOP.Location = new System.Drawing.Point(603, 11);
            this.buttonAddOP.Name = "buttonAddOP";
            this.buttonAddOP.Size = new System.Drawing.Size(94, 23);
            this.buttonAddOP.TabIndex = 4;
            this.buttonAddOP.Text = "添加输出参数";
            this.buttonAddOP.UseVisualStyleBackColor = true;
            this.buttonAddOP.Click += new System.EventHandler(this.buttonAddOP_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(135, 133);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonGetAllList
            // 
            this.buttonGetAllList.Location = new System.Drawing.Point(239, 12);
            this.buttonGetAllList.Name = "buttonGetAllList";
            this.buttonGetAllList.Size = new System.Drawing.Size(143, 23);
            this.buttonGetAllList.TabIndex = 6;
            this.buttonGetAllList.Text = "获取全部衍生品";
            this.buttonGetAllList.UseVisualStyleBackColor = true;
            this.buttonGetAllList.Click += new System.EventHandler(this.buttonGetAllList_Click);
            // 
            // buttonDeleteOPara
            // 
            this.buttonDeleteOPara.Location = new System.Drawing.Point(415, 13);
            this.buttonDeleteOPara.Name = "buttonDeleteOPara";
            this.buttonDeleteOPara.Size = new System.Drawing.Size(143, 23);
            this.buttonDeleteOPara.TabIndex = 6;
            this.buttonDeleteOPara.Text = "删除衍生品输出参数";
            this.buttonDeleteOPara.UseVisualStyleBackColor = true;
            this.buttonDeleteOPara.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "封装数据服务";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "自动编目";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(415, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "自动发布";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(603, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "自动授权";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 440);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDeleteOPara);
            this.Controls.Add(this.buttonGetAllList);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonAddOP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGetList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelect;
        private System.Windows.Forms.Button buttonAddOP;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonGetAllList;
        private System.Windows.Forms.Button buttonDeleteOPara;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

