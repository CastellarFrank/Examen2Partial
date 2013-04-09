<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newTodo.aspx.cs" Inherits="Examen2Partial.newTodo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New TO-DO</title>
    <link rel="stylesheet" href="css/estilos.css"/>
    <script type="text/javascript">
        function validate() {
            if (txtName.validate() && txtDescription.validate())
                return true;
            else
                Ext.Msg.alert('Error...', 'Incomplete data, please write the fields required.');
            return false;
        }
    </script>
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
        <section id="panePrincipal">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <section ID="panelTitle">
                        <asp:Label ID="lblAddTitle" runat="server" Text="Add a new TO-DO"></asp:Label>
                    </section>                    
                    <br />
                    <br />
                    <section id="panelLabel">
                        <asp:Label ID="Label1" runat="server" Text="To-Do Name:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Started Date:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Finished Date:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Status:"></asp:Label>
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
                            ID="CalendarExtender1" 
                            runat="server" 
                            TargetControlID="txtFechaInicio">
                        </asp:CalendarExtender>
                        <br />
                        <br />
                        <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                        <asp:CalendarExtender 
                            ID="CalendarExtender2" 
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
                    <br />
                    <section ID=panelBoton>
                        <ext:Button 
                            ID="btnAddTodo" 
                            runat="server" 
                            Text="Submit"
                            Icon="Accept">
                            <Listeners>
                                <Click Handler="return validate();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnAddTodo_Click">
                                    <EventMask ShowMask="true" Msg="Verifing..." MinDelay="100"/>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </section>
    </form>
</body>
</html>
