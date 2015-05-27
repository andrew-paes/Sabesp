using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class content_module_workflow_workflow : SmartUserControl
{

    #region Properties

    Database db = DatabaseFactory.CreateDatabase();

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadPage();
    }

    #endregion

    #region Methods

    protected void LoadPage()
    {
        if (this.IdRegistro > 0)
        {
            WorkflowData dadosW = WorkflowUtil.GetWorkflowModuleData(Convert.ToInt32(this.IdRegistro));

            if (dadosW != null)
            {
                Response.Redirect(String.Format("~/content/edit.aspx?md={0}&id={1}&wid={2}", dadosW.ModuleName, dadosW.ConteudoId, dadosW.WorkflowId));
            }
            else
            {
                throw new Exception("Falha ao obter módulo ou id do conteúdo");
            }
        }
    }

    #endregion
}