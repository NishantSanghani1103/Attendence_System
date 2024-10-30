﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="CodeHtml.Student.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            height: 23px;
        }
        .style6
        {
            width: 561px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">
                My Profile</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #8506A9; font-weight: bold; font-size: large">
                Name :
                <asp:Label ID="lblname" runat="server"></asp:Label>
           
               
            </td>
        </tr>
        <tr>
            <td style="color: #8506A9; font-weight: bold; font-size: large">
                 StdName:
                <asp:Label ID="Label3" runat="server"></asp:Label>
           
               
            </td>
        </tr>
        <tr>
             <td class="style5" style="color: #8506A9; font-weight: bold; font-size: large">
                Roll No :&nbsp;
                <asp:Label ID="lblroll" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="style6">
                    <tr>
                        <td class="lbl">
                            Email :</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="160px" />
                            <asp:Button ID="btnchange" runat="server" CssClass="btn"  Text="ADD" 
                                onclick="btnchange_Click" Width="50px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Mobile :</td>
                        <td>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td rowspan="4">
                            <asp:Image ID="img" runat="server" Height="125px" Width="112px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl"> 
                            Address :
                        </td>
                        <td>
                            <asp:TextBox ID="txtadd" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            City :
                        </td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl"> 
                            Pincode :
                        </td>
                        <td>
                            <asp:TextBox ID="txtpin" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnupdate" runat="server" CssClass="btn" Text="Update" 
                                onclick="btnupdate_Click" />
                            <br />
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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

