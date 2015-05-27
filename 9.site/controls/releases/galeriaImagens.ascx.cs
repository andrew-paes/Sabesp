using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using System.Web.UI.HtmlControls;

public partial class controls_releases_galeriaImagens : SmartUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		string[] ordenacao = { "ordem" };
		string[] orientacao = { "ASC" };
		ReleaseImagemService releaseImagemService = new ReleaseImagemService();
		List<ReleaseImagem> releaseImagens = (List<ReleaseImagem>)releaseImagemService.RetornaTodos(0, 0, ordenacao, orientacao, new ReleaseImagemFH() { ReleaseId = RegistroId.ToString() });

		if (releaseImagens != null && releaseImagens.Count > 0)
		{
			rptImagens.DataSource = releaseImagens;
			rptImagens.DataBind();
		}

		ulFooter.Controls.Clear();

		AddCss();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptImagens_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgGaleria = (Image)e.Item.FindControl("imgGaleria");

			ReleaseImagem ni = (ReleaseImagem)e.Item.DataItem;
			ni.ReleaseImagemComentarios = new List<ReleaseImagemComentario>();
			ReleaseImagemComentarioService releaseImagemComentarioService = new ReleaseImagemComentarioService();
			ReleaseImagemComentario nic = releaseImagemComentarioService.Carregar(new ReleaseImagemComentario() { Idioma = Util.CurrentIdioma, ReleaseImagem = ni });

			if (nic != null)
			{
				ni.ReleaseImagemComentarios.Add(nic);
			}

			Arquivo arquivoBO = new Arquivo();
			arquivoBO.ArquivoId = ni.Arquivo.ArquivoId;
			arquivoBO = new ArquivoService().Carregar(arquivoBO);

			if (ni != null && arquivoBO != null)
			{
				if (!String.IsNullOrEmpty(arquivoBO.NomeArquivo))
				{
					imgGaleria.ImageUrl = String.Concat("~/uploads/secao/", arquivoBO.NomeArquivo);

					if (ni.ReleaseImagemComentarios != null && ni.ReleaseImagemComentarios.Count > 0)
					{
						imgGaleria.AlternateText = ni.ReleaseImagemComentarios[0].ComentarioImagem;
					}
				}
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void AddCss()
	{
		if (rptImagens != null && rptImagens.Items.Count > 0)
		{
			for (int i = 0; i < rptImagens.Items.Count; i++)
			{
				HtmlGenericControl liGaleria = (HtmlGenericControl)rptImagens.Items[i].FindControl("liGaleria");
				HtmlGenericControl li = new HtmlGenericControl("li");
				HyperLink hlLi = new HyperLink();

				if (i == 0)
				{
					li.Attributes.Add("class", "atv");
					if (liGaleria != null)
					{
						liGaleria.Attributes.Add("style", "display:block");
					}
				}

				hlLi.Text = (i + 1).ToString();
				hlLi.NavigateUrl = "javascript:;";
				li.Controls.Add(hlLi);
				ulFooter.Controls.Add(li);
			}
		}
		else
		{
			this.Visible = false;
		}
	}
}