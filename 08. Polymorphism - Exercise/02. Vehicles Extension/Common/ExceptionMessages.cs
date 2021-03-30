using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VehiclesExtension.Common
{
    public static class ExceptionMessages
    {
        public static string NOT_ENOUGHT_FUEL_EXCEPTION_MESSAGE = "{0} needs refueling";
        public static string INVALID_VEHICLE_TYPE_EXEPTION_MESSAGE = "Invalid vehicle type!";
        public static string INVALID_MAXIMUM_FUEL_AMOUNT_EXCEPTION_MESSAGE = "Cannot fit {0} fuel in the tank";
        public static string INVALID_MINIMUM_FUEL_AMOUNT_EXCEPTION_MESSAGE = "Fuel must be a positive number";
    }
}
