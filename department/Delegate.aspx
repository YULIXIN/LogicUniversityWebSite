<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="Delegate.aspx.cs" Inherits="department_Delegate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <br />
        <h1>Edit Delegate</h1>
        <div class="panel panel-success" style="width: 50%; margin: 3px auto">
            <div class="panel-heading" style="background-color: rgba(51, 170, 189, 0.63);">
                <h3 class="panel-title">Current Delegate person:</h3>
            </div>
            <div class="panel-body" style="text-align: center">
                <asp:Label ID="lbCDP" runat="server" Text="" class="control-label"></asp:Label>
            </div>
        </div>
        <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <div id="showAll" runat="server">
           <div class="btnInline">
               <label class="control-label">From:</label>
            <input type="date" runat="server" id="datepicker" />
            <label class="control-label">To:</label>
            <input type="date" runat="server" id="datepicker2" />
           </div>       
            <br />     
            <div class="btnInline">
                <asp:Button ID="btnChangeDate" runat="server" Text="Change Duration" OnClick="btnChangeDate_Click" class="btn btn-primary"/>
                <asp:Button ID="btnCancelDelegate" runat="server" Text="Cancel Delegate" OnClick="btnCancelDelegate_Click" class="btn btn-primary"/>
            </div>
        </div>
    </div>
</asp:Content>

