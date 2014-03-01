<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GrantSummary.aspx.cs" Inherits="GrantSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <h1>Grant Summary</h1>
        <p>Thank you for applying. Here's a summary of your grant:</p>
         <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>

