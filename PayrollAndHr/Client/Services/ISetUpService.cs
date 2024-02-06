﻿using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface ISetUpService
    {
        Task<ServiceResponse<BranchEntity>?> SaveBranchInfo(BranchEntity branchEntity);
        Task<ServiceResponse<TitleEntity>?> SaveTitle(TitleEntity title);
    }
}