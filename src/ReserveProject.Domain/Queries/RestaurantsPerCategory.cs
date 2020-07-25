namespace ReserveProject.Domain.Queries
{
    public class RestaurantsPerCategoryQuery
    {
        public string CategoryName { get; set; }
    }
    
    public class RestaurantsPerCategoryQueryResult : RestaurantsQueryResult
    {
        public string CategoryName { get; set; }
    }
}
