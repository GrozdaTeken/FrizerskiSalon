﻿namespace Domain.Entities
{
    public class Blacklist
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Razlog { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
