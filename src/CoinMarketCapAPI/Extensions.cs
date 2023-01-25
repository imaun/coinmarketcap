﻿using System;

namespace ImanN.CoinMarketCap
{
    public static class HelperExtensions
    {

        public static void CheckArgumentIsNull(this object o, string name = "") {
            if (o == null)
                throw new ArgumentNullException(name);
        }
    }
}
