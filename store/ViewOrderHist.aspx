<%@ Page Title="Process Order" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" Language="C#" AutoEventWireup="true" CodeFile="ViewOrderHist.aspx.cs" Inherits="store_ViewOrderHist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" runat="Server">

    <div class="contentDiv">
        <div>
            <br>
            <asp:Label ID="Label2" runat="server" Text="Order Status" class="control-label"></asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                <asp:ListItem Selected="True">Approved</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Delivered</asp:ListItem>
                <asp:ListItem>Canceled</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div>
            <div class="btnInline">
                <h2>
                    Order History</h2>
            </div>
            <div class="panel-group" id="accordion">
                <div class="panel panel-default" runat="server">
                    <asp:ListView ID="ListView1" runat="server"  OnItemDataBound="ListView1_ItemDataBound">
                        <ItemTemplate>
                            <table width="100%" border="1px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="10%">
                                        <div class="panel-heading">
                                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href='<%# "#collapse"+ Container.DataItemIndex %>'>View</a> </h4>
                                        </div>
                                    </td>
                                    <td width="15%">
                                        <asp:Label ID="lbPO" runat="server" Text='<%#(string)Eval("PurchaseOrder_ID")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbPONO" runat="server" Text='<%#"PO: "+ (string)Eval("PurchaseOrder_ID")%>'></asp:Label>
                                    </td>
                                    <td width="20%">
                                        <asp:Label ID="lbTitle" runat="server" Text='<%#"Supplier: "+ (string)Eval("Supplier.Name")%>'></asp:Label>
                                    </td>
                                    <td width="20%">
                                        <asp:Label ID="lbOrderPrice" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="15%">
                                        <asp:Label ID="Label4" runat="server" Text='<%#((DateTime)Eval("Submission_Date")).ToString("yyyy-MMM-dd")%>'></asp:Label>
                                    </td>
                                    <td visible="false" id="tdReason">
                                        <asp:Label ID="lbRjectReason" runat="server" Text='<%#Eval("Reason") %>'></asp:Label>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div id='<%# "collapse"+ Container.DataItemIndex %>' class="panel-collapse collapse">
                                            <div class="panel-body">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"  ValidationGroup="G1"/>
                                                <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
                                                    Width="60%" runat="server" AutoGenerateColumns="false" DataSource='<%#Eval("PurchaseOrder_Details") %>'>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Description" DataField="Item.Item_Name" />
                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="tbQty" runat="server" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[1-9]\d{0,5}$" ControlToValidate="tbQty" ValidationGroup="G1" runat="server" ErrorMessage="Quantity must be positive integer" ForeColor="Red">*</asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbQty" ValidationGroup="G1" runat="server"  ErrorMessage="Quantity Cannot be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                <asp:HiddenField ID="hiddenItemID" runat="server" Value='<%#Eval("Item.Item_ID") %>' />
                                                                <%--<asp:HiddenField ID="hiddenDetailID" runat="server" Value='<%#Eval("PurchaseOrderDetails_ID") %>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Price">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbPrice" runat="server" Text='<%# "S$ " + Eval("Item.Price") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Unit" DataField="Item.UnitOfMeasurement" />
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAmount" runat="server" Text='<%# "S$ " + ((Convert.ToDouble(Eval("Item.Price")))*(Convert.ToInt32(Eval("Quantity")))) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                                <div class="btnInline">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Confirm Delivery" ValidationGroup="G1" OnClick="btnSubmit_Click" class="btn btn-primary" />
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="G1" OnClick="btnUpdate_Click" class="btn btn-primary"/>
                                                    <asp:Button ID="btnReorder" runat="server" Text="Reorder" ValidationGroup="G1" OnClick="btnReorder_Click" class="btn btn-primary" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel Editing" OnClick="btnCancel_Click" class="btn btn-primary"/>
                                                    <asp:Button ID="btnCancelOrder" runat="server" Text="CancelOrder" OnClick="btnCancelOrder_Click" class="btn btn-primary" />
                                                </div>
                                                <asp:HiddenField ID="hiddenOrderID" runat="server" Value='<%#Eval("PurchaseOrder_ID") %>' />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
