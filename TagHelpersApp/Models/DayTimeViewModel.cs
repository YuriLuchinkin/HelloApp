using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TagHelpersApp.Models
{
    public enum DayTime
    {
        [Display(Name = "Утро")]
        Morning,
        [Display(Name = "День")]
        Afternoon,
        [Display(Name = "Вечер")]
        Evening,
        [Display(Name = "Ночь")]
        Night
    }
    public class DayTimeViewModel
    {
        public DayTime Period { get; set; }
    }
}
