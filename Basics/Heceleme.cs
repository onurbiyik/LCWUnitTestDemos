using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public static class StringExtensions
    {
        //// copy paste from https://mustafabukulmez.com/2018/11/30/c-kelime-heceleme-islemi/
        //public string CumleHeceleme(string Metin)
        //{
        //    const string Sesli_Harfler = "aeıioöuüAEIİOÖUÜ";
        //    const string Sessiz_Harfler = "bçdfgğhjklmnprsştvyzBÇDFGĞHJKLMNPRSŞTVYZ";
        //    const string OzelKarakterler = "., ;\'!?\"";
        //    Metin = (Metin + " ");
        //    string Hece = "";
        //    int Index = 1;
        //    string AlinanHece = "";

        //IslemeBasla:

        //    for (int i = Index; (i <= Metin.Length); i++)
        //    {
        //        //Önce karakterleri kontrol et. Eğer boşluk varsa döngüyü tekrar çalıştır
        //        if (((OzelKarakterler.IndexOf(Metin.Substring((i - 1), 1), 0) + 1) > 0))
        //        {
        //            // boşluk ise direkt başa dön 
        //            AlinanHece = Metin.Substring((Index - 1), 1);
        //            Hece = (Hece + AlinanHece);
        //            Index++;
        //            goto IslemeBasla;
        //        }

        //        if (((Sessiz_Harfler.IndexOf(Metin.Substring((i - 1), 1), 0) + 1) > 0))
        //        {
        //            // ilk harf sessiz 
        //            if (((Sesli_Harfler.IndexOf(Metin.Substring(i, 1), 0) + 1) > 0))
        //            {
        //                // ikinci harf sesli 
        //                if (((Sessiz_Harfler.IndexOf(Metin.Substring((i + 1), 1), 0) + 1) > 0))
        //                {
        //                    // Üçüncü harf sessiz 
        //                    if (((Sesli_Harfler.IndexOf(Metin.Substring((i + 2), 1), 0) + 1) > 0))
        //                    {
        //                        // dördüncü  harf sesli ise ilk iki harf hecedir. 
        //                        AlinanHece = (Metin.Substring((Index - 1), 2) + "-");
        //                        Hece = (Hece + AlinanHece);
        //                        Index += 2;
        //                        goto IslemeBasla;
        //                    }

        //                    if (((Sessiz_Harfler.IndexOf(Metin.Substring((i + 2), 1), 0) + 1) > 0))
        //                    {
        //                        // dördüncü harf te sessiz 
        //                        if (((Sesli_Harfler.IndexOf(Metin.Substring((i + 3), 1), 0) + 1) > 0))
        //                        {
        //                            // 5.harf sesli ise ilk 3 harf hecedir. 
        //                            AlinanHece = (Metin.Substring((Index - 1), 3) + "-");
        //                            Hece = (Hece + AlinanHece);
        //                            Index += 3;
        //                            goto IslemeBasla;
        //                        }
        //                        if (((Sessiz_Harfler.IndexOf(Metin.Substring((i + 3), 1), 0) + 1) > 0))
        //                        {
        //                            // 5.harf sessiz ise ilk 4 harf hecedir. 
        //                            AlinanHece = (Metin.Substring((Index - 1), 4) + "-");
        //                            Hece = (Hece + AlinanHece);
        //                            Index += 4;
        //                            goto IslemeBasla;
        //                        }
        //                    }
        //                }
        //                if (((Sesli_Harfler.IndexOf(Metin.Substring((i + 1), 1), 0) + 1) > 0))
        //                {
        //                    // Üçüncü harf sesli ise ilk iki harf hecedir. 
        //                    AlinanHece = (Metin.Substring((Index - 1), 2) + "-");
        //                    Hece = (Hece + AlinanHece);
        //                    Index += 2;
        //                    goto IslemeBasla;
        //                }
        //            }
        //            if (((Sessiz_Harfler.IndexOf(Metin.Substring(i, 1), 0) + 1) > 0))
        //            {
        //                // ikinci de sessiz ise ilk 4 harf hecedir. 
        //                AlinanHece = (Metin.Substring((Index - 1), 4) + "-");
        //                Hece = (Hece + AlinanHece);
        //                Index += 4;
        //                goto IslemeBasla;
        //            }
        //        }



        //        if (((Sesli_Harfler.IndexOf(Metin.Substring((i - 1), 1), 0) + 1) > 0))
        //        {
        //            // ilk harf sesli 
        //            if (((Sessiz_Harfler.IndexOf(Metin.Substring(i, 1), 0) + 1) > 0))
        //            {
        //                // ikinci harf sessiz 
        //                if (((Sessiz_Harfler.IndexOf(Metin.Substring((i + 1), 1), 0) + 1) > 0))
        //                {
        //                    // Üçüncü harf sessiz. 
        //                    if (((Sesli_Harfler.IndexOf(Metin.Substring((i + 2), 1), 0) + 1) > 0))
        //                    {
        //                        // Dördüncü harf sesli ise ilk iki harf hecedir. 
        //                        AlinanHece = (Metin.Substring((Index - 1), 2) + "-");
        //                        Hece = (Hece + AlinanHece);
        //                        Index += 2;
        //                        goto IslemeBasla;
        //                    }
        //                    if (((Sessiz_Harfler.IndexOf(Metin.Substring((i + 2), 1), 0) + 1) > 0))
        //                    {
        //                        // dördüncü harf te sessiz ise ilk üç harf hecedir. 
        //                        AlinanHece = (Metin.Substring((Index - 1), 3) + "-");
        //                        Hece = (Hece + AlinanHece);
        //                        Index += 3;
        //                        goto IslemeBasla;
        //                    }
        //                }
        //                if (((Sesli_Harfler.IndexOf(Metin.Substring((i + 1), 1), 0) + 1) > 0))
        //                {
        //                    // Üçüncü harf sesli.Bu durumda ilk harf hece demektir. 
        //                    AlinanHece = (Metin.Substring((Index - 1), 1) + "-");
        //                    Hece = (Hece + AlinanHece);
        //                    Index++;
        //                    goto IslemeBasla;
        //                }
        //            }
        //        }
        //    }
        //    return Hece;
        //}



        static readonly Char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü','A', 'E','I','İ','O','Ö','U','Ü'};
        static readonly Char[] sessizHarfler = { 'b', 'c', 'ç', 'd', 'f', 'g', 'ğ', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 'ş', 't', 'v', 'y', 'z', 'B', 'C', 'Ç', 'D', 'F', 'G', 'Ğ', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'Ş', 'T', 'V', 'Y', 'Z' };
        static readonly Char[] karakter = { ' ', '!', '?', '/', '.', ',', ':', ';' };

        public static List<string> Hecele(this string input)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return result;
            }

            var words = input.Split(karakter);
            
            foreach (var word in words)
            {
                result.AddRange(KelimeHecele2(word));
            }

            return result;
        }

        private static List<string> KelimeHecele(string input)
        {
            List<string> result = new();  

            var inputLength = input.Length;
            int indexForSplit = 0;
            for (int chIndexForFindVowel = 0; chIndexForFindVowel < inputLength; chIndexForFindVowel++)
            {
                if (IsVowel(input[chIndexForFindVowel]))
                {
                    // Bulunan sesli harf kelimenin sonunda veya sondan ikinci harf ise
                    if (chIndexForFindVowel == inputLength - 1 || chIndexForFindVowel == inputLength - 2)
                    {
                        int characterCountForSyllable = inputLength - chIndexForFindVowel + 1;
                        string temp = input.Substring(indexForSplit, characterCountForSyllable);
                        result.Add((temp));
                    }
                    // Bulunan sesli harften sonra gelen harf sesli ise (Saat)
                    else if (IsVowel(input[chIndexForFindVowel + 1]))
                    {
                        string temp = input.Substring(indexForSplit, chIndexForFindVowel + 1);
                        result.Add((temp));
                        indexForSplit = chIndexForFindVowel + 1;
                    }
                    // Bulunan sesli harften sonra gelen sessiz harften sonra gelen harf sesli ise
                    else if (IsVowel(input[chIndexForFindVowel + 2]))
                    {
                        int characterCountForSyllable = chIndexForFindVowel + 1 - indexForSplit;
                        string temp = input.Substring(indexForSplit, characterCountForSyllable);
                        result.Add((temp));
                        indexForSplit = chIndexForFindVowel + 1;
                    }
                    // Bulunan sesli harften sonra gelen yanyana 2 sessiz harften sonra gelen harf sesli ise
                    else if (IsVowel(input[chIndexForFindVowel + 3]))
                    {
                        int characterCountForSyllable = chIndexForFindVowel + 2 - indexForSplit;
                        string temp = input.Substring(indexForSplit, characterCountForSyllable);
                        result.Add((temp));
                        indexForSplit = chIndexForFindVowel + 2;
                    }
                    // Bulunan sesli harften sonra gelen 3 harf de sessiz ise
                    else
                    {
                        int characterCountForSyllable = chIndexForFindVowel + 3 - indexForSplit;
                        string temp = input.Substring(indexForSplit, characterCountForSyllable);
                        result.Add((temp));
                        indexForSplit = chIndexForFindVowel + 3;
                    }
                }
            }
            return result;
        }


        private static List<string> KelimeHecele2(string input)
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
