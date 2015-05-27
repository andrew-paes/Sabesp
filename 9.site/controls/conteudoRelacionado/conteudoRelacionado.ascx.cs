using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using System.Data;
using Sabesp.Enumerators;
using Sabesp.BO;

public partial class controls_conteudoRelacionado_conteudoRelacionado : System.Web.UI.UserControl
{
	#region [ Page Events ]
	/// <summary>
	/// Page Load event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	/// <summary>
	/// rptContent ItemDataBound
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		this.ContentDataBound(sender, e);
	}

	#endregion

	#region [ Methods ]
	/// <summary>
	/// Load Page Method
	/// </summary>
	private void LoadPage()
	{
		this.LoadResources();
	}

	protected void LoadResources()
	{
		ltrConteudosRelacionados.Text = GetLocalResourceObject(ltrConteudosRelacionados.ID).ToString();
	}

	/// <summary>
	/// Arrange controls on DataBound event
	/// </summary>
	private void ContentDataBound(object sender, RepeaterItemEventArgs e)
	{
		DataRowView dr = (DataRowView)((RepeaterItem)e.Item).DataItem;

		if (dr != null)
		{
			var lblDate = (Label)e.Item.FindControl("lblDate");
			var hlContent = (HyperLink)e.Item.FindControl("hlContent");

			//set date
			lblDate.Text = Convert.ToDateTime(dr["ultimaAlteracao"].ToString()).ToString("dd/MM/yyyy");

			// set link text
			hlContent.Text = this.GetDescription(Convert.ToInt32(dr["conteudotipoid"]), Convert.ToInt32(dr["conteudoid"]));

			// set link navigate
			hlContent.NavigateUrl = this.GetLinkDetail(Convert.ToInt32(dr["conteudotipoid"].ToString()), Convert.ToInt32(dr["conteudoid"].ToString()));

			if (String.IsNullOrEmpty(hlContent.Text))
			{
				e.Item.Visible = false;
			}
		}
		else
		{
			e.Item.Visible = false;
		}
	}

	/// <summary>
	/// Get description of content
	/// </summary>
	/// <param name="contentTypeId"></param>
	/// <param name="contentId"></param>
	/// <returns></returns>
	private string GetDescription(int contentTypeId, int contentId)
	{
		string description = string.Empty;

		Conteudos tipoConteudo = (Conteudos)Enum.Parse(typeof(Conteudos), contentTypeId.ToString());

		Conteudo cont = new Conteudo(contentId);

		switch (tipoConteudo)
		{
			case Conteudos.Noticia:
				NoticiaService noticiaService = new NoticiaService();
				Noticia noticia = noticiaService.Carregar(new Noticia() { Conteudo = cont });
				if (noticia != null)
				{
					NoticiaIdiomaService noticiaIdiomaService = new NoticiaIdiomaService();
					NoticiaIdioma noticiaIdioma = noticiaIdiomaService.Carregar(new NoticiaIdioma() { Noticia = noticia, Idioma = Util.CurrentIdioma });
					if (noticiaIdioma != null)
					{
						description = noticiaIdioma.TituloNoticia;
					}
				}
				break;
			case Conteudos.Evento:
				EventoService eventoService = new EventoService();
				Evento evento = eventoService.Carregar(new Evento() { Conteudo = cont });
				if (evento != null)
				{
					EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
					EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
					if (eventoIdioma != null)
					{
						description = eventoIdioma.NomeEvento;
					}
				}
				break;
			case Conteudos.Comunicado:
				ComunicadoService comunicadoService = new ComunicadoService();
				Comunicado comunicado = comunicadoService.Carregar(new Comunicado() { Conteudo = cont });
				if (comunicado != null)
				{
					ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
					ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = comunicado, Idioma = Util.CurrentIdioma });
					if (comunicadoIdioma != null)
					{
						description = comunicadoIdioma.TituloComunicado;
					}
				}
				break;
			case Conteudos.Video:
				VideoService videoService = new VideoService();
				Video video = videoService.Carregar(new Video() { Conteudo = cont });
				if (video != null)
				{
					VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
					VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
					if (videoIdioma != null)
					{
						description = videoIdioma.TituloVideo;
					}
				}
				break;
			case Conteudos.Podcast:
				PodcastService podcastService = new PodcastService();
				Podcast podcast = podcastService.Carregar(new Podcast() { Conteudo = cont });
				if (podcast != null)
				{
					PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
					PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
					if (podcastIdioma != null)
					{
						description = podcastIdioma.TituloPodcast;
					}
				}
				break;
			case Conteudos.Release:
				ReleaseService releaseService = new ReleaseService();
				Release release = releaseService.Carregar(new Release() { Conteudo = cont });
				if (release != null)
				{
					ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
					ReleaseIdioma releaseIdioma = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = release, Idioma = Util.CurrentIdioma });
					if (releaseIdioma != null)
					{
						description = releaseIdioma.TituloRelease;
					}
				}
				break;
			default:
				break;
		}


		return description;
	}

	/// <summary>
	/// Get Detail link to related content
	/// </summary>
	/// <param name="contentTypeId">Type do check detail page</param>
	/// <returns></returns>
	private string GetLinkDetail(int contentTypeId, int contentId)
	{
		string link = "errorPage"; // TODO: Pagina de conteudo nao encontrado

		Conteudos tipoConteudo = (Conteudos)Enum.Parse(typeof(Conteudos), contentTypeId.ToString());

		switch (tipoConteudo)
		{
			case Conteudos.Noticia:
				link = String.Concat("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			case Conteudos.Evento:
				link = String.Concat("~/fique-por-dentro/eventos-Detalhes.aspx",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			case Conteudos.Comunicado:
				link = String.Concat("~/fique-por-dentro/comunicados-Detalhes.aspx?secaoId=",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			case Conteudos.Video:
				link = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			case Conteudos.Podcast:
				link = String.Concat("~/fique-por-dentro/podcasts-Detalhes.aspx?secaoId=",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			case Conteudos.Release:
				link = String.Concat("~/fique-por-dentro/releases-Detalhes.aspx?secaoId=",
					MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", contentId);
				break;
			default:
				break;
		}

		return link;
	}

	/// <summary>
	/// Bind Content
	/// </summary>
	/// <param name="conteudoId"></param>
	public void ContentDataBind(int conteudoId)
	{
		DataTable dt = new ConteudoService().RetornaConteudoRelacionado(conteudoId);

		if (dt != null && dt.Rows.Count > 0)
		{
			this.pnlContent.Visible = true;
			this.rptContent.DataSource = dt;
			this.rptContent.DataBind();

			//validation to show repeater only if contains visible items 
			int countVisible = 0;
			foreach (RepeaterItem item in rptContent.Items)
			{
				if (item.Visible)
				{
					countVisible++;
				}
			}
			this.Visible = (countVisible > 0);
		}
		else
		{
			this.pnlContent.Visible = false;
		}
	}

	#endregion

}
