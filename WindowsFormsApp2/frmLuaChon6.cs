using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    public partial class frmLuaChon6 : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=NguonNhanLucCNTT;Integrated Security=True";

        public frmLuaChon6()
        {
            InitializeComponent();
        }

        private void frmLuaChon6_Load(object sender, EventArgs e)
        {
            


            cbbHocVi.Items.Add("Cử nhân");
            cbbHocVi.Items.Add("Thạc sĩ");
            cbbHocVi.Items.Add("Tiến sĩ");
         
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT DISTINCT tentruong FROM cosodaotao ";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {

                            string tentruong = rdr["tentruong"].ToString();
                            cbbTenTruong.Items.Add(tentruong);
                            // lstKetQua.Items.AddRange(new object[] { "Mã khóa học: " + ma_khoa_hoc, "Số Lượng: " + so_luong });
                        }
                    }
                }
            }



        }

        private void cbbTenTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenTruong.SelectedIndex != -1)
            {
                if (cbbHocVi.Text == "Thạc sĩ")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select hoten  from giangvienCNTT as gv ,cosodaotao as cs where gv.matruong = cs.matruong and hocvi=N'Thạc Sĩ' and cs.tentruong =  N'" + cbbTenTruong.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        string hoten = rdr["hoten"].ToString();
                                       // int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Tên giảng viên: " + hoten});
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Kết nối thất bại");
                    }


                }

                //Học vị cử nhân 
                if (cbbHocVi.Text == "Cử nhân")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select hoten  from giangvienCNTT as gv ,cosodaotao as cs where gv.matruong = cs.matruong and hocvi=N'Cử nhân' and cs.tentruong =  N'" + cbbTenTruong.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        string hoten = rdr["hoten"].ToString();
                                        // int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Tên giảng viên: " + hoten });
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Kết nối thất bại");
                    }


                }

                //Học vị tiến sĩ 
                if (cbbHocVi.Text == "Tiến sĩ")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select hoten  from giangvienCNTT as gv ,cosodaotao as cs where gv.matruong = cs.matruong and hocvi=N'Tiến sĩ' and cs.tentruong =  N'" + cbbTenTruong.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        string hoten = rdr["hoten"].ToString();
                                        // int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Tên giảng viên: " + hoten });
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Kết nối thất bại");
                    }


                }
            }
            }

        private void cbbHocVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstKetQua.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
