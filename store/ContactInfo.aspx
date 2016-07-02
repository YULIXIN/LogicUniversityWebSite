<%@ Page Title="Contact Information" Language="C#" MasterPageFile="~/MasterPage/ClerkConbineMaster.master" AutoEventWireup="true" CodeFile="ContactInfo.aspx.cs" Inherits="store_ContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineClerkContentPlaceHolder" Runat="Server">
    <div class="contentDiv">
        <div class="treeDiv">
            <%--   <asp:TreeView ID="TreeView1" runat="server" Width="100px" NodeIndent="10" ShowExpandCollapse="False">
                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                <Nodes>
                    <asp:TreeNode Text="Supplier" Value="Supplier">
                        <asp:TreeNode Text="ALPA" Value="ALPA"></asp:TreeNode>
                        <asp:TreeNode Text="BANES" Value="BANES"></asp:TreeNode>
                        <asp:TreeNode Text="CHEF" Value="CHEF"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="Department" Value="Department">
                        <asp:TreeNode Text="ENGL" Value="ENGL"></asp:TreeNode>
                        <asp:TreeNode Text="CPSC" Value="CPSC"></asp:TreeNode>
                        <asp:TreeNode Text="COMM" Value="COMM"></asp:TreeNode>
                        <asp:TreeNode Text="REGR" Value="REGR"></asp:TreeNode>
                        <asp:TreeNode Text="ZOOL" Value="ZOOL"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                <ParentNodeStyle Font-Bold="False" />
                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>--%>

            <div class="btn-group btn-group-justified" style="width: 100%; margin: 2px auto">
                <table border="0">
                    <tr>
                        <td>
                            <asp:Button ID="Supplier" runat="server" Text="Supplier" class="btn btn-primary" OnClick="Supplier_Click" Width="100%"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="SupplierDiv">
                                <asp:Button ID="ALPA" runat="server" OnClick="ALPA_Click" Text="ALPA" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="CHEP" runat="server" OnClick="CHEP_Click" Text="CHEP" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="BANE" runat="server" OnClick="BANE_Click" Text="BANE" class="btn btn-info" Width="100%"></asp:Button>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Department" runat="server" Text="Department" class="btn btn-primary" OnClick="Department_Click" Width="100%"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="DepartmentDiv">
                                <asp:Button ID="ENGL" runat="server" OnClick="ENGL_Click" Text="ENGL" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="CPSC" runat="server" OnClick="CPSC_Click" Text="CPSC" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="COMM" runat="server" OnClick="COMM_Click" Text="COMM" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="REGR" runat="server" OnClick="REGR_Click" Text="REGR" class="btn btn-info" Width="100%"></asp:Button>
                                <asp:Button ID="ZOOL" runat="server" OnClick="ZOOL_Click" Text="ZOOL" class="btn btn-info" Width="100%"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="informationDiv" id="ALPAInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>ALPHA OFFICE SUPPLIER</strong></p>
                </caption>
                <tr>
                    <td>GST Registration NO.</td>
                    <td>MR-8500440-2</td>
                </tr>
                <tr>
                    <td>Contact Name</td>
                    <td>Ms Irene Tan</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>461 9928</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>461 2238</td>
                </tr>
                <tr>
                    <td>Adress</td>
                    <td>Blk 1128, Ang Mo Kio Industrial Park
                        <br />
                        #02-1108 Ang Mo Kio Street 62 
                        <br />
                        Singapore 622262
                    </td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="CHEPInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>CHEAP STATIONER</strong></p>
                </caption>
                <tr>
                    <td>GST Registration NO.</td>
                    <td>NIL</td>
                </tr>
                <tr>
                    <td>Contact Name</td>
                    <td>Mr Soh Kway Koh</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>354 3234</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>474 2734</td>
                </tr>
                <tr>
                    <td>Adress</td>
                    <td>Blk 34, Clementi Road
                        <br />
                        #07-02 Ban Soh Building
                        <br />
                        Singapore 110525
                    </td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="BANEInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>BANES SHOP</strong></p>
                </caption>
                <tr>
                    <td>GST Registration NO.</td>
                    <td>MR-8200420-2</td>
                </tr>
                <tr>
                    <td>Contact Name</td>
                    <td>Mr Loh Ah Pek</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>478 1234</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>479 2434</td>
                </tr>
                <tr>
                    <td>Adress</td>
                    <td>Blk 124, Alexandra Road
                        <br />
                        #03-04 Banes Building
                        <br />
                        Singapore 550315
                    </td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="ENGLInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>ENGLISH DEPARTMENT</strong></p>
                </caption>
                <tr>
                    <td>Contact Name</td>
                    <td>Mrs Pamela Kow</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>874 2234</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>892 1456</td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="CPSCInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>COMPUTER SCIENCE</strong></p>
                </caption>
                <tr>
                    <td>Contact Name</td>
                    <td>Mr Wee Kian Fatt</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>890 1235</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>892 1457</td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="COMMInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>COMMERCE DEPARTMENT</strong></p>
                </caption>
                <tr>
                    <td>Contact Name</td>
                    <td>Mr Mohd Azman</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>874 1284</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>892 1256</td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="REGRInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>REGISTRAR DEPARTMENT</strong></p>
                </caption>
                <tr>
                    <td>Contact Name</td>
                    <td>Ms Helen Ho</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>890 1266</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>892 1465</td>
                </tr>
            </table>
        </div>

        <div class="informationDiv" id="ZOOLInfo" runat="server" >
            <table class="table table-striped table-hover informationTable ">
                <caption style="margin: 3px auto; text-align:center">
                    <p><strong>ZOOLOGY DEPARTMENT</strong></p>
                </caption>
                <tr>
                    <td>Contact Name</td>
                    <td>Mr. Peter Tan Ah Meng</td>
                </tr>
                <tr>
                    <td>Phone NO</td>
                    <td>890 1266</td>
                </tr>
                <tr>
                    <td>Fax NO</td>
                    <td>892 1465</td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

