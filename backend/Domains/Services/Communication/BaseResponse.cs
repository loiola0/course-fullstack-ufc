namespace backend.Domains.Services.Communication
{
    public abstract class BaseResponse
    {

        public bool Success {get;protected set;}
        public string Message {get;protected set;}

        public BaseResponse(bool Success,string Message){
            this.Success = Success;
            this.Message = Message;
        }
        
    }
}