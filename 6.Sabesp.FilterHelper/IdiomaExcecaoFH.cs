using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sabesp.FilterHelper
{
    /// <summary>
    /// Classe de filtro que recebe os Id's da Idiomas que não devem ser retornados em um consulta
    /// </summary>
    public class IdiomaExcecaoFH : IFilterHelper
    {
        /// <summary>
        /// Ids dos idiomas que não devem retornar
        /// </summary>
        private IEnumerable<string> _identificadoresDosIds;
        public IEnumerable<string> IdentificadoresDosIds
        {
            get { return _identificadoresDosIds == null ? null : _identificadoresDosIds; }
            set { _identificadoresDosIds = value; }
        }

        /// <summary>
        /// Método que retorna a string do SQL a ser processada na cláusula WHERE do SQL.
        /// </summary>
        /// <returns>String contendo o SQL da cláusula WHERE.</returns>
        public string GetWhereString()
        {
            StringBuilder sbWhere = new StringBuilder();

            if (IdentificadoresDosIds != null && (IdentificadoresDosIds.Count())>0)
            {
                sbWhere.Append(" IdiomaId NOT IN (");
                sbWhere.Append(IdentificadoresDosIds.Aggregate((atual, proximo) => atual + ", " + proximo).ToCharArray());
                sbWhere.Append(")");
            }

            return sbWhere.ToString();
        }
    }
}
