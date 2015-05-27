using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabesp.Data.Services;
using Sabesp.BO;

public class SmartUserControl : System.Web.UI.UserControl
{
    public SmartUserControl() { }

    #region Properties

    public static int SecaoId
    {
        get
        {
            int _secao = 2;
            if (HttpContext.Current.Request.QueryString["secaoId"] != null)
            {
                try
                {
                    _secao = Convert.ToInt32(HttpContext.Current.Request.QueryString["secaoId"]);
                }
                catch
                {
                    _secao = 2;
                }
            }

            return _secao;
        }
    }


	public static int RegistroId
	{
		get
		{
			int _registroId = 0;
			if (HttpContext.Current.Request.QueryString["id"] != null)
			{
				try
				{
					_registroId = Convert.ToInt32(HttpContext.Current.Request.QueryString["id"]);
				}
				catch
				{
					_registroId = 0;
				}
			}

			return _registroId;
		}
	}

    #endregion
}
