<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ViewDisbursment.aspx.cs" Inherits="department_ViewDisbursment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <div class="panel-heading" style="background-color: rgba(51, 170, 189, 0.63); text-align: left; width: 70%; margin: 3px auto">
            <label class="control-label marginModify">
                Delevery Time:
            </label>
            <asp:Label ID="lbDDate" runat="server" Text="" class="control-label marginModify"></asp:Label>
            <br />
            <label class="control-label marginModify">
                Collection Point:
            </label>            
            <asp:Label ID="lbCP" runat="server" Text="" class="control-label marginModify"></asp:Label>
        </div>
        <asp:GridView ID="gridView" class="table table-striped table-hover autoCenter textInCenter" Width="60%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Item.Item_Name" HeaderText="Name" />
                <asp:BoundField DataField="Request_Qty" HeaderText="Request Quantity" />
                <asp:BoundField DataField="Item.UnitOfMeasurement" HeaderText="Unit" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

