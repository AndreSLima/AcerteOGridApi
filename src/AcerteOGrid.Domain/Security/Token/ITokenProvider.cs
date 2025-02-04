namespace AcerteOGrid.Domain.Security.Token
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
