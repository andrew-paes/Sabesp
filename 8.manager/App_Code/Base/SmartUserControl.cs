using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SmartUserControl
/// </summary>
public class SmartUserControl : System.Web.UI.UserControl
{
    public SmartUserControl() { }

    #region Properties
    Ag2.Manager.Helper.Util util = null;

    public int IdiomaId
    {
        get
        {
            if (util == null)
            {
                util = new Ag2.Manager.Helper.Util();
            }

            if (ViewState["idiomaAnterior"] == null)
            {
                this.IdiomaHasChanged = true;
            }
            else
            {
                if (Convert.ToString(ViewState["idiomaAnterior"]) != util.CurrentIdioma)
                {
                    this.IdiomaHasChanged = true;
                }
                else
                {
                    this.IdiomaHasChanged = false;
                }
            }

            ViewState["idiomaAnterior"] = util.CurrentIdioma;
            return Convert.ToInt32(util.CurrentIdioma);
        }
    }

    private bool _idiomaHasChanged;
    public bool IdiomaHasChanged
    {
        get
        {
            if (util == null)
            {
                util = new Ag2.Manager.Helper.Util();
            }

            if (ViewState["idiomaAnterior"] == null)
            {
                _idiomaHasChanged = true;
            }
            else
            {
                if (Convert.ToString(ViewState["idiomaAnterior"]) != util.CurrentIdioma)
                {
                    _idiomaHasChanged = true;
                }
                else
                {
                    _idiomaHasChanged = false;
                }
            }

            ViewState["idiomaAnterior"] = util.CurrentIdioma;

            return _idiomaHasChanged;
        }
        private set
        {
            _idiomaHasChanged = value;
        }
    }

    public int? IdRegistro
    {
        get
        {
            int _idRegistro = 0;
            if (!String.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])))
            {
                try
                {
                    _idRegistro = Convert.ToInt32(Convert.ToString(Request.QueryString["id"]));
                }
                catch
                {
                    _idRegistro = 0;
                }
            }
            return _idRegistro;
        }
    }

    public int? IdWorkflow
    {
        get
        {
            int _idWorkflow = 0;
            if (!String.IsNullOrEmpty(Convert.ToString(Request.QueryString["wid"])))
            {
                try
                {
                    _idWorkflow = Convert.ToInt32(Convert.ToString(Request.QueryString["wid"]));
                }
                catch
                {
                    _idWorkflow = 0;
                }
            }
            return _idWorkflow;
        }
    }

    public String ModuleName
    {
        get
        {
            String _moduleName = string.Empty;
            if (!String.IsNullOrEmpty(Convert.ToString(Request.QueryString["md"])))
            {
                try
                {
                    _moduleName = Convert.ToString(Convert.ToString(Request.QueryString["md"]));
                }
                catch
                {
                    _moduleName = string.Empty;
                }
            }
            return _moduleName;
        }
    } 
    #endregion

	#region Validação de Datas

	protected void ServerValidationDateTime(object source, ServerValidateEventArgs args)
	{
		try
		{
			args.IsValid = Ag2.Manager.Helper.Util.IsDate(args.Value);
		}
		catch
		{
			args.IsValid = false;
		}
	}

	#endregion

   
}
