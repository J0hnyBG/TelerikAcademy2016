﻿using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IExhaust : ITunningPart
    {
        ExhaustType ExhaustType { get; }
    }
}
