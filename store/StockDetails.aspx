<%@ Page Title="Stock Management" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" Language="C#" AutoEventWireup="true" CodeFile="StockDetails.aspx.cs" Inherits="store_StockDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <div style="width:80%; margin:3px auto">
            <br>
        <label class="control-label">
            Bin#:&nbsp;
        </label>        
        <asp:Label ID="Label2" runat="server" Text="" Font-Overline="False" class="control-label"></asp:Label>
        <br />
        <label class="control-label">
            Unit:&nbsp;
        </label>        
        <asp:Label ID="Label3" runat="server" Text="" Font-Overline="False" class="control-label"></asp:Label>
        <br />
        <br />
        </div>        
        <div class="btnInline">
            <asp:Label ID="Label1" runat="server" Font-Overline="False" Font-Size="Larger" ForeColor="#3399FF"></asp:Label>
        </div>
        <div style="height:400px;overflow:scroll">
            <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Balance" DataField="Balance" />
            </Columns>
        </asp:GridView>
        </div>
        
        <div class="btnInline">
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" CssClass="btn btn-primary" />

        </div>
    </div>

</asp:Content>


