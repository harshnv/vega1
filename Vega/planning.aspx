<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="planning.aspx.cs" Inherits="planning" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <asp:Panel ID="Panel4" runat="server"></asp:Panel>--%>
<%--    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="ddlq" runat="server"></asp:DropDownList>--%>
    <table>
        <tr>
            <td>
                Pending Since(Days)
            </td>
            <td><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server">60</asp:TextBox></td>
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
            <asp:Button ID="Button1" CssClass="btn btn-successs" runat="server" Text="Apply Date" OnClick="Button1_Click" />
        </tr>

    </table>
    
   
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false"></asp:Panel>
    <asp:ListBox ID="ListBox1" runat="server" Visible="false"></asp:ListBox>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:Panel ID="Panel3" runat="server" Visible="false"></asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

