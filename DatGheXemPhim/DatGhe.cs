﻿//using DatGheXemPhim.Models;
using DatGheXemPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        #region Load Form 
        private void DatGhe_Load(object sender, EventArgs e)
        {
            RapPhimModel db = new RapPhimModel();
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
                    btn.BackColorChanged += btnBackGround_Changed;

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
                btn.BackColorChanged += btnBackGround_Changed;

                btn.Location = new System.Drawing.Point(18 + i * 50, 387);
                groupBox1.Controls.Add(btn);
            }

            foreach (Button btn in groupBox1.Controls)
            {
                GheNgoi g = db.GheNgois.FirstOrDefault(p => p.MaGhe.Trim() == btn.Name.Trim());
                if (g.TrangThai == 1 && g != null)
                {
                    btn.BackColor = Color.Gray;
                }
                else
                {
                    btn.BackColor = Color.White;
                }
            }
            lbThanhTien.Text = "0";
        }
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
        #endregion
        #region Chọn ghế, Huỷ ghế đang chọn
        private bool CheckGhe()
            {
                int dachon = 0;
                foreach (Button b in groupBox1.Controls)
                {
                    if (b.BackColor == Color.Blue)
                    {
                        dachon++;
                    }
                }
                if (dachon > 0)
                {
                    return true;
                }
                return false;
            }
        private void BtnChon_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang();
                if (CheckGhe() == true)
                {
                    RapPhimModel context = new RapPhimModel();
                    #region Thêm thông tin khách hàng - Bằng
                    ThongTinKH formTTKH = new ThongTinKH();

                    if (formTTKH.ShowDialog() == DialogResult.OK)
                    {
                        List<GheNgoi> gh = context.GheNgois.ToList();
                        {
                            foreach (Button b in groupBox1.Controls)
                            {
                                GheNgoi g = context.GheNgois.FirstOrDefault(p => p.MaGhe.Trim() == b.Name.Trim());
                                if (b.BackColor == Color.Blue)
                                {
                                    b.BackColor = Color.Gray;
                                    g.TrangThai = 1;
                                    lbThanhTien.Text = ThanhTien(b).ToString();
                                    g.SDT = formTTKH.txtSDT.Text;
                                }
                            }

                        }
                        kh.TenKH = formTTKH.txtName.Text;
                        kh.SDT = formTTKH.txtSDT.Text;
                        context.KhachHangs.Add(kh);
                        context.SaveChanges();
                        tong = 0;
                    }
                    else
                    {
                        DatGhe_Load(sender, e);
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn ghế !!!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai định dạng SDT (SDT quá dài)", "Thông báo", MessageBoxButtons.OK);
                DatGhe_Load(sender, e);
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
        #endregion
        #region Tính tiền, Huỷ vé 
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
            txtInfor_Name.Text = null;
            lbThanhTien.Text = "0";
            tong = 0;
        }
        #endregion
        #region tìm kiếm theo sđt, theo tên
        private void btnFind_Click(object sender, EventArgs e)
        {
            foreach (Button btn in this.groupBox1.Controls)
            {
                if (btn.BackColor == Color.Yellow)
                {
                    btn.BackColor = Color.Gray;
                }
            }
            tong = 0;
            TimKiem tk = new TimKiem();
            if (tk.ShowDialog() == DialogResult.OK)
            {
                txtInfor_Name.Text = tk.txtKeyname.Text;
                txtInfor_SDT.Text = tk.txtKeynum.Text;
            }       
        }
        #endregion
        private void txtInfor_SDT_TextChanged(object sender, EventArgs e)
        {
            RapPhimModel contextDB = new RapPhimModel();
            List<GheNgoi> g = contextDB.GheNgois.Where(p => p.SDT == txtInfor_SDT.Text).ToList();
            for (int i = 0; i < g.Count; i++)
            {
                foreach (Button btn in this.groupBox1.Controls)
                {
                    if (btn.Name.Trim() == g[i].MaGhe.Trim())
                    {
                        btn.BackColor = Color.Yellow;
                        lbThanhTien.Text = ThanhTien(btn).ToString();
                    }
                }
            }
        }

        private void btnBackGround_Changed(object sender, EventArgs e)
        {
            foreach (Button btn in groupBox1.Controls)
            {
                if (btn.BackColor == Color.Blue)
                {
                    foreach (Button btn1 in groupBox1.Controls)
                    {
                        if ( btn1.BackColor == Color.Yellow)
                        {
                            btn1.BackColor = Color.Gray;
                            txtInfor_Name.Text = txtInfor_SDT.Text = null;
                            lbThanhTien.Text = "0";
                        }
                    }
                }
            }
        }
    }
}