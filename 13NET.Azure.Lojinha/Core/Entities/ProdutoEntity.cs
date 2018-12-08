using Microsoft.WindowsAzure.Storage.Table;

namespace _13NET.Azure.Lojinha.Core.Entities
{
    public class ProdutoEntity : TableEntity
    {
        public ProdutoEntity()
        {

        }
        public ProdutoEntity(string partitionKey, string rowKey)
            : base(partitionKey, rowKey)
        {

        }
        public string Produto { get; set; }
    }
}
