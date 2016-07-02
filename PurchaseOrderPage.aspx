<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseOrderPage.aspx.cs" Inherits="PurchageOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/LogicUniversityStyle.css" rel="stylesheet" />
    <link href="Content/SubMenu.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</head>
<body>
    <div runat="server" id="divMain" class="contentDiv">
        <form id="form1" runat="server">
       <div class="btnInline">
            <h1>Logic University</h1>
             <h3>Stationery Purchase Order</h3>
       </div>
           
                Supplier:
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
                Deliver to: Logic University<br />
                By Date:
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
                <asp:GridView class="table table-striped table-hover autoCenter textInCenter tableCenterText"
                                            Width="60%" ID="GridView1" runat="server">
                </asp:GridView>
            <br />
            <br />
 

        </form>
     </div>
    <div runat="server" id="divError">
        <h5 style="color: #FF0000">you are not allowed to visit this page</h5>
    </div>
</body>
</html>
