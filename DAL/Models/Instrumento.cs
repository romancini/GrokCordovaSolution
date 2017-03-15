using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Instrumentos
    {

        private InstrumentosInstrumento[] _Lista;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Instrumento")]
        public InstrumentosInstrumento[] Lista
        {
            get
            {
                return this._Lista;
            }
            set
            {
                this._Lista = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InstrumentosInstrumento
    {

        private byte idField;

        private string nomeField;

        private string tipoField;

        private string descricaoField;

        private string imagemField;

        private string somField;

        /// <remarks/>
        public byte Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Nome
        {
            get
            {
                return this.nomeField;
            }
            set
            {
                this.nomeField = value;
            }
        }

        /// <remarks/>
        public string Tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }

        /// <remarks/>
        public string Descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }

        /// <remarks/>
        public string Imagem
        {
            get
            {
                return this.imagemField;
            }
            set
            {
                this.imagemField = value;
            }
        }

        /// <remarks/>
        public string Som
        {
            get
            {
                return this.somField;
            }
            set
            {
                this.somField = value;
            }
        }
    }

}
