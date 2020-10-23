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
    public partial class BieuDo : Form
    {
        public string conString = "Data Source=KAKA-20190630DR\\SQLEXPRESS;Initial Catalog=NguonNhanLucCNTT;Integrated Security=True";
        public BieuDo()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter ad = new SqlDataAdapter("select  gv.hocvi as HocVi, count(*) as 'SoLuong'  from giangviencntt as gv , cosodaotao as cs where gv.matruong = cs.matruong group by gv.hocvi", con);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    chart1.DataSource = dt;
                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tên học vị";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";

                    chart1.Series["Series1"].XValueMember = "HocVi";
                    chart1.Series["Series1"].YValueMembers = "SoLuong";

                }
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BieuDo frm = new BieuDo();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new Form1());
            //}
            Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void BieuDo_Load(object sender, EventArgs e)
        {

        }
    }

        //private void chart1_Click(object sender, EventArgs e)
        //{
           // lstKetQua.Items.Clear();
           
    //}
}
