using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class controls_eventos_destaqueLista : SmartUserControl
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
			rptDestaques.DataSource = this.Eventos;
			rptDestaques.DataBind();
            var li = (HtmlGenericControl)rptDestaques.Items[rptDestaques.Items.Count - 1].FindControl("li");
            if (li != null)
            {
                li.Attributes.Add("style", "display:none");
            }
		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptDestaques_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
            var divImg = (HtmlGenericControl)e.Item.FindControl("divImg");

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
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", evento.ArquivoThumbGrande.NomeArquivo);
				}
                else
                {
                    divImg.Attributes.Add("style", "display:none");
                }
				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/Eventos-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", evento.Conteudo.ConteudoId);
                ltrTitulo.Text = eventoIdioma.NomeEvento;
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
