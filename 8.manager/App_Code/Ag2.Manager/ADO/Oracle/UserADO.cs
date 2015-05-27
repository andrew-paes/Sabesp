using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Data.OracleClient;


namespace Ag2.Manager.ADO.Oracle
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

            //dataset com informações do usuario
            DataTable userData;

            DbCommand userProc = db.GetStoredProcCommand("ag2mngPerfilByUserIdLoadById");

            OracleParameter parametro1 = new OracleParameter("p_userId", OracleType.VarChar);
            parametro1.Value = userId;
            parametro1.Direction = ParameterDirection.Input;

            userProc.Parameters.Add(parametro1);

            OracleParameter parametro3 = new OracleParameter("OUTCURSOR", OracleType.Cursor);
            parametro3.Direction = ParameterDirection.Output;

            userProc.Parameters.Add(parametro3);

            userData = db.ExecuteDataSet(userProc).Tables[0];

            //retorno da função
            return userData;
        }

    }
}
