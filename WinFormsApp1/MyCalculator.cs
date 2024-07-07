using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{

    internal class MyCalculator
    {
        // 函数字典
        public Dictionary<string, Func<decimal, decimal, decimal>> MathFuncDict = new Dictionary<string, Func<decimal, decimal, decimal>>();
        // 用户窗口
        public Dictionary<string, string?> OutputBox = new Dictionary<string, string?>();
        // 暂存操作符
        public (Func<decimal, decimal, decimal>,string) TempStorageOperate = (null,null);
        // 暂存数字
        public decimal TempStorageNum = 0;
        // 初始标志
        public bool InitFlag = false;

        public MyCalculator() {

            this.MathFuncDict.Add(" = ", (a, b) => a + b); 
            this.MathFuncDict.Add(" + ", (a, b) => a + b);
            this.MathFuncDict.Add(" - ", (a, b) => a - b);
            this.MathFuncDict.Add(" * ", (a, b) => a * b);
            this.MathFuncDict.Add(" % ", (a, b) => a % b);

            this.MathFuncDict.Add(" / ", (a, b) => {
                if (b == 0)
                {
                    return a;
                }
                return a / b;
            });
            this.MathFuncDict.Add(" ** ", (a, b) => {
                decimal result = 1;
                for (int i = 0; i < b; i++)
                {
                    result *= a;
                }
                return result;
            });
            this.MathFuncDict.Add(" √￣ ", (a, b) => {
                if (a <= 0)
                {
                    return a;
                }
                if (b == 0)
                {
                    return 1;
                } 

                return (decimal)System.Math.Pow((double)a,1/ (double)b);
            });


            this.OutputBox.Add("Result_forms", "");
            this.OutputBox.Add("TempWaitNum_forms", "");
            this.OutputBox.Add("History_forms", "");
        }



        // 核心代码 处理器 
        public void handle(string TempWaitNum_forms,  string Operate)
        {
            Func<decimal, decimal, decimal> Func = this.MathFuncDict[Operate];
            decimal num = ConvertStringToDecimal(TempWaitNum_forms);
            // 未初始
            if (!this.InitFlag) {
                // 空数 操作数先行（主要负数有用）
                if (TempWaitNum_forms == "")
                {
                    this.TempStorageOperate = (Func,Operate);
                    this.InitFlag = true;
                    this.OutputBox["Result_forms"] = "";

                    return;
                }
                // 初始 数字先行 
                else if (TempWaitNum_forms != "")
                {
                    this.TempStorageNum = num;
                    this.TempStorageOperate = (Func, Operate);
                    this.InitFlag = true;
                    this.OutputBox["Result_forms"] = this.TempStorageNum.ToString();
                    return;
                }
            }

            // 初始过 循环操作
            if (this.InitFlag)
            {

                // 判断用户反复按 “ = ” 号 直接return
                if (this.TempStorageOperate.Item1 == Func && Operate == " = ")
                {
                    return;
                }
                // 没数字、用户在切换操作符    
                if (TempWaitNum_forms == "")
                    {
                        this.TempStorageOperate = (Func, Operate);
                    }
                // 有数字、需要求值 掉进来新的操作符和操作数
                else if (TempWaitNum_forms != "")
                    {

                    // 用户尝试 除0 直接return
                    if (this.TempStorageOperate.Item2 == " / " && num == 0)
                        {
                        this.OutputBox["History_forms"] += this.OutputBox["Result_forms"] + " / 0 is invalid.\r\n";
                        return;
                        }
                    // 用户尝试 拿<=0的数字开根 直接return
                    if (this.TempStorageOperate.Item2 == " √￣ " && this.TempStorageNum <= 0)
                    {
                        this.OutputBox["History_forms"] += this.OutputBox["Result_forms"] + $"  √￣  {num} is invalid.\r\n";
                        return;
                    }
                    this.OutputBox["History_forms"] += this.TempStorageNum.ToString() + this.TempStorageOperate.Item2 +  num.ToString();
                    this.TempStorageNum = this.TempStorageOperate.Item1(this.TempStorageNum, num);
                    this.OutputBox["History_forms"] += " = " + this.TempStorageNum.ToString() + "\r\n";
                    
                    // 存入下个操作
                    this.OutputBox["Result_forms"] = this.TempStorageNum.ToString();
                    this.TempStorageOperate = (Func,Operate);
                    }
            }
        }


        // 转换 
        public decimal ConvertStringToDecimal(string _String)
        {
            if (decimal.TryParse(_String, out decimal result))
            {
                return result;
            }
            else
            {
                return result; // 待改 检测截断、精度之类的
            }
        }


        // 重置
        public void reset()
        {
            this.OutputBox["Result_forms"] = "";
            this.OutputBox["TempWaitNum_forms"] = "";
            this.OutputBox["History_forms"] = "";
            this.TempStorageOperate = (null,null);
            this.TempStorageNum = 0;
            this.InitFlag = false;
        }

    }
}
