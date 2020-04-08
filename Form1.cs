using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baitapwf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
            con.Open();
            string sql = "select * from phong";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            index = dataGridView1.CurrentRow.Index;
            txtmaphong.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txttenphong.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtdongia.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            txtmaphong.ReadOnly = false;
            try {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
                con.Open();
                string sql = "insert into phong values('" + txtmaphong.Text + "','" + txttenphong.Text + "','" + txtdongia.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("không lưu được vì trùng mã");
                txtmaphong.Clear();
                txttenphong.Clear();
                txtdongia.Clear();
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
                con.Close();
            }


        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            txtmaphong.Clear();
            txttenphong.Clear();
            txtdongia.Clear();
            txtmaphong.Focus();
            txttenphong.Focus();
            txtdongia.Focus();
            txtmaphong.ReadOnly = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
                txtmaphong.ReadOnly = true;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
                con.Open();
                string sql = "update phong set tenphong='" + txttenphong.Text + "',dongia='" + txtdongia.Text + "' where maphong='" + txtmaphong.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(txtmaphong.TextLength==0)
            {
                MessageBox.Show("bạn chưa chọn dòng xóa");
            }
            txtmaphong.ReadOnly = false;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
            con.Open();
            string sql = "delete from phong where maphong='" + txtmaphong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            txtmaphong.Clear();
            txttenphong.Clear();
            txtdongia.Clear();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            txtmaphong.Clear();
            txttenphong.Clear();
            txtdongia.Clear();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
