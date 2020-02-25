using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Challenges_Console_App
{
    public class Methods
    {
        //Build a method that takes in a list of strings, and returns the list sorted. - Can you do it without using "linq"?
        public List<string> SortMethodAtoZ(List<string> unsortedList)
        {
            return unsortedList.OrderBy(q => q ).ToList();
        }
        public List<string> SortMethodZtoA(List<string> unsortedList)
        {
            return unsortedList.OrderByDescending(q => q).ToList();
        }

        public void writelineList(List<string> list)
        {
            foreach(string str in list)
            {
                Console.WriteLine(str);
            }
        }

        //Build a method that takes in a string and returns an integer that is equal to the length of the string. 

        public int StringLength(String str)
        {
            return str.ToList<char>().Count;
        }

        //Build a method that takes in a list of integers and returns the list sorted biggest to smallest. 

        public List<int> SortMethodBigtoSmall(List<int> unsortedList)
        {
            return unsortedList.OrderByDescending(q => q).ToList();
        }
        public void writelineList(List<int> list)
        {
            foreach (int n in list)
            {
                Console.WriteLine(n);
            }
        }
        public List<int> SortMethodSmalltoBig(List<int> unsortedList)
        {
            return unsortedList.OrderBy(q => q).ToList();
        }

        /*
         * Build a method that the user will input a string and the method should return the reverse of that string
    input: hello, output: olleh
    input: hello world, output: dlrow olleh
         * */

        public string ReverseString(string str)
        {
            List<char> charList = str.ToList();
            List<int> intList = new List<int>();
            List<char> charListFinal = new List<char>();
            for (int i = 0; i < charList.Count; i++)
            {
                intList.Add(i);
            }
            List<int> intListReverse = intList.OrderByDescending(q => q).ToList();
            foreach(int n in intListReverse)
            {
                charListFinal.Add(charList[n]);
            }
            string finalString = string.Join("", charListFinal.ToArray());
            return finalString;
        }
    }
    /*
     * Build a method that takes in a list of strings, and returns the list sorted.                 DONE
     * 
     * 
     * 
Build a method that takes in a string and returns an integer that is equal to the length of the string.     DONE



On a piece of paper or on your whiteboard desk write out a simple method.    DIDN'T DO BUT I CAN DO ALL THAT
  Label the following 
    Return Type
    Both parts of the method signature 
    Access modifier 
    Body of the method


Build a method that takes in a list of integers and returns the list sorted biggest to smallest.        DONE



Build a method that the user will input a string and the method should return the reverse of that string        DONE
    input: hello, output: olleh
    input: hello world, output: dlrow olleh



Build a method that takes in a list of strings and returns the list but without any vowels (you can leave out ‘y’ if you want to).
    Extra challenge: Make sure to take out ‘y’ if it is the vowel
**Bonus- build out a test assembly and a test class to test all the methods you are building. 
**Another bonus - write out by hand (on another paper or whiteboard) a few of the methods you have built. Mark the different parts of the method.
     * */
}
