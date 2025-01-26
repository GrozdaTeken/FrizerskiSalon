using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Domain.Entities;

namespace Application.Authentication
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public UserReturnable Data { get; set; }
    }
}