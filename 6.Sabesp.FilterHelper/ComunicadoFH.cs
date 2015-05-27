
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
'  Script criado por: Leonardo Alves Lindermann (lindermannla@ag2.com.br)
'  Gerado pelo MyGeneration versão # (???)
'
'===============================================================================
*/
using System;
using System.Text;

namespace Sabesp.FilterHelper
{
    public class ComunicadoFH : IFilterHelper
    {
        private string _comunicadoId;
        public string ComunicadoId
        {
            get { return _comunicadoId == null ? String.Empty : _comunicadoId; }
            set { _comunicadoId = value; }
        }

        private string _ativo;
        public string Ativo
        {
            get { return _ativo == null ? String.Empty : _ativo; }
            set { _ativo = value; }
        }

        private string _destaqueHome;
        public string DestaqueHome
        {
            get { return _destaqueHome == null ? String.Empty : _destaqueHome; }
            set { _destaqueHome = value; }
        }

        private string _destaqueFiquePorDentro;
        public string DestaqueFiquePorDentro
        {
            get { return _destaqueFiquePorDentro == null ? String.Empty : _destaqueFiquePorDentro; }
            set { _destaqueFiquePorDentro = value; }
        }

        private string _dataHoraPublicacaoPeriodoInicial;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataHoraPublicacaoPeriodoInicial
        {
            get { return _dataHoraPublicacaoPeriodoInicial == null ? String.Empty : _dataHoraPublicacaoPeriodoInicial; }
            set { _dataHoraPublicacaoPeriodoInicial = value; }
        }
        private string _dataHoraPublicacaoPeriodoFinal;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataHoraPublicacaoPeriodoFinal
        {
            get { return _dataHoraPublicacaoPeriodoFinal == null ? String.Empty : _dataHoraPublicacaoPeriodoFinal; }
            set { _dataHoraPublicacaoPeriodoFinal = value; }
        }

        private string _dataExibicaoInicioPeriodoInicial;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataExibicaoInicioPeriodoInicial
        {
            get { return _dataExibicaoInicioPeriodoInicial == null ? String.Empty : _dataExibicaoInicioPeriodoInicial; }
            set { _dataExibicaoInicioPeriodoInicial = value; }
        }
        private string _dataExibicaoInicioPeriodoFinal;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataExibicaoInicioPeriodoFinal
        {
            get { return _dataExibicaoInicioPeriodoFinal == null ? String.Empty : _dataExibicaoInicioPeriodoFinal; }
            set { _dataExibicaoInicioPeriodoFinal = value; }
        }

        private string _dataExibicaoFimPeriodoInicial;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataExibicaoFimPeriodoInicial
        {
            get { return _dataExibicaoFimPeriodoInicial == null ? String.Empty : _dataExibicaoFimPeriodoInicial; }
            set { _dataExibicaoFimPeriodoInicial = value; }
        }
        private string _dataExibicaoFimPeriodoFinal;
        /// <summary>
        /// Formato da string contendo data: YYYY/MM/DD.
        /// </summary>
        public string DataExibicaoFimPeriodoFinal
        {
            get { return _dataExibicaoFimPeriodoFinal == null ? String.Empty : _dataExibicaoFimPeriodoFinal; }
            set { _dataExibicaoFimPeriodoFinal = value; }
        }


        public string GetWhereString()
        {
            StringBuilder sbWhere = new StringBuilder();

            if (!ComunicadoId.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (comunicadoId=", ComunicadoId, ")"));
            }

            if (!Ativo.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (ativo=", Ativo, ")"));
            }

            if (!DestaqueHome.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (destaqueHome=", DestaqueHome, ")"));
            }

            if (!DestaqueFiquePorDentro.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (destaqueFiquePorDentro=", DestaqueFiquePorDentro, ")"));
            }

            if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty) && !DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataHoraPublicacao >='", DataHoraPublicacaoPeriodoInicial, "'"));
                sbWhere.Append(String.Concat(" AND dataHoraPublicacao <='", DataHoraPublicacaoPeriodoFinal, "')"));
            }
            else if (!DataHoraPublicacaoPeriodoInicial.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataHoraPublicacao >='", DataHoraPublicacaoPeriodoInicial, "')"));
            }
            else if (!DataHoraPublicacaoPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataHoraPublicacao <='", DataHoraPublicacaoPeriodoFinal, "')"));
            }

            if (!DataExibicaoInicioPeriodoInicial.Equals(String.Empty) && !DataExibicaoInicioPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoInicio >='", DataExibicaoInicioPeriodoInicial, "'"));
                sbWhere.Append(String.Concat(" AND dataExibicaoInicio <='", DataExibicaoInicioPeriodoFinal, "')"));
            }
            else if (!DataExibicaoInicioPeriodoInicial.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoInicio >='", DataExibicaoInicioPeriodoInicial, "')"));
            }
            else if (!DataExibicaoInicioPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoInicio <='", DataExibicaoInicioPeriodoFinal, "')"));
            }

            if (!DataExibicaoFimPeriodoInicial.Equals(String.Empty) && !DataExibicaoFimPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoFim >='", DataExibicaoFimPeriodoInicial, "'"));
                sbWhere.Append(String.Concat(" AND dataExibicaoFim <='", DataExibicaoFimPeriodoFinal, "')"));
            }
            else if (!DataExibicaoFimPeriodoInicial.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoFim >='", DataExibicaoFimPeriodoInicial, "')"));
            }
            else if (!DataExibicaoFimPeriodoFinal.Equals(String.Empty))
            {
                sbWhere.Append(String.Concat(" AND (dataExibicaoFim <='", DataExibicaoFimPeriodoFinal, "')"));
            }


            if (sbWhere.Length > 0) // Remove o primeiro "AND "
                sbWhere.Remove(0, 4);
            return sbWhere.ToString();
        }
    }
}
