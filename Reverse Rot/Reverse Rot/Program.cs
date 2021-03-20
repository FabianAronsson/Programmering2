using System;
using System.Collections;
using System.Collections.Generic;

namespace Reverse_Rot
{
    class Program
    {

        static void Main(string[] args)
        {
            int index = 0;
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_.".ToCharArray();
            List<string> wordList = new List<string>();
            while (true)
            {
                string s = Console.ReadLine();
                if(s == "0"){
                    break;
                }
                wordList.Add(s);
                if (isTestCaseComplete(splitString(wordList, index)))
                {
                    break;
                }
                else
                {
                    
                }
                index++;
            }

            index = 0;
            for (int i = 0; i < wordList.Count; i++)
            {
                PrintWord(ReverseWord(RotateWord(getPositionOfLetters(alphabet, wordList, index), splitString(wordList, index)[1].ToCharArray(), alphabet)));
                index++;
            }
            
        }

        public static string[] splitString(List<string> wordList, int index)
        {
            return wordList[index].Split(' ');
        }

        public static bool isTestCaseComplete(string[] arrayToBeTested)
        {
            if(arrayToBeTested[0] == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] getPositionOfLetters(char[] alphabet, List<string> wordList, int index)
        {
            string[] splittedString = splitString(wordList, index);

            char[] wordPositionfromArray = splittedString[1].ToCharArray();

            int rotation = Convert.ToInt32(splittedString[0]);

            int[] positionArray = new int[wordPositionfromArray.Length];

            for (int i = 0; i < wordPositionfromArray.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == wordPositionfromArray[i])
                    {
                        
                        if (j + rotation == 28)
                        {
                            positionArray[i] = 0;
                        }
                        else if(j + rotation > 28)
                        {
                            
                            positionArray[i] = j + rotation - 28;
                        }
                        else
                        {
                            positionArray[i] = j + rotation;
                        }
                    }
                }
            }
            
            return positionArray;
        }

        public static char[] RotateWord(int[] position, char[] wordToBeRotated, char[] alphabet)
        {
            char[] tempArray = new char[wordToBeRotated.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                if(position[i] > 27)
                {
                    tempArray[i] = alphabet[position[i] - 1];
                }
                else
                {
                    tempArray[i] = alphabet[position[i]];
                }            
            }
            return tempArray;
        }

        public static string ReverseWord(char[] semiEncryptedWord)
        {
            string encryptedWord = "";

            for (int i = semiEncryptedWord.Length - 1; i >= 0; i--)
            {
                encryptedWord += semiEncryptedWord[i];
            }
            return encryptedWord;
        }

        public static void PrintWord(string word)
        {
            Console.WriteLine(word);
        }
    }
}
