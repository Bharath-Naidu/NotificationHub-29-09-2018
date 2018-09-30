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
            <td style="height: 39px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 156px; height: 32px;">Mandatory Event</td>
            <td style="height: 32px"></td>
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
                
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lstFruits]').multiselect({
                includeSelectAllOption: true
            });
            $("#Button1").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>

            <asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple">
                <asp:ListItem Text="Mango" Value="1" />
                <asp:ListItem Text="Apple" Value="2" />
                <asp:ListItem Text="Banana" Value="3" />
                <asp:ListItem Text="Guava" Value="4" />
                <asp:ListItem Text="Orange" Value="5" />
            </asp:ListBox>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                
                
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
