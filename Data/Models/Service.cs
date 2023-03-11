﻿namespace DotAgroAPI.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
    }
}
