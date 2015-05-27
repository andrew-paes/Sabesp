using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.Data.Services
{
    public class IdiomaService
    {
        /// <summary>
        /// Váriavel privada de acesso a camada de dados;
        /// </summary>
        private IIdiomaDAL _idiomaDAL;

        public IIdiomaDAL IdiomaDAL
        {
            get
            {
                if (_idiomaDAL == null)
                    _idiomaDAL = new IdiomaADO();
                return _idiomaDAL;
            }            
        }

        /// <summary>
        /// Método que recupera todos os idiomas;
        /// </summary>
        /// <returns>Coleção de Idioma.</returns>
        public List<Idioma> RecuperarTodosIdiomas()
        {
            return IdiomaDAL.CarregarTodos();
        }

        /// <summary>
        /// Método que recupera todos os idiomas;
        /// </summary>
        /// <returns>Coleção de Idioma.</returns>
        public List<Idioma> CarregarIdiomasSemSolucaoAmbiental()
        {
            return IdiomaDAL.CarregarIdiomasSemSolucaoAmbiental();
        }

        /// <summary>
        /// Método que recupera todos idiomas com exeção da lista de idiomas informados.
        /// </summary>
        /// <returns>Coleção de Idioma.</returns>
        public List<Idioma> RecuperarTodosIdiomasComExececao(List<Idioma> idiomas)
        {
            IEnumerable<string> ids = idiomas.Select(p => p.IdiomaId.ToString());

            IdiomaExcecaoFH filtro = new IdiomaExcecaoFH();
            filtro.IdentificadoresDosIds = ids;

            return IdiomaDAL.CarregarTodos(0, 0, null, null, filtro);
        }
        public int TotalRegistros(IdiomaFH filtro)
        {
            return IdiomaDAL.TotalRegistros(filtro);
        }

    }
}
