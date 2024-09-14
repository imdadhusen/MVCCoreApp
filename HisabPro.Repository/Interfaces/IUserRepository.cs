﻿using HisabPro.DTO.Response;
using HisabPro.Entities.Models;
using System.Linq.Expressions;

namespace HisabPro.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<LoginRes?> GetUser(Expression<Func<User, bool>> where);
        Task<User?> Register(string name, string email, string password);
        Task<LoginRes?> Authenticate(string email, string password);
    }   
}
