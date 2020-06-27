﻿namespace ReserveProject.Domain.Commands
{
    public class EditMenuItemCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int[] IngredientIds { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}