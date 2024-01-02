﻿using PayrollAndHr.Shared.Models;
using PayrollAndHr.Shared.ViewModel;

namespace PayrollAndHr.Server.Services
{
    public interface IEmployeeService
    {
        List<StateEntity> GetStates(string CountryName);
        Task SavePersonalInformation(PersonalInformationEntity personal);

        List<EmployList> EmployeeListTa();
    }
}
