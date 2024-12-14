using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Application.Repositories
{
    public interface IMasterLookUpRepository
    {
        Task<List<MasterLookUp>> GetLocationsAsync();
        Task<List<MasterLookUp>> GetRegionsAsync();
        Task<List<MasterLookUp>> GetStatesAsync();


    }
}
