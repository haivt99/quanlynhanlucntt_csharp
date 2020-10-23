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
    public partial class frmLuaChon4 : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=True";

        public frmLuaChon4()
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
                    string q = "select DiaChi, count(*) as 'so_luong' from CoQuan, KhuVuc where coquan.MaKhuVuc = KhuVuc.MaKhuVuc group by DiaChi";
                    //List<String> TenCoQuan = new List<string>();
                    //List<int> SoLuong = new List<int>();
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string DiaChi = rdr["DiaChi"].ToString();
                                int so_luong = int.Parse(rdr["so_luong"].ToString());
                                lstKetQua.Items.AddRange(new object[] { "Địa chỉ cơ sở đào tạo: " + DiaChi, "Số lượng cơ sở: " + so_luong });
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

        private void button2_Click(object sender, EventArgs e)
        {
            BieuDo frmBieudo = new BieuDo();
            if (frmBieudo.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
