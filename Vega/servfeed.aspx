<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="servfeed.aspx.cs" Inherits="servfeed" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="table table-hover ">
        <tr>
            <td>
                Visited
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Called Back
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="form-control">
                     <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
               Revisit Date
            </td>
            <td>
                <input type="date" runat="server" id="dt"  Class="form-control"/>
            </td>
        </tr>
         <tr>
            <td>
                Done
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server"  CssClass="form-control">
                    <asp:ListItem Value="1">Yes</asp:ListItem> 
                    <asp:ListItem Value="0">No</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
              Part Used
            </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server"  CssClass="form-control">
                     
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
             Part  Quantity
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control">1</asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
             Notes
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
             Cost Of Service
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            Amount Paid
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"  CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr>
            
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-success" OnClick="Button1_Click" />
            </td>
        </tr>


    </table>

</asp:Content>

