using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TripTrackerDTO;

namespace TripTracker.BackService.Models
{
    public class Trip : TripTrackerDTO.Trip
    {
       public virtual ICollection<Segment> Segments { get; set; }
    }
}
