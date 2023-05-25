﻿using ASP.Net.Areas.Admin.Models;

namespace OnlineShopWebApplication
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private readonly List<RoleViewModel> roles = new List<RoleViewModel>();
        public void Add(RoleViewModel role)
        {
            roles.Add(role);
        }

        public List<RoleViewModel> GetAll()
        {
            return roles;
        }

        public RoleViewModel TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}