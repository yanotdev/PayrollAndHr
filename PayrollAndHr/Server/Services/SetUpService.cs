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
    }
}
