<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Complain.aspx.cs" Inherits="CodeHtml.Admin.Complain1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style3 {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">Complain Form</td>
        </tr>
        <tr>
            <td class="style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="style3">Total =
                <asp:Label ID="lblcomplain" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  runat="server" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="Roll No">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Rollno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Complain">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reply">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Reply") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
