<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="CodeHtml.Admin.Message1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style3 {
            height: 19px;
        }

        .style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">Leave Report</td>
        </tr>
        <tr>
            <td class="style3"></td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>Select Standard :
                        <asp:DropDownList ID="drpstd" runat="server" CssClass="txt">
                        </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnnewleave" runat="server" CssClass="btn"
                                OnClick="btnnewleave_Click" Text="New Leave Report" Width="160px" />
                            &nbsp;
                <asp:Button ID="btnapprove" runat="server" CssClass="btn"
                    OnClick="btnapprove_Click" Text="Approve Leave" Width="160px" />
                            &nbsp;
                <asp:Button ID="btnreject" runat="server" CssClass="btn"
                    OnClick="btnreject_Click" Text="Reject Leave" Width="160px" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td>Total New Leave =
                                    <asp:Label ID="lblnew" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="#333333"
                                                    Style="text-align: center" Width="727px" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="RollNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Days">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("NoDays") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
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
                                                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="#333333"  
                                        style="text-align: center" Width="727px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="rollno" HeaderText="RollNo" />
                                            <asp:BoundField DataField="name" HeaderText="Student Name" />
                                            <asp:BoundField DataField="message" HeaderText="Subject" />
                                            <asp:BoundField DataField="nodays" HeaderText="Days" />
                                            <asp:BoundField DataField="Reply" HeaderText="Status" />
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
                                    </asp:GridView>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td>Total Apporved Leave =
                                    <asp:Label ID="lblapp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                       BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="#333333"  style="text-align: center" 
                                        Width="727px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="rollno" HeaderText="RollNo" />
                                            <asp:BoundField DataField="name" HeaderText="Student Name" />
                                            <asp:BoundField DataField="message" HeaderText="Subject" />
                                            <asp:BoundField DataField="nodays" HeaderText="Days" />
                                            <asp:BoundField DataField="Reply" HeaderText="Status" />
                                        
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
                                    </asp:GridView>--%>
                                                <asp:GridView ID="GridView2" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="#333333"
                                                    Style="text-align: center" Width="727px" runat="server" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="RollNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Days">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("NoDays") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Reply") %>'></asp:Label>
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
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table class="style1">
                                        <tr>
                                            <td>Total Rejected Leave =
                                    <asp:Label ID="lblrej" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView3" runat="server" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ForeColor="#333333"
                                                    Style="text-align: center" Width="727px" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="RollNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Days">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("NoDays") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Reply") %>'></asp:Label>
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
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
