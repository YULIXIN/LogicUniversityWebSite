<%@ Page Title="Search Item" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="SearchItem.aspx.cs" Inherits="store_SearchItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" runat="Server">


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
        <br />
        <div class="btnInline">
            <asp:TextBox ID="tbKeyword" runat="server" Style="margin-left: 0px" Width="280px" Height="40px" CssClass="control-label marginModify"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-primary marginModify" />
            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View Request list" ValidationGroup="Qty" CssClass="btn btn-primary marginModify" />
        </div>

        <br />
        <br />
        <div id="searchResult" runat="server" style="height: 600px; overflow: scroll">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Qty" />
            <br />
            <asp:GridView ID="gridView" class="table table-striped table-hover autoCenter textInCenter tableCenterText" Width="60%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Selection">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" CssClass="centerCheckbox tableCenterText" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ckRow" runat="server" CssClass="centerCheckbox tableCenterText" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ItemImage") %>' Width="80" Height="80" CssClass="centerInput tableCenterText" />
                        </ItemTemplate>
                        <%--<ItemStyle BorderColor="#003300" Height="50px" Width="50px" />--%>
                    </asp:TemplateField>
                     <asp:BoundField DataField="ItemName" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Order Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="tbQty" runat="server" TextMode="Number" Text="0" name="quantity" CssClass="centerInput tableCenterText"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="Field is required" ValidationGroup="Qty" ForeColor="Red">*this field is required</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="Quantity must be positive integer" ForeColor="Red" ValidationExpression="^\d{1,5}$" ValidationGroup="Qty">*Quantity must be a positive integer</asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit" Visible="True" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
        <div id="searchResult1" runat="server">
            <div class="btnInline" >
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add to Request list" ValidationGroup="Qty" CssClass="btn btn-primary marginModify" />
            </div>
        </div>
        </div>
</asp:Content>
