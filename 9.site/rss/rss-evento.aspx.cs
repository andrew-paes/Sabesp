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

public partial class rss_rss_evento : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.ContentType = "text/xml";
		Response.Write(MontaRSS());
	}

	protected List<Evento> BindRSS()
	{
		EventoService eventoService = new EventoService();
		List<Evento> eventoBOList = new List<Evento>();
		EventoFH eventoFH = new EventoFH();

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		eventoBOList = (List<Evento>)eventoService.RetornaTodosSite(50, dataExibicaoInicio, orderBy, eventoFH);

		return eventoBOList;
	}

	public string MontaRSS()
	{
		StringBuilder rss = new StringBuilder();
		rss.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
		rss.Append("<rss xmlns:itunes=\"http://www.itunes.com/dtds/podcast-1.0.dtd\" version=\"2.0\">");
		rss.Append("<channel>");
		rss.Append("<title><![CDATA[SABESP]]></title>");
		rss.Append(String.Concat("<link>", "<![CDATA[", "http://www.sabesp.com.br", "]]>", "</link>"));
		rss.Append("<description><![CDATA[SABESP]]></description>");
		rss.Append("<copyright><![CDATA[Copyright 2010 Sabesp - Todos os direitos reservados]]></copyright>");

		List<Evento> eventoBOList = this.BindRSS();

		if (eventoBOList != null && eventoBOList.Count > 0)
		{
			foreach (Evento eventoBOTemp in eventoBOList)
			{
				EventoIdioma noticiaIdiomaBOTemp = new EventoIdioma();
				noticiaIdiomaBOTemp.Evento = new Evento();
				noticiaIdiomaBOTemp.Evento.Conteudo = new Conteudo();
				noticiaIdiomaBOTemp.Evento.Conteudo.ConteudoId = eventoBOTemp.Conteudo.ConteudoId;
				noticiaIdiomaBOTemp.Idioma = new Idioma();
				noticiaIdiomaBOTemp.Idioma.IdiomaId = Convert.ToInt32(Request.QueryString["idioma"]);

				EventoIdioma eventoIdiomaBO = new EventoIdioma();
				eventoIdiomaBO = new EventoIdiomaService().Carregar(noticiaIdiomaBOTemp);

				if (eventoIdiomaBO != null)
				{
					string urlSiteMasterPage = Request.Url.ToString();
					string rawUrlSiteMasterPage = Convert.ToString(Request.RawUrl);
					string diretorioRaizSite = urlSiteMasterPage.Replace(rawUrlSiteMasterPage,"");
					string urlLink = ResolveUrl("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=65&id=" + eventoBOTemp.Conteudo.ConteudoId);
					string urlLinkAbsoluth = String.Concat(diretorioRaizSite, urlLink);

					rss.Append("<item>");
					rss.AppendFormat("<title><![CDATA[{0}]]></title>", eventoIdiomaBO.NomeEvento);
					rss.Append(String.Concat("<link>", "<![CDATA[", urlLinkAbsoluth, "]]>", "</link>"));
					rss.AppendFormat("<description><![CDATA[{0}]]></description>", WordsInjector.Hotword(eventoIdiomaBO.ChamadaEvento));
					rss.AppendFormat("<pubDate><![CDATA[{0}]]></pubDate>", Convert.ToDateTime(eventoBOTemp.DataHoraPublicacao).ToString("yyyy-MM-dd HH:mm:ss"));
					rss.Append("</item>");
				}
			}
		}

		rss.Append("</channel>");
		rss.Append("</rss>");

		return rss.ToString();
	}
}
