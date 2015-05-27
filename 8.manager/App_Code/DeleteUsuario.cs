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

/// <summary>
/// Summary description for DeleteUsuario
/// </summary>
public class DeleteUsuario
{
    public DeleteUsuario()
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
        IUsuarioDAL usuarioADO = (IUsuarioDAL)Util.GetADO("UsuarioADO", (System.Reflection.Assembly)System.Web.Compilation.BuildManager.CodeAssemblies[0]);

        DeleteRegisterInfo ObjDelete = new DeleteRegisterInfo();
        Database db = DatabaseFactory.CreateDatabase();
        
        //SETADO COMO FALSE PARA ELE NÃO EXECUTAR O DELETE PADRAO DO MANAGER
        ObjDelete.CanDelete = false;

        MembershipUser user = Membership.GetUser(new Guid(id));

        usuarioADO.DeleteUser(user);

        return ObjDelete;
    }
}
