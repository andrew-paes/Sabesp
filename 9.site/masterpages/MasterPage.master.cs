using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using System.Text;
using System.Configuration;

public partial class masterpages_MasterPage : System.Web.UI.MasterPage
{
	#region Properties

	public String strNomeSecao;
	public String strNomeArquivo;

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
					_secao = 0;
				}
			}

			return _secao;
		}
	}



	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		if (Util.IsHomolog)
		{
			pnlAvisoHomolog.Visible = true;
		}

		try
		{
			Page.Title = this.GetSiteMap();
		}
		catch
		{
			Page.Title = "Sabesp";
		}
	}

	protected string GetSiteMap()
	{
		Trace.Write("Master > Getsitemap() > ini");

		StringBuilder lblPai = new StringBuilder();
		string lbl;
		List<Secao> caminho = new SecaoService().ObterCaminho(new Secao() { SecaoId = SecaoId }, Util.CurrentIdioma);

		lblPai.Append("Sabesp » ");
		lblPai.Append(Resources.Resource.Home);

        if (caminho.Count > 0)
        {
            Secao sec;
            for (int a = caminho.Count; a > 0; a--)
            {
                sec = caminho[a - 1];
                if (sec.SecaoPai != null && sec.SecaoPai.SecaoId != 0)
                {
                    lbl = " » ";
                    lblPai.Append(lbl);

                    if (a == 1)
                    {
                        lbl = sec.SecaoIdiomas[0].Titulo;
                        lblPai.Append(lbl);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sec.Modelo.Arquivo))
                        {
                            lbl = sec.SecaoIdiomas[0].Titulo;
                            lblPai.Append(lbl);
                        }
                        else
                        {
                            lbl = sec.SecaoIdiomas[0].Titulo;
                            lblPai.Append(lbl);
                        }
                    }
                }
            }
        }
        else
        {
            if (Request.Url.AbsoluteUri.ToLower().Contains("/rss/default.aspx"))
            {
                lblPai.Append(" » RSS");
            }
        }
		Trace.Write("Master > Getsitemap() > fim");
		return lblPai.ToString();
	}
}