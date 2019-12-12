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
            this.buttonPackageDBService = new System.Windows.Forms.Button();
            this.buttonServiceCatalog = new System.Windows.Forms.Button();
            this.buttonServicePublish = new System.Windows.Forms.Button();
            this.buttonServicePrivi = new System.Windows.Forms.Button();
            this.buttonDerdataCheck = new System.Windows.Forms.Button();
            this.buttonGetDBSInfo = new System.Windows.Forms.Button();
            this.buttonGetUnPublishService = new System.Windows.Forms.Button();
            this.buttonOneKey = new System.Windows.Forms.Button();
            this.buttonDeleteDedataRelationInfo = new System.Windows.Forms.Button();
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
            this.dataGridView1.Size = new System.Drawing.Size(1258, 458);
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
            this.buttonAddOP.Location = new System.Drawing.Point(592, 13);
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
            this.checkBox1.Location = new System.Drawing.Point(136, 112);
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
            // buttonPackageDBService
            // 
            this.buttonPackageDBService.Location = new System.Drawing.Point(1006, 13);
            this.buttonPackageDBService.Name = "buttonPackageDBService";
            this.buttonPackageDBService.Size = new System.Drawing.Size(114, 23);
            this.buttonPackageDBService.TabIndex = 7;
            this.buttonPackageDBService.Text = "封装数据服务";
            this.buttonPackageDBService.UseVisualStyleBackColor = true;
            this.buttonPackageDBService.Click += new System.EventHandler(this.buttonPackageDBService_Click);
            // 
            // buttonServiceCatalog
            // 
            this.buttonServiceCatalog.Location = new System.Drawing.Point(1138, 13);
            this.buttonServiceCatalog.Name = "buttonServiceCatalog";
            this.buttonServiceCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonServiceCatalog.TabIndex = 8;
            this.buttonServiceCatalog.Text = "自动编目";
            this.buttonServiceCatalog.UseVisualStyleBackColor = true;
            this.buttonServiceCatalog.Click += new System.EventHandler(this.buttonServiceCatalog_Click);
            // 
            // buttonServicePublish
            // 
            this.buttonServicePublish.Location = new System.Drawing.Point(182, 51);
            this.buttonServicePublish.Name = "buttonServicePublish";
            this.buttonServicePublish.Size = new System.Drawing.Size(75, 23);
            this.buttonServicePublish.TabIndex = 9;
            this.buttonServicePublish.Text = "自动发布";
            this.buttonServicePublish.UseVisualStyleBackColor = true;
            this.buttonServicePublish.Click += new System.EventHandler(this.buttonServicePublish_Click);
            // 
            // buttonServicePrivi
            // 
            this.buttonServicePrivi.Location = new System.Drawing.Point(290, 51);
            this.buttonServicePrivi.Name = "buttonServicePrivi";
            this.buttonServicePrivi.Size = new System.Drawing.Size(75, 23);
            this.buttonServicePrivi.TabIndex = 10;
            this.buttonServicePrivi.Text = "自动授权";
            this.buttonServicePrivi.UseVisualStyleBackColor = true;
            this.buttonServicePrivi.Click += new System.EventHandler(this.buttonServicePrivi_Click);
            // 
            // buttonDerdataCheck
            // 
            this.buttonDerdataCheck.Location = new System.Drawing.Point(731, 11);
            this.buttonDerdataCheck.Name = "buttonDerdataCheck";
            this.buttonDerdataCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonDerdataCheck.TabIndex = 11;
            this.buttonDerdataCheck.Text = "衍生品测试";
            this.buttonDerdataCheck.UseVisualStyleBackColor = true;
            this.buttonDerdataCheck.Click += new System.EventHandler(this.buttonDerdataCheck_Click);
            // 
            // buttonGetDBSInfo
            // 
            this.buttonGetDBSInfo.Location = new System.Drawing.Point(836, 13);
            this.buttonGetDBSInfo.Name = "buttonGetDBSInfo";
            this.buttonGetDBSInfo.Size = new System.Drawing.Size(135, 23);
            this.buttonGetDBSInfo.TabIndex = 12;
            this.buttonGetDBSInfo.Text = "获取未编目数据服务";
            this.buttonGetDBSInfo.UseVisualStyleBackColor = true;
            this.buttonGetDBSInfo.Click += new System.EventHandler(this.buttonGetDBSInfo_Click);
            // 
            // buttonGetUnPublishService
            // 
            this.buttonGetUnPublishService.Location = new System.Drawing.Point(36, 51);
            this.buttonGetUnPublishService.Name = "buttonGetUnPublishService";
            this.buttonGetUnPublishService.Size = new System.Drawing.Size(105, 23);
            this.buttonGetUnPublishService.TabIndex = 13;
            this.buttonGetUnPublishService.Text = "获取未发布服务";
            this.buttonGetUnPublishService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetUnPublishService.UseVisualStyleBackColor = true;
            this.buttonGetUnPublishService.Click += new System.EventHandler(this.buttonGetUnPublishService_Click);
            // 
            // buttonOneKey
            // 
            this.buttonOneKey.Location = new System.Drawing.Point(415, 50);
            this.buttonOneKey.Name = "buttonOneKey";
            this.buttonOneKey.Size = new System.Drawing.Size(131, 23);
            this.buttonOneKey.TabIndex = 14;
            this.buttonOneKey.Text = "一键发布授权";
            this.buttonOneKey.UseVisualStyleBackColor = true;
            this.buttonOneKey.Click += new System.EventHandler(this.buttonOneClick_Click);
            // 
            // buttonDeleteDedataRelationInfo
            // 
            this.buttonDeleteDedataRelationInfo.Location = new System.Drawing.Point(592, 49);
            this.buttonDeleteDedataRelationInfo.Name = "buttonDeleteDedataRelationInfo";
            this.buttonDeleteDedataRelationInfo.Size = new System.Drawing.Size(214, 23);
            this.buttonDeleteDedataRelationInfo.TabIndex = 15;
            this.buttonDeleteDedataRelationInfo.Text = "删除该衍生品所有信息";
            this.buttonDeleteDedataRelationInfo.UseVisualStyleBackColor = true;
            this.buttonDeleteDedataRelationInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 579);
            this.Controls.Add(this.buttonDeleteDedataRelationInfo);
            this.Controls.Add(this.buttonOneKey);
            this.Controls.Add(this.buttonGetUnPublishService);
            this.Controls.Add(this.buttonGetDBSInfo);
            this.Controls.Add(this.buttonDerdataCheck);
            this.Controls.Add(this.buttonServicePrivi);
            this.Controls.Add(this.buttonServicePublish);
            this.Controls.Add(this.buttonServiceCatalog);
            this.Controls.Add(this.buttonPackageDBService);
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
        private System.Windows.Forms.Button buttonPackageDBService;
        private System.Windows.Forms.Button buttonServiceCatalog;
        private System.Windows.Forms.Button buttonServicePublish;
        private System.Windows.Forms.Button buttonServicePrivi;
        private System.Windows.Forms.Button buttonDerdataCheck;
        private System.Windows.Forms.Button buttonGetDBSInfo;
        private System.Windows.Forms.Button buttonGetUnPublishService;
        private System.Windows.Forms.Button buttonOneKey;
        private System.Windows.Forms.Button buttonDeleteDedataRelationInfo;
    }
}

