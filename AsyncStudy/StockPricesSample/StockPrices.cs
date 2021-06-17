using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockPricesSample
{
    class StockPrices
    {
        public  Dictionary<string, decimal> _stockPrices;
        public async Task<decimal> GetStockPriceForAsync(string companyId)
        {
            await InitializeMapIfNeededAsync();
            _stockPrices.TryGetValue(companyId, out var result);
            return result;
        }

        private async Task InitializeMapIfNeededAsync()
        {
            if (_stockPrices != null)
                return;

            await Task.Delay(42);
            // 从外部数据源或内存中的缓存得到股票价格
            _stockPrices = new Dictionary<string, decimal> { { "MSFT", 42 } };
        }

        public async Task InitializeMapIfNeeded()
        {
            if (_stockPrices != null)
                return;

            await Task.Delay(42);
            // 从外部数据源或内存中的缓存得到股票价格
            _stockPrices = new Dictionary<string, decimal> { { "MSFT", 42 } };
        }
    }

}
