using System;
using Enums;

namespace ViewModels.Dtos
{
    public class UserFavoriteDto
    {
        public Guid Id { get; set; }
        public FavoriteType Type { get; set; }
        public Guid TargetId { get; set; }
    }
}