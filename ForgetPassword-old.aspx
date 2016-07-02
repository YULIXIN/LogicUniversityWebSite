<%@ Page Title="Forget Password" Language="C#" MasterPageFile="~/MasterPage/SupMasterPage.master" AutoEventWireup="true" CodeFile="ForgetPassword-old.aspx.cs" Inherits="ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SupContentPlaceHolder" runat="Server">
    <div class="auto-style1">

        <asp:Label ID="Label1" runat="server" Text="Email:    "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEmailAddress" runat="server" Width="224px"></asp:TextBox>
        <br />
        <asp:Label ID="lbError" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Style="height: 26px" Text="Send Email" />
        <br />
        <asp:Label ID="lbEmailSent" runat="server"></asp:Label>

    </div>
</asp:Content>
