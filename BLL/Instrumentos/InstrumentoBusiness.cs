using Common.Models.Instrumentos;
using DAL.Instrumentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Instrumentos
{
    public class InstrumentoBusiness : IDisposable
    {

        InstrumentoDbController db = null;

        public InstrumentoBusiness(string path)
        {
            db = new InstrumentoDbController(path);
        }

        public List<InstrumentoModel> GetInstrumentos()
        {
            return db.GetAll().OrderBy(row => row.Descricao).ToList();
        }
        public async Task<List<InstrumentoModel>> GetInstrumentosAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return GetInstrumentos();
            });
        }

        public InstrumentoModel GetInstrumento(long Id)
        {
            return db.Get(Id);
        }
        public async Task<InstrumentoModel> GetInstrumentosAsync(long Id)
        {
            return await Task.Factory.StartNew(() =>
            {
                return GetInstrumento(Id);
            });
        }

        public string PutInstrumento(InstrumentoModel Instrumento)
        {
            return db.Alter(Instrumento);
        }
        public async Task<string> PutInstrumentoAsync(InstrumentoModel Instrumento)
        {
            return await Task.Factory.StartNew(() =>
            {
                return PutInstrumento(Instrumento);
            });
        }

        public string PostInstrumento(InstrumentoModel Instrumento)
        {
            return db.Create(Instrumento);
        }
        public async Task<string> PostInstrumentoAsync(InstrumentoModel Instrumento)
        {
            return await Task.Factory.StartNew(() =>
            {
                return PostInstrumento(Instrumento);
            });
        }

        public string DeleteInstrumento(long id)
        {
            return db.Delete(id);
        }
        public async Task<string> DeleteInstrumentoAsync(long id)
        {
            return await Task.Factory.StartNew(() =>
            {
                return DeleteInstrumento(id);
            });
        }

        public bool InstrumentoExists(long id)
        {
            return db.Exists(id);
        }
        public async Task<bool> InstrumentoExistsAsync(long id)
        {
            return await Task.Factory.StartNew(() =>
            {
                return InstrumentoExists(id);
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InstrumentoBusiness() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
