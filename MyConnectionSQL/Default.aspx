<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Default.aspx.vb" Inherits="MyConnectionSQL._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 71%;
            height: 90px;
        }

        .auto-style4 {
            width: 229px;
            height: 23px;
        }

        .auto-style5 {
            height: 23px;
        }

        .auto-style6 {
            height: 23px;
            width: 158px;
        }

        .auto-style7 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="auto-style2">
        <tr>
            <td class="auto-style4">Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style7" Height="16px" Width="207px"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Email</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style7" Height="16px" TextMode="Email" Width="207px"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Telephone number</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style7" Height="16px" TextMode="Phone" Width="207px"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Passenger ID</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxPassengerId" runat="server" CssClass="auto-style7" Height="16px" Width="207px"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style6">
                <asp:Button ID="Button1" runat="server" Text="Insert" Width="134px" OnClick="Button1_Click" />
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Show Data</td>
            <td class="auto-style6">
                <asp:Button ID="ButtonShowData" runat="server" Text="Show Data" Width="134px" OnClick="ButtonShowData_Click" />
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Last Name</td>
            <td>
                <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Status</td>
            <td>
                <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style4">Date of Birth</td>
            <td>
                <asp:Label ID="LabelDateOfBirth" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
    </table>
</asp:Content>
