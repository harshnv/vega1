using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class p2 : System.Web.UI.Page
{
    SqlConnection hookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);
    SqlConnection pookup = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["vega2"].ConnectionString);

    SqlCommand sqlcmd, sqlcmd2;
    SqlDataReader readbind, readbind2;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        
        refr();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        refr();
    }
    void refr()
    {
        Panel1.Controls.Clear();
        sqlcmd = new SqlCommand("select * from orders where type='SA' and balance>0 and cardno not in(select distinct   cardno from services where dt  >= @dt1 and dt<=@dt2)  ", hookup);

        if (DropDownList1.SelectedItem.Value.Equals("all"))
        {
            sqlcmd2 = new SqlCommand("select * from customers where cid=@cid ", pookup);
        }
        else
        {
            sqlcmd2 = new SqlCommand("select * from customers where cid=@cid and acode=@acode ", pookup);
            sqlcmd2.Parameters.AddWithValue("@acode", DropDownList1.SelectedItem.Value);

        }

        string cid = "";

        sqlcmd2.Parameters.AddWithValue("@cid", -1);
        int x = Convert.ToInt32(TextBox1.Text);
        sqlcmd.Parameters.AddWithValue("@dt1", DateTime.Now.Subtract(new TimeSpan(x, 0, 0, 0)));
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
        hc.Controls.Add(new LiteralControl("blank"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Select"));
        hc.CssClass = "thc";
        hr.Cells.Add(hc);

        hr = new TableHeaderRow();
        hc = new TableHeaderCell();
        hc.Controls.Add(new LiteralControl("Card-No"));
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
        while (readbind.Read())
        {

            sqlcmd2.Parameters["@cid"].Value = readbind["cid"].ToString();
            cid = readbind["cid"].ToString();
            readbind2 = sqlcmd2.ExecuteReader();

            if (readbind2.HasRows)
            {
                readbind2.Read();
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
                tc.Controls.Add(new LiteralControl(readbind["cardno"].ToString()));

                tr.Cells.Add(tc);
                t.Rows.Add(tr);

                tc = new TableCell();

                tc.Controls.Add(new LiteralControl(readbind2["name"].ToString()));
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


           

        }
        Panel1.Controls.Add(t);
        readbind.Close();


        pookup.Close();
        hookup.Close();
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
        Panel1.Controls.Add(ddl);
        Panel1.Controls.Add(ddl);
        Button btn = new Button();
        btn.Text = "Assign";
        btn.ID = "b" + cid;
        btn.Click += new EventHandler(go2);
        btn.CssClass = "btn btn-info";
        Panel1.Controls.Add(btn);

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField2.Value = DropDownList1.SelectedItem.Value;
    }
    protected void ddlq(object sender, EventArgs e)
    {
        DropDownList chk = sender as DropDownList;

        HiddenField1.Value = chk.SelectedItem.Text;
    }

    protected void go2(object sender, EventArgs e)
    {
        sqlcmd = new SqlCommand("select e.eid from emp e where e.name= @nm", hookup);
        sqlcmd.Parameters.AddWithValue("@nm", HiddenField1.Value);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        readbind.Read();
        string pp = readbind[0].ToString();
        // decimal acost = Convert.ToDecimal(readbind["1"]);
        readbind.Close();
        hookup.Close();




        

        sqlcmd2 = new SqlCommand("insert into services values(@uid,@cardno,@emp,@dt,null,null,null,null,null,null,null,null,null,@acost,null,null)", pookup);
        pookup.Open();
        sqlcmd2.Parameters.AddWithValue("@uid", "-1");
        sqlcmd2.Parameters.AddWithValue("@cardno", "dummy");
        sqlcmd2.Parameters.AddWithValue("@emp", pp);
        sqlcmd2.Parameters.AddWithValue("@dt", DateTime.Now);
        sqlcmd2.Parameters.AddWithValue("@acost", -1);


        foreach (ListItem li in ListBox1.Items)
        {

            sqlcmd = new SqlCommand("select cid from orders where cardno=@cardno", hookup);
            sqlcmd.Parameters.AddWithValue("@cardno", li.Text);
            hookup.Open();
            readbind = sqlcmd.ExecuteReader();
            readbind.Read();
            string cide = readbind["cid"].ToString();
            hookup.Close();
            readbind.Close();

            sqlcmd = new SqlCommand("select a.charge from area a inner join customers c on a.acode=c.acode where c.cid= @cid", hookup);
            sqlcmd.Parameters.AddWithValue("@cid",cide);
            hookup.Open();
            readbind = sqlcmd.ExecuteReader();
            readbind.Read();
            //  string pp = readbind[0].ToString();
            decimal acost = Convert.ToDecimal(readbind[0]);
            readbind.Close();
            hookup.Close();

            string uid = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            sqlcmd2.Parameters["@uid"].Value = uid;
            sqlcmd2.Parameters["@cardno"].Value = li.Text;
            sqlcmd2.Parameters["@acost"].Value = acost;
            sqlcmd2.ExecuteNonQuery();
            


        }

      
        //foreach (ListItem li in ListBox1.Items)
        //{
        //    string uid = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
        //    sqlcmd.Parameters["@uid"].Value = uid;
        //    sqlcmd.Parameters["@cardno"].Value = li.Text;
        //    sqlcmd.ExecuteNonQuery();


        //}

        pookup.Close();
        refr();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {

        if (DropDownList1.SelectedItem.Value.Equals("all"))
        {
            sqlcmd = new SqlCommand("select count(cardno) from orders o inner join customers c on o.cid=c.cid  where o.type='SA'  and balance>0 and cardno not in(select distinct   cardno from services where dt  >= @dt1 and dt<=@dt2)   ", hookup);
        }
        else
        {
            sqlcmd = new SqlCommand("select count(cardno) from orders o inner join customers c on o.cid=c.cid  where o.type='SA' and c.acode=@acode and balance>0 and cardno not in(select distinct   cardno from services where dt  >= @dt1 and dt<=@dt2)   ", hookup);
            sqlcmd.Parameters.AddWithValue("@acode", DropDownList1.SelectedItem.Value);

        }
        int x = Convert.ToInt32(TextBox2.Text) + Convert.ToInt32(TextBox1.Text);
        sqlcmd.Parameters.AddWithValue("@dt1", DateTime.Now.Subtract(new TimeSpan(x, 0, 0, 0)));
        sqlcmd.Parameters.AddWithValue("@dt2", DateTime.Now);
        hookup.Open();
        readbind = sqlcmd.ExecuteReader();
        readbind.Read();
        Label1.Text = "After " + TextBox2.Text + " Days the count of customers will be " + readbind[0].ToString();
        Label1.Visible = true;
        hookup.Close();
        readbind.Close();



    }
}