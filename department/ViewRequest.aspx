<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ViewRequest.aspx.cs" Inherits="department_ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" runat="Server">
    <div class="contentDiv">

        <div class="panel-heading" style="background-color: rgba(51, 170, 189, 0.63); text-align: left; width: 70%; margin: 3px auto">
            <label class="control-label marginModify">
                Request Date:
            </label>
            <asp:Label ID="lbDate" runat="server" Text="" class="control-label marginModify"></asp:Label>
            <br />
            <label class="control-label marginModify">
                Status : 
            </label>
            <asp:Label ID="lbStatus" runat="server" Text="" class="control-label marginModify"></asp:Label>
        </div>
        <div style="text-align: center">
            <asp:GridView ID="gridview" class="table table-striped table-hover autoCenter textInCenter tableCenterText" Width="60%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Item.Item_Name" HeaderText="Item Name" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Label1" runat="server" ImageUrl='<%# "../itemImage/"+Eval("Item.Item_ID")+".jpg" %>' Width="80" Height="80"></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Requested_Qty" HeaderText="Quantity" />
                    <asp:BoundField DataField="Item.UnitOfMeasurement" HeaderText="Unit" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="btnInline">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-primary marginModify" />
            <asp:Button ID="btnDelete" runat="server" Text="Cancel this Requisition" Visible="False" OnClick="btnDelete_Click" CssClass="btn btn-primary marginModify" />
        </div>
    </div>

</asp:Content>

