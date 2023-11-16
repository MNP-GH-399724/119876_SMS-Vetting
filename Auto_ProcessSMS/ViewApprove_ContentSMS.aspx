<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewApprove_ContentSMS.aspx.cs" Inherits="HoApps.Auto_ProcessSMS.ViewApprove_ContentSMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Theme/assets/js/ViewApprove_ContentSMS.js"></script>
    <script src="../App_Themes/Theme/assets/js/html2canvas.js"></script>
    <script src="../App_Themes/Theme/assets/js/jspdf.js"></script>
    <style>
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div data-ng-controller="MyCtrl" >
        <div class="col-md-12 align-center" id="CanVas">
            <form id="Form2" class="form-horizontal row-border" action="#" runat="server">
                <div class="row">
                    <br />`
                    <div class="container align-center">
                        <div class="row">
                            <h3 style="color: #091221;"><i class="icon-reorder"></i>MANAPPURAM FINANCE LIMITED</h3>
                        </div>
                        <div class="row">
                            <h3 style="color: #091221;">DETAIL VIEW SMS CONTENT</h3>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="container col-md-12">
                        <div class=" col-md-6 ">
                            <div class="form-group col-md-12 padding-bottom-10px" id="divcreteDate">
                                <label class="col-md-4 align-right" id="creteDate">CREATED DATE: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_CreteDate" name="enm" maxlength="80" style="background-color: white; color:black; padding:0;" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divfrmecd">
                                <label class="col-md-4 align-right" id="empcd">CREATED EMP_CODE: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_code" name="enm" maxlength="80" style="background-color: white; color:black; padding:0;" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divfrmenm">
                                <label class="col-md-4 align-right" id="empnm">CREATED EMP_NAME : </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_name" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divfrmedp ">
                                <label class="col-md-4 align-right" id="empDpt">EMP_DEPT: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_dept" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>

                            <div class="form-group col-md-12 padding-bottom-10px" id="divfrmelen ">
                                <label class="col-md-4 align-right" id="charLength">TEXT LENGTH: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_type_length" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" />
                                </div>
                            </div>

                            <table class="table table-striped  col-md-12">
                                <thead class="col-md-4">
                                    <tr>
                                        <th scope="col" class="col-md-4 text-right" style="padding-bottom:30px; border:none;">USER CONTENT: </th>
                                    </tr>
                                </thead>
                                <tbody class="col-md-8">
                                   <tr class="col-md-8" style="padding:0; margin:0">
                                        <th scope="col" id="txtRemarks" class="col-md-8 text-center"></th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group col-md-12 padding-bottom-10px" id="divUpdtDate">
                                <label class="col-md-4 align-right" id="updtDate">UPDATED DATE: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txtUpdteDate" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divToecd">
                                <label class="col-md-4 align-right" id="Updtempcd">UPDATED EMP_CODE: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txtUpdt_code" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divToenm">
                                <label class="col-md-4 align-right" id="Updtempnm">UPDATED EMP_NAME : </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txtUpdt_name" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divTodep ">
                                <label class="col-md-4 align-right" id="UpdtempDpt">UPDATED_DEPARTMENT: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txtUpdt_dept" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                </div>
                            </div>
                            <div class="form-group col-md-12 padding-bottom-10px" id="divTolen ">
                                <label class="col-md-4 align-right" id="updtCharLength">TEXT LENGTH: </label>
                                <div class="col-md-8">
                                    <input type="text" class="col-md-8" id="txt_UpdtLength" name="enm" maxlength="80" style="background-color: white; color:black" required="required" readonly="true" />
                                </div>
                            </div>
                           
                            <table class="table table-striped col-md-12" style="border:none">
                                <thead class="col-md-4">
                                    <tr>
                                        <th scope="col" class="col-md-4 align-right" style="padding-bottom:30px; border:none;">APPROVER CONTENT: </th>
                                    </tr>
                                    <tr>
                                        <th scope="col" class="col-md-4 align-right text-muted" style="border:none;">APPROVER REMARK: </th>
                                    </tr>
                                </thead>
                                <tbody class="col-md-8">
                                    <tr class="col-md-8" style="padding:0; margin:0">
                                        <th scope="col" id="txtUpdtRemarks" style="padding-bottom: 30px" class="col-md-8 text-center"></th>
                                    </tr>
                                    <tr class="col-md-8" style="padding:0; margin:0">
                                        <th scope="col" id="txtSMS_contentRMK" class="col-md-8 text-center  text-success"></th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-md-12 align-center container">
                            <input type="button" value="Download" class="btn-prop btn--outline-success" id="btn_ext" onclick="ExportPDF();" style="padding: 12px; margin-top: 5%;" />
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <br />
            </form>
            <input id="hdUserId" type="hidden" runat="server" />
            <input id="hduname" type="hidden" runat="server" />
        </div>
        <br />
        <br />
        <br />
        <input id="Hidden1" type="hidden" runat="server" />
        <input id="Hidden2" type="hidden" runat="server" />
    </div>

</asp:Content>
