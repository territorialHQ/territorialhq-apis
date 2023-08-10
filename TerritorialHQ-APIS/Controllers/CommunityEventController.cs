using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class CommunityEventController : BaseDtoController<CommunityEvent, DTOCommunityEvent>
    {
        public CommunityEventController(IBaseService<CommunityEvent> baseService) : base(baseService)
        {
        }

        [HttpGet("Schedule/{days}")]
        public async Task<List<DTOCommunityEvent>> GetCurrentEvents(int days)
        {
            if (days <= 0)
                days = 1;
            if (days > 60)
                days = 60;

            var from = DateTime.Today;
            var to = DateTime.Today.AddDays(days + 1).AddSeconds(-1);

            var singleEvents = await ((CommunityEventService)_baseService).GetBetween(from, to) ?? new List<CommunityEvent>();
            var recurringEvents = await ((CommunityEventService)_baseService).GetRecurring() ?? new List<CommunityEvent>();

            var result = new List<DTOCommunityEvent>();
            foreach (var item in singleEvents)
                result.Add((DTOCommunityEvent)item.GetDto());

            var current = from;
            while (current < to)
            {
                foreach (var item in recurringEvents)
                {
                    var difference = current.Subtract(item.Start!.Value.Date).Days;
                    if (difference % item.Interval == 0)
                    {
                        var dto = (DTOCommunityEvent)item.GetDto();
                        dto.Start = dto.Start!.Value.AddDays(difference);
                        dto.End = dto.End!.Value.AddDays(difference);

                        result.Add(dto);
                    }
                }

                current = current.AddDays(1);
            }

            return result.OrderBy(o => o.Start).ThenBy(o => o.End).ThenBy(o => o.Title).ToList();
        }
    }
}
