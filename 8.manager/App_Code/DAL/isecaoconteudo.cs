using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.Generic;
using Ag2.Manager.BusinessObject;

namespace Ag2.Manager.DAL
{
    public interface ISecaoConteudo
    {
        
        /// <summary>
        /// Carrega Seções
        /// </summary>
        /// <returns></returns>
        System.Data.DataSet CarregaSecoes();

    }
}
