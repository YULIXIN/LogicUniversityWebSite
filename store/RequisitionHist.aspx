<%@ Page Title="Requisition History" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" Language="C#" AutoEventWireup="true" CodeFile="RequisitionHist.aspx.cs" Inherits="store_RequisitionHist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">

        <script>
        $(function () {
            var checkFields = function () {
                if ($("#" + "<%=selectedDate.ClientID%>").val().length > 7)
                        return true;
                return false;
            };
            $("#" + "<%=btnView.ClientID%>").click(function (e) {
                if (!checkFields()) {
                    e.preventDefault();
                    alert("Date format is illegal");
                    }
            })

        });
    </script>

    <div class="contentDiv">
        <div class="btnInline">
            <br>
            Department:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlDept" runat="server">
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Category:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="selectedDate" type="date" runat="server" />
        </div>
        <div class="btnInline">
            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" class="btn btn-primary" />
        </div>
        <asp:Label ID="lbNoResultNotice" runat="server" Font-Size="Large" ForeColor="#3399FF"></asp:Label>
        <div class="btnInline">
            <br />
            <asp:Label ID="lbRetrivalTitle" runat="server" Font-Size="Large" ForeColor="#3399FF"></asp:Label>
        </div>
        <div style="width:80%;text-align:right;right:3px">
        <p> *-1 Means Not Delivered to the department</p>
        </div>
        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Width="80px" Height="80px" ImageUrl='<%#"~/itemImage/"+ ((LogicUniversity.Retrieval)Container.DataItem).Item_ID +".jpg" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Item" DataField="Item.Item_Name" />
                <asp:BoundField HeaderText="Requested Quantity" DataField="RequestedQuantity" />
                <asp:BoundField HeaderText="Retrieved Quantity" DataField="RetrievedQuantity" />
                <asp:BoundField HeaderText="Unit" DataField="Item.UnitOfMeasurement" />
                <asp:BoundField HeaderText="Generate Date" DataField="Date_Week" DataFormatString="{0:MM/dd/yyyy}" />
            </Columns>
        </asp:GridView>
        <div class="btnInline">
            <br />
            <asp:Label ID="lbDisbTitle" runat="server" Font-Size="Large" ForeColor="#3399FF"></asp:Label>
        </div>
        <asp:GridView ID="GridView2" class="table table-striped table-hover autoCenter textInCenter tableCenterText"
            Width="60%" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Width="80px" Height="80px" ImageUrl='<%#"~/itemImage/"+ ((LogicUniversity.Disbursement)Container.DataItem).Item_ID +".jpg" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Item" DataField="Item.Item_Name" />
                <asp:BoundField HeaderText="Requested Quantity" DataField="Request_Qty" />
                <asp:BoundField HeaderText="Disbursed Quantity" DataField="Disbursed_Qty" />
                <asp:BoundField HeaderText="Received Quantity" DataField="Received_Qty" />
                <asp:BoundField HeaderText="Generate Date" DataField="Retrieval.Date_Week" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField HeaderText="Unit" DataField="Item.UnitOfMeasurement" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
