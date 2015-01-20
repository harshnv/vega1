<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="p2.aspx.cs" Inherits="p2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:Panel ID="Panel4" runat="server"></asp:Panel>--%>
<%--    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="ddlq" runat="server"></asp:DropDownList>--%>



    <table class="table table-hover">
        <tr>
            <td>
                Pending Since(Days)
            </td>
            <td> <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server">60</asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Area
            </td>
           
            <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td>
            <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Apply Date" OnClick="Button1_Click" />
                </td>
        </tr>

    </table>
            <h2>
            Statistics
        </h2>
        <table class="table table-responsive">
            <tr>
                <td>
                    Enter No Of Days
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control">5</asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Get Stat" CssClass="btn btn-success" OnClick="Button2_Click" /></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label></td>
                </tr>
        </table>

    
   
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false"></asp:Panel>
    <asp:ListBox ID="ListBox1" runat="server" Visible="false"></asp:ListBox>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:Panel ID="Panel3" runat="server" Visible="false"></asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
