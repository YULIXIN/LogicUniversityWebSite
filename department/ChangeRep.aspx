<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ChangeRep.aspx.cs" Inherits="department_ChangeRep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <br />
        <div class="panel panel-success" style="width: 50%; margin: 3px auto">
            <div class="panel-heading" style="background-color: rgba(63, 163, 220, 0.48);">
                <h3 class="panel-title">Current Representation:</h3>
            </div>
            <div class="panel-body" style="text-align: center">
                <asp:Label ID="lbCurrentRep" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
            <label class="col-lg-2 control-label modal-header" style="width: 52%; border: none">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Pick up a representative:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="col-lg-2 control-label modal-header blankBorder">
            </asp:DropDownList>
        </div>
        <br />
        <div class="btnInline">
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="btn btn-primary" style="background-color: rgba(63, 163, 220, 0.48);" />
        </div>
    </div>

    
</asp:Content>

