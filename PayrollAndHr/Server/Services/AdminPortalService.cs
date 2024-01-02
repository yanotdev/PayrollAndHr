using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Data;

namespace PayrollAndHr.Server.Services
{
    public class AdminPortalService: IAdminPortalService
    {
        private readonly AppDbContext _appDbContext;

        public AdminPortalService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetEmpCount()
        {
            var EmpCount = _appDbContext.PersonalInfo.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
            return EmpCount;
        }
       
        public int GetUserCount()
        {
            var EmpCount = _appDbContext.Users.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
            return EmpCount;
        }

        public int GetStaffLeaveCount()
        {
            var EmpCount = _appDbContext.Leaves.AsEnumerable().Where(d => d.Status == true).ToList().Count();
            return EmpCount;
        }

        public int GetUnapproveCount()
        {
            int unLeaves = _appDbContext.Leaves.AsEnumerable().Where(d => d.IsDeclined == true).ToList().Count();
            int unLoan = _appDbContext.Messages.AsEnumerable().Where(d => d.IsLoan == true).ToList().Count();
            int unapprove = unLeaves + unLoan;
            return unapprove;
        }
    }
}
