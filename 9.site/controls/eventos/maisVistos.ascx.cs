using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class controls_eventos_maisVistos : SmartUserControl
{
    #region Properties

    /// <summary>
    /// DataSource of this control
    /// </summary>
    public List<Evento> Eventos { get; set; }

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

        if (this.Eventos != null && this.Eventos.Count > 0)
        {
            rptMaisVistos.DataSource = this.Eventos;
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
            var mImage1 = (Image)e.Item.FindControl("mImage1");
            var hlEvento = (HyperLink)e.Item.FindControl("hlEvento");
            var lblChamada = (Label)e.Item.FindControl("lblChamada");
            var lblQtdVisualizacoes = (Label)e.Item.FindControl("lblQtdVisualizacoes");
            
            
            

            Evento evento = (Evento)e.Item.DataItem;
            EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
            EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
            if (eventoIdioma != null)
            {
                ArquivoService arquivoService = new ArquivoService();
                if (evento.ArquivoThumbGrande != null && evento.ArquivoThumbGrande.ArquivoId > 0)
                {
                    evento.ArquivoThumbGrande = arquivoService.Carregar(evento.ArquivoThumbGrande);
                }
                if (evento.ArquivoThumbGrande != null && File.Exists(String.Concat("~/uploads/secao/", evento.ArquivoThumbGrande.NomeArquivo)))
                {
					mImage1.ImageUrl = String.Concat("~/uploads/secao/", evento.ArquivoThumbGrande.NomeArquivo);
                }
                else
                {
                    mImage1.Attributes.Add("style", "display:none");
                }

                ConteudoHits conteudoHits = new ConteudoHits();
                ConteudoHitsService conteudoHitsService = new ConteudoHitsService();
                conteudoHits = conteudoHitsService.CarregarToSite(evento.Conteudo.ConteudoId);

                lblQtdVisualizacoes.Text = conteudoHits.Hits.ToString() + Resources.Resource.lblQtdVisualizacoes.ToString();
                hlEvento.NavigateUrl = String.Concat("~/fique-por-dentro/Eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
                lblChamada.Text = eventoIdioma.NomeEvento;
                
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion
}
