<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GrantApplyPage.aspx.cs" Inherits="GrantApplyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Grant Application Form</h1>   
    <table>
    <tr>
        <td>Select Service:  </td>
         <td>
             <asp:DropDownList ID="ddServices" runat="server" DataSourceID="SqlDataSource1" DataTextField="ServiceName" DataValueField="ServiceKey"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommunityAssistConnectionString %>" SelectCommand="SELECT [ServiceKey], [ServiceName] FROM [CommunityService]">
             </asp:SqlDataSource>
         </td>
         </tr>
         <tr>
            <td>Enter requested grant amount:  </td>
            <td><asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>Enter reason for grant request below:  </td>
        </tr>
        </table>
        <table>
        <tr>
            <td><asp:TextBox ID="txtExplain" TextMode="MultiLine" Rows="10" Columns="45" runat="server"></asp:TextBox>
            </td>
        </tr>
        </table>
        <table>
         <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
