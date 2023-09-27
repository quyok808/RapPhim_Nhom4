using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
