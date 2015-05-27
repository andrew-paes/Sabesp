<%@ Application Language="C#" %>

<script RunAt="server">

	protected void Application_Start(object sender, EventArgs e)
	{
		RegisterRoutes();
	}

	void Application_End(object sender, EventArgs e)
	{
		//  Code that runs on application shutdown 

	}

	void Application_Error(object sender, EventArgs e)
	{
		System.Web.HttpContext context = HttpContext.Current;
		System.Exception exception = Context.Server.GetLastError();

		//LogError(exception);

		context.Server.ClearError(); // limpa os erros do server
		
		string url = Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower();

		if (url != "~/default.aspx")
		{
			Response.Redirect("~/Default.aspx"); // redireciona para esta pagina caso haja erros
		}

		// Code that runs when an unhandled error occurs
	}

	void Session_Start(object sender, EventArgs e)
	{
		// Code that runs when a new session is started
		if (Session["dataAcesso"] == null)
		{
			Session["dataAcesso"] = DateTime.Now;
		}
	}

	void Session_End(object sender, EventArgs e)
	{
		// Code that runs when a session ends. 
		// Note: The Session_End event is raised only when the sessionstate mode
		// is set to InProc in the Web.config file. If session mode is set to StateServer 
		// or SQLServer, the event is not raised.

	}

	/// <summary>
	/// Register routes to friendly url's
	/// </summary>
	private static void RegisterRoutes()
	{
		//Register a new Route to Noticia
		System.Web.Routing.RouteTable.Routes.Add(
			"Noticia",
			new System.Web.Routing.Route("noticia/{noticiaId},{secaoId},{name}.aspx",
					  new NoticiaDetalheRouteHandler(
						  "~/fique-por-dentro/noticias-Detalhes.aspx")));
	}
       
</script>

