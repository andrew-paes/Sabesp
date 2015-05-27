using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_bancoAudio_maisVistos : SmartUserControl
{
    #region Properties

    /// <summary>
    /// DataSource of this control
    /// </summary>
    public List<Podcast> Podcasts { get; set; }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        var ltrMaisVistos = (Literal)this.FindControl("ltrMaisVistos");
        ltrMaisVistos.Text = Resources.Resource.ltrMaisVistos.ToString();

    }
    /// <summary>
    /// Bind the repeater control
    /// </summary>
    public override void DataBind()
    {
        base.DataBind();

        if (this.Podcasts != null && this.Podcasts.Count > 0)
        {
            rptMaisVistos.DataSource = this.Podcasts;
            rptMaisVistos.DataBind();
            var li = (HtmlGenericControl)rptMaisVistos.Items[rptMaisVistos.Items.Count - 1].FindControl("li");
            if (li != null)
            {
                li.Attributes.Add("class", "last");
            }
        }
        else
        {
            this.Visible = false;
        }
    }

    protected void rptMaisVistos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {            
            var hlPodcast = (HyperLink)e.Item.FindControl("hlPodcast");
            var lblChamada = (Label)e.Item.FindControl("lblChamada");
            var lblQtdVisualizacoes = (Label)e.Item.FindControl("lblQtdVisualizacoes");
            var ltrQtdVisualizacoes = (Literal)e.Item.FindControl("ltrQtdVisualizacoes");
            

            Podcast podcast = (Podcast)e.Item.DataItem;
            PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
            PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
            if (podcastIdioma != null)
            {

                //ArquivoService arquivoService = new ArquivoService();
                //if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
                //    podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);

                //if (podcastIdioma.ArquivoPodcast != null)
                //{
				//    mImage1.ImageUrl = String.Concat("~/uploads/secao/", podcastIdioma.ArquivoPodcast.NomeArquivo);
                //}

                ConteudoHits conteudoHits = new ConteudoHits();
                ConteudoHitsService conteudoHitsService = new ConteudoHitsService();
                conteudoHits = conteudoHitsService.CarregarToSite(podcast.Conteudo.ConteudoId);

                lblQtdVisualizacoes.Text = conteudoHits.Hits.ToString() + Resources.Resource.lblQtdVisualizacoes.ToString(); ;
				hlPodcast.NavigateUrl = String.Concat("~/fique-por-dentro/banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
                lblChamada.Text = podcastIdioma.TituloPodcast.ReplaceHtml();
                
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion
}
