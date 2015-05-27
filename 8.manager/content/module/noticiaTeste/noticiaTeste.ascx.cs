using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;

public partial class content_module_noticiaTeste_noticiaTeste : SmartUserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IdRegistro > 0)
        {
            if (!IsPostBack || this.IdiomaHasChanged)
            {
                this.LoadForm();
            }
        }
        //else
        //{
        //    phStatus.Visible = false;
        //}
    }

    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {
        this.Save();
    }

    protected void LoadForm()
    {
        this.ClearForm();

        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dataProc = db.GetStoredProcCommand("NoticiaTesteSelect");
        db.AddInParameter(dataProc, "@noticiaTesteId", DbType.Int32, this.IdRegistro > 0 ? this.IdRegistro : null);
        db.AddInParameter(dataProc, "@idiomaId", DbType.String, this.IdiomaId);

        DataTable dtData = db.ExecuteDataSet(dataProc).Tables[0];

        if (dtData != null && dtData.Rows.Count > 0)
        {
            txtTitulo.Text = Convert.ToString(dtData.Rows[0]["titulo"]);
            //lblStatusAtual.Text = Convert.ToString(dtData.Rows[0]["status"]);
            txtConteudo.Text = Convert.ToString(dtData.Rows[0]["conteudo"]);
        }
    }

    protected void Save()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dataProc = db.GetStoredProcCommand("NoticiaTesteInsertUpdate");
        db.AddInParameter(dataProc, "@noticiaTesteId", DbType.Int32, this.IdRegistro > 0 ? this.IdRegistro : null);
        db.AddInParameter(dataProc, "@idiomaId", DbType.String, this.IdiomaId);
        db.AddInParameter(dataProc, "@titulo", DbType.String, txtTitulo.Text);
        db.AddInParameter(dataProc, "@conteudo", DbType.String, txtConteudo.Text);

        DataTable dtData = db.ExecuteDataSet(dataProc).Tables[0];

        if (dtData != null && dtData.Rows.Count > 0)
        {
            this.LoadForm();

            int noticiaId = Convert.ToInt32(dtData.Rows[0][0]);
            int wId = WorkflowUtil.SaveWorkflow(this.IdWorkflow, StatusWorkflow1, noticiaId, txtTitulo.Text, this.ModuleName, "NoticiaTeste");

            if (wId > 0)
            {
                if (this.IdRegistro > 0)
                {
                    Util.ShowUpdateMessage();
                    this.LoadForm();
                    StatusWorkflow1.DataBind();
                }
                else
                {
                    Util.ShowInsertMessage();
                    Response.Redirect(String.Concat("edit.aspx?md=", this.ModuleName, "&id=", noticiaId, "&wid=", wId), false);
                }
            }
            else
            {
                Util.ShowMessage("Erro ao associar workflow");
            }
        }
        else
        {
            Util.ShowMessage("Erro ao inserir o registro");
        }
    }

    protected void ClearForm()
    {
        txtTitulo.Text = string.Empty;
    }
}
