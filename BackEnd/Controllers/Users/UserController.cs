﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BackEnd.DataBase;
using BackEnd.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.People;
using Models.PublicAPI.Responses.People;
using Extensions;
using BackEnd.Services.Interfaces;
using Models.People.Roles;
using Models.PublicAPI.Requests.User;
using System.Collections.Generic;

namespace BackEnd.Controllers.Users
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : AuthorizeController
    {
        private readonly DataBaseContext dbContext;
        private readonly IUserRegisterTokens registerTokens;
        private readonly IEmailSender emailSender;

        public UserController(UserManager<User> userManager,
                              DataBaseContext dbContext,
                              IUserRegisterTokens registerTokens,
                              IEmailSender emailSender) : base(userManager)
        {
            this.dbContext = dbContext;
            this.registerTokens = registerTokens;
            this.emailSender = emailSender;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserView>>> GetAsync(
            string email,
            string firstname,
            string lastname,
            string middleName,
            string match,
            int count = 5,
            int offset = 0)
            => await GetUsersByParams(email, firstname, lastname, middleName, match)
                .If(count > 0, users => users.Skip(offset * count).Take(count))
                .ProjectTo<UserView>()
                .ToListAsync();

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCountAsync(
            string email,
            string firstname,
            string lastname,
            string middleName,
            string match)
            => await GetUsersByParams(email, firstname, lastname, middleName, match)
                .CountAsync();

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserView>> GetAsync(Guid id)
        {
            var userView = await UserManager
                       .Users
                       .ProjectTo<UserView>()
                       .SingleOrDefaultAsync(u => u.Id == id);
            if (userView == null)
                return NotFound();
            return userView;
        }

        [RequireRole(RoleNames.CanInviteToSystem)]
        [HttpPost]
        public async Task<ActionResult> InviteUser([FromBody]InviteUserRequest inviteRequest)
        {
            if (await dbContext.Users.AnyAsync(u => u.NormalizedEmail == inviteRequest.Email.ToUpper()))
                return Conflict();
            var token = await registerTokens.AddRegisterToken(inviteRequest.Email);
            await emailSender.SendInvitationEmail(inviteRequest.Email, inviteRequest.RedirectUrl, token);
            return Ok();
        }


        private IQueryable<User> GetUsersByParams(string email,
            string firstname,
            string lastname,
            string middleName,
            string match)
            => UserManager
                .Users
                .ResetToDefault(m => true, ref match, match?.ToUpper())
                .IfNotNull(email, users => users.Where(u => u.Email.ToUpper().Contains(email.ToUpper())))
                .IfNotNull(firstname, users => users.Where(u => u.FirstName.ToUpper().Contains(firstname.ToUpper())))
                .IfNotNull(lastname, users => users.Where(u => u.LastName.ToUpper().Contains(lastname.ToUpper())))
                .IfNotNull(middleName, users => users.Where(u => u.MiddleName.ToUpper().Contains(middleName.ToUpper())))
                .IfNotNull(match, users => users.ForAll(match.Split(' '), (us2, matcher) => us2.Where(u => u.LastName.ToUpper().Contains(matcher)
                                                           || u.FirstName.ToUpper().Contains(matcher)
                                                           || u.MiddleName.ToUpper().Contains(matcher)
                                                           || u.Email.ToUpper().Contains(matcher)
                                                           || u.PhoneNumber.ToUpper().Contains(matcher))));
    }
}