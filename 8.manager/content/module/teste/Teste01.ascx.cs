using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Ag2.Manager.WebUI;

public partial class content_module_teste_Teste01 : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            populaSubForm();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //populaSubForm();  
        List<int> lstItens = subform1.BuscaPKs();
        foreach (int i in lstItens)
        {
        }
        
    }

    private void populaSubForm()
    {
        //Database db = DatabaseFactory.CreateDatabase();

        //DbCommand objCmd = db.GetSqlStringCommand("Select * From arquivo");
        //DataSet ds = db.ExecuteDataSet(objCmd);

        ////subform1.DataSource = ds.Tables[0];
        ////subform1.DataBind();
    }

    public void SubFormAdicionar(object sender, SubFormEventArgs e)
    {
        SubForm objSubForm = (SubForm)sender;

        //if (objSubForm.TipoConsistenciaEnum == SubFormTipoConsistencia.Assincrona)
        //    SubFormAdicionarAssicrono(e, objSubForm);

    }

    //private void SubFormAdicionarAssicrono(SubFormEventArgs e, SubForm objSubForm)
    //{
    //    foreach (string strID in e.listIDs)
    //    {
    //        try
    //        {
    //            // Verifica se o ID já não está cadastrado
    //            if (!objSubForm.TableItens.ObjRows.Exists(delegate(clsObjectRow objItem)
    //            {
    //                return objItem.ObjParameters.Exists(delegate(clsObjectParameter op)
    //                {
    //                    return op.ObjType == ctrType.PK && op.ObjValue.ToString() == strID;
    //                });
    //            }))
    //            {
    //                Database db = DatabaseFactory.CreateDatabase();
    //                // Se não encontrou o item, inclui ele na coleção
    //                DbCommand cmdObj = db.GetSqlStringCommand((string)objSubForm.SqlStringCommand);
    //                db.AddInParameter(cmdObj, objSubForm.DataValueField, DbType.Int32, Convert.ToInt32(strID));

    //                DataTable datTable = db.ExecuteDataSet(cmdObj).Tables[0];

    //                clsItemSubForm objItem = new clsItemSubForm();
    //                objItem.ID = Convert.ToInt32(strID);

    //                //string[] strColunas;
    //                clsObjectTable listaObjeto = new clsObjectTable();
                    
    //                //strColunas = objSubForm.DataTextField.Split(',');
                    

    //                clsObjectRow newItem = new clsObjectRow();
    //                foreach (DataRow dr in datTable.Rows)
    //                {
                        
    //                    clsObjectParameter objParam = new clsObjectParameter();
                        
    //                    objParam.ObjType = ctrType.Text;
    //                    objParam.ObjValue = dr[objSubForm.DataTextField].ToString();
    //                    objParam.ObjColumn = objSubForm.DataTextField;

    //                    newItem.ObjParameters.Add(objParam);
                        
    //                }

    //                clsObjectParameter paramPK = new clsObjectParameter();
    //                paramPK.ObjColumn = "order_PK";
    //                paramPK.ObjType = ctrType.PK;
    //                paramPK.ObjValue = strID;
    //                newItem.ObjParameters.Add(paramPK);

    //                objSubForm.TableItens.ObjRows.Add(newItem);

    //            }
    //        }
    //        catch (System.Exception exc)
    //        {

    //        }
    //    }
    //    //objSubForm.CreateChildControls();
    //}

    //public void SubFormExcluir(object sender, SubFormEventArgs e)
    //{
    //    //int fieldIndex = FindFieldIndexByName(((SubForm)sender).ID);
    //    //if (fieldIndex >= 0)
    //    //{
    //    //    ManagerModuleFieldSubForm objFieldSubForm = ((ManagerModuleFieldSubForm)_moduleStructure.Fields[fieldIndex]);
    //    //    SubForm objSubForm = (SubForm)objFieldSubForm.FormField;

    //    //    if (objSubForm.TipoConsistenciaEnum == SubFormTipoConsistencia.Sincrona)
    //    //        SubFormExcluirSicrono(e, objFieldSubForm, objSubForm);

    //    //}
    //}

}
