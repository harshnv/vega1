using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class group : System.Web.UI.Page
{
    SqlConnection hookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vegaConnectionString1"].ConnectionString);
    SqlCommand sqlcmd;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField1.Value = "1";
        HiddenField2.Value = GridView1.SelectedRow.Cells[1].Text;
        gid.Value = GridView1.SelectedRow.Cells[1].Text;
        name.Value = GridView1.SelectedRow.Cells[2].Text;
        notes.Value = GridView1.SelectedRow.Cells[3].Text;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (HiddenField1.Value.Equals("1"))
        {

            sqlcmd = new SqlCommand("delete from cgroup where gid=@gid", hookup);
            sqlcmd.Parameters.AddWithValue("@gid", HiddenField2.Value);
            hookup.Open();
            sqlcmd.ExecuteNonQuery();
            hookup.Close();
            sqlcmd = new SqlCommand("insert into cgroup values(@gid,@name,@notes)", hookup);
            sqlcmd.Parameters.AddWithValue("@gid", gid.Value);
            sqlcmd.Parameters.AddWithValue("@name", name.Value);
            sqlcmd.Parameters.AddWithValue("@notes", notes.Value);
            hookup.Open();
            sqlcmd.ExecuteNonQuery();
            hookup.Close();
            refr();
        }
        else
        {
            sqlcmd = new SqlCommand("insert into cgroup values(@gid,@name,@notes)", hookup);
            sqlcmd.Parameters.AddWithValue("@gid", gid.Value);
            sqlcmd.Parameters.AddWithValue("@name", name.Value);
            sqlcmd.Parameters.AddWithValue("@notes", notes.Value);
            hookup.Open();
            sqlcmd.ExecuteNonQuery();
            hookup.Close();
            refr();
        }


    }
    void refr()
    {
        GridView1.DataSourceID = SqlDataSource1.ID;
        GridView1.DataBind();
    }
}