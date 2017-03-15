using Common.Models.Base;
using Common.Models.Instrumentos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Instrumentos
{
    public class InstrumentoDbController : BaseController<InstrumentoModel>
    {
        private Models.Instrumentos _instrumentos = null;
        private string _path = null;

        /// <summary>
        /// Carrega o xml de instrumentos
        /// </summary>
        /// <param name="path"></param>
        public InstrumentoDbController(string path)
        {
            _path = path;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Instrumentos));
            var stringReader = new StringReader(File.ReadAllText(_path + @"\Xml\Instrumentos.xml"));
            _instrumentos = (Models.Instrumentos)xmlSerializer.Deserialize(stringReader);
        }     

        /// <summary>
        /// Salva as alterações no atributo _instrumentos no arquivo xml.
        /// </summary>
        private void SaveFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Models.Instrumentos));
            using (var file = new StreamWriter(_path + @"\Xml\Instrumentos.xml"))
            {
                xmlSerializer.Serialize(file, _instrumentos);
            }
        }

        public override string Alter(InstrumentoModel obj)
        {
            var itemEncotnrado = _instrumentos.Lista.FirstOrDefault(item => item.Id == obj.Id);

            itemEncotnrado.Nome = obj.Nome;
            itemEncotnrado.Som = obj.Som;
            itemEncotnrado.Tipo = obj.Tipo;
            itemEncotnrado.Imagem = obj.Imagem;
            itemEncotnrado.Descricao = obj.Descricao;

            SaveFile();

            return "OK";
        }

        public override string Create(InstrumentoModel obj)
        {
            var newId = _instrumentos.Lista.Max(item => item.Id) + 1;
            var lst = _instrumentos.Lista.ToList();

            lst.Add(new Models.InstrumentosInstrumento {
                Id = (byte)newId,
                Nome = obj.Nome,
                Tipo = obj.Tipo,
                Descricao = obj.Descricao,
                Imagem = obj.Imagem,
                Som = obj.Som
            });

            _instrumentos.Lista = lst.ToArray();

            return "OK";
        }

        public override string Delete(long Id)
        {
            var itemEncontrado = _instrumentos.Lista.FirstOrDefault(item => item.Id == Id);
            var lst = _instrumentos.Lista.ToList();
            lst.Remove(itemEncontrado);

            _instrumentos.Lista = lst.ToArray();

            SaveFile();

            return "OK";
        }

        public override InstrumentoModel Get(long Id)
        {
            var ret = new InstrumentoModel();
            var itemEncontrado = _instrumentos.Lista.FirstOrDefault(item => item.Id == Id);

            ret.Id = itemEncontrado.Id;
            ret.Nome = itemEncontrado.Nome;
            ret.Tipo = itemEncontrado.Tipo;
            ret.Descricao = itemEncontrado.Descricao;
            ret.Imagem = @"Imagem/" + itemEncontrado.Imagem;
            ret.Som = @"Som/" + itemEncontrado.Som;

            return ret;
        }

        public override List<InstrumentoModel> GetAll()
        {
            var ret = new List<InstrumentoModel>();
            foreach (var item in _instrumentos.Lista)
            {
                ret.Add(new InstrumentoModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Tipo = item.Tipo,
                    Descricao = item.Descricao,
                    Imagem = item.Imagem,
                    Som = item.Som
                });
            }

            return ret;
        }

        public bool Exists(long Id)
        {
            return _instrumentos.Lista.Count(e => e.Id == Id) > 0;
        }

        #region IDisposable support
        private bool disposableValue = false;
        protected override void Dispose(bool v)
        {
            if (!disposableValue)
            {
                if (v)
                {

                }
                disposableValue = true;
            }
        }

        ~InstrumentoDbController()
        {
            Dispose(false);
        }
        #endregion
    }
}
