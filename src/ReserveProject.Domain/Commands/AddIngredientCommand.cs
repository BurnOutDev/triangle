namespace ReserveProject.Domain.Commands
{
    public class AddIngredientCommand
    {
        public string Name { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAllergen { get; set; }
    }
}
