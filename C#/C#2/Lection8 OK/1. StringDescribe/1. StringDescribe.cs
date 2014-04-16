//Describe the strings in C#. What is typical for the string data type? Describe the most important methods of the String class.
// описал съм някои от най-важните за мен методи

using System;
using System.Linq;

namespace StringDescribe
{
    class Program
    {
        static void Main(string[] args)
        {
            string example = string.Empty;  //дефиниране на празен стринг

            int result = example.CompareTo(" ");    //инстанционен метод за сравняване на стрингове
            bool res = example.Contains(" ");       //инстанционен метод, който проверява дали даден стринг съдържа даден друг стринг
            result = example.IndexOf('a', 0);       //инстанционен метод за намиране на индекс на даден char в стринга
            example.Insert(0, " ");                 //инстанционен метод за инсъртване на стринг от даден индекс
            result = example.Length;                //инстанционен метод за намиране дължина на стринг
            example.PadLeft(8, '0');                //инстанционен метод за запълване отляво на стринг с даден символ до опр. дължина
            example.PadRight(8, '0');               //инстанционен метод за запълване отдясно на стринг с даден символ до опр. дължина
            example.Split('a');                     //инстанционен метод за разделяне на стринг на други стрингове, в зав. от даден символ
            example.Substring(0, 32);               //инстанционен метод за намиране на подстринг с опр. дължина от опр.индекс
        }
    }
}
