﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Verify_ContentSMS.aspx.cs" Inherits="HoApps.Auto_ProcessSMS.Verify_ContentSMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../App_Themes/Theme/assets/js/Verify_ContentSMS.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div data-ng-controller="MyCtrl">
        <div class="col-md-12 align-center">
            <form id="Form2" class="form-horizontal row-border" action="#" runat="server">
                <div class="row">
                    <br />
                    <div class="form-group align-center">
                      <div>
                         <b style="font-size: 15px;">VERIFY CONTENT SMS </b><br />
                      </div>
                    </div>
                    
                    <br />
                    <br />

                    <div id="swt_app" class="clonedInput">
                        <div class="widget-content">
                            <div class="widget box align-center border=1">
                                <div class="form-group">

                                    <div class="container">
                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmenm">
                                            <label class="col-md-4 align-right" id="empRept">REPORTS : </label>
                                            <div>
                                                <div class="col-md-4">
                                                    <select onchange="handleOption()" id="ddlReport" class="form-control w-50 mx-auto" style="text-align: center;">
                                                        <option value="-1"> --- SELECT APPROVAL OPTION --- </option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmenm ">
                                            <label class="col-md-4 align-right" id="empnm">CREATED EMP_NAME : </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txt_name" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmecd">
                                            <label class="col-md-4 align-right" id="empcd">CREATED EMP_CODE: </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txt_code" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmemob">
                                            <label class="col-md-4 align-right" id="empMob">CREATED EMP_MOB: </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txt_mob" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmedp">
                                            <label class="col-md-4 align-right" id="empDpt">CREATED EMP_DEPT: </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txt_dept" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" onkeyup="this.value=this.value.toUpperCase()" />
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmetxtareRmk" style="display: flex;">
                                            <label class="col-md-4 align-right" id="empRmk">APPROVER REMARK: </label>
                                            <textarea class="col-md-4 align-left" rows="2" cols="10" name="Remarks" id="txtSMS_contentRMK" maxlength="3500" title="Remarks"  style="letter-spacing: 3px; resize:none; color:forestgreen;" required="required">
                                            </textarea>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmelen">
                                            <label class="col-md-4 align-right" id="charLength"> INITIAL TEXT LENGTH: </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txtSMS_length" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" />
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12 padding-bottom-10px" id="divfrmetxtare" style="display: flex;">
                                            <textarea class="col-md-4 align-center" rows="4" cols="10" name="Remarks" id="txtSMS_content" maxlength="3500" title="Remarks" onkeyup="getCharecterLength()" style="letter-spacing: 3px; resize:none;" required="required">
                                            </textarea>
                                        </div>
                                         <div class="form-group col-md-12 padding-bottom-10px" id="divfrmelenNew">
                                            <label class="col-md-4 align-right" id="charLengthNew"> MODIFY TEXT LENGTH: </label>
                                            <div class="col-md-4">
                                                <input type="text" class="form-control" id="txtSMS_lengthNew" name="enm" maxlength="80" style="background-color: white" required="required" readonly="true" />
                                            </div>
                                        </div>
                                        <div class="d-flex justify-content-around">
                                           
                                            <input type="button" value="Exit" class="btn-prop p-2" id="btn_ext" onclick="exitclick();" style="padding: 5px" />
                                            <input type="button" value="Confirm" class="btn-prop" id="btn_view" onclick="approveSubmitclick();" style="padding:5px" />

                                        </div>

                                        <input id="hdSel" type="hidden" runat="server" />




                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <br />
                 <br />
                 <br />

                 <div class="col-md-12 well well align-center" id="divStatus" style="margin-left: 50px; width: 1000px;display:none;">
                    <table id="CurStatus" class="table table-dark"></table>
                 </div>
                <asp:HiddenField ID="hdvUserID" runat="server" />
            </form>
        </div>
    <input id="hdUserId" type="hidden" runat="server" />

       </div>
</asp:Content>
