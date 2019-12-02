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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetList
            // 
            this.buttonGetList.Location = new System.Drawing.Point(51, 13);
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
            this.dataGridView1.Location = new System.Drawing.Point(51, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(744, 386);
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
            this.buttonAddOP.Location = new System.Drawing.Point(606, 12);
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
            this.checkBox1.Location = new System.Drawing.Point(136, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonGetAllList
            // 
            this.buttonGetAllList.Location = new System.Drawing.Point(252, 13);
            this.buttonGetAllList.Name = "buttonGetAllList";
            this.buttonGetAllList.Size = new System.Drawing.Size(143, 23);
            this.buttonGetAllList.TabIndex = 6;
            this.buttonGetAllList.Text = "获取全部衍生品";
            this.buttonGetAllList.UseVisualStyleBackColor = true;
            this.buttonGetAllList.Click += new System.EventHandler(this.buttonGetAllList_Click);
            // 
            // buttonDeleteOPara
            // 
            this.buttonDeleteOPara.Location = new System.Drawing.Point(413, 13);
            this.buttonDeleteOPara.Name = "buttonDeleteOPara";
            this.buttonDeleteOPara.Size = new System.Drawing.Size(143, 23);
            this.buttonDeleteOPara.TabIndex = 6;
            this.buttonDeleteOPara.Text = "删除衍生品输出参数";
            this.buttonDeleteOPara.UseVisualStyleBackColor = true;
            this.buttonDeleteOPara.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 440);
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
    }
}

