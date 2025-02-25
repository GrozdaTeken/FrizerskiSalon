﻿using Domain.Entities;

namespace Application.DTOs.Create
{
    public class FrizerCreate
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public ICollection<Rezervacija> Rezervacije { get; set; }

        public FrizerCreate(string ime, string prezime, string telefon, ICollection<Rezervacija> rezervacije)
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            Rezervacije = rezervacije;
        }

        public FrizerCreate()
        {
        }
    }
}
