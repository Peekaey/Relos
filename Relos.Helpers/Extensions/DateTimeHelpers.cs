using Microsoft.Extensions.Logging;
using Relos.Models.Dtos;

namespace Relos.Helpers.Extensions;

public static class DateTimeHelpers
{
    private static readonly TimeZoneInfo AestTimeZone = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
    
    public static List<WorkspaceDto> ConvertToAest(this List<WorkspaceDto> workspaces)
    {
        workspaces.ForEach(w => w.CreatedOn = TimeZoneInfo.ConvertTimeFromUtc(w.CreatedOn, AestTimeZone));
        return workspaces;
    }
    
    
}