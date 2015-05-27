using System;
using System.Globalization;
using System.Threading;
using Sabesp.Enumerators;
using Sabesp.Data.Services;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage() { }

    #region Properties

    /// <summary>
    /// Parse of Request.Querystirng["id"]
    /// </summary>
    public int RegistroId
    {
        get
        {
            int _registroId = 0;
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    _registroId = Convert.ToInt32(Request.QueryString["id"]);
                }
                catch
                {
                    _registroId = 0;
                }
            }
            return _registroId;
        }
    }
    /// <summary>
    /// Parse of Request.Querystirng["tagId"]
    /// </summary>
    public int TagId
    {
        get
        {
            int _tagId = 0;
            if (Request.QueryString["tagId"] != null)
            {
                try
                {
                    _tagId = Convert.ToInt32(Request.QueryString["tagId"]);
                }
                catch
                {
                    _tagId = 0;
                }
            }
            return _tagId;
        }
    }

    /// <summary>
    /// Parse of Request.Querystring["secaoId"]
    /// </summary>
    public int SecaoId
    {
        get
        {
            int _secao = 0;

            if (Request.QueryString["secaoId"] != null)
            {
                try
                {
                    _secao = Convert.ToInt32(Request.QueryString["secaoId"]);
                }
                catch
                {
                    _secao = 2;
                }
            }

            return _secao;
        }
       
    }

    #endregion

    #region Page Events

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

		//Add code here
		this.RedirectHome();
    }

	private void RedirectHome()
	{
		string url = Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower();

		//Response.Write("SesID: " + Request.QueryString["secaoId"] + "<br />");
		//Response.Write("URL: " + url + "<br />");

		if (String.IsNullOrEmpty(Request.QueryString["secaoId"]) && url != "~/default.aspx" && url != "~/interna/resultado-busca.aspx")
		{
			if (!Request.Url.AbsoluteUri.Contains(","))
			{
				//Response.Redirect("~/default.aspx");
			}
		}
	}

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        //Add code here
    }

    /// <summary>
    /// Sets the page culture previously stored in the cookie
    /// </summary>
    protected override void InitializeCulture()
    {
        Cookie cook = new Cookie();
        Sabesp.BO.Idioma idioma = new Sabesp.BO.Idioma(cook.IdiomaId);

        string strCulture = string.Empty;

        if (idioma.IdiomaId == Idiomas.Portugues.GetHashCode())
        {
            strCulture = "pt-BR";
        }
        else if (idioma.IdiomaId == Idiomas.Ingles.GetHashCode())
        {
            strCulture = "en-US";
        }
        else
        {
            strCulture = "pt-BR";
        }

        //sets the culture
        CultureInfo ci = new CultureInfo(strCulture);
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;

        base.InitializeCulture();
    }

    protected void AddHits(int conteudoId)
    {
        //Add hits to table
        var serviceConteudo = new ConteudoHitsService();
        serviceConteudo.AddHits(Convert.ToInt32(conteudoId));        
    }

    #endregion

}
