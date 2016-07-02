<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="ViewAdjustmentHis.aspx.cs" Inherits="store_ViewAdjustmentHis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" runat="Server">
    <div class="contentDiv">
        <div class="btnInline">
            <h2>Adjustment History</h2>
        </div>
        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Item.Item_Name" HeaderText="Item Name " />
                <asp:BoundField DataField="Reason" HeaderText="Reason" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="Reject_Reason" HeaderText="Reject Reason" />
            </Columns>
            <EmptyDataTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </EmptyDataTemplate>

        </asp:GridView>
    </div>
</asp:Content>

