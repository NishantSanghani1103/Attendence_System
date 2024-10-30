<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddStd.aspx.cs" Inherits="CodeHtml.Admin.AddStd1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 394px;
    }
    .style3
    {
        height: 19px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
    <tr>
        <td class="tblhead">
            ADD Standerd</td>
    </tr>
    <tr>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td>
            <table align="center" class="style2">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="lbl">
                        Standard Name :</td>
                    <td>
                        <asp:TextBox ID="txtstdname" runat="server" CssClass="txt"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnaddstd" CssClass="btn"  runat="server" Text="ADD" OnClick="btnaddstd_Click" />
                        <%--<asp:Button ID="btnaddstd" runat="server" CssClass="btn" Text="ADD" 
                            onclick="btnaddstd_Click" />--%>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lbl" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
    
                        
                
                        
                
                       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT StdName FROM StdMst" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True"></asp:SqlDataSource>--%>
                                <asp:GridView ID="GridView1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" >
                            <Columns>
                                 <asp:TemplateField HeaderText="Edit">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SID") %>' CommandName="cmd_edt">Edit</asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cmd_dlt" CommandArgument='<%# Eval("SID") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Standard Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("StdName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                                     <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
    
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

