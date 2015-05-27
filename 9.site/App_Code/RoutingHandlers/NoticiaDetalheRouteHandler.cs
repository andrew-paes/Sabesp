using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;

/// <summary>
/// Handler of Noticia
/// </summary>
public class NoticiaDetalheRouteHandler : IRouteHandler
{
    string _virtualPath;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="virtualPath"></param>
    public NoticiaDetalheRouteHandler(string virtualPath)
    {
        _virtualPath = virtualPath;
    }

    /// <summary>
    /// Fill the object with parameters of route
    /// </summary>
    /// <param name="requestContext"></param>
    /// <returns></returns>
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        var display = BuildManager.CreateInstanceFromVirtualPath(_virtualPath, typeof(Page)) as INoticiaDetalhe;
        display.NoticiaId = requestContext.RouteData.Values["noticiaId"] as string;
        display.NoticiaName = requestContext.RouteData.Values["name"] as string;
		display.NoticiaSecaoId = requestContext.RouteData.Values["secaoId"] as string;
        return display;
    }
}
