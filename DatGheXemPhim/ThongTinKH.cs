using DatGheXemPhim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThongTinKH_Load(object sender, EventArgs e)
        {

        }

        
    }
}
