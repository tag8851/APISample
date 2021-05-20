using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.BusinessLogic
{
    //ビジネスロジック用例外処理クラス
    public class BusinessLogicException : SystemException
    {
        public string Id { get; set; }
        public BusinessLogicException(string id, string message) : base(message)
        {
            this.Id = id;
        }
    }
}
