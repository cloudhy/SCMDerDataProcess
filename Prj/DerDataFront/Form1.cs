using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DerDataBusiness;
using DerDataModel;

namespace DerDataFront
{
    public partial class Form1 : Form
    {
        private IAutoService autoService=new AutoService();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void buttonGetList_Click(object sender, EventArgs e)
        {

            var derList = ProcessService.GetDerList();
            
            dataGridView1.DataSource = derList;
            dataGridView1.Show();

        }


        /// <summary>
        /// 添加输出参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonAddOP_Click(object sender, EventArgs e)
        {
           
            int count = dataGridView1.Rows.Count;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    string Id, DbId, AccessType, AccessKey;
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        ///赋值
                        Id = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        DbId = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                        AccessType = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                        AccessKey = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                        ProcessService.AddOPara(Id, DbId, AccessKey);

                    }                  

                }

                ProcessService.conn.Close();
                ProcessService.ReviseAlias();
                MessageBox.Show("添加输出参数成功");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == false)
                {
                    checkCell.Value = true;
                }
                else
                {
                    continue;
                }
            }
        }

        private void buttonGetAllList_Click(object sender, EventArgs e)
        {
            var derList = ProcessService.GetDerList(2);

            dataGridView1.DataSource = derList;
            dataGridView1.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            try
            {
                List<string> deleteList = new List<string>();
                for (int i = 0; i < count; i++)
                {
          
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        ///将需要删除的id信息放入list中
                        string id= this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        deleteList.Add(id);

                    }

                }

                ProcessService.DeleteList(deleteList);

                MessageBox.Show("删除成功");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonDerdataCheck_Click(object sender, EventArgs e)
        {
           // autoService = new
            int count = dataGridView1.Rows.Count;
            int errorCount = 0;
            string errorName = "";
            int chooseCount = 0;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    string Id, Name;
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        chooseCount++;
                        ///赋值
                        Id = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Name = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                        bool derdataCheckResult = autoService.DerDataCheck(Id);
                        autoService.UpdateDerDataStatus(Id, derdataCheckResult);
                        if (derdataCheckResult == false)
                        {
                            MessageBox.Show("衍生品" + Name + "测试失败");
                            errorCount++;
                            errorName += Name;

                        }

                    }

                }
                
            }
            catch
            {

            }

            MessageBox.Show("衍生品测试成功，总个数" + chooseCount.ToString() + " 失败个数" + errorCount.ToString() + " 失败名称" + errorName);
          }


        private void buttonPackageDBService_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            int errorCount = 0;
            string errorName = "";
            int chooseCount = 0;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    chooseCount++;
                    string Id, KeyWords;
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        ///赋值
                        Id = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        KeyWords= this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                        bool serviceCatalogResult = autoService.DerDataToDBService(Id);
                        if (serviceCatalogResult == false)
                        {
                            errorCount++;
                            errorName += " " + KeyWords;                
                            MessageBox.Show(String.Format("服务{0}编目失败", KeyWords));
                        }                       
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                MessageBox.Show(String.Format("封装数据服务,总个数：{0}",
                   chooseCount));
                MessageBox.Show(String.Format("封装数据服务编目,失败个数：{0}", 
                    errorCount.ToString()));
                MessageBox.Show(String.Format(" 封装数据服务名称：{0}",
                    errorName));
            }
        }

        private void buttonGetDBSInfo_Click(object sender, EventArgs e)
        {
            var dbsList = autoService.GetDBSInfo();

            dataGridView1.DataSource = dbsList;
            dataGridView1.Show();
        }

        private void buttonServiceCatalog_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            int errorCount = 0;
            string errorName = "";
            try
            {
                for (int i = 0; i < count; i++)
                {
                    string Id, Name;
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        ///赋值
                        Id = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Name = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                        bool serviceCatalogResult = autoService.ServiceAutoCatalog(Id);

                        
                        if (serviceCatalogResult == false)
                        {
                            errorCount++;
                            errorName += " " + Name;
                            MessageBox.Show("服务{0}编目失败", Name);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                MessageBox.Show("服务编目完成,失败个数：{0}",
                    errorCount.ToString());
                MessageBox.Show(" 失败衍生品名称：{0}",
                    errorName);
            }
        }

        

        private void buttonServicePublish_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            int errorCount = 0;
            string errorName = "";
            try
            {
                for (int i = 0; i < count; i++)
                {
                    string Id, UId;
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        ///赋值
                        Id = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        UId = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                        bool servicePublishResult = autoService.ServiceAutoPublish(Id, UId);


                        if (servicePublishResult == false)
                        {
                            errorCount++;
                            errorName += " " + Name;
                            MessageBox.Show("服务{0}编目失败", Name);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                MessageBox.Show("服务编目完成,失败个数：{0}",
                    errorCount.ToString());
                MessageBox.Show(" 失败衍生品名称：{0}",
                    errorName);
            }

        }

        private void buttonServicePrivi_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetUnPublishService_Click(object sender, EventArgs e)
        {
            var dbsList = autoService.GetUnPublishService();

            dataGridView1.DataSource = dbsList;
            dataGridView1.Show();
        }
    }
}
