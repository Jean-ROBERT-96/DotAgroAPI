﻿namespace DotAgroAPI.Data.Models
{
    public class Headquarter
    {
        public int Id { get; set; }
        public string City { get; set; }
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
    }
}
