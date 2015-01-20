using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class servfeed : System.Web.UI.Page
{
    SqlConnection hookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);
    SqlConnection pookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);

    SqlCommand sqlcmd, sqlcmd2;
    SqlDataReader readbind, readbind2;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcmd = new SqlCommand("select * from parts", hookup);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        DropDownList4.Items.Add("None");
       while(readbind.Read())
       {
           DropDownList4.Items.Add(readbind["name"].ToString());
          
       }
       readbind.Close();
       hookup.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sqlcmd=new SqlCommand("select acode from customers where cid in(select cid from orders inner join services on orders.cardno=services.cardno and services.uid=@uid)",hookup);
        sqlcmd.Parameters.AddWithValue("@uid",Request.QueryString["uid"].ToString());
        hookup.Open();
        readbind=sqlcmd.ExecuteReader();
        readbind.Read();
        string acode=readbind[0].ToString();
        hookup.Close();
        readbind.Close();


        sqlcmd = new SqlCommand("select partid from parts where name=@name", hookup);

        sqlcmd.Parameters.AddWithValue("@name",DropDownList4.SelectedItem.Text);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        readbind.Read();
        string pid = readbind["partid"].ToString();
        hookup.Close();
        readbind.Close();



        sqlcmd=new SqlCommand("select charge from area where acode=@acode",hookup);

        sqlcmd.Parameters.AddWithValue("@acode",acode);
        hookup.Open();
        readbind=sqlcmd.ExecuteReader();
        readbind.Read();
        decimal acost= Convert.ToDecimal(readbind["charge"]);
        hookup.Close();
        readbind.Close();

        sqlcmd = new SqlCommand("update services set cost=@cost,visited=@visited,done=@done,callback=@callback,[when]=@when,partid=@partid,pqty=@pqty,notes=@notes,areacost=@acost,total=@total,paid=@paid where [uid]=@uid", hookup);
        sqlcmd.Parameters.AddWithValue("@cost", TextBox3.Text);
        sqlcmd.Parameters.AddWithValue("@visited",DropDownList1.SelectedItem.Value);
        sqlcmd.Parameters.AddWithValue("@done", DropDownList3.SelectedItem.Value);
        sqlcmd.Parameters.AddWithValue("@callback", DropDownList2.SelectedItem.Value);
        sqlcmd.Parameters.AddWithValue("@when", dt.Value);
        sqlcmd.Parameters.AddWithValue("@partid",pid);
        sqlcmd.Parameters.AddWithValue("@pqty", TextBox1.Text);
        sqlcmd.Parameters.AddWithValue("@notes",TextBox2.Text);
        sqlcmd.Parameters.AddWithValue("@uid", Request.QueryString["uid"].ToString());
            sqlcmd.Parameters.AddWithValue("@acost",acode);
            sqlcmd.Parameters.AddWithValue("@total", Convert.ToDecimal(TextBox3.Text) + acost);
                    sqlcmd.Parameters.AddWithValue("@paid",TextBox4.Text);


        hookup.Open();
        sqlcmd.ExecuteNonQuery();
        hookup.Close();


    }
}