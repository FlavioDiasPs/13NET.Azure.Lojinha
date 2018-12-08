using _13NET.Azure.Lojinha.Core.Entities;
using _13NET.Azure.Lojinha.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13NET.Azure.Lojinha.Infrastructure.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly CloudStorageAccount _account;
        private readonly CloudTableClient _tableClient;
        public AzureStorage(IConfiguration config)
        {
            _account = CloudStorageAccount.Parse(config.GetSection("Azure:Storage").Value);
            _tableClient = _account.CreateCloudTableClient();
        }

        public void AddProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(produto);
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new ProdutoEntity("13net", produto.Id.ToString());
            entity.Produto = json;

            var operation = TableOperation.Insert(entity);
            table.ExecuteAsync(operation).Wait();
        }
        public async Task<List<Produto>> GetProdutos()
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var query = new TableQuery<ProdutoEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "13net"));

            TableContinuationToken token = null;

            var produtosEntity = await table.ExecuteQuerySegmentedAsync(query, token);
            return produtosEntity
                .Where(x => x.Produto != null)
                .Select(x => JsonConvert.DeserializeObject<Produto>(x.Produto)).ToList();
        }
        public async Task<Produto> GetProduto(string id)
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var operation = TableOperation.Retrieve<ProdutoEntity>("13net", id);
            var retrievedResult = await table.ExecuteAsync(operation);

            if (retrievedResult.Result != null)
            {
                var produtoEntity = (ProdutoEntity)retrievedResult.Result;
                return JsonConvert.DeserializeObject<Produto>(produtoEntity.Produto);
            }

            return null;
        }
    }
}
