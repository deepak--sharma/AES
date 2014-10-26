using System;
using System.Collections.Generic;
using System.Text;

namespace AES.BusinessFramework
{

    public enum DateFormat
    {
        MMDDYYYY,
        DDMMYYYY

    }
    public enum RecordStatus
    {
        Active = 1,
        InActive = 0
    }
    public enum BindListItem
    {
        ByValue = 0,
        ByText = 1
    }
    public enum MetadataTypeEnum
    {
        None = 0,
        Nationality = 1,
        Gender = 2,
        CasteCategory = 3,
        Relation = 4,
        Operator = 5,
        Stream = 6,
        Section = 7,
        RoomType = 8,
        RegistrationRequestStatus = 9,
        AdmissionStatus = 10,
        ReservationType = 11,
        ReservationCotaType = 12,
        EligiblityFactor = 13,
        DeductionType = 14,
        CourseMedium = 15,
        Religion = 16,
        MaritalStatus = 17,
        BoardingType = 18,
        EmployeeType = 21,
        AccountType = 22,
        PaymentMode = 23,
        Currency = 24,
        Language = 27,
        MemberType = 28,
        LicenceType = 29,
        ImmigrationStatus = 30,
        AttendanceStatus = 31,
        FeeFrequency = 32,
        FeeGroup = 33,
        FeeApplicableTo = 34,
        FeeProcessMode = 35,
        LateFeeFrequency = 36,
        RegistrationStatus = 38
    }

    public enum ReservationCriteria
    {
        //These are MetadataType
        Gender = 2,
        CasteCategory = 3,
        OtherCriteria = 12
    }

    public enum Nationality
    {
        Indian = 1,
        American = 2,
        English = 3,
        Pakistani = 4,
        Chieneese = 5
    }
    public enum Gender
    {
        Male = 6,
        Female = 7,
        None = 8
    }
    public enum CasteCategory
    {
        General = 9,
        OBC = 10,
        SC = 11,
        ST = 12
    }
    public enum Relation
    {
        Mother = 13,
        Father = 14,
        Guardian = 15
    }
    public enum Operator
    {
        In = 16,
        NotIn = 17,
        GreaterThan = 18,
        LessThan = 19,
        Between = 20,
        GreaterThanEqualTo = 21,
        LessThanEqualTo = 22
    }
    public enum Stream
    {
        Arts = 23,
        Commerce = 24,
        Science = 25
    }
    public enum Section
    {
        A = 26,
        B = 27
    }
    public enum RoomType
    {
        ClassRoom = 28,
        TeachersRoom = 29,
        PrincipleRoom = 30,
        Auditorium = 31
    }
    public enum RegistrationRequestStatus
    {
        New = 32,
        Verified = 33,
        Accepted = 34,
        Rejected = 35,
        Hold = 72
    }
    public enum ReservationType
    {
        ManagementSeat = 36,
        FreeSeat = 37
    }
    public enum ReservationCotaType
    {
        Management = 39,
        Staff = 40,
        Free = 41
    }
    public enum EligibilityFactor
    {
        Age = 42,
        Nationality = 43
    }
    public enum CourseMedium
    {
        English = 44,
        Hindi = 45,
        Urdu = 46
    }
    public enum AdmissionStatus
    {
        New = 47,
        Accepted = 48,
        Rejected = 49
    }
    public enum Religion
    {
        Hindu = 50,
        Muslim = 51

    }
    public enum MaritalStatus
    {

        Married = 52,
        UnMarried = 53,
        Widowed = 54,
        Divorced = 55
    }
    public enum BoardingType
    {
        Day = 56,
        Scholar = 57,

    }
    public enum DeductionType
    {

    }
    public enum EmployeeType
    {
        Permanent = 58,
        Contract = 59
    }
    public enum AccountType
    {
        Saving = 60,
        Current = 61
    }
    public enum PaymentMode
    {
        Cash = 62,
        Cheque = 63
    }
    public enum Currency
    {
        INR = 64,
        USD = 65
    }
    public enum Language
    {
        Hindi = 66,
        English = 67,
        Urdu = 68
    }
    public enum MemberType
    {
        Student = 69,
        Employee = 70,
        Guardian = 71
    }
    public enum LicenceType
    {
        DLL = 73,
        DLP = 74
    }
    public enum ImmigrationStatus
    {
        Valid = 75,
        Expired = 76
    }
    public enum AttendanceStatus
    {
        Present = 77,
        Absent = 78,
        Leave = 78
    }
    public enum FeeFrequency
    {
        OneTime = 80,
        Yearly = 81,
        HalfYearly = 82,
        Quaterly = 83,
        BiMonthly = 84,
        Monthly = 85
    }
    public enum FeeGroup
    {
        RegistrationFee = 86,
        AdmissionFee = 87,
        RegularFee = 88
    }
    public enum FeeApplicableTo
    {
        OldStudents = 89,
        NewStudents = 90,
        AllStudents = 91
    }
    public enum FeeProcessMode
    {
        AdvancePayment = 92,
        PostPayment = 93
    }
    public enum LateFeeFrequency
    {
        Fixed = 94,
        PerDay = 95
    }
    public enum RegistrationStatus
    {
        Created = 99,
        Open = 100,
        Closed = 101,
        ResultPublished = 102,
        Cancelled = 103
    }
}
