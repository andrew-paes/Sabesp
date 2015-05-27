using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using AG2.Sabesp.HotWords;

public partial class rss_rss_noticia : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.ContentType = "text/xml";
		Response.Write(MontaRSS());
	}

	protected List<Noticia> BindRSS()
	{
		NoticiaService noticiaService = new NoticiaService();
		List<Noticia> noticias = new List<Noticia>();
		NoticiaIdiomaFH noticiaIdiomaFH = new NoticiaIdiomaFH();
		noticias = (List<Noticia>)noticiaService.CarregarUltimasNoticias(50, noticiaIdiomaFH);

		return noticias;
	}

	public string MontaRSS()
	{
		StringBuilder rss = new StringBuilder();
		//rss.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>");
		rss.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
		rss.Append("<rss xmlns:itunes=\"http://www.itunes.com/dtds/podcast-1.0.dtd\" version=\"2.0\">");
		rss.Append("<channel>");
		rss.Append("<title><![CDATA[SABESP]]></title>");
		rss.Append(String.Concat("<link>", "<![CDATA[", "http://www.sabesp.com.br", "]]>", "</link>"));
		rss.Append("<description><![CDATA[SABESP]]></description>");
		rss.Append("<copyright><![CDATA[Copyright 2010 Sabesp - Todos os direitos reservados]]></copyright>");

		List<Noticia> noticiaBOList = this.BindRSS();

		if (noticiaBOList != null && noticiaBOList.Count > 0)
		{
			foreach (Noticia noticiaBOTemp in noticiaBOList)
			{
				NoticiaIdioma noticiaIdiomaBOTemp = new NoticiaIdioma();
				noticiaIdiomaBOTemp.Noticia = new Noticia();
				noticiaIdiomaBOTemp.Noticia.Conteudo = new Conteudo();
				noticiaIdiomaBOTemp.Noticia.Conteudo.ConteudoId = noticiaBOTemp.Conteudo.ConteudoId;
				noticiaIdiomaBOTemp.Idioma = new Idioma();
				//noticiaIdiomaBOTemp.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
				noticiaIdiomaBOTemp.Idioma.IdiomaId = Convert.ToInt32(Request.QueryString["idioma"]);

				NoticiaIdioma noticiaIdiomaBO = new NoticiaIdioma();
				noticiaIdiomaBO = new NoticiaIdiomaService().Carregar(noticiaIdiomaBOTemp);

				if (noticiaIdiomaBO != null)
				{
					string urlSiteMasterPage = Request.Url.ToString();
					string rawUrlSiteMasterPage = Convert.ToString(Request.RawUrl);
					string diretorioRaizSite = urlSiteMasterPage.Replace(rawUrlSiteMasterPage,"");
					string urlLink = ResolveUrl("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=65&id=" + noticiaBOTemp.Conteudo.ConteudoId);
					string urlLinkAbsoluth = String.Concat(diretorioRaizSite, urlLink);

					rss.Append("<item>");
					rss.AppendFormat("<title><![CDATA[{0}]]></title>", noticiaIdiomaBO.TituloNoticia);
					rss.Append(String.Concat("<link>", "<![CDATA[", urlLinkAbsoluth, "]]>", "</link>"));
					rss.AppendFormat("<description><![CDATA[{0}]]></description>", WordsInjector.Hotword(noticiaIdiomaBO.ChamadaNoticia));
					rss.AppendFormat("<pubDate><![CDATA[{0}]]></pubDate>", Convert.ToDateTime(noticiaBOTemp.DataHoraPublicacao).ToString("yyyy-MM-dd HH:mm:ss"));
					rss.Append("</item>");
				}
			}
		}

		rss.Append("</channel>");
		rss.Append("</rss>");

		return rss.ToString();
	}
}
