using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rss : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	protected void LoadPage()
	{
		segundaColunaDinamica1.DataBind();
		hlEvento.NavigateUrl = String.Concat("rss-evento.aspx", "?idioma=", Util.CurrentIdiomaId);
		hlNoticia.NavigateUrl = String.Concat("rss-noticia.aspx", "?idioma=", Util.CurrentIdiomaId);
		hlImprensa.NavigateUrl = String.Concat("rss-imprensa.aspx", "?idioma=", Util.CurrentIdiomaId);
		hlPodcast.NavigateUrl = String.Concat("rss-podcast.aspx", "?idioma=", Util.CurrentIdiomaId);
		hlBancoAudio.NavigateUrl = String.Concat("rss-banco-de-audio.aspx", "?idioma=", Util.CurrentIdiomaId);
	}
}