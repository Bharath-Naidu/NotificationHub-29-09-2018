<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNotifications.aspx.cs" Inherits="NHub.EditNotifications" %>
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
            <td class="modal-sm" style="height: 32px; width: 156px">Confidential Event</td>
            <td style="height: 32px">

             



                <asp:RadioButton ID="CYes" runat="server" GroupName="Confidential" Text="Yes" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="CNo" runat="server" GroupName="Confidential" Checked="True" Text="No"/>

             



            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">Mandatory Event</td>
            <td>
                <asp:RadioButton ID="MYes" runat="server" GroupName="Manadatroy" Text="Yes" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="MNo" runat="server" Checked="True" GroupName="Manadatroy" Text="No" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="2">Dynamic Fields:<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Source Field&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Unique Alias<br />
&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="138px" Font-Size="Large">SC_User Name</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="138px">
                    <asp:ListItem Value="1">Text</asp:ListItem>
                    <asp:ListItem Enabled="False" Value="2">Type</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="138px" Font-Size="Large">BD_Name</asp:TextBox>
                <br />
                <br />
                2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" Height="25px" Width="138px" Font-Size="Large">SC_Birth date</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="138px">
                    <asp:ListItem Value="1">Text</asp:ListItem>
                    <asp:ListItem Value="2">Type</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" Height="25px" Width="138px" Font-Size="Large">BD_Day</asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Height="46px" Text="Cancel" Width="103px" OnClick="ButtonCancel_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonUpdateEvent" runat="server" Height="44px" Text="Update" Width="98px" OnClick="ButtonADDEvent_Click" />
    </p>



</asp:Content>
