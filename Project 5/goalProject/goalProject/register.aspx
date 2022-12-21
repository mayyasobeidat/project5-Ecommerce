<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="goalProject.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    body{
        background-image : url("images/rigester.jpg") ;
        background-repeat :no-repeat ;
        background-size : cover ;
    }
    .cont{
           width: 500px;
  padding: 4% 0 0;
  margin: auto;
    }
    .reg{
                      width: 550px ; 
            background-image : url("images/opacity.jpg") ;
              display: flex;
            flex-direction :column ;
            justify-content :center ;
            height: 580px;
            align-items: center;
          
    }
    .txt {
        width: 380px;
            height: 45px ;
            background-color :snow ;
            color : orangered ;
            opacity : 0.7 ;
            border : solid 2px double ;
            font-weight : 400 ;
            padding : 0px 5px ;
            
    }
    .btn {
                width : 398px ;
                height : 48px ;
                background-color : orangered ; 
                color :aliceblue ; 
                border : none ;
                font-weight : 400 ;
                font-size : 24px ;
                 font-family : Bahnschrift ;
            }
      h1 {
                margin-bottom : 45PX ;
                color: orangered; 
                font-family : Bahnschrift ;
                font-size :27px ;
                word-spacing : 5px ;
            }
      #FileUpload1{
           input[type=file]::file-selector-button 
  margin-right: 20px;
  border: none;
  background-color:white ;
  padding: 11px 20px;
  color: black;
  cursor: pointer;
  width :354px ;
   height : 25px !important;
   opacity : 0.7 ;
  transition: background .2s ease-in-out;
   border : solid 2px double  ;
}

input[type=file]::file-selector-button:hover {
  background-color:orangered ;
}


  /* -----------------media-------------------*/
     @media (min-width: 1px) and (max-width: 481px) {
            .reg {
    width: 557px;
     background-image: none; 
    display: flex;
    flex-direction: column;
    justify-content: center;
    height: 1408px;
    align-items: center;
    background-color : aqua !important ;
}

         
                      
        }
     
      
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cont">
            <div class="reg">
            
                <h1>REGISTERATION</h1>

            <asp:TextBox ID="TextBox1" runat="server" placeholder=" First Name " CssClass="txt"></asp:TextBox>
            <br />
             <asp:TextBox ID="TextBox4" runat="server" placeholder=" Last Name"  CssClass="txt"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder=" Email"  CssClass="txt"></asp:TextBox>
            <br />
           
            <asp:TextBox  ID="TextBox3" runat="server" TextMode="Password" placeholder=" Password"  CssClass="txt"></asp:TextBox>
            <br />
          <asp:FileUpload ID="FileUpload1" runat="server"  placeholder=" Photo"/>
               
            <br /> 

            <asp:Button ID="btnUpload" Text="Confirm" runat="server" OnClick="UploadFile"   CssClass="btn"/>
            <br />
            <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
                </div>
        </div>
    </form>
</body>
</html>