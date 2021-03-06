﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class LetiSpaghetti : Driver
    {
        private const GenderType LetiSpaghettiGender = GenderType.Female;
        private const string LetiSpaghettiName = "Leti Spaghetti";
        public LetiSpaghetti()
            : base(LetiSpaghettiName, LetiSpaghettiGender)
        {
        }
    }
}
