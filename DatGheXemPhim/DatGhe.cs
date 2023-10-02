//using DatGheXemPhim.Models;
using DatGheXemPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatGheXemPhim
{
    public partial class DatGhe : Form
    {
        public DatGhe()
        {
            InitializeComponent();
        }
        int tong;

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Blue;
            }
            else if (btn.BackColor == Color.Gray)
            {
                MessageBox.Show("Ghe nay da co nguoi chon !!!", "Thong bao", MessageBoxButtons.OK);
            }
            else
            {
                btn.BackColor = Color.White;
            }
        }

        private int ThanhTien(Button btn)
        {

            if (btn.Name.Contains("A") || btn.Name.Contains("B") || btn.Name.Contains("C") || btn.Name.Contains("D"))
            {
                tong += 30000;
            }
            else if (btn.Name.Contains("E") || btn.Name.Contains("F") || btn.Name.Contains("G") || btn.Name.Contains("H") || btn.Name.Contains("J"))
            {
                tong += 50000;
            }
            else if (btn.Name.Contains("K"))
            {
                tong += 100000;
            }

            return tong;
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            RapPhimModel contextDB = new RapPhimModel();
            List<GheNgoi> g = contextDB.GheNgois.Where(p => p.SDT == txtInfor_SDT.Text).ToList();
            foreach (Button btn in groupBox1.Controls)
            {
                KhachHang kh = contextDB.KhachHangs.FirstOrDefault(p => p.SDT == txtInfor_SDT.Text);
                for (int i = 0; i < g.Count; i++)
                {
                    if (btn.Name.Trim() == g[i].MaGhe.Trim())
                    {
                        btn.BackColor = Color.White;
                        contextDB.KhachHangs.Remove(kh);
                        g[i].TrangThai = 0;
                    }
                }
            }
            contextDB.SaveChanges();
            txtInfor_SDT.Text = null;
        }

        private void DatGhe_Load(object sender, EventArgs e)
        {
            string tiento = "ABCDEFGHJK";
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char c = tiento[j];
                    Button btn = new Button();
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.Size = new System.Drawing.Size(36, 31);
                    btn.Font = new System.Drawing.Font("Times New Roman", 6.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.BackColor = Color.White;

                    btn.Name = c + (i + 1).ToString();
                    btn.TabIndex = 1;
                    btn.Text = c + (i + 1).ToString();
                    btn.UseVisualStyleBackColor = false;
                    btn.Click += Button_Click;

                    btn.Location = new System.Drawing.Point(71 + i * 50, 27 + j * 40);
                    groupBox1.Controls.Add(btn);
                    if (j > 3)
                    {
                        btn.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                char c = tiento[9];
                Button btn = new Button();
                btn.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Size = new System.Drawing.Size(36, 31);
                btn.Font = new System.Drawing.Font("Times New Roman", 6.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.BackColor = Color.White;

                btn.Name = c + (i + 1).ToString();
                btn.TabIndex = 1;
                btn.Text = c + (i + 1).ToString();
                btn.UseVisualStyleBackColor = false;
                btn.Click += Button_Click;

                btn.Location = new System.Drawing.Point(18 + i * 50, 387);
                groupBox1.Controls.Add(btn);
            }
            tong = 0;
        }
        
        private void btnChon_Click(object sender, EventArgs e)
        {
            RapPhimModel context = new RapPhimModel();
            List<GheNgoi> gh = context.GheNgois.ToList();
            {
                foreach (Button b in groupBox1.Controls)
                {
                    GheNgoi g = context.GheNgois.FirstOrDefault(p => p.MaGhe.Trim() == b.Name.Trim());
                    if (b.BackColor == Color.Blue)
                    {
                        b.BackColor = Color.Gray;
                        g.TrangThai = 1;
                    }                   
                }
                context.SaveChanges();
            }           
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {        
            foreach (Button btn1 in groupBox1.Controls)
            {

                if (btn1.BackColor == Color.Blue)
                {
                    btn1.BackColor = Color.White;

                }
            }
        }
    }
}
    

