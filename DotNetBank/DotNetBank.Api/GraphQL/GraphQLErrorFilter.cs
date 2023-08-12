namespace DotNetBank.Api.GraphQL
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.RemovePath().RemoveLocations().RemoveExtensions().WithMessage(error.Exception?.Message);
        }
    }
}
