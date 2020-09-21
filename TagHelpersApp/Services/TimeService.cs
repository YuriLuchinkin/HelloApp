using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersApp.Services
{
    public interface ITimeService
    {
        string GetTime();
    }
    public class SimpleTimeService : ITimeService
    {
        public string GetTime() => System.DateTime.Now.ToString("HH:mm:ss");
    }
}
