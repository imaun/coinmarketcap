namespace ImanN.CoinMarketCap {

    public enum CoinMarketCapError {
        API_KEY_INVALID = 1001,
        API_KEY_MISSING = 1002,
        API_KEY_PLAN_REQUIRES_PAYEMENT = 1003,
        API_KEY_PLAN_PAYMENT_EXPIRED = 1004,
        API_KEY_REQUIRED = 1005,
        API_KEY_PLAN_NOT_AUTHORIZED = 1006,
        API_KEY_DISABLED = 1007,
        API_KEY_PLAN_MINUTE_RATE_LIMIT_REACHED = 1008,
        API_KEY_PLAN_DAILY_RATE_LIMIT_REACHED = 1009,
        API_KEY_PLAN_MONTHLY_RATE_LIMIT_REACHED = 1010,
        IP_RATE_LIMIT_REACHED = 1011
    }

    public static class CoinMarketCapErrorMessages {

        public static string Message(this CoinMarketCapError error) {
            switch(error) {
                case CoinMarketCapError.API_KEY_INVALID:
                    return "This API Key is invalid.";

                case CoinMarketCapError.API_KEY_MISSING:
                    return "API key missing.";

                case CoinMarketCapError.API_KEY_PLAN_REQUIRES_PAYEMENT:
                    return "Your API Key must be activated. Please go to pro.coinmarketcap.com/account/plan.";

                case CoinMarketCapError.API_KEY_PLAN_PAYMENT_EXPIRED:
                    return "Your API Key's subscription plan has expired.";

                case CoinMarketCapError.API_KEY_REQUIRED:
                    return "An API Key is required for this call.";

                case CoinMarketCapError.API_KEY_PLAN_NOT_AUTHORIZED:
                    return "Your API Key subscription plan doesn't support this endpoint.";

                case CoinMarketCapError.API_KEY_DISABLED:
                    return "This API Key has been disabled. Please contact support.";

                case CoinMarketCapError.API_KEY_PLAN_MINUTE_RATE_LIMIT_REACHED:
                    return "You've exceeded your API Key's HTTP request rate limit. Rate limits reset every minute.";

                case CoinMarketCapError.API_KEY_PLAN_DAILY_RATE_LIMIT_REACHED:
                    return "You've exceeded your API Key's daily rate limit.";

                case CoinMarketCapError.API_KEY_PLAN_MONTHLY_RATE_LIMIT_REACHED:
                    return "You've exceeded your API Key's monthly rate limit.";

                case CoinMarketCapError.IP_RATE_LIMIT_REACHED:
                    return "You've hit an IP rate limit.";

                default: return null;
            }
        }

    }

}
