using backend.Domains.Models;

namespace backend.Domains.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        
        public User User {get;private set;}

        private UserResponse(bool success,string message, User _user) : base(success,message){
            User = _user;
        }

        public UserResponse(User user) : this(true,string.Empty,user){}

        public UserResponse(string message) : this(false,message,null){}



    }
}