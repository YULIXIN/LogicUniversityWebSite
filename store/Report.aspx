<%@ Page Title="Logic University Report" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" runat="Server">
    <div class="contentDiv">
        <div id="alertDiv" runat="server" visible="false" class="panel panel-success" style="width: 50%; margin: 3px auto">
            <div class="panel-heading">
                <h2 class="panel-title">System Alert</h2>
            </div>
            <div class="panel-body" style="text-align: center">
                <h1>Sorry! Wrong Input!<br />
                    Please Input Correct Date.
                </h1>
                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <div style="text-align: center" id="mainDiv" runat="server">
            <div style="text-align: left; width: 85%; margin: 6px auto">
                <div class="btn-group btn-group-justified" style="margin: 2px auto">
                    <asp:Button ID="btnItem" runat="server" Text="Department Requisition Report" OnClick="btnItem_Click" CssClass="btn btn-default" Width="220px" />
                    <asp:Button ID="btnPurchase" runat="server" Text="Purchase Order Report" CssClass="btn btn-default" OnClick="btnPurchase_Click" Width="200px" />
                    <asp:Button ID="btnCategoryCompare" runat="server" Text="Consumption Compare Report" CssClass="btn btn-default" OnClick="btnCategoryCompare_Click" Width="220px" />
                </div>
            </div>
            <div style="text-align: left; width: 70%; margin: 6px auto">
                <asp:Label ID="lbFrom" runat="server" Text="From: " Width="60px" Height="25px" Visible="false"></asp:Label>
                <input id="fromDate" type="date" class="control-label" runat="server" visible="false" />
                <asp:Label ID="lbTo" runat="server" Text="TO:" Width="60px" Height="25px" Visible="false"></asp:Label>
                <input id="toDate" type="date" class="control-label" runat="server" visible="false" />
            </div>
            <div style="text-align: left; width: 70%; margin: 6px auto">
                <asp:Label ID="lbCategory" runat="server" Text="Category :" Visible="false" Width="100px" Height="25px"></asp:Label>
                <asp:DropDownList ID="dpnCategory" runat="server" Width="200px" Height="25px" CssClass="dpnInput" Visible="false"></asp:DropDownList>
                <asp:Label ID="lbDepartment" runat="server" Text="Department :" Visible="false" Width="100px" Height="25px"></asp:Label>
                <asp:DropDownList ID="dpnDepartment" runat="server" Width="250px" Height="25px" CssClass="dpnInput" Visible="false"></asp:DropDownList>
            </div>
            <div style="text-align: left; width: 70%; margin: 6px auto" id="monthChoose" runat="server" visible="false">
                <asp:Label ID="lbMonthChoose" runat="server" Text="Choose Three Month To Compare : " Visible="false"></asp:Label>
                <input id="firstMonth" type="month" runat="server" visible="false" />
                <input id="secondMonth" type="month" runat="server" visible="false" />
                <input id="thirdMonth" type="month" runat="server" visible="false" />
            </div>
            <div class="btnInline">
                <asp:Button ID="btnOrder" runat="server" Text="Purchase Report" CssClass="btn btn-primary " OnClick="btnOrder_Click" Visible="false" />
                <asp:Button ID="btnCategory" runat="server" Text="Category Consumption" CssClass="btn btn-primary " OnClick="btnCategory_Click" Visible="false" />
                <asp:Button ID="btnCateCompare" runat="server" Text="Compare Report" CssClass="btn btn-primary " OnClick="btnCateCompare_Click" Visible="false" />
            </div>

            <div id="illustrationDiv" runat="server" visible="true" class="instructionDiv">
                <div style="margin: 2px auto">
                    <h1 style="margin: 1px">Welcome to Logic University Stationery Store Inventory Report System!
                    </h1>
                </div>
                <div style="text-align: left; width: 70%; margin: 2px auto">
                    <p>
                        <strong>You can generate following reports:
                        </strong>
                    </p>
                    <div style="text-align: left; width: 85%; margin: 2px auto">
                        <p>
                            •Category/Item & Department Consumption Report (for any continue duration have data)
                        </p>
                        <div style="text-align: left; width: 90%; margin: 2px auto">
                            <p>
                                * &nbsp; Click "Department Requisition Report"
                            </p>
                        </div>

                        <p>
                            •Purchase Order Report (for any continue duration have data)
                        </p>
                        <div style="text-align: left; width: 90%; margin: 2px auto">
                            <p>
                                * &nbsp; Click "Purchase Order Report"
                            </p>
                        </div>
                        <p>
                            •Category/Item & Department Consumption Compare Repo  (for any three month)
                        </p>
                        <div style="text-align: left; width: 90%; margin: 2px auto">
                            <p>
                                * &nbsp; Click "Consumption Compare Report"
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </div>
    </div>
</asp:Content>
