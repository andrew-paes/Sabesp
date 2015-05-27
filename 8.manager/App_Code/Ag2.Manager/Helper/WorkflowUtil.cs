using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Ag2.Manager.Helper;

/// <summary>
/// Summary description for WorkflowUtil
/// </summary>
public class WorkflowUtil
{
    public WorkflowUtil() { }

    public static WorkflowData GetWorkflowModuleData(int workflowId)
    {
        Database db = DatabaseFactory.CreateDatabase();
        CurrentSessions cs = new CurrentSessions();

        WorkflowData retorno = null;
        string sql = @"SELECT
                              Workflow.workflowId
                            , Fluxo.fluxoId
                            , Workflow.userId
                            , Status.statusId
                            , Status.descricao AS status
                            , Workflow.conteudoId
                            , Workflow.moduleId
                            , ag2mngMenu.moduleName
                        FROM         
                            ag2mngMenu 
                            INNER JOIN Workflow ON ag2mngMenu.menuId = Workflow.moduleId 
                            INNER JOIN aspnet_Users ON Workflow.userId = aspnet_Users.UserId 
		                    INNER JOIN dbo.Status ON dbo.Workflow.statusId = dbo.Status.statusId 
		                    INNER JOIN dbo.Fluxo ON dbo.Workflow.fluxoId = dbo.Fluxo.fluxoId
                        WHERE 
                            Workflow.workflowId=@workflowId";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@workflowId", DbType.Int32, workflowId);
        DataTable dtData = db.ExecuteDataSet(dataProc).Tables[0];

        if (dtData != null)
        {
            retorno = new WorkflowData();
            retorno = new WorkflowData();
            retorno.WorkflowId = Convert.ToInt32(dtData.Rows[0]["workflowId"]);
            retorno.FluxoId = Convert.ToInt32(dtData.Rows[0]["fluxoId"]);
            retorno.UserId = Convert.ToString(dtData.Rows[0]["userId"]);
            retorno.StatusId = Convert.ToInt32(dtData.Rows[0]["statusId"]);
            retorno.Status = Convert.ToString(dtData.Rows[0]["status"]);
            retorno.ConteudoId = Convert.ToInt32(dtData.Rows[0]["conteudoId"]);
            retorno.ModuleId = Convert.ToInt32(dtData.Rows[0]["moduleId"]);
            retorno.ModuleName = Convert.ToString(dtData.Rows[0]["moduleName"]);
        }

        return retorno;
    }

    public static int GetWorkflowId(string moduleName, int conteudoId)
    {
        Database db = DatabaseFactory.CreateDatabase();
        CurrentSessions cs = new CurrentSessions();

        string sql = @"SELECT     
                            Workflow.workflowId
                        FROM         
                            Workflow 
                            INNER JOIN ag2mngMenu ON Workflow.moduleId = ag2mngMenu.menuId
                        WHERE     
                            (Workflow.conteudoId = @conteudoId) 
                            AND (ag2mngMenu.moduleName = @moduleName)";

        DbCommand dataProc = db.GetSqlStringCommand(sql);
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, conteudoId);
        db.AddInParameter(dataProc, "@moduleName", DbType.String, moduleName);

        int retorno = 0;
        try
        {
            Int32.TryParse(Convert.ToString(db.ExecuteScalar(dataProc)), out retorno);
        }
        catch
        {
            retorno = 0;
        }

        return retorno;
    }

    public static int SaveWorkflow(int? workflowId, Ag2.Manager.WebUI.StatusWorkflow ctlStatusWorkflow, int conteudoId, string conteudoDescricao, string moduleName, string tableName)
    {
        CurrentSessions cs = new CurrentSessions();

        return SaveWorkflow(workflowId, cs.UserId, cs.Perfil.PerfilId, ctlStatusWorkflow, conteudoId, conteudoDescricao, moduleName, null, tableName);
    }

    public static int SaveWorkflow(int? workflowId, string userId, int perfilId, Ag2.Manager.WebUI.StatusWorkflow ctlStatusWorkflow, int conteudoId, string conteudoDescricao, string moduleName, string tableName)
    {
        return SaveWorkflow(workflowId, userId, perfilId, ctlStatusWorkflow, conteudoId, conteudoDescricao, moduleName, null, tableName);
    }

    public static int SaveWorkflow(int? workflowId, string userId, int perfilId, Ag2.Manager.WebUI.StatusWorkflow ctlStatusWorkflow, int conteudoId, string conteudoDescricao, string moduleName, int? moduleId, string tableName)
    {
        int retorno = 0;
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dataProc = db.GetStoredProcCommand("WorkflowInsertUpdate");
        db.AddInParameter(dataProc, "@workflowId", DbType.Int32, workflowId != null && workflowId > 0 ? workflowId : null);
        db.AddInParameter(dataProc, "@userId", DbType.String, userId);
        db.AddInParameter(dataProc, "@statusId", DbType.Int32, ctlStatusWorkflow.StatusIdSelected);
        db.AddInParameter(dataProc, "@perfilId", DbType.Int32, perfilId);
        db.AddInParameter(dataProc, "@conteudoId", DbType.Int32, conteudoId);
        db.AddInParameter(dataProc, "@moduleName", DbType.String, moduleName);
        db.AddInParameter(dataProc, "@moduleId", DbType.Int32, moduleId);
        db.AddInParameter(dataProc, "@conteudoDescricao", DbType.String, conteudoDescricao);
        db.AddInParameter(dataProc, "@comentario", DbType.String, ctlStatusWorkflow.Comentario);
        db.AddInParameter(dataProc, "@tableName", DbType.String, String.IsNullOrEmpty(tableName) ? null : tableName);

        DataSet ds = db.ExecuteDataSet(dataProc);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                retorno = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                retorno = 0;
            }
        }

        return retorno;
    }

    private void ValidaControleStatusWorkflow(Ag2.Manager.WebUI.StatusWorkflow ctlStatusWorkflow)
    {
        if (!String.IsNullOrEmpty(ctlStatusWorkflow.StatusIdSelected))
        {

        }
    }
}