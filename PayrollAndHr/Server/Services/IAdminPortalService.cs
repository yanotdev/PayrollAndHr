namespace PayrollAndHr.Server.Services
{
    public interface IAdminPortalService
    {
        int GetEmpCount();
        int GetUserCount();
        int GetStaffLeaveCount();
        int GetUnapproveCount();
    }
}
