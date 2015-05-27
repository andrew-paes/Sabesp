using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.BO;
using System.Web.UI.HtmlControls;
using Sabesp.Data.Services;

public partial class controls_BreadCrumb : SmartUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		try
		{
			this.LoadBreadCrumb();
		}
		catch
		{
			this.Visible = false;
		}
	}

	protected void LoadBreadCrumb()
	{
		HtmlGenericControl lblPai;
		HtmlGenericControl lbl;
		HyperLink link;
		List<Secao> caminho = new SecaoService().ObterCaminho(new Secao() { SecaoId = SecaoId }, Util.CurrentIdioma);

		//CRIA LABEL CAMINHO DO PAO
		lblPai = new HtmlGenericControl("span");
		lblPai.Attributes.Add("id", "caminho_pao");
		lblPai.Attributes.Add("class", "caminho_pao");

		//CRIA LINK PARA HOME
		link = new HyperLink();
		link.NavigateUrl = "~/Default.aspx";
		link.CssClass = "root_node";
		link.Text = Resources.Resource.Home;

		//CRIA LABEL E ADICIONA O LINK DA HOME NA LABEL CRIADA
		HtmlGenericControl lbl2 = new HtmlGenericControl("span");
		lbl2.Controls.Add(link);

		//ADICIONA A LABEL CRIADA ACIMA NA LABEL DO CAMINHO DO PAO
		lblPai.Controls.Add(lbl2);

		Secao sec;

		for (int a = caminho.Count; a > 0; a--)
		{
			sec = caminho[a - 1];

			if (sec.SecaoPai != null && sec.SecaoPai.SecaoId != 0)
			{
				lbl = new HtmlGenericControl("span");
				lbl.Attributes.Add("class", "separator");
				lbl.InnerHtml = " / ";
				lblPai.Controls.Add(lbl);

				if (a == 1)
				{
					lbl = new HtmlGenericControl("span");
					lbl.Attributes.Add("class", "current_node");
					lbl.InnerHtml = sec.SecaoIdiomas[0].Titulo;
					lblPai.Controls.Add(lbl);
				}
				else
				{
					if (!string.IsNullOrEmpty(sec.Modelo.Arquivo))
					{
						link = new HyperLink();
						link.NavigateUrl = String.Concat(sec.Modelo.Arquivo, "?secaoId=" + sec.SecaoId);
						link.Text = sec.SecaoIdiomas[0].Titulo;

						lbl = new HtmlGenericControl("span");
						lbl.Controls.Add(link);

						lblPai.Controls.Add(lbl);
					}
					else
					{
						lbl = new HtmlGenericControl("span");
						lbl.InnerHtml = sec.SecaoIdiomas[0].Titulo;
						lblPai.Controls.Add(lbl);
					}
				}
			}
		}

		pnlCaminhoPao.Controls.Add(lblPai);
	}
}