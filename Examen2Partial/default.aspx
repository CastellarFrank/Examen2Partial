<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Examen2Partial._default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My TO-DO</title>
    <link rel="stylesheet" href="css/estilos.css"/>
</head>
<body id="bodyMain">
    
	<form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server"/>    
		<header>
			<h1>THINGS TO-DO LIST</h1>
			<nav>
			<ul>
				<li><a id="aFirst" href="default.aspx">My To-Do</a></li>
				<li><a href="newTodo.aspx">New To-Do</a></li>
				<li><a id="aLast" href="editTodo.aspx">Edit To-Do</a></li>
				<li id="liLogout">
					<a id="aLogout">
                		<ext:Label ID="lblEmail" runat="server" />
                		<ext:Button ID="btnLogout" runat="server" Text="Logout">
                            <DirectEvents>
                                <Click OnEvent="btnLogout_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
					</a>
				</li>
			</ul>
		</nav>
		</header>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
		<section id="panePrincipal">
            <section id="panelLabels">
                <asp:Label ID="lblTitleStart" runat="server" Text="Search To-Do"></asp:Label>
            </section>
            <section Id="panelFilter">
                <asp:CheckBox ID="chFilter" runat="server" Checked="false" Text=" Use Filter"></asp:CheckBox>
                <br /><br />
                <asp:Label ID="lblStart" runat="server" Text="Started Date: "></asp:Label>
                <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStart"></asp:CalendarExtender>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Finished Date: "></asp:Label>
                <asp:TextBox ID="txtFinish" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFinish"></asp:CalendarExtender>
                <br />
                <section ID="panelbotonunic">
                    <ext:Button ID="btnRefresh" runat="server" Text="Refresh" Icon="Reload" >
                    <DirectEvents>
                        <Click OnEvent="btnRefresh_Click"></Click>
                    </DirectEvents>
                </ext:Button>
                </section>
                
                <br />
            </section>
            <section ID="panelResult">
                <section ID="panelIzquierdo">
                <section ID="panelTitleIzquierd">
                    <asp:Label ID="lblSelectTitle" runat="server" Text="Select your To-Do"></asp:Label>
                </section>
                <asp:ListBox ID="cmbListTodo" runat="server" 
                    onselectedindexchanged="cmbListTodo_SelectedIndexChanged" AutoPostBack="True">
                </asp:ListBox>               
                </section>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <section ID="panelDerecho">
                        <section ID="panelTitle">
                            <asp:Label ID="lblAddTitle" runat="server" Text="Edit a TO-DO"></asp:Label>
                        </section>                    
                        <br />
                        <br />
                        <section id="panelLabel">
                            <asp:Label ID="Label2" runat="server" Text="To-Do Name:"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Description:"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="Started Date:"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Finished Date:"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label6" runat="server" Text="Status:"></asp:Label>
                            <br />
                        </section>
                        <section id="panelTextBox">
                            <ext:TextField 
                                ID="txtName" 
                                runat="server" 
                                AllowBlank="false"
                                BlankText="This field is required."
                                EmptyText="Write a name"                             
                                 />
                            <br />
                            <br />
                            <ext:TextField 
                                ID="txtDescription" 
                                runat="server"  
                                AllowBlank="false"
                                BlankText="This field is required."
                                EmptyText="Write a description" 
                                 />
                            <br />
                            <br />
                            <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                            <asp:CalendarExtender 
                                ID="CalendarExtender3" 
                                runat="server" 
                                TargetControlID="txtFechaInicio">
                            </asp:CalendarExtender>
                            <br />
                            <br />
                            <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                            <asp:CalendarExtender 
                                ID="CalendarExtender4" 
                                runat="server" 
                                TargetControlID="txtFechaFinal">
                            </asp:CalendarExtender>
                            <br />
                            <br />
                            <asp:DropDownList ID="cmbStatusReal" runat="server">
                                <asp:ListItem Selected="True">Ongoing</asp:ListItem>
                                <asp:ListItem>Cancel</asp:ListItem>
                                <asp:ListItem>Done</asp:ListItem>
                            </asp:DropDownList>
                        </section>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </section>
            </section>
		</section>
	</form>
</body>
</html>
