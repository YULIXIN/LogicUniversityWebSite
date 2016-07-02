<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="RejectedAdjustment.aspx.cs" Inherits="store_RejectedAdjustment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <asp:Panel ID="Panel1" runat="server">
            <div class="btnInline">
                <h2>Rejected Adjustment Form</h2>
                <asp:Label ID="CurrentDateLabel" class="control-label" runat="server" Text="Current Date:"></asp:Label>
                <asp:Label ID="currentDate" class="control-label" runat="server"></asp:Label>
            </div>

            <br />
            <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
                Width="60%" runat="server" AutoGenerateColumns="False" DataKeyNames="AdjustmentDetails_ID" DataSourceID="RejectedDS">
                <Columns>
                    <asp:BoundField DataField="AdjustmentDetails_ID" HeaderText="AdjustmentDetails_ID" InsertVisible="False" ReadOnly="True" SortExpression="AdjustmentDetails_ID" Visible="False" />
                    <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                    <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
                    <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" SortExpression="Item_ID" Visible="False" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Reject_Reason" HeaderText="RejectReason" SortExpression="Reason" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="RejectedDS" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString %>" SelectCommand="SELECT a.AdjustmentDetails_ID, i.Item_Name AS Item, i.UnitOfMeasurement AS Unit, a.Item_ID, a.Reject_Reason, a.Status, a.Qty FROM Adjustment_Details AS a INNER JOIN Items AS i ON i.Item_ID = a.Item_ID WHERE (a.Status LIKE '%Rejected%') order by  a.AdjustmentDetails_ID DESC"></asp:SqlDataSource>
            <%--<asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" Text="Update" />--%>
            <br />
        </asp:Panel>
    </div>
</asp:Content>

