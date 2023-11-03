using Techsnovel.Application.Common.Interfaces;

namespace Techsnovel.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
