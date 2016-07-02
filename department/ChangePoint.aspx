<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ChangePoint.aspx.cs" Inherits="department_ChangePoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" runat="Server">
    <div class="contentDiv">
        <br />
        <div class="panel panel-success" style="width: 50%; margin: 3px auto">
            <div class="panel-heading" style="background-color: rgba(63, 163, 220, 0.48);">
                <h3 class="panel-title">Current Collection Point:</h3>
            </div>
            <div class="panel-body" style="text-align: center">
                <asp:Label ID="lbCurrentCP" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
            <label class="col-lg-2 control-label modal-header" style="width: 52%; border: none">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                New Collection Point:</label>
            <asp:DropDownList ID="ddlPoint" runat="server" CssClass="col-lg-2 control-label modal-header blankBorder"  DataTextField="Name" DataValueField="CollectionPoint_ID" OnSelectedIndexChanged="ddlPoint_SelectedIndexChanged" AutoPostBack="True" >
            </asp:DropDownList>
        </div>
        <br />
        <div style="text-align: center; margin: 2px auto; padding: 3px; height: 53px">
            <label class="col-lg-2 control-label modal-header" style="width: 52%; border: none">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Delivery Date:</label>
            <asp:Label ID="lbTime" runat="server" Text="" CssClass="col-lg-2 control-label modal-header blankBorder"></asp:Label>
        </div>
        <div class="btnInline">
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Changes" OnClick="btnConfirm_Click" CssClass="btn btn-primary" style="background-color: rgba(63, 163, 220, 0.48);"/>
        </div>
    </div>


</asp:Content>

