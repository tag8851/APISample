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

            //�e�X�g���s
            var ret = logic.GetExchangePriceAsync("JPY/USD", 1000).Result;

            //�m�F
            Assert.AreEqual(ret.Rate * 1000, ret.ExchangePrice);

            Assert.AreEqual(1000, ret.Price);
            Assert.AreEqual("JPY/USD", ret.CurrencyPair);
        }
        [TestMethod]
        public void Error()
        {
            var logic = new APISample.BusinessLogic.Logic();

            //�e�X�g���s
            try
            {
                var ret = logic.GetExchangePriceAsync("Hoge", 1000).Result;
            }
            catch(BusinessLogicException e)
            {
                //�m�F
                Assert.AreEqual("100", e.Id);
                Assert.AreEqual("�ʉ݃y�A�����݂��܂���", e.Message);
            }

        }
    }
}
