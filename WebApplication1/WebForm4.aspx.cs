using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// ExecuteReader, ExecuteNonQuery, ExecuteScalar
    /// </summary>
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString2"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where student_name like @name";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        gvResult.DataSource = dt;
                        gvResult.DataBind();
                        dr.Close();
                    }
                }
            }
        }

        //ExecuteScalar
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO [dbo].[student]
           ([student_name]
           ,[student_id]
           ,[student_age])
     VALUES
                               (@Name
                               ,@id,@age);";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString2"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Name", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@id", txtID.Text));
                    cmd.Parameters.Add(new SqlParameter("@age", txtAge.Text));
                    cmd.ExecuteNonQuery();
                }
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = @"update [student] set [student_name] = @Name,[student_age] = @Age
                             where [student_id] = @ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString2"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID", txtE_ID.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", txtE_Name.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", txtE_Age.Text));

                    cmd.ExecuteNonQuery();
                }
                btnSearch_Click(null, null);
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString2"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from [student]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Select(string.Format("student_id = {0}", delid.Text)).First();
                        dr.Delete();
                        da.Update(dt);

                        btnSearch_Click(null, null);
                    }
                }
            }
        }
    }
}