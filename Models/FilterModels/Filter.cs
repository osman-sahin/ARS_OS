using Microsoft.AspNetCore.Mvc;

namespace ARS_OS.Models.FilterModels
{
    public record Filter
    {
        [FromQuery(Name = "from")]
        public Guid? From { get; set; }
        [FromQuery(Name = "to")]
        public Guid? To { get; set; }

    }
}
