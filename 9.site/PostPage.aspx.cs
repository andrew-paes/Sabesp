using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using Sabesp.Data.Services;

[WebService]
public partial class PostPage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    [WebMethod]
    [ScriptMethod]
    public static string AddHit(string conteudoId)
    {
        //Add hits to table
        var serviceConteudo = new ConteudoHitsService();
        serviceConteudo.AddHits(Convert.ToInt32(conteudoId));

        return string.Empty;
    }
    [WebMethod]
    [ScriptMethod]
    public static int voteBad(string conteudoId)
    {
        
        var serviceConteudoAvaliacao = new ConteudoAvaliacaoService();
        int ret = serviceConteudoAvaliacao.AddAvaliacaoNegativo(Convert.ToInt32(conteudoId));
        if (ret != 0)
        {
            Cookie ck = new Cookie();
            ck.AddAvaliado(Convert.ToInt32(conteudoId));
        }

        return ret;
    }
    [WebMethod]
    [ScriptMethod]
    public static int voteGood(string conteudoId)
    {

        var serviceConteudoAvaliacao = new ConteudoAvaliacaoService();
        int ret = serviceConteudoAvaliacao.AddAvaliacaoPositivo(Convert.ToInt32(conteudoId));
        if (ret != 0)
        {
            Cookie ck = new Cookie();
            ck.AddAvaliado(Convert.ToInt32(conteudoId));
        }
        return ret;
    }

}
