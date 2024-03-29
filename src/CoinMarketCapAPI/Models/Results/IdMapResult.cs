﻿using ImanN.CoinMarketCap.Models;
using System.Collections.Generic;

namespace ImanN.CoinMarketCap {

    public class IdMapResult: ApiResponse<List<CryptoCurrencyIdMapData>> {

        public static IdMapResult From(ApiResponse<List<CryptoCurrencyIdMapData>> model)
            => new IdMapResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
