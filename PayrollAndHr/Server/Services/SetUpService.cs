using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly AppDbContext _appDbContext;

        public SetUpService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       

        public List<BranchEntity> LoadBranchInfo()
        {
            var model = _appDbContext.Branches.Where(d => d.IsDeleted == false).OrderBy(d => d.BranchName).ToList();
            return model;
        }

        public async Task<ServiceResponse<BranchEntity>> SaveBranchInfo(BranchEntity Bra)
        {
            var oldBra = _appDbContext.Branches.Where(d => d.BranchCode == Bra.BranchCode).FirstOrDefault();
            BranchEntity newBra = new BranchEntity();
            if (oldBra != null)
            {
                oldBra.Address = Bra.Address;
                //oldBra.BranchCode = bra.BranchCode;
                oldBra.BranchName = Bra.BranchName;
                oldBra.Email = Bra.Email;
                oldBra.PhoneNo = Bra.PhoneNo;

            }
            else
            {
                
                newBra.Address = Bra.Address;
                newBra.BranchCode = Bra.BranchCode;
                newBra.BranchName = Bra.BranchName;
                newBra.Email = Bra.Email;
                newBra.PhoneNo = Bra.PhoneNo;
                _appDbContext.Branches.Add(newBra);
            }
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse<BranchEntity>()
            {
                Data = newBra,
                Message = "Save Successful",
                Success = true,
            };
        }
    }
}
