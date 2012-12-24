using ServiceStack.ServiceInterface.ServiceModel;

namespace BlogBuiltBy.ServiceStack.Web.Dtos
{
    public abstract class ResponseBase
    {
        public ResponseStatus ResponseStatus { get; set; }
        public bool IsSuccessful { get; set; }
        public int RowsAffected { get; set; }
        public string Message { get; set; }
    }
}