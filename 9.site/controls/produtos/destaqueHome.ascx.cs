using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;

public partial class controls_produtos_destaqueHome : SmartUserControl
{
	#region [ Properties ]
    public SolucaoAmbientalIdioma solucaoAmbiental;

	#endregion

	#region [ Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		hlProdutoMain.NavigateUrl = "http://site.sabesp.com.br/site/interna/Default.aspx?secaoId=63";

		//this.DataBind();
	}

	public override void DataBind()
	{
		base.DataBind();

		this.BindControl();
	}

	#endregion

	#region [ Methods ]

	private void BindControl()
	{
        if (solucaoAmbiental != null)
		{
            this.ltlTituloFirst.Text = solucaoAmbiental.TituloPrincipal;
            if (!string.IsNullOrEmpty(solucaoAmbiental.TituloChamada1))
			{
                this.ltlTituloSecond.Text = solucaoAmbiental.TituloChamada1;
                this.lblDescricaoSecond.Text = solucaoAmbiental.TextoChamada1.GenerateResume(120);
                this.hlProdutoSecond.NavigateUrl = solucaoAmbiental.Link1;
			}

            if (!string.IsNullOrEmpty(solucaoAmbiental.TituloChamada2))
			{
                this.ltlTituloThird.Text = solucaoAmbiental.TituloChamada2;
                this.lblDescricaoThird.Text = solucaoAmbiental.TextoChamada2.GenerateResume(120);
                this.hlProdutoThird.NavigateUrl = solucaoAmbiental.Link2;
			}

            if (!string.IsNullOrEmpty(solucaoAmbiental.TituloChamada3))
			{
                this.ltlTituloFourth.Text = solucaoAmbiental.TituloChamada3;
                this.lblDescricaoFourth.Text = solucaoAmbiental.TextoChamada3.GenerateResume(120);
                this.hlProdutoFourth.NavigateUrl = solucaoAmbiental.Link3;			
			}

            if (!string.IsNullOrEmpty(solucaoAmbiental.LinkImagem))
            {
                this.hlLinkImagem.NavigateUrl = solucaoAmbiental.LinkImagem;
            }

            ArquivoService arquivoService = new ArquivoService();
            if (solucaoAmbiental.ArquivoFoto != null && solucaoAmbiental.ArquivoFoto.ArquivoId > 0)
            {
                solucaoAmbiental.ArquivoFoto = arquivoService.Carregar(solucaoAmbiental.ArquivoFoto);
            }
            if (solucaoAmbiental.ArquivoFoto != null)
            {
                ImageMain.ImageUrl = String.Concat("~/uploads/secao/", solucaoAmbiental.ArquivoFoto.NomeArquivo);
            }
            else
            {
                ImageMain.ImageUrl = ResolveUrl( "~/contents/img/produtos_home.jpg");
            }

		}
	}

	#endregion
}
