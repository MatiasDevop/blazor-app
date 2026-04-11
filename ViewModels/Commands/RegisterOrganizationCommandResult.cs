using System;
using ViewModels.Dtos;

namespace ViewModels.Commands
{
    public class RegisterOrganizationCommandResult
    {
        public Guid UserId { get; set; }
        public Guid InvoiceId { get; set; }
    }
}