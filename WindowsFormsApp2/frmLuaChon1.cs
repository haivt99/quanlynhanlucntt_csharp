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
    public partial class frmLuaChon1 : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=NguonNhanLucCNTT;Integrated Security=True";

        public frmLuaChon1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            lstKetQua.Items.Clear();
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT tentruong, count(*) as 'so_luong' FROM giangviencntt, cosodaotao WHERE giangvienCNTT.matruong = cosodaotao.matruong GROUP BY cosodaotao.tentruong";
                    

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string tentruong = rdr["tentruong"].ToString();
                                //TenCoQuan.Add(ten_co_quan);
                                int so_luong = int.Parse(rdr["so_luong"].ToString());
                                //SoLuong.Add(so_luong);
                                lstKetQua.Items.AddRange(new object[] { "Tên trường: " + tentruong, "Số lượng giảng viên: " + so_luong });
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



        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo1.SelectedIndex != -1)
            {
                if (cbo1.Text == "Thạc sĩ")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {   
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select count(*) as 'so_luong' from giangviencntt, cosodaotao, nganhdaotao, solieutuyensinh where giangvienCNTT.MaTruong = cosodaotao.matruong and cosodaotao.matruong = solieutuyensinh.matruong and solieutuyensinh.manganh = nganhdaotao.manganh and hocvi = N'Thạc sĩ' and tennganh = N'" + cbbTenNganh.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Số Lượng: " + so_luong });
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
                if (cbo1.Text == "Tiến sĩ")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select count(*) as 'so_luong' from giangviencntt, cosodaotao, nganhdaotao, solieutuyensinh where giangvienCNTT.MaTruong = cosodaotao.matruong and cosodaotao.matruong = solieutuyensinh.matruong and solieutuyensinh.manganh = nganhdaotao.manganh and hocvi = N'Tiến sĩ' and tennganh = N'" + cbbTenNganh.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Số Lượng: " + so_luong });
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
                if (cbo1.Text == "Cử nhân")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select count(*) as 'so_luong' from giangviencntt, cosodaotao, nganhdaotao, solieutuyensinh where giangvienCNTT.MaTruong = cosodaotao.matruong and cosodaotao.matruong = solieutuyensinh.matruong and solieutuyensinh.manganh = nganhdaotao.manganh and hocvi = N'Cử nhân' and tennganh = N'" + cbbTenNganh.SelectedItem + "'";

                            using (SqlCommand cmd = new SqlCommand(q, con))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {

                                        int so_luong = int.Parse(rdr["so_luong"].ToString());
                                        lstKetQua.Items.AddRange(new object[] { "Số Lượng: " + so_luong });
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
        private void frmLuaChon1_Load(object sender, EventArgs e)
        {
            cbo1.Items.Add("Thạc sĩ");
            cbo1.Items.Add("Tiến sĩ");
            cbo1.Items.Add("Cử nhân");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT DISTINCT tennganh FROM nganhdaotao";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {

                            string tennganh = rdr["tennganh"].ToString();
                            cbbTenNganh.Items.Add(tennganh);
                            // lstKetQua.Items.AddRange(new object[] { "Mã khóa học: " + ma_khoa_hoc, "Số Lượng: " + so_luong });
                        }
                    }
                }
            }

        }

        private void btnLuaChon2_Click(object sender, EventArgs e)
        {
            lstKetQua.Items.Clear();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "select truong_Thong.ten_truong as truonghoc, count(*) as so_luong from giangvien, truong_Thong where giangvien.ma_truong = truong_Thong.ma_truong group by truong_Thong.ten_truong";

                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {

                                string truonghoc = rdr["truonghoc"].ToString();
                                int so_luong = int.Parse(rdr["so_luong"].ToString());
                                lstKetQua.Items.AddRange(new object[] { "Tên trường học: " + truonghoc, "Số Lượng giáo viên: " + so_luong });
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

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbbTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstKetQua.Items.Clear();
        }

        private void lstKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
