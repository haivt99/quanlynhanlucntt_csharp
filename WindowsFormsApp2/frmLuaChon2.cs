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
    public partial class frmLuaChon2 : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=NguonNhanLucCNTT;Integrated Security=True";
        public frmLuaChon2()
        {
            InitializeComponent();
        }

        private void frmLuaChon2_Load(object sender, EventArgs e)
        {
            cbbNam.Items.Add("SLSV2014");
            cbbNam.Items.Add("SLSV2015");
            cbbNam.Items.Add("SLSV2016");
            cbbNam.Items.Add("SLSV2017");
            cbbNam.Items.Add("SLSV2018");
            cbbNam.Items.Add("CT2019");
            cbbNam.Items.Add("CT2020");


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
                            cbbNganhDaoTao.Items.Add(tennganh);
                            // lstKetQua.Items.AddRange(new object[] { "Mã khóa học: " + ma_khoa_hoc, "Số Lượng: " + so_luong });
                        }
                    }
                }
            }



        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstKetQua.Items.Clear();
            if (cbbNam.SelectedIndex != -1)
            {
                if (cbbNam.Text == "SLSV2014")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            string q = "select SUM(SLSV2014) as so_luong from solieutuyensinh where MaTruong = N'BKA'";

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

        private void cbbNganhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNganhDaoTao.SelectedIndex != -1)
            {
                //Số lượng SV2014
                if (cbbNam.Text == "SLSV2014")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(SLSV2014) as so_luong from solieutuyensinh, nganhdaotao where solieutuyensinh.MaNganh = nganhdaotao.MaNganh and TenNganh=N'"+cbbNganhDaoTao.SelectedItem+"'";
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

                //Số lượng SV2015
                if (cbbNam.Text == "SLSV2015")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(SLSV2015) as so_luong from solieutuyensinh, nganhdaotao where solieutuyensinh.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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

                //Số lượng SV2016
                if (cbbNam.Text == "SLSV2016")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(SLSV2016) as so_luong from solieutuyensinh, nganhdaotao where solieutuyensinh.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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

                //Số lượng SV2017
                if (cbbNam.Text == "SLSV2017")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(SLSV2017) as so_luong from solieutuyensinh, nganhdaotao where solieutuyensinh.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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

                //Số lượng SV2018
                if (cbbNam.Text == "SLSV2018")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(SLSV2018) as so_luong from solieutuyensinh, nganhdaotao where solieutuyensinh.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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
                //Số lượng SV2019
                if (cbbNam.Text == "CT2019")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(CT2019) as so_luong from solieutuyensinh2019, nganhdaotao where solieutuyensinh2019.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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


                //Số lượng SV2020
                if (cbbNam.Text == "CT2020")
                {
                    lstKetQua.Items.Clear();
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            //string q = "select count(*) as 'so_luong' from giangvien,nganh where  giangvien.ma_nganh=nganh.ma_nganh and hoc_vi = N'Thạc sĩ' and ten_nganh=N'" + cbbTenNganh.SelectedItem + "'";
                            string q = "select SUM(CT2020) as so_luong from solieutuyensinh2020, nganhdaotao where solieutuyensinh2020.MaNganh = nganhdaotao.MaNganh and TenNganh=N'" + cbbNganhDaoTao.SelectedItem + "'";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}