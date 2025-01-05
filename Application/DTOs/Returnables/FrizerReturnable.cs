﻿namespace Application.DTOs.Returnable
{
    public class FrizerReturnable
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }

        public FrizerReturnable(Guid id, string ime, string prezime, string telefon)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
        }

        public FrizerReturnable() { }
    }
}
