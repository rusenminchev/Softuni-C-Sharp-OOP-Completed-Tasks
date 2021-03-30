using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models.Contracts
{
    public interface IDriveable
    {
        string Drive(double distance);
    }
}
