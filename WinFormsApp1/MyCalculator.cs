using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class MyCalculator
    {
        public string? UserSetData = "";

        /*
       创建一个空的 List<object>
        List<object> list = new List<object>();

        // 向 List 中添加元素
        list.Add(10);       // 添加整数
        list.Add("Hello");  // 添加字符串
        list.Add(new MyClass()); // 添加自定义类的实例

        // 清空 List
        list.Clear();
        1234
        object[] array = list.ToArray();
        */
        public List<object> list = new List<object>();



        public MyCalculator()
        {
        }
        


        public void ConvertInputType(string input)
        {
            decimal result;

            if (decimal.TryParse(input, out result))
            {
                // 转换成功，result 中包含转换后的值
                Console.WriteLine("转换成功，结果为: " + result);
                list.Add(result);
            }
            else
            {
                // 转换失败，输入的字符串不是有效的 decimal 格式
                // Console.WriteLine("无法将字符串转换为 decimal");
            }
        }
        
        /*
        public string? input_text(string? text)
        {
            MyCalculator.UserSetStrNum += text;
            return MyCalculator.UserSetStrNum;

        }
        */
    }
}
