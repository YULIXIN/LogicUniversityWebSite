<%@ Page Title="Search Item" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ModifyRequest.aspx.cs" Inherits="department_ModifyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <br />
    <asp:GridView ID="gridView" class="table table-striped table-hover autoCenter textInCenter" Width="60%" runat="server" AutoGenerateColumns="False" OnRowCommand="gridView_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="Requested_Date" HeaderText="Submit Date" />

                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Reason" HeaderText="Reject Reason" />
                    <asp:TemplateField HeaderText="View Detail">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%#Bind("Requisition_ID") %>'>View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


        
       <div ID="Label1" runat="server"  class="panel-heading" Visible="False" style="background-color: rgba(51, 170, 189, 0.63);">
            <asp:Label runat="server" ForeColor="#CC3300" Text="No pending request!" Style="text-align: center"></asp:Label>
        </div>
    </div>
</asp:Content>
