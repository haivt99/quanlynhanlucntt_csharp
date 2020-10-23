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
    public partial class Form1 : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=NguonNhanLucCNTT;Integrated Security=True";
        //SELECT DISTINCT ten_truong FROM giangviencntt,cosodaotao where giangviencntt.matruong=cosodaotao.matruong
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuaChon5_Click(object sender, EventArgs e)
        {
            BieuDo bd = new BieuDo();
            if (bd.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnLuaChon4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            //lstKetQua.Items.Clear();
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    //string q = "select ten_nganh , count(*) as 'so_luong' from nganh, giangvien where nganh.ma_nganh = giangvien.ma_nganh group by nganh.ten_nganh";
                    string q = "select MaTruong from cosodaotao";
                    //List<String> TenCoQuan = new List<string>();
                    //List<int> SoLuong = new List<int>();
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                //string ten_nganh = rdr["ten_nganh"].ToString();
                                //int so_luong = int.Parse(rdr["so_luong"].ToString());
                                //lstKetQua.Items.AddRange(new object[] { "Tên ngành: " + ten_nganh, "Số lượng giáo viên: " + so_luong });
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

        private void btnLuaChon3_Click(object sender, EventArgs e)
        {
            //lstKetQua.Items.Clear();
            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //try
            //{
            //    if (con.State == System.Data.ConnectionState.Open)
            //    {
            //        string q = "select truong_Thong.ten_truong as truonghoc, count(*) as so_luong from giangvien, truong_Thong where giangvien.ma_truong = truong_Thong.ma_truong group by truong_Thong.ten_truong";

            //        using (SqlCommand cmd = new SqlCommand(q, con))
            //        {
            //            using (SqlDataReader rdr = cmd.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {

            //                    string truonghoc = rdr["truonghoc"].ToString();
            //                    int so_luong = int.Parse(rdr["so_luong"].ToString());
            //                    lstKetQua.Items.AddRange(new object[] { "Tên trường học: " + truonghoc, "Số Lượng giáo viên: " + so_luong });
            //                }
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Kết nối thất bại");
            //}
        }

        private void btnLuaChon2_Click(object sender, EventArgs e)
        {
            frmLuaChon2 frm2 = new frmLuaChon2();
            if (frm2.ShowDialog() == DialogResult.OK)
            {

            }
            //lstKetQua.Items.Clear();
            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //try
            //{
            //    if (con.State == System.Data.ConnectionState.Open)
            //    {
            //        string q = "select SUM(CT2014) as so_luong from solieutuyensinh where MaTruong = N'BKA'";

            //        using (SqlCommand cmd = new SqlCommand(q, con))
            //        {
            //            using (SqlDataReader rdr = cmd.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {

            //                    //string ma_khoa_hoc = rdr["ma_khoa_hoc"].ToString();
            //                    int so_luong = int.Parse(rdr["so_luong"].ToString());
            //                    lstKetQua.Items.AddRange(new object[] { "BKA: " + "Số Lượng: " + so_luong });
            //                }
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Kết nối thất bại");
            //}
        }

        private void lstKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLuaChon1_Click(object sender, EventArgs e)
        {
            frmLuaChon1 frm1 = new frmLuaChon1();
            if (frm1.ShowDialog() == DialogResult.OK)
            {

            }
            
        }

        private void txtMSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVeBieuDo_Click(object sender, EventArgs e)
        {

            //DialogResult = DialogResult.OK;
            BieuDo frmBieudo = new BieuDo();
            if (frmBieudo.ShowDialog() == DialogResult.OK)
            {

            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DialogResult = DialogResult.Yes;
        //    //Form1 frm = new Form1();
        //    //if (frm.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    Application.Run(new Form2());
        //    //}

        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    frmLuaChon5 lc5 = new frmLuaChon5();
        //    if(lc5.ShowDialog() == DialogResult.OK)
        //    {

        //    }
        //}

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmLuaChon6 frm6 = new frmLuaChon6();
            if(frm6.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn thoát phần mềm không?",
                "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        //private void btnVeBieuDo_Click(object sender, EventArgs e)
        //{
        //    lstKetQua.Items.Clear();
        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();
        //    try
        //    {
        //        if (con.State == System.Data.ConnectionState.Open)
        //        {
        //            SqlDataAdapter ad = new SqlDataAdapter("select sv.ma_khoa_hoc as ma_khoa_hoc , count(*) as 'so_luong' from sinh_vien as sv , khoa_hoc where sv.ma_khoa_hoc = khoa_hoc.ma_khoa_hoc group by sv.ma_khoa_hoc", con);
        //            DataTable dt = new DataTable();
        //            ad.Fill(dt);
        //            chart1.DataSource = dt;
        //            chart1.ChartAreas["ChartArea1"].AxisX.Title = "ma_khoa_hoc";
        //            chart1.ChartAreas["ChartArea1"].AxisX.Title = "so_luong";

        //            chart1.Series["Series1"].XValueMember = "ma_khoa_hoc";
        //            chart1.Series["Series1"].YValueMembers = "so_luong";

        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Kết nối thất bại");
        //    }
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();
        //    try
        //    {
        //        if (con.State == System.Data.ConnectionState.Open)
        //        {
        //            string q = "insert into sinh_vien(ma_sinh_vien,ho_ten) values('" + txtMSV.Text.ToString() + "','" + txtHoVaTen.Text + "')";

        //            //string q = "select id from Test";
        //            SqlCommand cmd = new SqlCommand(q, con);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Kết nối thành công");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Kết nối thất bại");
        //    }
        //}

    }
}
