<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="ProcessOrder.aspx.cs" Inherits="store_ProcessOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">
    <div class="panel-group contentDiv" id="accordion">
        <div class="panel panel-default">
            <div class="btnInline">
                    <h2>
                        Pending Order
                    </h2>
            </div>
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>
                    <table width="85%" border="1px" cellpadding="0" cellspacing="0" class="table table-striped table-hover autoCenter textInCenter tableCenterText">
                        <tr>
                            <td width="10%">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href='<%# "#collapse"+ Container.DataItemIndex %>'>View Detail</a>
                                    </h4>
                                </div>
                            </td>
                            <td width="50%">
                                <asp:Label ID="lbTitle" runat="server" Text='<%#"Supplier: "+ (string)Eval("Supplier.Name")+ " , "+((DateTime)Eval("Submission_Date")).ToString("yyyy-MMM-dd")%>'></asp:Label>
                            </td>

                            <td width="15%">
                                <asp:LinkButton ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%#Bind("PurchaseOrder_ID")%>'>Approve</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%#Bind("PurchaseOrder_ID")%>'>Reject</asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="tbReason" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id='<%# "collapse"+ Container.DataItemIndex %>' class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
                                            Width="60%" runat="server" AutoGenerateColumns="false" DataSource='<%#Eval("PurchaseOrder_Details") %>'>
                                            <Columns>
                                                <asp:BoundField HeaderText="Description" DataField="Item.Item_Name" />
                                                <asp:BoundField HeaderText="Required Quantity" DataField="Quantity" />
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

                                    </div>
                                </div>
                            </td>

                        </tr>

                    </table>

                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

