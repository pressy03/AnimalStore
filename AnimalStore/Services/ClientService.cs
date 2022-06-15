using AnimalStore.DataOperators;
using AnimalStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalStore.Services
{
    public class ClientService
    {
        private Repository repo;

        public ClientService()
        {
            repo = new Repository();
        }

        public Client GetClientByNames(string firstName, string lastName)
        {
            var client = repo.All<Client>()
                .Include(c => c.Address)
                .ThenInclude(c => c.Town)
                .Include(c => c.ClientCard)
                .Where(c => c.FirstName == firstName && c.LastName == lastName)
                .FirstOrDefault();

            if(client == null)
            {
                return null;
            }
            else
            {
                return client;
            }
        }
    }
}
