using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.BLL.Infrastructure;
using Auction.BLL.Intefraces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace Auction.BLL.Services
{
    public class UserService:IUserService
    {
        IIdentityUnitOfWork DbIdentity { get; set; }
        IAuctionUnitOfWork DbAuction { get; set; }


        public UserService(IIdentityUnitOfWork Iuow, IAuctionUnitOfWork Auow)
        {
            DbIdentity = Iuow;
            DbAuction = Auow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            try
            {
                User user = await DbIdentity.UserManager.FindByEmailAsync(userDto.Email);
                if (user == null)
                {
                    user = new User {Email = userDto.Email, UserName = userDto.Email};
                    var result = await DbIdentity.UserManager.CreateAsync(user, userDto.Password);
                    if (result.Errors.Any())
                        return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                    // добавляем роль
                    await DbIdentity.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                    // создаем профиль клиента
                    UserProfile clientProfile = new UserProfile {Id = user.Id};
                    DbAuction.UserProfile.Create(clientProfile);
                    await DbIdentity.SaveAsync();
                    return new OperationDetails(true, "Регистрация успешно пройдена", "");
                }
                else
                {
                    return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await DbIdentity.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await DbIdentity.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                Role role = await DbIdentity.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await DbIdentity.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            DbIdentity.Dispose();
        }
    }
}

