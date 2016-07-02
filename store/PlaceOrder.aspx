<%@ Page Title="Process Order" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="store_ProcessOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" runat="Server">

    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gridView.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
                document.getElementById('<%= this.gridView.ClientID %>');
            var TargetChildControl = "ckRow";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                          Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }

        //checkbox validator
        function Validate() {
            var gridView = document.getElementById("<%=gridView.ClientID %>");
            var checkBoxes = gridView.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    return true;
                }
            }
            return false;
        }

        $(document).ready(function () {
            $("#" + "<%=btnAdd.ClientID %>").click(function (e) {
                if (!Validate()) {
                    e.preventDefault();
                    alert("Please select at least one Item");
                }

            });
        });
    </script>
    <div class="contentDiv">
        <div class="btnInline">
            <asp:TextBox ID="tbKeyword" runat="server" Style="margin-left: 0px" Width="233px" CssClass=" control-label "></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" class="btn btn-primary" />
        </div>
        <div class="leftContent">
            <div id="searchResult" runat="server" class="searchDiv">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Qty" />
                <br />
                <asp:GridView ID="gridView" class="table table-striped table-hover autoCenter  textInCenter" Width="60%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Selection">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ckRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ItemImage") %>' Width="80" Height="80" />
                        </ItemTemplate>
                        <ItemStyle BorderColor="#003300" Height="50px" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Item_Name" HeaderText="Item Name" />

                    <asp:BoundField HeaderText="Balance" DataField="Balance" />

                    <asp:TemplateField HeaderText="Order Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="tbQty" runat="server" TextMode="Number" Text='<%# Eval("ReOrderLevel") %>'></asp:TextBox>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="Quantity must be positive integer" ForeColor="Red" ValidationExpression="^\d{1,5}$" ValidationGroup="Qty" >*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Quantity cannot be empty" ValidationGroup="Qty" ForeColor="Red" ControlToValidate="tbQty" >*</asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit" Visible="True" />

                </Columns>
            </asp:GridView>
                <br />
            </div>

            <div class="btnInline" style="display: block; bottom: 2px">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add to Order list" ValidationGroup="Qty" class="btn btn-primary" />
            </div>
        </div>

        <div class="rightContent">
            <div id="shoppingcart"  class="pendingListDiv">
                <div class="btnInline">
                    <label>Supperlier:</label>
                    <asp:DropDownList ID="ddlSupplier" runat="server" DataTextField='Name' DataValueField="Supplier_ID"></asp:DropDownList>
                </div>
                <div id="emptyDiv" runat="server" class="btnInline">
                    <p style="color: red">The Order list is empty</p>
                </div>
                <div id="notEmptyDiv" runat="server">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="G1"  ForeColor="Red"/>                    
                    <br />
                    
                    <asp:GridView ID="gvCart" class="table table-striped table-hover autoCenter  textInCenter" Width="80%" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Item_Name" HeaderText="Item Name" />

                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbQuantity" runat="server" TextMode="Number" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbQuantity" runat="server" ErrorMessage="Quantity in the order list cannot be empty" ValidationGroup="G1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbQuantity" runat="server" ErrorMessage="Quantity in the order list must be positive integer" ValidationGroup="G1" ValidationExpression="^[1-9]\d{0,4}$" ForeColor="Red">*</asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkButtonRemove" runat="server" OnClick="linkButtonRemove_Click">Remove</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenFieldItemName" runat="server" Value='<%# Eval("Item_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>                
            </div>
            <div class="btnInline">
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" ValidationGroup="G1" OnClick="btnConfirm_Click" class="btn btn-primary" />

                </div>
        </div>
    </div>

<%--
    <div>
        <asp:TextBox ID="tbKeyword" runat="server" Style="margin-left: 0px" Width="233px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        <br />
        <br />

        <div id="searchResult" runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Qty" />
            <br />

            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Selection">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ckRow" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ItemImage") %>' Width="80" Height="80" />
                        </ItemTemplate>
                        <ItemStyle BorderColor="#003300" Height="50px" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Item_Name" HeaderText="Item Name" />

                    <asp:BoundField HeaderText="Balance" DataField="Balance" />

                    <asp:TemplateField HeaderText="Order Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="tbQty" runat="server" TextMode="Number" Text='<%# Eval("ReOrderLevel") %>'></asp:TextBox>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="Quantity must be positive integer" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Qty">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Quantity cannot be empty" ValidationGroup="Qty" ForeColor="Red" ControlToValidate="tbQty">*</asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit" Visible="True" />

                </Columns>
            </asp:GridView>--%>


        <%--<div id="shoppingcart" style="text-align: center">
                <div style="background-color: blue" id="notEmptyDiv" runat="server">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="G1" />
                    <asp:DropDownList ID="ddlSupplier" runat="server" DataTextField='Name' DataValueField="Supplier_ID"></asp:DropDownList>
                    <br />
                    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Item_Name" HeaderText="Item Name" />

                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbQuantity" runat="server" TextMode="Number" Text='<%# Eval("Qty") %>' BackColor="Blue"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbQuantity" runat="server" ErrorMessage="Quantity in the order list cannot be empty" ValidationGroup="G1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbQuantity" runat="server" ErrorMessage="Quantity in the order list must be positive integer" ValidationGroup="G1" ValidationExpression="^[1-9]\d*$" ForeColor="Red">*</asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkButtonRemove" runat="server" OnClick="linkButtonRemove_Click">Remove</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenFieldItemName" runat="server" Value='<%# Eval("Item_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" ValidationGroup="G1" OnClick="btnConfirm_Click" />
                </div>
                <div class="dropdown-content" style="background-color: blue" id="emptyDiv" runat="server">
                    <p style="color: red">The Order list is empty</p>
                </div>
            </div>--%>


          <%--  <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add to Order list" ValidationGroup="Qty" />

            <br />
            <br />--%>
<%--        </div>
    </div>--%>
</asp:Content>
