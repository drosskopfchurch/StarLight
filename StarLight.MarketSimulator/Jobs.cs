using StarLight.MarketSimulator;
using StarLight.Provider.MarketData;
using Microsoft.Extensions.Caching.Hybrid;

public class AAL(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(AAL));
public class AAPL(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(AAPL));
public class APPL(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(APPL));
public class AMZN(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(AMZN));
public class MSFT(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(MSFT));
public class GOOGL(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(GOOGL));
public class META(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(META));
public class JNJ(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(JNJ));
public class NFLX(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(NFLX));
public class ADBE(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(ADBE));
public class PEP(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(PEP));
public class DIS(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(DIS));
public class CAT(ILogger<Worker> logger, MarketDataService marketDataService) : Worker(logger, marketDataService, nameof(CAT));

