using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Data.Services;
using Sabesp.BO;

public partial class controls_eventos_galeriaImagens : SmartUserControl
{

    #region Properties

    /// <summary>
    /// DataSource of this control
    /// </summary>
    public List<EventoFoto> Fotos { get; set; }

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

		if (this.Fotos != null && this.Fotos.Count > 0)
		{
			for (int i = 0; i < Fotos.Count; i++)
			{
				Fotos[i].EventoFotoComentarios = new List<EventoFotoComentario>();
				EventoFotoComentarioService eventoFotoComentarioService = new EventoFotoComentarioService();
				EventoFotoComentario efc = eventoFotoComentarioService.Carregar(new EventoFotoComentario() { Idioma = Util.CurrentIdioma, EventoFoto = Fotos[i] });
				if (efc != null)
				{
					Fotos[i].EventoFotoComentarios.Add(efc);
				}
			}
			rptImagens.DataSource = this.Fotos;
			rptImagens.DataBind();
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
			EventoFoto eventoFoto = (EventoFoto)e.Item.DataItem;
			if (eventoFoto != null)
			{
				var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
				var hlGaleria = (HyperLink)e.Item.FindControl("hlGaleria");
				var ltrDescricao = (Literal)e.Item.FindControl("ltrDescricao");
				//var lblImagem = (Label)e.Item.FindControl("lblImagem");


				ArquivoService arquivoService = new ArquivoService();
				Arquivo arquivo = new Arquivo();
				if (eventoFoto.Arquivo != null && eventoFoto.Arquivo.ArquivoId > 0)
					arquivo = arquivoService.Carregar(eventoFoto.Arquivo);

				if (arquivo != null)
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/evento/galeria/", arquivo.NomeArquivo);
					hlGaleria.NavigateUrl = String.Concat("~/uploads/evento/galeria/", arquivo.NomeArquivo);

					ltrDescricao.Text = eventoFoto.EventoFotoComentarios[0].ComentarioImagem.ReplaceHtml();
				}
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	} 

	#endregion

}
