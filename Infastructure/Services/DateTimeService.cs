using Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Services
{
    public class DateTimeService: IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
