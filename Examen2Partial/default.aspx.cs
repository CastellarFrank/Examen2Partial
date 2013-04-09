using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using Ext.Net;

namespace Examen2Partial
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtFechaFinal.Enabled = false;
            this.txtFechaInicio.Enabled = false;
            this.txtName.Disabled = true;
            this.txtDescription.Disabled = true;
            this.cmbStatusReal.Enabled = false;
            if(!IsPostBack){
                this.lblEmail.Text = User.Identity.Name;
                using (TodoDBEntities context = new TodoDBEntities())
                {
                    var miusuario = (from u in context.todos
                                     where u.userOwner == User.Identity.Name
                                     select u);
                    if (miusuario.Count() == 0)
                    {
                        this.cmbListTodo.Visible = false;
                        this.lblSelectTitle.Text = "You don't have any To-Do.";
                        this.btnRefresh.Disabled = true;
                    }
                    else
                    {
                        if (Session["range"] != null)
                        {
                            if ((bool)Session["range"] == true)
                            {
                                this.chFilter.Checked = true;
                                this.txtStart.Text = Session["fechaI"].ToString();
                                this.txtFinish.Text = Session["fechaF"].ToString();
                            }
                        }
                        foreach (todo u in miusuario)
                        {
                            if (Session["range"] == null || (bool)Session["range"]==false)
                            {
                                System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(u.nombre,
                                u.idTodo.ToString());
                                this.cmbListTodo.Items.Add(item);
                            }
                            else
                            {
                                if(validateFechas(u.fechaF)){
                                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(u.nombre,
                                    u.idTodo.ToString());
                                    this.cmbListTodo.Items.Add(item);
                                }
                            }
                        }
                        if (cmbListTodo.Items.Count == 0)
                        {
                            this.lblSelectTitle.Text = "There isn't any To-Do in that Date Range";
                            this.cmbListTodo.Visible = false;
                        }
                        else
                        {
                            this.cmbListTodo.SelectedIndex = 0;
                            this.cmbListTodo_SelectedIndexChanged(this, null);                        
                        }
                        
                    }
                }
            }
        }
        private bool validateFechas(DateTime fecha)
        {
            DateTime fechaInicial, fechaFinal;
            string fechaIn = this.txtStart.Text;
            string fechaEn = this.txtFinish.Text;
            string[] fechaIns = fechaIn.Split('/');
            string[] fechaEns = fechaEn.Split('/');
            fechaInicial = new DateTime(int.Parse(fechaIns[2]),
            int.Parse(fechaIns[0]),
            int.Parse(fechaIns[1]));
            fechaFinal = new DateTime(int.Parse(fechaEns[2]),
            int.Parse(fechaEns[0]),
            int.Parse(fechaEns[1]));
            if (DateTime.Compare(fecha, fechaFinal) <= 0 &&
                DateTime.Compare(fecha, fechaInicial) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void cmbListTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Si entro cabrones");
            using (TodoDBEntities context = new TodoDBEntities())
            {
                int idPos = int.Parse(this.cmbListTodo.SelectedValue);
                var miusuario = (from u in context.todos
                                 where u.userOwner == User.Identity.Name && u.idTodo == idPos
                                 select u);
                todo temp = miusuario.First();
                this.txtName.SetValue(temp.nombre);
                this.txtDescription.SetValue(temp.descripcion);
                string fechaIn = temp.fechaI.ToShortDateString();
                string[] fechaIns = fechaIn.Split('/');
                string fechaEn = temp.fechaF.ToShortDateString();
                string[] fechaEns = fechaEn.Split('/');
                this.txtFechaInicio.Text = fechaIns[1] + "/" + fechaIns[0] + "/" + fechaIns[2];
                this.txtFechaFinal.Text = fechaEns[1] + "/" + fechaEns[0] + "/" + fechaEns[2];
                string c = temp.status;
                this.cmbStatusReal.SelectedIndex = (c.Equals("O") ? 0 : c.Equals("C") ? 1 : 2);

            }
        }
        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx", true);

        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Si entro boton");
            if (this.chFilter.Checked == true)
            {
                System.Diagnostics.Debug.WriteLine("Si entro check");

                if (this.txtStart.Text.Equals("") || this.txtFinish.Text.Equals(""))
                {
                    System.Diagnostics.Debug.WriteLine("Si entro mensg empty");
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
                    Session["range"] = true;
                    Session["fechaI"] = this.txtStart.Text;
                    Session["fechaF"] = this.txtFinish.Text;
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                Session["range"] = false;
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}