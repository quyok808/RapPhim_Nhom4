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
            dataGridView1.Rows.Clear();
            RapPhimModel context = new RapPhimModel();
            var list = context.GheNgois.ToList();
            foreach (GheNgoi g in list)
            {
                KhachHang kh = context.KhachHangs.FirstOrDefault(p => p.SDT == g.SDT);
                if (kh != null)
                {
                    int newRow = dataGridView1.Rows.Add();
                    dataGridView1.Rows[newRow].Cells[0].Value = kh.TenKH;
                    dataGridView1.Rows[newRow].Cells[1].Value = kh.SDT;
                    dataGridView1.Rows[newRow].Cells[2].Value = g.MaGhe;
                }

            }
        }
        private void TimKiem_Load(object sender, EventArgs e)
        {
            Grid();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string keywordname = txtKeyname.Text;
            string keywordnum = txtKeynum.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && row.Cells[1].Value.ToString().Contains(keywordnum) && row.Cells[0].Value.ToString().Contains(keywordname) )
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKeyname.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKeynum.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = DialogResult.OK;
        }

        private void txtKeynum_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeynum.Text) && string.IsNullOrEmpty(txtKeyname.Text))
            {
                Grid();
            } else
            {
                Find_Click(sender, e);
            }
        }
    }
}
