using System;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ag2.Manager;
using Ag2.Manager.Module;
using Ag2.Manager.Module.Info;
using Ag2.Manager.Helper;
using Ag2.Manager.DAL;
using Sabesp.DAL;
using Sabesp.BO;
using Sabesp.DAL.ADO;
using Sabesp.Data.Services;

/// <summary>
/// Summary description for DeleteUsuario
/// </summary>
public class DeleteContato
{
	public DeleteContato()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	/// <summary>
	/// Método configurado no Web.Config para ser executado quando o usuário executa a ação de delete no manager
	/// </summary>
	/// <param name="module"></param>
	/// <param name="id"></param>
	/// <returns></returns>
	public static DeleteRegisterInfo BeforeRegisterDelete(ManagerModuleStructure module, string id)
	{
		DeleteRegisterInfo ObjDelete = new DeleteRegisterInfo();
		ObjDelete.CanDelete = false; //SETA PARA ELE EXECUTAR O DELETE PADRAO DO MANAGER

		Contato contatoBO = new Contato();
		contatoBO.ContatoId = Convert.ToInt32(id);

		new FormularioService().ExcluirRelacionado(contatoBO.ContatoId);
		new ContatoService().Excluir(contatoBO);

		return ObjDelete;
	}
}