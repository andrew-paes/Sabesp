using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_module_tipoProduto_tipoProduto : System.Web.UI.UserControl
{
    #region [ Properties ]

    #endregion

    #region [ Events ]

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sfArquivo_Excluir(object sender, Ag2.Manager.WebUI.SubFormEventArgs e)
    {
        if (e.listIDs != null)
        {
            foreach (string sid in e.listIDs)
            {
                //NoticiaImagemComentarioService noticiaImagemComentarioService = new NoticiaImagemComentarioService();
                //List<NoticiaImagemComentario> noticiaImagensComentarios = (List<NoticiaImagemComentario>)noticiaImagemComentarioService.CarregarTodos(0, 0, null, null, new NoticiaImagemComentarioFH() { NoticiaImagemId = sid });
                //if (noticiaImagensComentarios != null)
                //{
                //    foreach (NoticiaImagemComentario nic in noticiaImagensComentarios)
                //    {
                //        noticiaImagemComentarioService.Excluir(nic);
                //    }
                //}

                //NoticiaImagemService noticiaImagemService = new NoticiaImagemService();
                //NoticiaImagem ni = noticiaImagemService.Carregar(new NoticiaImagem() { NoticiaImagemId = Convert.ToInt32(sid) });
                //if (ni != null)
                //{
                //    noticiaImagemService.Excluir(ni);
                //}
            }
        }

        // this.BindSubformArquivo();
    }

    protected void btnExecute_Click(object sender, ImageClickEventArgs e)
    {

    }

    #endregion

    #region [ Methods ]

    #endregion
}
