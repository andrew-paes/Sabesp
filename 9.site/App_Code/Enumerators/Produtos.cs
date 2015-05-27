using System;
using System.ComponentModel;

namespace Sabesp.Enumerators
{
	/// <summary>
	/// Enum that specifies the id's of ProdutoTipo on database
	/// </summary>
	public enum Produtos
	{
		[DescriptionAttribute("128")] //set the Description as SecaoId associed with the product type.
		Empresas = 1,

		[DescriptionAttribute("129")] 
		MicroEmpresas = 2,

		[DescriptionAttribute("130")] 
		MunicipiosEEstados = 3,

		[DescriptionAttribute("131")] 
		ConsultoriaInternacional = 4,

		[DescriptionAttribute("132")] 
		ConsultoriaSustentavel = 5,

		[DescriptionAttribute("133")] 
		Condominios = 6
	}
}