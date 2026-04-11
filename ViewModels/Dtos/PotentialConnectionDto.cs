using System;
using Enums;

namespace ViewModels.Dtos
{
    public class PotentialConnectionDto : UserConnectionDto
    {
        public int Score { get; set; }
    }
}