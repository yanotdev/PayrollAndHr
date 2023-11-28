using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAndHr.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAllowance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllowance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblAttachment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttachment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblBranch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBranch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCompanyInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanyInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblDegree",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDegree", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptCode = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblDesignation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDesignation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpContactInfo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpContactInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpEmployment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpEmployment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpExperience",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DLeft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpExperience", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordID = table.Column<long>(type: "bigint", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptCode = table.Column<int>(type: "int", nullable: false),
                    SupervisorCode = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmploymentType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmploymentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpQualification",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationQua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpQualification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblGurrantor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    GFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPayLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGurrantor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLeave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeclined = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeave", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLevel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinPay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMedical",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    BGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genotype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smoke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedical", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMessage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isread = table.Column<bool>(type: "bit", nullable: false),
                    From_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsLoan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMessage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblNextofKin",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNextofKin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblOtherAllowances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOtherAllowances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPAYE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Housing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Utility = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Transport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lunch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanDeduct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PenaltyDeduct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pension = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NationalHFC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsolidatedR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TNonTDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetTIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalPayE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPAYE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPayroll",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossPayWithoutAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pension = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayeeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PensionAvcDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayroll", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPayrollHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossPayWithoutAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pension = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayeeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PensionAvcDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayrollHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPenalty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPenalty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPension",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePer = table.Column<int>(type: "int", nullable: false),
                    EmployerPer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPension", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPersonalInformation",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleCode = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisabilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPersonalInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPrefix",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrefix", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblReference",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationID = table.Column<long>(type: "bigint", nullable: false),
                    RFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RJobPosition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblSalary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicPer = table.Column<int>(type: "int", nullable: false),
                    HousingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HousingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HousingPer = table.Column<int>(type: "int", nullable: false),
                    TransportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportPer = table.Column<int>(type: "int", nullable: false),
                    UtilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilityPer = table.Column<int>(type: "int", nullable: false),
                    LunchDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchPer = table.Column<int>(type: "int", nullable: false),
                    OtherDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherPer = table.Column<int>(type: "int", nullable: false),
                    BasicAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UtilityAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LunchAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblStaffAVC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AVC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStaffAVC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblStaffDeductions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PenaltyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeductionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStaffDeductions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblStaffLoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interest = table.Column<int>(type: "int", nullable: false),
                    TotalLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    Repayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStaffLoan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblStaffOtherAllowance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowanceCode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AllowanceType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStaffOtherAllowance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblStartDocumentNo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStartDocumentNo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblState",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblTitle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTitle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAllowance");

            migrationBuilder.DropTable(
                name: "tblAttachment");

            migrationBuilder.DropTable(
                name: "tblBranch");

            migrationBuilder.DropTable(
                name: "tblCompanyInfo");

            migrationBuilder.DropTable(
                name: "tblCountry");

            migrationBuilder.DropTable(
                name: "tblDegree");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblDesignation");

            migrationBuilder.DropTable(
                name: "tblEmpContactInfo");

            migrationBuilder.DropTable(
                name: "tblEmpEmployment");

            migrationBuilder.DropTable(
                name: "tblEmpExperience");

            migrationBuilder.DropTable(
                name: "tblEmployeeInfo");

            migrationBuilder.DropTable(
                name: "tblEmploymentType");

            migrationBuilder.DropTable(
                name: "tblEmpQualification");

            migrationBuilder.DropTable(
                name: "tblGurrantor");

            migrationBuilder.DropTable(
                name: "tblLeave");

            migrationBuilder.DropTable(
                name: "tblLevel");

            migrationBuilder.DropTable(
                name: "tblLoan");

            migrationBuilder.DropTable(
                name: "tblMedical");

            migrationBuilder.DropTable(
                name: "tblMessage");

            migrationBuilder.DropTable(
                name: "tblNextofKin");

            migrationBuilder.DropTable(
                name: "tblOtherAllowances");

            migrationBuilder.DropTable(
                name: "tblPAYE");

            migrationBuilder.DropTable(
                name: "tblPayroll");

            migrationBuilder.DropTable(
                name: "tblPayrollHistory");

            migrationBuilder.DropTable(
                name: "tblPenalty");

            migrationBuilder.DropTable(
                name: "tblPension");

            migrationBuilder.DropTable(
                name: "tblPersonalInformation");

            migrationBuilder.DropTable(
                name: "tblPrefix");

            migrationBuilder.DropTable(
                name: "tblReference");

            migrationBuilder.DropTable(
                name: "tblSalary");

            migrationBuilder.DropTable(
                name: "tblStaffAVC");

            migrationBuilder.DropTable(
                name: "tblStaffDeductions");

            migrationBuilder.DropTable(
                name: "tblStaffLoan");

            migrationBuilder.DropTable(
                name: "tblStaffOtherAllowance");

            migrationBuilder.DropTable(
                name: "tblStartDocumentNo");

            migrationBuilder.DropTable(
                name: "tblState");

            migrationBuilder.DropTable(
                name: "tblTitle");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
