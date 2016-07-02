<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="ProcessAdjustment2.aspx.cs" Inherits="store_ProcessAdjustment2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <br />

        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" Height="159px"  OnRowCommand="GridView1_RowCommand"  OnRowCreated="GridView1_RowCreated" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Adjustment Detail ID" />
                <asp:BoundField DataField="Item" HeaderText="Item" />
                <asp:BoundField DataField="Adjust_Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                <asp:BoundField DataField="totalPrice" HeaderText="Total Price" />
                <asp:TemplateField HeaderText="Reject Reason">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField CommandName="Approve" Text="Approve"   />
                <asp:ButtonField CommandName="Reject" Text="Reject"  />
            </Columns>
            <EmptyDataTemplate>
                <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Approve" />--%>
            </EmptyDataTemplate>
        </asp:GridView>
<%--        <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="">
        </asp:LinqDataSource>--%>
</div>
</asp:Content>

