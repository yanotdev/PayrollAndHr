using PayrollAndHr.Shared.Models;
using PayrollAndHr.Shared.ViewModel;

namespace PayrollAndHr.Server.Services
{
    public interface IEmployeeService
    {
        List<StateEntity> GetStates(string CountryName);
        Task<ServiceResponse<PersonalInformationEntity>> SavePersonalInformation(PersonalInformationEntity personal);

        List<EmployList> EmployeeListTa();
       
        Task<ServiceResponse<PrefixEntity>> SavePrefix(PrefixEntity prefixEntity);
        string GetPrefixNo();

        Task<ServiceResponse<EmpContactInfoEntity>> SaveContact(EmpContactInfoEntity contact);

        Task<ServiceResponse<NextofKinEntity>> SaveNoKin(NextofKinEntity nextofKin);
        Task<ServiceResponse<GurrantorEntity>> SaveGuarantor(GurrantorEntity guarantor);
        Task<ServiceResponse<ReferenceEntity>> SaveReference(ReferenceEntity reference);
        Task<ServiceResponse<MedicalEntity>> SaveMedicalHis(MedicalEntity history);

    }
}
