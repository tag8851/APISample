using APISample.Models;
using APISample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.BusinessLogic
{
    /// <summary>
    /// ビジネスロジッククラス
    /// </summary>
    public class Logic
    {
        private SampleDBContext sampleDBContext;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public Logic(SampleDBContext context = null)
        {
            if (context == null) context = new SampleDBContext();

            this.sampleDBContext = context;
        }
        /// <summary>
        /// 為替変換ロジック
        /// </summary>
        /// <param name="currencyPair"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public async Task<ExchangeInfo> GetExchangePriceAsync(string currencyPair, double price)
        {
            var rate = await sampleDBContext.Rates.Where(x => x.CurrencyPair == currencyPair).SingleOrDefaultAsync();

            if (rate == null)
            {
                throw new BusinessLogicException("100", "通貨ペアが存在しません");
            }

            return new ExchangeInfo { CurrencyPair = currencyPair, Rate = rate.Value, Price = price, ExchangePrice = rate.Value * price };
        }
        /// <summary>
        /// レート一覧取得ロジック
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Rate>> GetRatesAsync()
        {
            return await sampleDBContext.Rates.ToArrayAsync();
        }
    }
}