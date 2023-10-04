using DatGheXemPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DatGheXemPhim
{
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }
        #region tìm kiếm theo sđt, theo tên - Xuân Huy
        public void Grid()
        {
            RapPhimModel context = new RapPhimModel();
            //var listkh = context.KhachHangs.ToList();
            var list = context.GheNgois.ToList();
            foreach (GheNgoi g in list)
            {
                int newRow = dataGridView1.Rows.Add();
                dataGridView1.Rows[newRow].Cells[0].Value = g.KhachHang.TenKH;
                dataGridView1.Rows[newRow].Cells[1].Value = g.KhachHang.SDT;
                dataGridView1.Rows[newRow].Cells[2].Value = g.MaGhe;
            }
        }
        private void TimKiem_Load(object sender, EventArgs e)
        {
            Grid();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();

            DatGhe dg = new DatGhe();
            dg.Show();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string keywordname = txtKeyname.Text;
            string keywordnum = txtKeynum.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(keywordnum) && cell.Value.ToString().Contains(keywordname) )
                    {
                        row.Visible = true;
                        break;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
        #endregion
    }
}
