<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="ViewPendingRequests.aspx.cs" Inherits="department_ViewPendingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <h2 class="text-center contentDiv">Pending Requisition</h2>
    <div class="panel-group" id="accordion">
        <div class="panel panel-default">
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" >
                <LayoutTemplate>
                    <table width="100%" border="1px" cellpadding="0" cellspacing="0" class="table table-striped table-hover autoCenter textInCenter tableCenterText">
                        <tr>
                            <th width="15%">Detail</th>
                            <th width="15%">Employee Name</th>
                            <th width="15%">Submit Date</th>
                            <th width="15%">Status</th>
                            <th width="15%">Action</th>
                            <th>Reject Reason</th>
                        </tr>
                    </table>
                    <div runat="server" id="itemPlaceHolder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <table width="100%" border="1px" cellpadding="0" cellspacing="0" class="table table-striped table-hover autoCenter textInCenter tableCenterText">
                        <tr>
                            <td width="15%">
                                <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href='<%# "#collapse"+Container.DataItemIndex %>'>View Detail</a>
                                </h4>
                                </div>
                            </td>
                            
                            <td width="15%"><%#Eval("Staff.Name") %></td>
                            <td width="15%"><%#Eval("Requested_Date") %></td>
                            <td width="15%"><%#Eval("Status") %></td>
                            <td width="15%">
                                    <asp:LinkButton ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%#Bind("Requisition_ID")%>'>Approve</asp:LinkButton>
                                    &nbsp;
                                <asp:LinkButton ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%#Bind("Requisition_ID")%>'>Reject</asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="tbReason" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id='<%# "collapse"+ Container.DataItemIndex %>' class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <asp:GridView ID="GridView1" class="table table-striped table-hover autoCenter textInCenter tableCenterText" Width="60%" runat="server" AutoGenerateColumns="false" DataSource='<%#Eval("Requisition_Details") %>'>
                                            <Columns>
                                                <asp:BoundField HeaderText="Description" DataField="Item.Item_Name" />
                                                <asp:BoundField HeaderText="Required Quantity" DataField="Requested_Qty" />
                                                <asp:BoundField HeaderText="Unit" DataField="Item.UnitOfMeasurement" />
                                            </Columns>
                                        </asp:GridView>
                                            
                                    </div>
                                </div>
                            </td>
                                
                        </tr>

                    </table>
                    
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    </div>
    <asp:Label ID="Label1" runat="server" ForeColor="#CC3300" Text="No pending request!" Visible="False" style="text-align: center" class="control-label marginModify"></asp:Label>
</asp:Content>

