using System;
using Enums;

namespace ViewModels.Dtos
{
    public class UserConnectionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserConnectionType Type { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateRequested { get; set; }
        public string ApproverMessage { get; set; }
    }
}