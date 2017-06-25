using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.Domain.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services
{
    public class MatchService : BaseService<Match>
    {
        public List<Match> GetList(long matchDayId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Matches.Where(x => x.MatchDayId == matchDayId)
                    .Include(x => x.MatchDay).ToList();
            }
        }
    }
}