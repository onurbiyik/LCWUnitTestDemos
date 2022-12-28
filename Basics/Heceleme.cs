using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public static class StringExtensions
    {
        static readonly Char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü','A', 'E','I','İ','O','Ö','U','Ü'};
        static readonly Char[] sessizHarfler = { 'b', 'c', 'ç', 'd', 'f', 'g', 'ğ', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 'ş', 't', 'v', 'y', 'z', 'B', 'C', 'Ç', 'D', 'F', 'G', 'Ğ', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'Ş', 'T', 'V', 'Y', 'Z' };
        static readonly Char[] karakter = { ' ', '!', '?', '/', '.', ',', ':', ';' };

        // [ExcludeFromCodeCoverage]
        public static List<string> Hecele(this string input)
        {
            var result = new List<string>();

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var words = input.Split(karakter);
            
            foreach (var word in words)
            {
                result.AddRange(KelimeHecele(word));
            }

            return result;
        }




        private static List<string> KelimeHecele(string input)
        {
            List<string> result = new();

            var inputLength = input.Length;
            // for (int chIndex = 0; chIndex < inputLength; chIndex++)
            int chIndex = 0;
            while (chIndex < inputLength)
            {
                if (IsVowel(input[chIndex]))
                {
                    if (chIndex + 1 >= inputLength)
                    {
                        result.Add(input.Substring(chIndex));
                        return result;
                    }
                    else
                    {
                        Debug.Assert(IsNotVowel(input[chIndex + 1]));


                        if (chIndex + 2 >= inputLength)
                        {
                            result.Add(input.Substring(chIndex));
                            return result;
                        }
                        else
                        {
                            if (IsNotVowel(input[chIndex + 2]))//3.harf sessiz
                            {
                                if (chIndex + 3 >= inputLength)
                                {
                                    result.Add(input.Substring(chIndex));
                                    return result;
                                }
                                else
                                {
                                    if (IsNotVowel(input[chIndex + 3]))//4.harf sessiz
                                    {
                                        result.Add(input.Substring(chIndex, 3)) ;//ilk 3 harf hece
                                        chIndex = chIndex+ 3;
                                    }
                                    if (IsVowel(input[chIndex + 3]))//4.harf sesliyse 
                                    {
                                        result.Add(input.Substring(chIndex, 2));//ilk 2 harf hece
                                        chIndex = chIndex + 2;
                                    }
                                }
                            }
                            else if (IsVowel(input[chIndex + 2]))//3.harf sesliyse
                            {
                                result.Add(input.Substring(chIndex, 1));
                                chIndex = chIndex + 1;
                            }
                        }
                    }
                }
                else
                {
                    if ((chIndex + 1) >= inputLength)
                    {
                        result.Add(input.Substring(chIndex));
                        return result;
                    }
                    else
                    {
                        if (IsVowel(input[chIndex + 1]))//ikinci sesli
                        {
                            if (chIndex + 2 >= inputLength)
                            {

                                result.Add(input.Substring(chIndex)); 
                                return result;

                            }
                            else
                            {
                                if (IsNotVowel(input[chIndex + 2]) )//3.harf sessiz
                                {
                                    if (chIndex + 3 >= inputLength)
                                    {
                                        result.Add(input.Substring(chIndex));
                                        return result;
                                    }
                                    else
                                    {
                                        if (IsVowel(input[chIndex + 3]))//4.harf sesli
                                        {
                                            result.Add(input.Substring(chIndex, 2));
                                            chIndex = chIndex + 2;
                                        }
                                        else if (IsNotVowel(input[chIndex + 3]))//4.sessiz
                                        {
                                            if (chIndex + 4 >= inputLength)
                                            {
                                                result.Add(input.Substring(chIndex));
                                                return result;
                                            }
                                            else
                                            {
                                                if (IsVowel(input[chIndex + 4]))//5.harf sesli
                                                {
                                                    result.Add(input.Substring(chIndex, 3));//ilk 3 harf hece
                                                    chIndex = chIndex + 3;
                                                }
                                                else if (IsNotVowel(input[chIndex + 4]))//5.harf sessiz
                                                {
                                                    result.Add(input.Substring(chIndex, 2));//ilk 2 harf hece
                                                    chIndex = chIndex + 2;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (IsVowel(input[chIndex + 2]))//3.harf sesli
                                {
                                    result.Add(input.Substring(chIndex, 2));//ilk 2 harf hece
                                    chIndex = chIndex + 2;
                                }
                            }
                        }
                        else if (IsNotVowel(input[chIndex + 1]))//2.harf sessiz
                        {
                            result.Add(input.Substring(chIndex, 4));//ilk 2 harf hece
                            chIndex = chIndex + 4;
                        }
                    }
                }
            }
            return result;
        }

        private static bool IsNotVowel(char input)
        {
            return !IsVowel(input);
        }

        private static bool IsVowel(char input)
        {
            return sesliHarfler.Contains(input);
        }
        
    }
}
