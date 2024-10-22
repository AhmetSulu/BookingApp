using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.Operations.Setting
{
    public interface ISettingService
    {
        Task ToggleMaintenence();
        bool GetMaintenanceState();
    }
}
