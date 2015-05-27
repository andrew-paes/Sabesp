using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Ag2.Manager.DAL;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Helper;
using System.Web.Security;

namespace Ag2.Manager.ADO.MSSql
{
    /// <summary>
    /// Summary description for PerfilADO
    /// </summary>
    public class secaoConteudo : BaseADO, ISecaoConteudo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public secaoConteudo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet CarregaSecoes()
        {

            DbCommand cmdSecao = db.GetStoredProcCommand("[SecaoConteudoCarregar]");
            db.AddInParameter(cmdSecao, "@idiomaId", DbType.Int16, 1);
            
            return db.ExecuteDataSet(cmdSecao);
        }

        
    }
}
