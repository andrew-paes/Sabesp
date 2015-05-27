using System;
using System.Web;

public interface INoticiaDetalhe : IHttpHandler
{
    string NoticiaId { get; set; }
    string NoticiaName { get; set; }
	string NoticiaSecaoId { get; set; }
}

