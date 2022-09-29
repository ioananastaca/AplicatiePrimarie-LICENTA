using System.Collections.Generic;
using PagedList;

namespace Licenta.Models
{
    public class Reports
    {
        public IEnumerable<Report> ReportsOnPage { get; set; }
    }
}