﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="Complain.aspx.cs" Inherits="CodeHtml.Staff.Complain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 625px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
    <tr>
        <td class="tblhead">
            COMPLAIN MODULE</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="style1">
                        <tr>
                            <td>
                                Total Complain =
                                <asp:Label ID="lblcomplain" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:GridView ID="Gv" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                     style="text-align: center" 
                                    Width="659px" runat="server" AutoGenerateColumns="False" OnRowCommand="Gv_RowCommand">

                                    <Columns>
                                        <asp:TemplateField HeaderText="RollNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Complain">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reply">
                                            <ItemTemplate>
                                                &nbsp;<asp:Label ID="Label6" runat="server" Text='<%# Eval("Reply") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("CID") %>' CommandName="cmd_reply">Reply</asp:LinkButton>
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
                          
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table align="center" class="style4" style="border: thin solid #FF0000">
                        <tr>
                            <td class="tblhead">
                                Reply Complain
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Roll No :
                                <asp:Label ID="lblrno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name :
                                <asp:Label ID="lblname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subject :
                                <asp:Label ID="lblsub" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Complain :
                                <asp:Label ID="lblcomp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Answer :
                                <asp:TextBox ID="txtans" runat="server" CssClass="txt" Height="60px" 
                                    TextMode="MultiLine" Width="260px"></asp:TextBox>
                                <asp:Button ID="btnreplyy" runat="server" CssClass="btn" 
                                    onclick="btnreplyy_Click" Text="Reply" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
                &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
