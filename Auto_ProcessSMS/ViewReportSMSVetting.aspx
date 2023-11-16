
    <%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewReportSMSVetting.aspx.cs" Inherits="HoApps.Auto_ProcessSMS.ViewReportSMSVetting" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">`
        <script src="../App_Themes/Theme/assets/js/ViewReportSMSVetting.js"></script>
        <script src="../App_Themes/Theme/assets/js/jquery.js"></script>
        <script src="../App_Themes/Theme/assets/js/jquery.dataTables.min.js"></script>
        <script src="../App_Themes/Theme/assets/js/ZeroClipboard.js"></script>
        <script src="../App_Themes/Theme/assets/js/TableTools.js"></script>
        <script src="../App_Themes/Theme/assets/js/FixedColumns.js"></script>

        <style type="text/css" title="currentStyle">
            /*@import "App_Theme/"*/
            @import "../App_Themes/Theme/assets/css/demo_page.css";
            @import "../App_Themes/Theme/assets/css/demo_table.css";
            @import "../App_Themes/Theme/assets/css/jquery-ui-1.8.4.custom.css";
            @import "../App_Themes/Theme/assets/css/TableTools.css";
            .scroll {
                overflow-x: auto;
                white-space: nowrap;
            }
        </style>


        <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                var oTable = $('#example').dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers",
                    "sDom": 'T<"clear"><"H"lfr>t<"F"ip>',
                    "bAutoWidth": false,
                    "oTableTools": {
                        "aButtons": []
                    }
                });

            });

            function GetASORPT(dep) {
                debugger;
                alert(dep);
                window.open('ViewApprove_ContentSMS.aspx?seqId=' + dep + '', '_self');
            }
        </script>

    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="Form1" class="form-horizontal row-border" action="#" runat="server">
            <div class="container">
                <div class="col-md-11 well align-center" style="margin-top: 80px; padding-bottom: 38px;">
                    <div class="col-md-12 align-center">
                        <asp:Panel ID="Panel1" runat="server" Height="16%" Style="z-index: 100; left: 11px; top: 7px" Width="100%">
                            <div style="margin: 35px auto; text-align: center">
                                <asp:Label ID="Label2" runat="server" BackColor="Transparent" Font-Bold="True" Font-Size="X-Large"
                                    ForeColor="Green" Height="28px" Text="MANAPPURAM FINANCE LIMITED" Width="100%"></asp:Label>
                                <asp:Label ID="lblTitle" runat="server" BackColor="Transparent" Font-Bold="True" Font-Size="Large"
                                    ForeColor="Purple" Height="21px" Width="100%">  VIEW REPORT OF MESSAGE VETTING SMS </asp:Label><br />
                            </div>

                            <div id="demo" class="scroll">
                                <div id="MyTable" runat="server" style="margin-left: auto; margin-right: auto; text-align: center">
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <div class="col-md-12 align-center" style="margin-top:12px">
                        <label class="col-md-4 align-right" id="empRept">VIEW DEPARTMENT REPORTS : </label>
                        <div class="col-md-4">
                            <select onchange="handleOption()" id="ddlReport" class="form-control w-50 mx-auto" style="text-align: center;">
                                <option value="-1">--- SELECT APPROVAL OPTION --- </option>
                            </select>
                        </div>
                        <asp:Button ID="Button1" class="btn-prop" Text="SEARCH" runat="server" OnClick="btnTest_Click" style="padding: 8px 0;"></asp:Button>
                    </div>                    

                </div>
            </div>
            <input id="hdUserId" type="hidden" runat="server" />            
            <input id="HdnDepId" type="hidden" runat="server" />
        </form>
        
    </asp:Content>
