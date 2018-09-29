<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="NHub.Access" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        Manage Users</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Search" />
    </p>
    <p>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">

        </asp:PlaceHolder>
    </p>
    <p>
    </p>
</asp:Content>
