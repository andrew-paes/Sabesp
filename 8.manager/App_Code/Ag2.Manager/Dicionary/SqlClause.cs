using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using Ag2.Manager.Helper;

namespace Ag2.Manager.Dicionary
{
    internal class SqlClause
    {
        private Dictionary<string, string> _clauses = new Dictionary<string, string>();

        public SqlClause()
        {
            //
        }

        public Dictionary<string, string> Clauses
        {
            get {

                if (_clauses.Count.Equals(0))
                {
                    CurrentSessions cs = new CurrentSessions();
                    MembershipUser user = Membership.GetUser();

                    _clauses.Add("{USER_ID}", user.ProviderUserKey.ToString());
                    _clauses.Add("{PERFIL_ID}", cs.Perfil.PerfilId.ToString());
                    _clauses.Add("{IDIOMA_ID}", cs.CurrentIdioma.IdiomaId.ToString());
                }

                return _clauses;
            }
        }
    }
}
