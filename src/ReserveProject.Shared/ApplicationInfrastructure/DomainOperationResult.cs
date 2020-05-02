using Newtonsoft.Json;

namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public class DomainOperationResult
    {
        public DomainOperationResult()
        {
        }

        [JsonConstructor]
        public DomainOperationResult(dynamic metaData)
        {
            Metadata = metaData;
        }

        public dynamic Metadata { get; }

        public static DomainOperationResult Create(dynamic secondaryId)
        {
            return new DomainOperationResult(secondaryId);
        }

        public static DomainOperationResult CreateEmpty()
        {
            return new DomainOperationResult();
        }

        public static DomainOperationResult Update(dynamic secondaryId)
        {
            return new DomainOperationResult(secondaryId);
        }

        public static DomainOperationResult UpdateEmpty()
        {
            return new DomainOperationResult();
        }
    }
}