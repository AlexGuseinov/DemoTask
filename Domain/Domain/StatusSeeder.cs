using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class StatusSeeder
    {
        public static List<Status> GetSeeders()
        {
            return Enum.GetValues<StatusEnum>().ToList().Select(a =>
            {
                return new Status()
                {
                    Id = (int)a,
                    Name = a.ToString(),
                    IsDeleted = false,
                    CreateDate = DateTime.UtcNow

                };
            }).ToList();
        }
    }
}
