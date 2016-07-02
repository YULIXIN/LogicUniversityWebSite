<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/EmployeeConbineMaster.master" AutoEventWireup="true" CodeFile="NewDelegate.aspx.cs" Inherits="department_NewDelegate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConbineEmployeeContentPlaceHolder" Runat="Server">
   <div class="contentDiv">
        <h2>Please select a new delegate</h2>

        <div class="panel panel-success" style="width: 50%; margin: 3px auto">
            <div class="panel-heading" style="background-color: rgba(51, 170, 189, 0.63);">
                <div id="divDelegated" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="You must cancel current before do a new delegation" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="panel-body" style="text-align: center">
                <div id="divNotDegated" runat="server">
                    <label class="control-label marginModify">
                        Choose a new Delegate:
                    </label>                    
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Height="25px" CssClass="dpnInput"></asp:DropDownList>
                    <br />
                    <div class="btnInline">
                        <label class="control-label marginModify">
                            Begin Date:
                        </label>
                        <input type="date" id="datepicker" runat="server" class="control-label marginModify" />
                        <label class="control-label marginModify">
                            End Date:
                        </label>
                        <input type="date" id="datepicker2" runat="server" class="control-label marginModify" />
                    </div>
                    <div class="btnInline marginModify">
                        <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" CssClass="btn btn-primary marginModify" />
                    </div>

                </div>
            </div>
        </div>
    </div>

    <script>
        $(function () {

            var checkFields = function () {
                if ($("#" + "<%=datepicker.ClientID%>").val().length > 3)
                    if ($("#" + "<%=datepicker2.ClientID%>").val().length > 3)
                        return true;
                return false;
            };
            $("#" + "<%=Button1.ClientID%>").click(function (e) {
                if (checkFields()) {
                    var d1 = new Date($("#" + "<%=datepicker.ClientID%>").val());
                    var d2 = new Date($("#" + "<%=datepicker2.ClientID%>").val());
                    if (d1 > d2) {
                        e.preventDefault();
                        alert("Start date cannot");
                    }
                }
            })

          <%--  $("#" + "<%=datepicker.ClientID%>").change(function () {
                if(checkFields())
                {
                    var d1 = new Date($("#" + "<%=datepicker.ClientID%>").val());
                    var d2 = new Date($("#" + "<%=datepicker2.ClientID%>").val());
                    if (d1 > d2) {
                        alert("Start date cannot");
                    }
                }
                
            });

            $("#" + "<%=datepicker2.ClientID%>").change(function () {
                console.log($(this).val());
            })--%>
        });
    </script>
</asp:Content>

