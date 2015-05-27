using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using Sabesp.FilterHelper;

public partial class controls_podcasts_maisRecente : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Podcast> Podcasts { get; set; }

	#endregion

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		//base.DataBind();

		//if (this.Podcasts != null && this.Podcasts.Count > 0)
		//{
		//    var hlTodosPodcasts = (HyperLink)this.FindControl("hlTodosPodcasts");
		//    hlTodosPodcasts.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		//    hlTodosPodcasts.Text = Resources.Resource.hlTodosPodcasts.ToString();

		//    var hlPodcastDestaque = (HyperLink)this.FindControl("hlPodcastDestaque");
		//    var ltrMaisRecentes = (Literal)this.FindControl("ltrMaisRecentes");

		//    ltrMaisRecentes.Text = Resources.Resource.ltrMaisRecentes.ToString();

		//    Podcast podcast = (Podcast)Podcasts[0];
		//    PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
		//    PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

		//    if (podcastIdioma != null)
		//    {
		//        hlPodcastDestaque.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
		//        hlPodcastDestaque.Text = podcastIdioma.TituloPodcast.ReplaceHtml();
		//    }

		//    Podcasts.RemoveAt(0);
		//}
		//else
		//{
		//    this.Visible = false;
		//}

		//if (this.Podcasts != null && this.Podcasts.Count > 0)
		//{
		//    rptPodcasts.DataSource = this.Podcasts;
		//    rptPodcasts.DataBind();
		//    var li = (HtmlGenericControl)rptPodcasts.Items[rptPodcasts.Items.Count - 1].FindControl("li");
		//    if (li != null)
		//    {
		//        li.Attributes.Add("class", "last");
		//    }
		//}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptPodcasts_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		//if (e.Item.DataItem != null)
		//{
		//    var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
		//    var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
		//    //var lblDescricao = (Label)e.Item.FindControl("lblDescricao");

		//    Podcast podcast = (Podcast)e.Item.DataItem;
		//    PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
		//    PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
		//    if (podcastIdioma != null)
		//    {
		//        hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
		//        ltrTitulo.Text = podcastIdioma.TituloPodcast.ReplaceHtml().GenerateResume(85);
		//        //lblDescricao.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
		//    }
		//    else
		//    {
		//        e.Item.Visible = false;
		//    }
		//}
	}

	/// <summary>
	/// 
	/// </summary>
	public void LoadPage()
	{
		bool flag1 = this.BindDiario();
		bool flag2 = this.BindSemanal();
		bool flag3 = this.BindQuinzenal();

		if (flag1 || flag2 || flag3)
		{
			HyperLink hlTodosPodcasts = (HyperLink)this.FindControl("hlTodosPodcasts");
			hlTodosPodcasts.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
			hlTodosPodcasts.Text = Resources.Resource.hlTodosPodcasts.ToString();
		}
		else
		{
			this.hlTodosPodcasts.Visible = false;
		}
	}

	#region [ Podcast Diario ]

	/// <summary>
	/// 
	/// </summary>
	protected bool BindDiario()
	{
		bool flag = false;

		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimDiario.GetHashCode();

		if (SecaoId != null && SecaoId > 0)
		{
			if (SecaoId == MenuPrincipal.FiquePorDentro.GetHashCode())
			{
				entidadePodcast.DestaqueFiquePorDentro = true;
			}
			else
			{
				if (SecaoId == MenuPrincipal.Podcasts.GetHashCode())
				{
					entidadePodcast.DestaquePodcasts = true;
				}
				else
				{
					entidadePodcast.DestaqueHome = true;
				}
			}
		}
		else
		{
			entidadePodcast.DestaqueHome = true;
		}

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(3, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 1;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrDiario.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrDiario.Text = "Boletins Diários";
			}

			this.rptDiario.DataSource = entidadePodcastList;
			this.rptDiario.DataBind();

			var li = (HtmlGenericControl)this.rptDiario.Items[this.rptDiario.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}

			flag = true;
		}
		else
		{
			this.divDiario.Visible = false;
		}

		return flag;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptDiario_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();

			PodcastIdioma podcastIdioma = new PodcastIdioma();
			podcastIdioma.Podcast = podcast;
			podcastIdioma.Idioma = Util.CurrentIdioma;
			podcastIdioma = podcastIdiomaService.Carregar(podcastIdioma);

			if (podcastIdioma != null)
			{
				hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast.ReplaceHtml().GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#region [ Podcast Semanal ]

	/// <summary>
	/// 
	/// </summary>
	protected bool BindSemanal()
	{
		bool flag = false;

		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimSemanal.GetHashCode();
		entidadePodcast.DestaqueHome = true;

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(1, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 2;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrSemanal.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrSemanal.Text = "Boletim Semanal";
			}

			this.rptSemanal.DataSource = entidadePodcastList;
			this.rptSemanal.DataBind();

			var li = (HtmlGenericControl)this.rptSemanal.Items[this.rptSemanal.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}

			flag = true;
		}
		else
		{
			this.divSemanal.Visible = false;
		}

		return flag;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptSemanal_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();

			PodcastIdioma podcastIdioma = new PodcastIdioma();
			podcastIdioma.Podcast = podcast;
			podcastIdioma.Idioma = Util.CurrentIdioma;
			podcastIdioma = podcastIdiomaService.Carregar(podcastIdioma);

			if (podcastIdioma != null)
			{
				hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast.ReplaceHtml().GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#region [ Podcast Quinzenal ]

	/// <summary>
	/// 
	/// </summary>
	protected bool BindQuinzenal()
	{
		bool flag = false;

		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimQuinzenal.GetHashCode();
		entidadePodcast.DestaqueHome = true;

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(2, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 3;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrQuinzenal.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrQuinzenal.Text = "Boletim Semanal";
			}

			this.rptQuinzenal.DataSource = entidadePodcastList;
			this.rptQuinzenal.DataBind();

			var li = (HtmlGenericControl)this.rptQuinzenal.Items[this.rptQuinzenal.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}

			flag = true;
		}
		else
		{
			this.divQuinzenal.Visible = false;
		}

		return flag;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptQuinzenal_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();

			PodcastIdioma podcastIdioma = new PodcastIdioma();
			podcastIdioma.Podcast = podcast;
			podcastIdioma.Idioma = Util.CurrentIdioma;
			podcastIdioma = podcastIdiomaService.Carregar(podcastIdioma);

			if (podcastIdioma != null)
			{
				hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast.ReplaceHtml().GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#endregion
}
