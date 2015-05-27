using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Ag2.Manager.ADO.MSSql
{
    /// <summary>
    /// Usuários de acesso ao gerenciador de conteúdo
    /// </summary>
    public class UserADO : BaseADO, Ag2.Manager.DAL.IUserDAL
    {
        //
        public UserADO()
        {
            //
            // TODO: Add constructor logic here
            //            
        }

        /// <summary>Consulta usario pelo ID</summary>
        /// <param name="ID">Código do usuário a ser pesquisado</param>
        public DataTable GetById(int ID)
        {
            //dataset com informações do usuario
            DataTable userData;

            DbCommand userProc = db.GetStoredProcCommand("UserGetById");

            //configura parametros da stored procedure
            db.AddInParameter(userProc, "ID", DbType.Int32, ID);

            //executa consuta           
            userData = db.ExecuteDataSet(userProc).Tables[0];

            //retorno da função
            return userData;
        }

        /// <summary>Consulta usuário pelo login</summary>
        /// <param name="login"></param>
        public DataTable GetByLogin(string login)
        {
            //dataset com informações do usuario
            DataTable userData;

            DbCommand userProc = db.GetStoredProcCommand("UserGetByLogin");

            //configura parametros da stored procedure
            db.AddInParameter(userProc, "Login", DbType.String, login.ToString());
            

            //executa consuta           
            userData = db.ExecuteDataSet(userProc).Tables[0];

            //retorno da função
            return userData;
        }

        public DataTable GetPerfilByUserId(string userId)
        {
            DataTable userData;

            DbCommand userProc = db.GetStoredProcCommand("ag2mngPerfilByUserIdLoadById");

            //configura parametros da stored procedure
            db.AddInParameter(userProc, "userId", DbType.String, userId);

            //executa consuta           
            userData = db.ExecuteDataSet(userProc).Tables[0];

            //retorno da função
            return userData;
        }

    }
}
