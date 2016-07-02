<%@ Page Title="Search Item" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="EditRequest2.aspx.cs" Inherits="department_EditRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" runat="Server">

    <div class="contentDiv">
        <div id="searchResult" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Qty"/>
            <br />
            <asp:GridView ID="gridView"  class="table table-striped table-hover autoCenter textInCenter" Width="60%" runat="server" AutoGenerateColumns="False" OnRowCommand="gridView_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ItemImage") %>' Width="80" Height="80" />
                        </ItemTemplate>
                        <ItemStyle BorderColor="#003300" Height="50px" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemName" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Order Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="tbQty" runat="server" TextMode="Number" Text='<%# Bind("Qty") %>' CssClass="centerInput"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="Field is required" ValidationGroup="Qty" ForeColor="Red">*this field is required</asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbQty" ErrorMessage="the quantity must be positive integer" ForeColor="Red" ValidationExpression="^[1-9]\d{0,5}$" ValidationGroup="Qty">*Quantity must be a positive integer</asp:RegularExpressionValidator>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit" />
                    <asp:TemplateField HeaderText="Remove">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                            <asp:HiddenField ID="HiddenFieldItemName" runat="server" Value='<%# Eval("ItemName") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="btnInline">
                <asp:Button ID="btnAddMore" runat="server" OnClick="btnAddMore_Click" Text="Add More Items" CssClass="btn btn-primary"/>
            <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" ValidationGroup="Qty" CssClass="btn btn-primary"/>
            </div>
        </div>
    </div>
</asp:Content>
