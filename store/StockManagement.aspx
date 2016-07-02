<%@ Page Title="Stock Management" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="StockManagement.aspx.cs" Inherits="store_StockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">

<div class="contentDiv">
        <br />
        <div class="btnInline">
            <asp:TextBox ID="tbSearch" runat="server" Width="164px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary"/>
            <asp:Button ID="Button1" runat="server" Text="Low Stock" OnClick="Button1_Click" CssClass="btn btn-primary" />
        </div>


        <div class="btnInline">            
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Larger" ForeColor="#3399FF"></asp:Label>
        </div>
    <div style="height:650px;overflow:scroll">
        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Width="80px" Height="80px" ImageUrl='<%#"~/itemImage/"+ ((LogicUniversity.Inventory)Container.DataItem).Item_ID +".jpg" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Item" DataField="Item.Item_Name" />
                <asp:TemplateField HeaderText="Tender Price">
                    <ItemTemplate>
                        <asp:Label ID="lbPrice" runat="server" Text='<%# "S$" + Eval("Item.Price")  + "/" + Eval("Item.UnitOfMeasurement")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Reorder Level" DataField="Item.ReOrderLevel" />
                <asp:BoundField HeaderText="Reorder Quantity" DataField="Item.ReOrderQty" />

                <asp:BoundField HeaderText="Current Stock" DataField="Balance" />
                <asp:BoundField HeaderText="Unit" DataField="Item.UnitOfMeasurement" />

                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%#Bind("Item_ID")%>'>View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

        

    </div>
</asp:Content>