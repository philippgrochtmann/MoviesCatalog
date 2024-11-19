namespace MoviesCatalogApi.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityType, object searchParam) : base($"Entidade não encontrada: {entityType} com id {searchParam}")
        {
            EntityType = entityType;
            Id = searchParam;
        }

        public string EntityType { get; }
        public object Id { get; }
    }
}
