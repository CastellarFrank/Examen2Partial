using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Ext.Net;

namespace Examen2Partial
{
    public partial class editTodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("SI ENTRO PUES");
                this.lblEmail.Text = User.Identity.Name;
                
                using (TodoDBEntities context = new TodoDBEntities())
                {
                    var miusuario = (from u in context.todos
                                     where u.userOwner == User.Identity.Name
                                     select u);
                    if (miusuario.Count() == 0)
                    {
                        this.btnAddTodo.Disabled=true;
                        this.btnDelete.Disabled = true;
                        this.cmbListTodo.Visible = false;
                        this.lblSelectTitle.Text = "You don't have any To-Do.";
                    }
                    else
                    {
                        foreach (todo u in miusuario)
                        {
                            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(u.nombre,
                                u.idTodo.ToString());
                            this.cmbListTodo.Items.Add(item);
                        }
                        this.cmbListTodo.SelectedIndex = 0;
                        this.cmbListTodo_SelectedIndexChanged(this, null);
                    }
                }
                
            }
            
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx", true);

        }
        protected void cmbListTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Si entro cabrones");
            using (TodoDBEntities context = new TodoDBEntities())
            {
                int idPos=int.Parse(this.cmbListTodo.SelectedValue);
                var miusuario = (from u in context.todos
                                 where u.userOwner == User.Identity.Name && u.idTodo==idPos
                                 select u);
                todo temp=miusuario.First();
                this.txtName.SetValue(temp.nombre);
                this.txtDescription.SetValue(temp.descripcion);
                string fechaIn=temp.fechaI.ToShortDateString();
                string []fechaIns=fechaIn.Split('/');
                string fechaEn = temp.fechaF.ToShortDateString();
                string[] fechaEns = fechaEn.Split('/');
                this.txtFechaInicio.Text = fechaIns[1] + "/" + fechaIns[0] + "/" + fechaIns[2];
                this.txtFechaFinal.Text = fechaEns[1] + "/" + fechaEns[0] + "/" + fechaEns[2];
                string c=temp.status;
                this.cmbStatusReal.SelectedIndex=(c.Equals("O")?0:c.Equals("C")?1:2);

            }
        }
        protected void btnAddTodo_Click(object sender, DirectEventArgs e)
        {
            if (this.txtFechaInicio.Text.Equals("") ||
                this.txtFechaFinal.Text.Equals(""))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Information Required",
                    Message = "You have to complete Date Fields",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR
                });
            }
            else
            {
                using (TodoDBEntities context = new TodoDBEntities())
                {
                    int idPos = int.Parse(this.cmbListTodo.SelectedValue);
                    todo miTodo = context.todos.Single(u => u.idTodo==idPos);

                    string fechaIn=txtFechaInicio.Text;
                    string fechaEn=txtFechaFinal.Text;
                    string []fechaIns=fechaIn.Split('/');
                    string []fechaEns=fechaEn.Split('/');
                    int index=this.cmbStatusReal.SelectedIndex;
                    string val=(index==0?"O":index==1?"C":"D");
                    miTodo.nombre = txtName.Value.ToString();
                    miTodo.descripcion = txtDescription.Value.ToString();
                    miTodo.fechaI=new DateTime(int.Parse(fechaIns[2]),
                            int.Parse(fechaIns[0]),
                            int.Parse(fechaIns[1]));

                    miTodo.fechaF=new DateTime(int.Parse(fechaEns[2]),
                            int.Parse(fechaEns[0]),
                            int.Parse(fechaEns[1]));
                    miTodo.status=val;
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Error...",
                            Message = error.Message,
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.ERROR
                        });
                        return;
                    }

                }

                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "TO-DO Updated!",
                    Message = "Your TO-DO has been updated",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
            }
        }
        protected void btnDelete_Click(object sender, DirectEventArgs e)
        {
            using (TodoDBEntities context = new TodoDBEntities())
            {
                
                    int idPos = int.Parse(this.cmbListTodo.SelectedValue);
                    todo miTodo = context.todos.Single(u => u.idTodo == idPos);
                    context.todos.DeleteObject(miTodo);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Error...",
                            Message = error.Message,
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.ERROR
                        });
                        return;
                    }
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "TO-DO Updated!",
                        Message = "Your TO-DO has been deleted",
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO
                    });
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}