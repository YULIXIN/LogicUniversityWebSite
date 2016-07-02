<%@ Page Title="Create Adjustment" Language="C#"  MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="CreateAdjustment.aspx.cs" Inherits="store_CreateAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">

        <div class="contentDiv">
                <asp:Panel ID="Panel1" runat="server" class="panel panel-default">
                    &nbsp;&nbsp;<asp:SqlDataSource ID="ItemSource" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString1 %>" SelectCommand="SELECT [Item_ID], [Item_Name], [UnitOfMeasurement] FROM [Items]"></asp:SqlDataSource>
                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="G1" />

                    <br />
                    <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
                        <label class="col-lg-2 control-label" id="ItemLabel" runat="server" style="width: 45%; border: none">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Item:
                        </label>
                        <asp:DropDownList ID="itemDropDown" runat="server" AutoPostBack="True" DataValueField="Item_ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataTextField="Item_Name" CssClass="col-lg-2 control-label modal-header blankBorder">
                        </asp:DropDownList>
                    </div>
                    <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
                        <label class="col-lg-2 control-label" id="QuantityLabel" runat="server" style="width: 45%; border: none">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Quantity:
                        </label>
                        <asp:TextBox ID="quantity" runat="server" TextMode="Number" CssClass="col-lg-2 control-label modal-header blankBorder"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="quantity" ErrorMessage="Quantity Cannot be Empty" ForeColor="Red" ValidationGroup="G1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="quantity" ErrorMessage="Quantity must be an Non-zero integer" ValidationExpression="^[-+]?[1-9]\d{0,5}$" ValidationGroup="G1">*</asp:RegularExpressionValidator>
                        <label class="col-lg-2 control-label" style="width: 35%; border: none">Unit:</label><asp:Label ID="lbUnit" runat="server" Text="Label" Style="width: 35%; border: none" class="col-lg-2 control-label"></asp:Label>
                       
                    </div>
                    <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
                        <label class="col-lg-2 control-label" id="reasonLabel" runat="server" style="width: 45%; border: none">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Reason:
                        </label>
                        <asp:TextBox ID="reason" runat="server" TextMode="MultiLine" CssClass="col-lg-2 control-label modal-header blankBorder" MaxLength="30"></asp:TextBox>
                    </div>
                    <br />
                    <div class="btnInline">
                        <asp:Button ID="Button1" runat="server" OnClick="Add_Click" Text="Add" ValidationGroup="G1" CssClass="btn btn-primary marginModify" />
                    </div>
                    
                    <div id="searchResult" runat="server" style="height:400px;overflow:scroll">
                        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText" Width="60%" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="AdjustmentDetails_ID" DataSourceID="AdjustmentDetailDS" >
                            <Columns>
                                <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" ReadOnly="True" />
                                <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" ReadOnly="True" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" ReadOnly="True" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:SqlDataSource ID="AdjustmentDetailDS" runat="server" ConnectionString="<%$ ConnectionStrings:LogicUniversityConnectionString1 %>" SelectCommand="select a.AdjustmentDetails_ID, i.Item_Name as Item, i.UnitOfMeasurement as Unit, a.Item_ID, a.Reason,a.status, a.Qty
 from Adjustment_Details  a join Items i on i.item_id = a.item_id and a.Status='Pending' order by a.AdjustmentDetails_ID DESC"
                        DeleteCommand="DELETE FROM Adjustment_Details WHERE (AdjustmentDetails_ID = @AdjustmentDetails_ID )" UpdateCommand="update Adjustment_Details set Qty = @Qty,Reason = @Reason where AdjustmentDetails_ID = @AdjustmentDetails_ID">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="AdjustmentDetails_ID" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="GridView1" DefaultValue="1" Name="Qty" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView1" DefaultValue="" Name="Reason" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="AdjustmentDetails_ID" PropertyName="SelectedValue" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                </asp:Panel>


            </div>
    
    

</asp:Content>

