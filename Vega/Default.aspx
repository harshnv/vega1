<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<script runat="server">
protected String GetTime()
{
   
    return DateTime.Now.ToString("t");
}

</script>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="container-fluid">
     <div class="row">
         <div class="col-md-12" style="height:100px;">
             <h1>Vega Industries pvt Limited.</h1>
             
         </div>
      </div>
  <div class="row">
  <div class="col-md-2" id="navBar" style="padding-left:0;margin-bottom:20px;">
      <button class="navButton" style="margin-top:25%;">Button 1</button>
       <button class="navButton">Button 2  </button>
       <button class="navButton">Button 3</button>
       <button class="navButton">Button 4</button>
  </div>
  <div class="col-md-7" id="searchR" style="padding-top:4%;">
     
      <!--div class="input-group">
          <input type="text" id="searchCus" class="form-control" placeholder="Enter Customer Name."/>
          <span class="input-group-btn">
            <button class="btn btn-info" type="button"> <span class="glyphicon glyphicon-search" aria-hidden="true"></span> Search!</button>
          </span>
     </!--div-->
      <asp:Panel ID="Panel1" runat="server"></asp:Panel>
      
      <%--<table id="csTable" class="table table-hover" style="margin-top:1%;" >
    <thead>
      <tr>
        <th>Name</th>
        <th>Phone No</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>John</td>
        <td>Doe</td>
        
      </tr>
      <tr>
        <td>Mary</td>
        <td>Moe</td>
        
      </tr>
      <tr>
        <td>July</td>
        <td>Dooley</td>
       
      </tr>
    </tbody>
  </table>--%>
  </div>
      
  <div class="col-md-3" id="todayCalls">
      <asp:Panel ID="Panel3" runat="server">

      </asp:Panel>
      <%--<div id="tCalls" style="margin-top:16%;">
          <h4 style="text-align:left;color:gray;font-family: fantasy;letter-spacing: 1px;">Service Calls</h4>
          <ol class="callsList">
              <a data-toggle="modal" data-target="#myModal"><li>Ashutosh Mangalekar</li></a>
              <a data-toggle="modal" data-target="#myModal" ><li>Siddhant Patil</li></a>
              <a data-toggle="modal" data-target="#myModal"><li>Ashutosh Mangalekar</li></a>
              <a data-toggle="modal" data-target="#myModal"><li>Siddhant Patil</li></a>
          </ol>
          <button class="moreBtn">More..</button>
      </div><br />
      <div id="breakCalls">
          <h4 style="text-align:left;color:red;font-family: fantasy;letter-spacing: 1px;">BreakDown Calls</h4>
           <ol>
              <a data-toggle="modal" data-target="#myModal"><li>Ashutosh Mangalekar</li></a>
              <a data-toggle="modal" data-target="#myModal"><li>Siddhant Patil</li></a>
              <a data-toggle="modal" data-target="#myModal"><li>Ashutosh Mangalekar</li></a>
              <a data-toggle="modal" data-target="#myModal"><li>Siddhant Patil</li></a>
          </ol>
           <button class="moreBtn">More..</button>
      </div>--%>
  </div>
  </div>
    <!------------------------------------------------------------->

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>
      <div class="modal-body">
         <%-- <table>
              <tr>
                  <td>
                        Employee Assigned
                  </td>
                  <td>

                  </td>
              </tr>
                <tr>
                    <td>
                  Time
              </td>
                    <td></td>
                  </tr> 
              <tr>
                  <td>Address</td>
                  <td>

                  </td>
              </tr>             
          </table>--%>
          <asp:Panel ID="Panel2" runat="server">


          </asp:Panel>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
     
      <script>
          $(document).ready(function () {
              var table = $('#ContentPlaceHolder1_csTable').dataTable();

              
              $('#searchCus').on('keyup', function () {
                  var val = $('#searchCus').val();
                  table.search(val).draw();
              });


          });
     </script>
</div>
</asp:Content>

