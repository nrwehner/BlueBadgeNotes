using System;
using System.Collections.Generic;
using System.Linq;
using _00_Challenges_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _00_Challenges_Tests
{
    [TestClass]
    public class ChallengesTests
    {
        public class Arrange
        {
            public Methods methods = new Methods();
            public List<string> list = new List<string> { "banana", "apple", "zebra", "carrot", "dog" };
            public List<int> listInt = new List<int> {1,4,6,8,3,7,0,8,9,2};
        }
        [TestMethod]
        public void sortListTests()
        {
            Arrange arrange = new Arrange();
            arrange.methods.writelineList(arrange.list);
            Console.WriteLine("\n");
            arrange.methods.writelineList(arrange.methods.SortMethodAtoZ(arrange.list));
            Console.WriteLine("\n");
            arrange.methods.writelineList(arrange.methods.SortMethodZtoA(arrange.list));
        }
        [TestMethod]
        public void StringLengthTests()
        {
            Arrange arrange = new Arrange();
            int n = arrange.methods.StringLength(arrange.list[0]);
            int m = arrange.methods.StringLength(arrange.list[1]);
            int o = arrange.methods.StringLength(arrange.list[2]);
            int p = arrange.methods.StringLength(arrange.list[3]);

            Console.WriteLine($"{n} {m} {o} {p}");
        }
        [TestMethod]
        public void SortIntListTests()
        {
            Arrange arrange = new Arrange();
            arrange.methods.writelineList(arrange.listInt);
            Console.WriteLine("\n");
            arrange.methods.writelineList(arrange.methods.SortMethodBigtoSmall(arrange.listInt));
            Console.WriteLine("\n");
            arrange.methods.writelineList(arrange.methods.SortMethodSmalltoBig(arrange.listInt));
        }
        [TestMethod]
        public void ReverStringTest()
        {
            Arrange arrange = new Arrange();
            Console.WriteLine(arrange.list[0]);
            Console.WriteLine(arrange.methods.ReverseString(arrange.list[0]));
            Console.WriteLine(arrange.methods.ReverseString(arrange.list[1]));
            Console.WriteLine(arrange.methods.ReverseString(arrange.list[2]));
        }
        [TestMethod]
        public void MyTestMethod()
        {
            string str = "banana";
            List<char> charList = str.ToList();
            Console.WriteLine($"{charList[0]} {charList[1]} {charList[2]} {charList[3]} {charList[4]} {charList[5]}");
            List<int> intList = new List<int>();
            List<char> charListFinal = new List<char>();
            for (int i = 0; i < charList.Count; i++)
            {
                intList.Add(i);
            }
            Console.WriteLine(charList.ToString());
            Console.WriteLine($"{intList[0]} {intList[1]} {intList[2]} {intList[3]} {intList[4]} {intList[5]}");
            
            List<int> intListReverse = intList.OrderByDescending(q => q).ToList();

            Console.WriteLine($"{intListReverse[0]} {intListReverse[1]} {intListReverse[2]} {intListReverse[3]}" +
                $" {intListReverse[4]} {intListReverse[5]}");

            
            foreach (int n in intListReverse)
            {
                charListFinal.Add(charList[n]);
            }

            Console.WriteLine($"{charListFinal[0]} {charListFinal[1]} {charListFinal[2]} {charListFinal[3]}" +
    $" {charListFinal[4]} {charListFinal[5]}");

            string finalString = string.Join("", charListFinal.ToArray());
            Console.WriteLine(finalString); 
            
        }
    }
}
