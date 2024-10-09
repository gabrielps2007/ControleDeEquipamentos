using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEquipamentos
{
    internal class Pessoas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string ID { get; set; }
        public string MATRICUALA { get; set; }
        public string NOME { get; set; }
        public string COLETOR { get; set; }
        public string MOVIMENTACAO { get; set; }
        public string STATUS { get; set; }
        public DateTime DATAHORA { get; set; }
    }
}
