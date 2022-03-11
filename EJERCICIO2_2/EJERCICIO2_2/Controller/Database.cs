using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EJERCICIO2_2.Models;
using SQLite;

namespace EJERCICIO2_2.Controller
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;

        public Database (String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Lista>().Wait();
        }

        public Task<List<Lista>> GetListSignatures()
        {
            return db.Table<Lista>().ToListAsync();
        }

        public Task<Lista> GetSignatureByCode(int signatureCode)
        {
            return db.Table<Lista>()
                .Where(i => i.code == signatureCode)
                .FirstOrDefaultAsync();
        }

        public Task<int> saveSignature(Lista signatures)
        {
            return signatures.code != 0 ? db.UpdateAsync(signatures) : db.InsertAsync(signatures);
        }

        public Task<int> deleteSignature(Lista signatures)
        {
            return db.DeleteAsync(signatures);
        }
    }
}
