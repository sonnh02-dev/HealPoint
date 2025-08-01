using AppointmentSchedulingApp.SharedKernel;
namespace CleanArchitectrure.Domain.Commons;

public  class BaseErrors
{
    public static Error Empty(string fieldName) =>
        Error.Validation($"{fieldName}.Empty", $"{fieldName} không được để trống!");

    public static Error InvalidFormat(string fieldName, object value, string? expectedFormat = null)
    {
        var message = $"Giá trị '{value}' không đúng định dạng cho {fieldName}.";

        if (!string.IsNullOrWhiteSpace(expectedFormat))
        {
            message += $" Định dạng yêu cầu: '{expectedFormat}'!";
        }

        return Error.Validation($"{fieldName}.InvalidFormat", message);
    }

    public static Error NotFoundById(string entityName, object id) =>
        Error.NotFound($"{entityName}.NotFoundById", $"Không tìm thấy {entityName} với định danh '{id}'!");

    public static Error Conflict(string fieldName) =>
        Error.Conflict($"{fieldName}.Conflict", $"Xung đột đã xảy ra với trường {fieldName}!");

    public static Error Unauthorized(string actor, string resource) =>
     Error.Unauthorized($"{resource}.Unauthorized", $"{actor} không có quyền truy cập tài nguyên '{resource}'!");


    public static Error Forbidden(string actor, string action, string resource) =>
    Error.Forbidden($"{resource}.Forbidden", $"{actor} không được phép {action} trên tài nguyên '{resource}'!");

}
