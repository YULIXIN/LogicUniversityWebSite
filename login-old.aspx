<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage/SupMasterPage.master" AutoEventWireup="true" CodeFile="login-old.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SupContentPlaceHolder" runat="Server">
    <div class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="tbUsername" runat="server" ValidationGroup="G1"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" ErrorMessage="Username cannot be empty" ValidationGroup="G1"></asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" ValidationGroup="G1"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" ErrorMessage="password cannot be empty" ValidationGroup="G1"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbLoginFail" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        <asp:Button ID="loginBtn" runat="server" Text="Login" Width="143px" OnClick="loginBtn_Click" ValidationGroup="G1" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ForgetPassword.aspx">Forget Password</asp:LinkButton>
    </div>
</asp:Content>

