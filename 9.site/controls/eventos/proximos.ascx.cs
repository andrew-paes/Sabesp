using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_eventos_proximos : SmartUserControl
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

    }
    /// <summary>
    /// Bind the repeater control
    /// </summary>
    public override void DataBind()
    {
        base.DataBind();

        if (this.Eventos != null && this.Eventos.Count > 0)
        {
            rptEventos.DataSource = this.Eventos;
            rptEventos.DataBind();
            var li = (HtmlGenericControl)rptEventos.Items[rptEventos.Items.Count - 1].FindControl("li");
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

    protected void rptEventos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            var hlEvento = (HyperLink)e.Item.FindControl("hlEvento");
            var lblTitulo = (Label)e.Item.FindControl("lblTitulo");
            var lblChamada = (Label)e.Item.FindControl("lblChamada");

            Evento evento = (Evento)e.Item.DataItem;
            EventoIdiomaService eventoIdiomaService = new EventoIdiomaService();
            EventoIdioma eventoIdioma = eventoIdiomaService.Carregar(new EventoIdioma() { Evento = evento, Idioma = Util.CurrentIdioma });
            if (eventoIdioma != null)
            {
                hlEvento.NavigateUrl = String.Concat("~/fique-por-dentro/Eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
                lblTitulo.Text = eventoIdioma.NomeEvento.ReplaceHtml();
                lblChamada.Text = eventoIdioma.ChamadaEvento.StripHTML().ReplaceHtml();
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion
}
