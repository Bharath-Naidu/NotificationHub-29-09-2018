﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addnotifications.aspx.cs" Inherits="NHub.Addnotifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <table class="nav-justified">
        <tr>
            <td class="modal-sm" style="height: 35px; width: 156px">Source</td>
            <td style="height: 35px">
                <asp:DropDownList ID="SourceName" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 40px; width: 156px">Name</td>
            <td style="height: 40px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                
                
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 58px; width: 156px">Avaliable Channels</td>
            <td style="height: 58px; margin-left: 40px">
                <asp:CheckBox ID="CheckBoxIntranet" runat="server" Text="Intranet" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxEmails" runat="server" Text="Emails" />
                <br />
                <asp:CheckBox ID="CheckboxUnabot" runat="server" Text="Unabot" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckboxSMS" runat="server" Text="SMS" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 20px; width: 156px">Confidential Event</td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">Mandatory Event</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
    </table>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Height="46px" Text="Cancel" Width="103px" OnClick="ButtonCancel_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonADDEvent" runat="server" Height="44px" Text="ADD" Width="98px" OnClick="ButtonADDEvent_Click" />
    </p>
</asp:Content>
