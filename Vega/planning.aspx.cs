using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class planning : System.Web.UI.Page
{
    SqlConnection hookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);
    SqlConnection pookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);

    SqlCommand sqlcmd,sqlcmd2;
    SqlDataReader readbind,readbind2;
     List<string> lis=new List<string>();


     protected void Page_Load(object sender, EventArgs e)
     {

         //DropDownList ddlx = new DropDownList();
         //ddlx.AutoPostBack = true;
         //ddlx.SelectedIndexChanged += new EventHandler(fgt);
         //Panel4.Controls.Add(ddlx);
         //ddlx.Items.Add("fuck");
         //ddlx.Items.Add("ggg");
         if (!IsPostBack)
         {
             sqlcmd = new SqlCommand("select acode from area", hookup);
             hookup.Open();
             readbind = sqlcmd.ExecuteReader();
             DropDownList1.Items.Clear();
             DropDownList1.Items.Add("all");
             while (readbind.Read())
             {
                 DropDownList1.Items.Add(readbind["acode"].ToString());
             }
             hookup.Close();
             readbind.Close();
         }
             try
             {
                 if (Request.QueryString["mode"].Equals("1"))
                 {
                     string cid = Request.QueryString["id"];
                     Panel2.Visible = true;
                     Panel1.Visible = false;
                     Panel3.Visible = false;
                     sqlcmd = new SqlCommand("select * from orders where cid=@cid", hookup);
                     sqlcmd.Parameters.AddWithValue("@cid", cid);
                     Table t = new Table();
                     TableCell tc;
                     TableRow tr;
                     TableHeaderRow hr;
                     TableHeaderCell hc;
                     t.CssClass = "table table-hover";
                     t.ID = "csTable";

                     hr = new TableHeaderRow();
                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("select"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);

                     hr = new TableHeaderRow();
                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("cardno"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     hr = new TableHeaderRow();
                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Item Name"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);

                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Quantity"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);
                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Balance"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);

                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Warranty Period"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);

                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Balance"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);

                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Warranty period"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);

                     hc = new TableHeaderCell();
                     hc.Controls.Add(new LiteralControl("Last Serviced"));
                     hc.CssClass = "thc";
                     hr.Cells.Add(hc);
                     t.Rows.Add(hr);




                     hookup.Open();
                     readbind = sqlcmd.ExecuteReader();
                     while (readbind.Read())
                     {
                         tr = new TableRow();



                         tc = new TableCell();
                         tc = new TableCell();
                         CheckBox chk = new CheckBox();
                         chk.ID = readbind["cardno"].ToString();
                         chk.AutoPostBack = true;
                         chk.CheckedChanged += new EventHandler(select);
                         tc.Controls.Add(chk);
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["cardno"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["iname"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["qty"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["balance"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["wp"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);

                         tc = new TableCell();
                         tc = new TableCell();
                         tc.Controls.Add(new LiteralControl(readbind["dt"].ToString()));
                         tr.Cells.Add(tc);
                         t.Rows.Add(tr);
                     }
                     hookup.Close();
                     readbind.Close();
                     Panel2.Controls.Add(t);


                     DropDownList ddl = new DropDownList();
                     ddl.ID = "dropid";
                     ddl.CssClass = "form-control";
                     ddl.SelectedIndexChanged += new EventHandler(ddlq);
                     ddl.AutoPostBack = true;
                     sqlcmd = new SqlCommand("select * from emp", hookup);
                     hookup.Open();
                     readbind = sqlcmd.ExecuteReader();
                     ddl.Items.Add("SELECT");
                     while (readbind.Read())
                     {
                         ddl.Items.Add(readbind["name"].ToString());
                     }
                     hookup.Close();
                     readbind.Close();
                     Panel2.Controls.Add(ddl);
                     Panel2.Controls.Add(ddl);
                     Button btn = new Button();
                     btn.Text = "Assign";
                     btn.ID = "b" + cid;
                     btn.Click += new EventHandler(go2);
                     btn.CssClass = "btn btn-info";
                     Panel2.Controls.Add(btn);

                 }
             }
             catch (Exception excv) { }

            

     }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sqlcmd = new SqlCommand("select cardno,cid from orders where type='SA' and balance>0 and cardno not in(select distinct   cardno from services where dt  >= @dt1 and dt<=@dt2)  ", hookup);
       
        if(DropDownList1.SelectedItem.Value.Equals("all"))
        {
            sqlcmd2 = new SqlCommand("select * from customers where cid=@cid ", pookup);
        }
        else
        {
            sqlcmd2 = new SqlCommand("select * from customers where cid=@cid and acode=@acode ", pookup);
            sqlcmd2.Parameters.AddWithValue("@acode", HiddenField2.Value);

        }
        
        sqlcmd2.Parameters.AddWithValue("@cid", -1);
        int x = Convert.ToInt32(TextBox1.Text);
        sqlcmd.Parameters.AddWithValue("@dt1", DateTime.Now.Subtract(new TimeSpan(x,0,0,0) ));
        sqlcmd.Parameters.AddWithValue("@dt2", DateTime.Now);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        Table t = new Table();
        TableCell tc;
        TableRow tr;
        TableHeaderRow hr;
        TableHeaderCell hc;
        t.CssClass = "table table-hover";
        t.ID = "csTable";

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Cust ID"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);


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

       
        t.Rows.Add(hr);
        
        
        pookup.Open();
        while(readbind.Read())
        {
            string cid = readbind["cid"].ToString();
            sqlcmd2.Parameters["@cid"].Value = cid;
            readbind2 = sqlcmd2.ExecuteReader();
            readbind2.Read();


            tr = new TableRow();
           
            HyperLink lnk = new HyperLink();
            //LinkButton lnk2 = new LinkButton();
            //lnk2.ID = readbind["cid"].ToString();
            //lnk2.Text = readbind2["name"].ToString();
           // lnk2.Click += new EventHandler(go);


            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(cid));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);
            
            tc = new TableCell();
            lnk.NavigateUrl = "planning.aspx?id=" + readbind["cid"].ToString()+"&mode=1";
            lnk.Text = readbind2["name"].ToString();
            tc.Controls.Add(lnk);
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind2["phone1"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind2["phone2"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind2["email"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind2["address"].ToString()));

            tr.Cells.Add(tc);
            t.Rows.Add(tr);

         
            readbind2.Close();
        }


        Panel1.Controls.Add(t);
        readbind.Close();


        pookup.Close();
        hookup.Close();
       // Response.Redirect("test.aspx?id=" + DateTime.Now.Subtract(new TimeSpan(60,0,0,0)));


    }
    protected void go2(object sender, EventArgs e)
    {
        sqlcmd=new SqlCommand("select e.eid from emp e where e.name= @nm",hookup);
        sqlcmd.Parameters.AddWithValue("@nm",HiddenField1.Value);
        hookup.Open();
        readbind=sqlcmd.ExecuteReader();
        readbind.Read();
        string pp =readbind[0].ToString();
       // decimal acost = Convert.ToDecimal(readbind["1"]);
        readbind.Close();
        hookup.Close();

        sqlcmd = new SqlCommand("select a.charge from area a inner join customers c on a.acode=c.acode where c.cid= @cid", hookup);
        sqlcmd.Parameters.AddWithValue("@cid", Request.QueryString["id"].ToString());
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        readbind.Read();
      //  string pp = readbind[0].ToString();
         decimal acost = Convert.ToDecimal(readbind[0]);
        readbind.Close();
        hookup.Close();



        sqlcmd = new SqlCommand("insert into services values(@uid,@cardno,@emp,@dt,null,null,null,null,null,null,null,null,null,@acost,null,null)",hookup);
        hookup.Open();
        sqlcmd.Parameters.AddWithValue("@uid", "-1");
        sqlcmd.Parameters.AddWithValue("@cardno", "dummy");
        sqlcmd.Parameters.AddWithValue("@emp", pp);
        sqlcmd.Parameters.AddWithValue("@dt", DateTime.Now);
        sqlcmd.Parameters.AddWithValue("@acost", acost);
        foreach (ListItem li in ListBox1.Items)
        {
            string uid = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            sqlcmd.Parameters["@uid"].Value = uid;
            sqlcmd.Parameters["@cardno"].Value = li.Text;
            sqlcmd.ExecuteNonQuery();
           

        }
        hookup.Close();
    }
    protected void go(object sender,EventArgs e)
    {
        LinkButton lkb = sender as LinkButton;

        string cid = lkb.ID;
        Panel2.Visible = true;
        Panel1.Visible = false;
        Panel3.Visible = false;
        sqlcmd = new SqlCommand("select * from orders where cid=@cid", hookup);
        sqlcmd.Parameters.AddWithValue("@cid", cid);
        Table t = new Table();
        TableCell tc;
        TableRow tr;
        TableHeaderRow hr;
        TableHeaderCell hc;
        t.CssClass = "table table-hover";
        t.ID = "csTable";

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("select"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("cardno"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Item Name"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Quantity"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Balance"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Warranty Period"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);

        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Last Serviced"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);
        t.Rows.Add(hr);




        hookup.Open();
        while (readbind.Read())
        {
            tr = new TableRow();



            tc = new TableCell();
            tc = new TableCell();
            CheckBox chk = new CheckBox();
            chk.ID = readbind["cardno"].ToString();
            chk.AutoPostBack = true;
            chk.CheckedChanged += new EventHandler(select);
            tc.Controls.Add(chk);
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["cardno"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["iname"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["qty"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["balance"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["wp"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);

            tc = new TableCell();
            tc = new TableCell();
            tc.Controls.Add(new LiteralControl(readbind["dt"].ToString()));
            tr.Cells.Add(tc);
            t.Rows.Add(tr);
        }
        hookup.Close();
        readbind.Close();
        Panel2.Controls.Add(t);


       
        Button btn = new Button();
        btn.Text = "Assign";
        btn.ID = "b" + cid;
        btn.OnClientClick += new EventHandler(go2);
        btn.CssClass = "btn btn-info";
        Panel2.Controls.Add(btn);

    }
    protected void select(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;

        ListItem li = new ListItem((chk.ID).ToString());
        if (chk.Checked)
            ListBox1.Items.Add(li);

        if (chk.Checked == false)
            ListBox1.Items.Remove((chk.ID).ToString());
    }
    protected void ddlq(object sender, EventArgs e)
    {
        DropDownList chk = sender as DropDownList;

        HiddenField1.Value = chk.SelectedItem.Text;
    }
    protected void fgt(object sender, EventArgs e)
    {
        Response.Redirect("ggg");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField2.Value = DropDownList1.SelectedItem.Value;
    }
}