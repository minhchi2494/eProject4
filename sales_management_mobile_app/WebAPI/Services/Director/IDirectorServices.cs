﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDirectorServices
    {
        Task<List<Director>> getDirectors(Director searchDirector);
        Task<Director> getDirector(string id);
        Task<Director> checkLogin(string username, string password);
        Task<bool> createDirector(Director newDirector);
        Task<bool> updateDirector(Director editDirector);
    }
}
