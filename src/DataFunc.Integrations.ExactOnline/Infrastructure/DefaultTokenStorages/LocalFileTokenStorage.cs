using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;
using Newtonsoft.Json;
using File = System.IO.File;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.DefaultTokenStorages
{
    public class LocalFileTokenStorage : ITokenStorage
    {
        private readonly string _fileName;

        public LocalFileTokenStorage(string fileName)
        {
            _fileName = fileName;
        }
        public async Task Save(TokenModel token,ExactOnlineContext context, CancellationToken cancellationToken)
        {
            await File.WriteAllTextAsync(_fileName, JsonConvert.SerializeObject(token), Encoding.UTF8, cancellationToken);
        }

        public async Task<TokenModel> Retrieve(ExactOnlineContext context, CancellationToken cancellationToken)
        {
            if (!File.Exists(_fileName)) 
                return null;

            var fileContents = await File.ReadAllTextAsync(_fileName, Encoding.UTF8, cancellationToken);
            return JsonConvert.DeserializeObject<TokenModel>(fileContents);
        }
    }
}