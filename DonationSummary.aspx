<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DonationSummary.aspx.cs" Inherits="DonationSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Donation Summary</h1>
        <p>Thank you for your donation. Here's your donation summary:</p>
         <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
