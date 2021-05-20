using APISample.Models;
using APISample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISample.Controllers
{
    /// <summary>
    /// 為替変換コントローラ
    /// </summary>
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        [HttpGet("api/[controller]/GetPrice")]
        public async Task<ActionResult<ExchangeInfo>> GetPrice(string currencyPair, double price)
        {
            //入力値チェック
            if(string.IsNullOrEmpty(currencyPair))
            {
                throw new ArgumentException("currencyPair");
            }
            
            var logic = new BusinessLogic.Logic();

            //指定した通貨ペアで金額を変換する
            var ret = await logic.GetExchangePriceAsync(currencyPair, price);

            return Ok(ret);
        }
        [HttpGet("api/[controller]/GetRates")]
        public async Task<ActionResult<IEnumerable<Rate>>> GetRates()
        {
            var logic = new BusinessLogic.Logic();

            //レート一覧を取得する
            var ret = await logic.GetRatesAsync();

            return Ok(ret);
        }
    }
}
