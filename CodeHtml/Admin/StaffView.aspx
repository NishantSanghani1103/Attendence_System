<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StaffView.aspx.cs" Inherits="CodeHtml.Admin.StaffView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
    {
        height: 19px;
            text-align: center;
        }
    .style2
    {
        width: 610px;
    }
        .style4
        {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">
                Staff Report</td>
        </tr>
        <tr>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style3">
                Select Staff :
                <asp:DropDownList ID="drpstaff" runat="server" CssClass="txt">
                </asp:DropDownList>
                <asp:Button ID="btnselect" runat="server" CssClass="btn" Text="Select" />
                <%--<asp:Button ID="btnselect" runat="server" CssClass="btn" Text="Select" OnClick="btnselect_Click" />--%>
               <%-- <asp:Button ID="btnselect" runat="server" CssClass="btn" Text="Select" 
                            onclick="btnaddstd_Click" />--%>
                <asp:Label ID="lbl" runat="server"></asp:Label>
            </td>
        </tr>
       
    </table>
</asp:Content>
