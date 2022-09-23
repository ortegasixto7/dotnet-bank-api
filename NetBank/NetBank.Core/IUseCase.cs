using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core
{
    public interface IUseCaseCommand<T>
    {
        Task Execute(T request);
    }

    public interface IUseCaseQuery<T>
    {
        Task<dynamic> Execute(T request);
    }
}
