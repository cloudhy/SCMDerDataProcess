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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
