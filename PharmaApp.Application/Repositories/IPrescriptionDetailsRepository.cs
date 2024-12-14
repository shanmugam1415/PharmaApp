using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Domain.Entities;

namespace PharmaApp.Application.Repositories
{
    public interface IPrescriptionDetailsRepository : IBaseRepository<PrescriptionDetails>
    {
        Task AddPrescriptionDetails(List<PrescriptionDetails> prescriptionDetails);
    }
    
}
