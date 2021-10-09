using System;
using System.Threading;
using System.Threading.Tasks;
using DataFunc.Integrations.ExactOnline.Infrastructure.Models;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces
{
    public interface ITokenStorage
    {
        Task Save(TokenModel token, ExactOnlineContext context, CancellationToken cancellationToken);
        Task<TokenModel> Retrieve(ExactOnlineContext context, CancellationToken cancellationToken);
    }
}