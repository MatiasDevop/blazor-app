using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using ViewModels.Dtos;
using ViewModels.Queries;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SearchController(ApplicationDbContext context) => _context = context;

    /// <summary>
    /// Full-text search across user profiles, companies, and career centers.
    /// </summary>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SearchResultDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SearchResultDto>>> Search([FromQuery] SearchObjectsQuery query)
    {
        if (string.IsNullOrWhiteSpace(query.SearchText))
            return Ok(Enumerable.Empty<SearchResultDto>());

        var text = query.SearchText.ToLower();
        var results = new List<SearchResultDto>();
        var types = query.Types ?? new List<SearchObjectType?>();

        var searchAll = !types.Any(t => t.HasValue);

        if (searchAll || types.Contains(SearchObjectType.Person))
        {
            var userMatches = await _context.UserProfiles
                .Where(u => u.FirstName.ToLower().Contains(text)
                            || u.LastName.ToLower().Contains(text)
                            || u.Email.ToLower().Contains(text))
                .OrderBy(u => u.FirstName)
                .Skip(query.Skip)
                .Take(20)
                .Select(u => new SearchResultDto { Id = u.Id, Type = SearchObjectType.Person })
                .ToListAsync();
            results.AddRange(userMatches);
        }

        if (searchAll || types.Contains(SearchObjectType.Company))
        {
            var companyMatches = await _context.CompanyProfiles
                .Where(c => c.Name.ToLower().Contains(text))
                .Take(20)
                .Select(c => new SearchResultDto { Id = c.Id, Type = SearchObjectType.Company })
                .ToListAsync();
            results.AddRange(companyMatches);
        }

        if (searchAll || types.Contains(SearchObjectType.CareerCenter))
        {
            var schoolMatches = await _context.Schools
                .Where(s => s.Name.ToLower().Contains(text)
                            || (s.DisplayName != null && s.DisplayName.ToLower().Contains(text)))
                .Take(20)
                .Select(s => new SearchResultDto { Id = s.Id, Type = SearchObjectType.CareerCenter })
                .ToListAsync();
            results.AddRange(schoolMatches);
        }

        return Ok(results);
    }
}
