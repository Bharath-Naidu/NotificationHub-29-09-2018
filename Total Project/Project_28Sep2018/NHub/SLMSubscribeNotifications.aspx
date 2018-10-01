<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SLMSubscribeNotifications.aspx.cs" Inherits="NHub.SLMSubscribeNotifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <body>
   <p>
        <br />
    </p>
    <table class="nav-justified">

        <tr>
            <td class="modal-sm" style="height: 54px; width: 156px">Name</td>
            <td style="height: 54px">
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
            <td class="modal-sm" style="height: 39px; width: 156px">Confidential Event</td>
            <td style="height: 39px">

             



                <asp:RadioButton ID="CYes" runat="server" GroupName="Confidential" Text="Yes" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="CNo" runat="server" GroupName="Confidential" Checked="True" Text="No"/>

             



            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px; height: 32px;">Mandatory Event</td>
            <td style="height: 32px">
                <asp:RadioButton ID="MYes" runat="server" GroupName="Manadatroy" Text="Yes" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="MNo" runat="server" Checked="True" GroupName="Manadatroy" Text="No" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px; height: 16px;"></td>
            <td style="height: 16px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px; height: 49px;">Source Line</td>
            <td style="height: 49px">
                <asp:DropDownList ID="SourceName" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="modal-sm" style="width: 156px; height: 36px;">End Users</td>
            <td style="height: 36px">
                
                
                
                
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Add" runat="server" OnClick="Button1_Click" style="margin-left: 15" Text="Select" Width="109px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                
                
                
                
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


         </body>

</asp:Content>
