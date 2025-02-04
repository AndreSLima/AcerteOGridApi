﻿using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Security.Token;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AcerteOGrid.Infrastructure.Services.LoggedUser
{
    internal class LoggedUser : ILoggedUser
    {
        private readonly AcerteOGridDbContex _dbcontext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(AcerteOGridDbContex dbcontext, ITokenProvider tokenProvider)
        {
            _dbcontext = dbcontext;
            _tokenProvider = tokenProvider;
        }

        public async Task<UserEntity> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _dbcontext.AOG_TB_USUARIO.AsNoTracking().FirstAsync(user => user.Identifier == Guid.Parse(identifier));
        }
    }
}
