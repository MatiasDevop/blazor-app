

namespace ViewModels.Dtos;

public class FullUserProfileDto : PartialUserProfileDto
{
    public List<Guid> SchoolClaims { get; set; }
    public List<Guid> CompanyClaims { get; set; }
    public List<UserFavoriteDto> Favorites { get; set; }
    public List<OrgUserConnectionDto> OrgConnections { get; set; }
    public List<UserConnectionDto> Connections { get; set; }
    public List<Guid> Blocks { get; set; }
}