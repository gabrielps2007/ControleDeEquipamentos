using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEquipamentos
{
    internal class Conn
    {
        public static readonly string Server = "mongodb://localhost:27017";
        public static readonly string Db = "APP";
        public static readonly string ColletionClientes = "Clientes";



        public static IMongoCollection<Pessoas> AbrirColecaoPessoas()

        {
            var cli = new MongoClient(Server);
            var db = cli.GetDatabase(Db);
            return db.GetCollection<Pessoas>(ColletionClientes);

        }

    }
    


}
