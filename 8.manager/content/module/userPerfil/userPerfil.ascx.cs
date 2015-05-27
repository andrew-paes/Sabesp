using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Ag2.Manager.Helper;
using Ag2.Manager.DAL;
using Ag2.Manager.BusinessObject;


public partial class content_module_atendimento_atendimento : System.Web.UI.UserControl
{

    private int _id = 0;
    Database db = DatabaseFactory.CreateDatabase();
    IPerfilDAL perfilado = (IPerfilDAL)Util.GetADO("PerfilADO", (System.Reflection.Assembly)System.Web.Compilation.BuildManager.CodeAssemblies[0]);

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            _id = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                LoadForm();
            }
        }

        if (!IsPostBack)
        {
            loadMenu();
        }

        msg.Text = "";

        if (Request.QueryString["existe"] != null)
        {
            msg.Text = "Já existe um perfil com este nome.<br>";
        }

    }

    #endregion

    #region LoadForm
    protected void LoadForm()
    {
        Perfil perfil = new Perfil();
        perfil.PerfilId = _id;
        perfil = perfilado.LoadById(perfil);

        txtNome.Text = perfil.Name;
        ViewState["nomeAtual"] = perfil.Name;
    }
    #endregion

    #region btnExecute_Click

    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {

        Perfil perfil = new Perfil();
        perfil.PerfilId = _id;
        perfil.Name = txtNome.Text;
        perfilado.Save(perfil, rptMenu);

        if (_id == 0)
        {
            txtNome.Text = "";
            ViewState["nomeAtual"] = null;
            loadMenu();
        }
    }

    #endregion

    protected void loadMenu()
    {
        rptMenu.DataSource = perfilado.LoadPermission();
        rptMenu.DataBind();
    }

    protected void getMarcado_ItemDataBound(object sender, GridViewRowEventArgs e)
    {
        string menuId = "";
        e.Row.Cells[0].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            menuId = e.Row.Cells[0].Text.ToString();
            //((CheckBox)e.Row.FindControl("chkFull")).Text = menuId;

            Perfil perfil = new Perfil();
            perfil.PerfilId = _id;
            IDataReader registro = perfilado.LoadPermissionByMenuIdAndPerfilId(menuId, perfil);
            if (registro.Read())
            {
                if (Convert.ToBoolean(registro["fullControl"]).Equals(true))
                {
                    ((CheckBox)e.Row.FindControl("chkFull")).Checked = true;
                }

                if (Convert.ToBoolean(registro["canRead"]).Equals(true))
                {
                    ((CheckBox)e.Row.FindControl("chkRead")).Checked = true;
                }

                if (Convert.ToBoolean(registro["canInsert"]).Equals(true))
                {
                    ((CheckBox)e.Row.FindControl("chkInsert")).Checked = true;
                }

                if (Convert.ToBoolean(registro["canUpdate"]).Equals(true))
                {
                    ((CheckBox)e.Row.FindControl("chkUpdate")).Checked = true;
                }

                if (Convert.ToBoolean(registro["canDelete"]).Equals(true))
                {
                    ((CheckBox)e.Row.FindControl("chkDelete")).Checked = true;
                }
            }

            registro.Close();
            registro.Dispose();

        }
    }

    protected void getInfoPonto_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int idMenuPai = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "menuId").ToString());

        IDataReader dr = perfilado.MenuLoadByParentId(idMenuPai);

        ((GridView)e.Item.FindControl("gvSubMenu")).DataSource = dr;
        ((GridView)e.Item.FindControl("gvSubMenu")).DataBind();


    }

}
