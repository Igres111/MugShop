﻿using MugShop.Data.Entities;

namespace MugShop.DTOs.CategoriesDTOs
{
    public class GetAllCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
