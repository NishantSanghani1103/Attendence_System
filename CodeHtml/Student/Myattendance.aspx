<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Myattendance.aspx.cs" Inherits="CodeHtml.Student.MyAttendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4 {
            width: 372px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">My Attendance Report</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="style4">
                    <tr>
                        <td class="lbl">Select Month&nbsp; :</td>
                        <td>
                            <asp:DropDownList ID="drpmonth" runat="server" CssClass="txt">
                                <asp:ListItem>SELECT</asp:ListItem>
                                <asp:ListItem Value="Jan">January</asp:ListItem>
                                <asp:ListItem Value="Feb">February</asp:ListItem>
                                <asp:ListItem Value="Mar">March</asp:ListItem>
                                <asp:ListItem Value="Apr">April</asp:ListItem>
                                <asp:ListItem>May</asp:ListItem>
                                <asp:ListItem Value="Jun">June</asp:ListItem>
                                <asp:ListItem Value="Jul">July</asp:ListItem>
                                <asp:ListItem Value="Aug">August</asp:ListItem>
                                <asp:ListItem Value="Sep">September</asp:ListItem>
                                <asp:ListItem Value="Oct">October</asp:ListItem>
                                <asp:ListItem Value="Nov">November</asp:ListItem>
                                <asp:ListItem Value="Dec">December</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnreport" runat="server" CssClass="btn"
                                OnClick="btnreport_Click" Text="Report" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" ForeColor="Black" GridLines="Vertical"
                    Style="text-align: center" Width="523px" runat="server" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("EDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendence">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendence  By">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("StaffName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#8506A9" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" ForeColor="Black" GridLines="Vertical" 
                    style="text-align: center" Width="624px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="date" HeaderText="Date" />
                        <asp:BoundField DataField="status" HeaderText="Attendance" />
                        <asp:BoundField DataField="staffname" HeaderText="Attendance By" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>--%>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

