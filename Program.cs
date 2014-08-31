using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer zhangchao = new Customer("220104198905121316", "Zhangchao");
            zhangchao.Register(zhangchao.Id, zhangchao.Name);
             zhangchao.Save(zhangchao.Id, 200);
            zhangchao.Save(zhangchao.Id, 40);
            zhangchao.closeAccount(zhangchao.Id, zhangchao.Name);
            Console.ReadKey();
        }
    }
}
