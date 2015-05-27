using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ag2.Manager.Helper;
using Ag2.Manager.Module;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Dicionary;

namespace Ag2.Manager.WebUI
{
    public class ManagerPage : Page
    {
        CurrentSessions cs = new CurrentSessions();
        ManagerModule manager = new ManagerModule();

        public ManagerPage()
        {
            //
        }

        protected override void OnLoad(EventArgs e)
        {
            int idiomaId = 0;

            HiddenField hdnIdioma = (HiddenField)this.Master.FindControl("hdnIdioma");

            if (!hdnIdioma.Value.Equals(string.Empty))
            {
                idiomaId = Convert.ToInt32(hdnIdioma.Value);
                cs.CurrentIdioma = manager.LoadIdioma(new Idioma(idiomaId));
            }
            else
            {
                hdnIdioma.Value = cs.CurrentIdioma.IdiomaId.ToString();
            }

            if (!IsPostBack)
            {
                cs.CurrentFilters = null;
            }
            base.OnLoad(e);
        }
    }
}
