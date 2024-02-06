using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<PersonalInformationEntity>> SaveEmployee(PersonalInformationEntity personalInformationEntity);
        Task<ServiceResponse<PrefixEntity>> SavePrefix(PrefixEntity prefixEntity);

        Task<RegistrationPara> GetRegistrationNo();
        Task<ServiceResponse<EmpContactInfoEntity>> SaveContact(EmpContactInfoEntity empContactInfoEntity);
        Task<ServiceResponse<NextofKinEntity>> SaveNextOfKin(NextofKinEntity nextofKinEntity);
        Task<ServiceResponse<GurrantorEntity>> SaveGuarantor(GurrantorEntity gurrantorEntity);
        Task<ServiceResponse<ReferenceEntity>> SaveReference(ReferenceEntity referenceEntity);
        Task<ServiceResponse<MedicalEntity>> SaveMedicalHis(MedicalEntity medicalEntity);
        Task<ServiceResponse<EmpEmploymentEntity>> SaveEmp(EmpEmploymentEntity empEmploymentEntity);
        Task<ServiceResponse<EmpExperienceEntity>> SaveEmpExp(EmpExperienceEntity empEmploymentEntity);
        Task<ServiceResponse<EmpQualificationEntity>> SaveEmpQua(EmpQualificationEntity empQualificationEntity);
    }
}
