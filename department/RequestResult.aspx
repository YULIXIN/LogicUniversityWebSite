<%@ Page Title="Requisition Result" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="RequestResult.aspx.cs" Inherits="department_RequestResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <div class="panel-heading" style="background-color: rgba(51, 170, 189, 0.63); text-align: center">
            <h2 style="color: red">Notice: Requisition has been successfully submitted .</h2>
        </div>
        <br />
        <asp:GridView ID="gridView" class="table table-striped table-hover autoCenter textInCenter" Width="60%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="Description" />
                <asp:TemplateField HeaderText="Order Quantity">
                    <ItemTemplate>
                        <asp:Label ID="tbQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Unit" HeaderText="Unit" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>