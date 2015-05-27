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

public partial class controls_noticias_galeriaImagens : SmartUserControl
{
	public int ConteudoId { get; set; }
	public int ConteudoSecaoId { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		string[] ordenacao = { "ordem" };
		string[] orientacao = { "ASC" };
		NoticiaImagemService noticiaImagemService = new NoticiaImagemService();
		List<NoticiaImagem> noticiaImagens = noticiaImagemService.CarregarToSite(0, ordenacao, orientacao, new NoticiaImagemFH() { NoticiaId = ConteudoId.ToString() });

		if (noticiaImagens != null)
		{
			for (int i = 0; i < noticiaImagens.Count; i++)
			{
				noticiaImagens[i].NoticiaImagemComentarios = new List<NoticiaImagemComentario>();
				NoticiaImagemComentarioService noticiaImagemComentarioService = new NoticiaImagemComentarioService();
				NoticiaImagemComentario nic = noticiaImagemComentarioService.Carregar(new NoticiaImagemComentario() { Idioma = Util.CurrentIdioma, NoticiaImagem = noticiaImagens[i] });
				if (nic != null)
				{
					noticiaImagens[i].NoticiaImagemComentarios.Add(nic);
				}
			}
		}

		rptImagens.DataSource = noticiaImagens;
		rptImagens.DataBind();

		ulFooter.Controls.Clear();
		if (rptImagens.Items.Count > 0)
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

	protected void rptImagens_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgGaleria = (Image)e.Item.FindControl("imgGaleria");

			NoticiaImagem ni = (NoticiaImagem)e.Item.DataItem;

			if (ni != null && ni.Arquivo != null)
			{
				if (!String.IsNullOrEmpty(ni.Arquivo.NomeArquivo))
				{
					imgGaleria.ImageUrl = String.Concat("~/uploads/noticia/galeria/", ni.Arquivo.NomeArquivo);

					if (ni.NoticiaImagemComentarios.Count > 0)
					{
						imgGaleria.AlternateText = ni.NoticiaImagemComentarios[0].ComentarioImagem;
					}
				}
			}
		}
	}
}
