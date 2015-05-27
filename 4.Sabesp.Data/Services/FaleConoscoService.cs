using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
    public class FaleConoscoService
    {

        #region Atributos
        private IFaleConoscoAssuntoDAL _assuntoDAL;
        private IFaleConoscoMensagemDAL _mensagemDAL;
        private IEstadoDAL _estadoDAL;
        private ICidadeDAL _cidadeDAL;
        #endregion

        #region Propriedades
        public IFaleConoscoAssuntoDAL AssuntoDAL
        {

            get
            {
                if (_assuntoDAL == null)
                    _assuntoDAL = new FaleConoscoAssuntoADO();

                return _assuntoDAL;
            }
            set
            {
                _assuntoDAL = value;
            }
        }

        public IFaleConoscoMensagemDAL MensagemDAL
        {

            get
            {
                if (_mensagemDAL == null)
                    _mensagemDAL = new FaleConoscoMensagemADO();

                return _mensagemDAL;
            }
            set
            {
                _mensagemDAL = value;
            }
        }

        public IEstadoDAL EstadoDAL
        {

            get
            {
                if (_estadoDAL == null)
                    _estadoDAL = new EstadoADO();

                return _estadoDAL;
            }
            set
            {
                _estadoDAL = value;
            }
        }

        public ICidadeDAL CidadeDAL
        {

            get
            {
                if (_cidadeDAL == null)
                    _cidadeDAL = new CidadeADO();

                return _cidadeDAL;
            }
            set
            {
                _cidadeDAL = value;
            }
        }
        #endregion

        #region Construtores
        public FaleConoscoService()
        {

        }
        #endregion

        #region Métodos
        public IList<FaleConoscoAssunto> ListarAssuntos()
        {
            return AssuntoDAL.CarregarTodos();
        }

        public void Inserir(FaleConoscoMensagem entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                MensagemDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public IList<Estado> ListarEstados()
        {
            return EstadoDAL.CarregarTodos();
        }

        public IList<Cidade> ListarCidades(Estado estado)
        {
            CidadeFH filtro = new CidadeFH();
            filtro.EstadoId = estado.EstadoId.ToString();
			string[] orderBy = { "nomeCidade" };
			string[] orderDirection = { "ASC" };
			return CidadeDAL.CarregarTodos(0, 0, orderBy, orderDirection, filtro);
        }
        #endregion
    }
}
