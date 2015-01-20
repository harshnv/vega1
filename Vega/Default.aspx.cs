using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection hookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vegaConnectionString1"].ConnectionString);
    SqlCommand sqlcmd;
    SqlDataReader readbind;
    protected void Page_Load(object sender, EventArgs e)
    {

       Table t = new Table();
        TableCell tc;
        TableRow tr;
        TableHeaderRow hr;
        TableHeaderCell hc;
        t.CssClass = "table table-hover";
        t.ID = "csTable";

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Name"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Phone No 1"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Phone No 2"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Email-ID"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Address"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);

        sqlcmd = new SqlCommand("select * from customers", hookup);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();



        while (readbind.Read())
        {
            tr = new TableRow();


            tr = new TableRow();
            tc = new TableCell();
            HyperLink lnk = new HyperLink();
            //   LinkButton lnk = new LinkButton();
            //    lnk.ID = readbind["cid"].ToString();
            //   lnk.Text = readbind["name"].ToString();
            //   lnk.onClick += new EventHandler(go);

            lnk.NavigateUrl = "cust.aspx?id=" + readbind["cid"].ToString();
            lnk.Text = readbind["name"].ToString();
            tc.Controls.Add(lnk);
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["phone1"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["phone2"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["email"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["address"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

        }
        Panel1.Controls.Add(t);
        readbind.Close();
        hookup.Close();
        readbind.Close();

       

        sqlcmd = new SqlCommand("select name,cid from customers where cid in(select cid from services s inner join orders o on s.cardno=o.cardno and o.type='SA' and s.done=0 )", hookup);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
       

        Panel3.Controls.Add(new LiteralControl("<div id='tCalls' style='margin-top:16%;'><h4 style='text-align:left;color:gray;font-family: fantasy;letter-spacing: 1px;'>Service Calls</h4> <ol class='callsList'>"));

        while (readbind.Read())
        {
            Panel3.Controls.Add(new LiteralControl(" <a id='"+readbind["cid"].ToString()+"' data-toggle='modal' data-target='#myModal'><li>"+readbind["name"].ToString()+"</li></a>"));

        }
        Panel3.Controls.Add(new LiteralControl(" </ol></div></br>"));

        hookup.Close();


        sqlcmd = new SqlCommand("select name,cid from customers where cid in(select cid from services s  inner join orders o on s.cardno=o.cardno and o.type='S' and s.done=0 )", hookup);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();


        Panel3.Controls.Add(new LiteralControl(" <div id='breakCalls'><h4 style='text-align:left;color:red;font-family: fantasy;letter-spacing: 1px;'>BreakDown Calls</h4><ol>"));

        while (readbind.Read())
        {
            Panel3.Controls.Add(new LiteralControl(" <a id='" + readbind["cid"].ToString() + "'data-toggle='modal' data-target='#myModal'><li>" + readbind["name"].ToString() + "</li></a>"));

        }
        Panel3.Controls.Add(new LiteralControl(" </ol></div></br>"));

        hookup.Close();



    }
    protected void go(object sender, EventArgs e)
    {
        LinkButton p = sender as LinkButton;
        Response.Redirect("test.aspx");


    }



   
}