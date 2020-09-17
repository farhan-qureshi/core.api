using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace core.api.commerce.Models
{
    public enum ApiErrorCode
    {

        [Description("Error due to unknown reason")]
        [Display(Name = "UNKNOWN_REASON")]
        UnknownReason = 1000,

        [Description("Fail to persist data")]
        [Display(Name = "UNABLE_TO_PERSIST")]
        UnableToPersist = 1001,

        [Description("Fail to retrieve data")]
        [Display(Name = "FAIL_TO_GET_DATA")]
        FailToGetData = 1002,

        [Description("Invalid parameter in request")]
        [Display(Name = "INVALID_REQUEST_PARAMETERS")]
        InvalidRequestParameters = 1003,

        [Description("Data not found")]
        [Display(Name = "DATA_NOT_FOUND")]
        DataNotFound = 1004,

        [Description("Reach to maximum limit")]
        [Display(Name = "REACH_TO_MAX_LIMIT")]
        ReachToMaxLimit = 1005,

        [Description("Record already exist")]
        [Display(Name = "RECORD_ALREADY_EXIST")]
        RecordAlreadyExist = 1006,

        [Description("Out of range")]
        [Display(Name = "OUT OF RANGE")]
        OutOfRange = 1007,

        [Description("Cannot insert identity field")]
        [Display(Name = "CANNOT_INSERT_IDENTITY_FIELD")]
        CannotInsertIdentity = 1008
    }
}
