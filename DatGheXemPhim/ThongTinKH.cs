using DatGheXemPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Bằng 
namespace DatGheXemPhim
{
    public partial class ThongTinKH : Form
    {
        public ThongTinKH()
        {
            InitializeComponent();
        }
        static RapPhimModel rp = new RapPhimModel();
        public bool checkNull()
        {
            if (txtName.Text == "" || txtSDT.Text == "")
                return false;
            return true;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNull() == false)
                {
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo");
                }
                else
                {
                    KhachHang kh = new KhachHang();
                    {
                        kh.TenKH = txtName.Text;
                        kh.SDT = txtSDT.Text;
                    };
                    rp.KhachHangs.Add(kh);
                    rp.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
