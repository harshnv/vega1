<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="group.aspx.cs" Inherits="group" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
         <center>
    <h1> <span class="glyphicon glyphicon-book" aria-hidden="true"></span> Groups</h1>
        </center>
    <br />
    <br />
    <br />
    <div class="col-md-12">


       <div class="col-md-6" style="margin-top:2%;" >
            <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="400px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="gid" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowSorting="True" Height="208px" Width="396px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
   
         <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True"  />
        <asp:BoundField DataField="gid" HeaderText="gid" ReadOnly="True" SortExpression="gid" Visible="false" />
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="notes" HeaderText="notes" SortExpression="notes" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vegaConnectionString1 %>" DeleteCommand="DELETE FROM [cgroup] WHERE [gid] = @gid" InsertCommand="INSERT INTO [cgroup] ([gid], [name], [notes]) VALUES (@gid, @name, @notes)" ProviderName="<%$ ConnectionStrings:vegaConnectionString1.ProviderName %>" SelectCommand="SELECT [gid], [name], [notes] FROM [cgroup]" UpdateCommand="UPDATE [cgroup] SET [name] = @name, [notes] = @notes WHERE [gid] = @gid">
    <DeleteParameters>
        <asp:Parameter Name="gid" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="gid" Type="String" />
        <asp:Parameter Name="name" Type="String" />
        <asp:Parameter Name="notes" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="name" Type="String" />
        <asp:Parameter Name="notes" Type="String" />
        <asp:Parameter Name="gid" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>
                <br>
                </br>
                <br>
    </br>
    
              
                </asp:Panel>  
        
       
    </div>

    <div>

    <h4 id="tit2" runat="server">Add New Group</h4>

            <hr />
            <table class="table table-hover">
                 
                       
                    
                        <input runat="server" id="gid" class="form-control" placeholder="Name" visible="false" />
                   
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <input runat="server" id="name" class="form-control" placeholder="Name" />
                    </td>
                    </tr>
                <tr>

                     <td>
                       Notes 
                    </td>
                    <td>
                        <input runat="server" id="notes" class="form-control" placeholder="Notes" />
                    </td>
</tr>
                         </table>

            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Button1_Click"/>
            

        </div>
    </div>



    
         
</asp:Content>

