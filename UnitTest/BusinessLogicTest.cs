using APISample.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BusinessLogicTest
    {
        [TestMethod]
        public void Normal()
        {
            var logic = new APISample.BusinessLogic.Logic();

            //テスト実行
            var ret = logic.GetExchangePriceAsync("JPY/USD", 1000).Result;

            //確認
            Assert.AreEqual(ret.Rate * 1000, ret.ExchangePrice);

            Assert.AreEqual(1000, ret.Price);
            Assert.AreEqual("JPY/USD", ret.CurrencyPair);
        }
        [TestMethod]
        public void Error()
        {
            var logic = new APISample.BusinessLogic.Logic();

            //テスト実行
            try
            {
                var ret = logic.GetExchangePriceAsync("Hoge", 1000).Result;
            }
            catch(BusinessLogicException e)
            {
                //確認
                Assert.AreEqual("100", e.Id);
                Assert.AreEqual("通貨ペアが存在しません", e.Message);
            }

        }
    }
}
