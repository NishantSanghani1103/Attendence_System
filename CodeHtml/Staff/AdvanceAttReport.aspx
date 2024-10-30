<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="AdvanceAttReport.aspx.cs" Inherits="CodeHtml.Staff.AdvanceAttReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4 {
            width: 644px;
        }

        .style7 {
            text-align: right;
            color: Red;
            width: 128px;
        }

        .style6 {
            width: 52px;
        }

        .style5 {
            width: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">ADVANCE REPORTS</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="left" class="style4">
                    <tr>
                        <td class="style7">Select Standard :
                        </td>
                        <td class="style6">
                            <asp:Label ID="lblstd" runat="server"></asp:Label>
                        </td>
                        <td class="style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">Select Division :
                        </td>
                        <td class="style6">
                            <asp:DropDownList ID="drpdiv" runat="server" CssClass="txt" AutoPostBack="True"
                                OnSelectedIndexChanged="drpdiv_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">Select Student : 
                        </td>
                        <td class="style6">
                            <asp:DropDownList ID="drpstudent" runat="server" CssClass="txt" OnSelectedIndexChanged="drpstudent_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="style5" valign="bottom">
                            <asp:Button ID="btnsarch" runat="server" CssClass="btn"
                                Text="Select" OnClick="btnsarch_Click" />
                        </td>
                        <td valign="bottom">
                            <asp:Label ID="lblcnt" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="659px" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Roll No">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Rollno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendence">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendence By">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("StaffName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendence Date">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("EDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <%--  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="659px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="rollno" HeaderText="RollNo" />
                        <asp:BoundField DataField="name" HeaderText="Student Name" />
                        <asp:BoundField DataField="status" HeaderText="Attendance" />
                        <asp:BoundField DataField="staffname" HeaderText="Attendance By" />
                        <asp:BoundField DataField="date" HeaderText="Attendance Date" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>--%>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


