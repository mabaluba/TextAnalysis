using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        static Dictionary<string, int> FrequentValue(List<List<string>> text, string wordCount)
        {
            var wordsCountDict= new Dictionary<string,int>();
            foreach (var list in text)
            {
                if(list.Count>1)
                {
                    for (var i = 0; i < list.Count - 1; i++)
                    {
                        if (list[i] == wordCount)
                        {
                            if (!wordsCountDict.ContainsKey(list[i + 1]))
                                wordsCountDict.Add(list[i + 1], 1);
                            else wordsCountDict[list[i + 1]]++;
                        }
                    }
                    for (var i = 0; i < list.Count - 2; i++)
                    {
                        if (list[i] + " " + list[i + 1] == wordCount)
                        {
                            if (!wordsCountDict.ContainsKey(list[i + 2]))
                                wordsCountDict.Add(list[i + 2], 1);
                            else wordsCountDict[list[i + 2]]++;
                        }
                    }
                }
            }
            return wordsCountDict;
        }

        //static Dictionary<string, Dictionary<string, int>> AllFrecuentDictionary(List<List<string>> text)
        //{
        //    var dictionariAll = new Dictionary<string, Dictionary<string, int>>();
        //    foreach (var list in text)
        //    {
        //        if (list.Count > 1)
        //        {
        //            for (var i = 0; i < list.Count - 1; i++)
        //            {
        //                if (!dictionariAll.ContainsKey(list[i]))
        //                {
        //                    var valMax = 0;
        //                    foreach (var pair in FrequentValue(text, list[i].ToString()))
        //                    {
        //                        if (pair.Value > valMax)

        //                    }
        //                }




        //                        dictionariAll.Add(list[i], FrequentValue(text, list[i].ToString()));
        //            }
        //            for (var i = 0; i < list.Count - 2; i++)
        //            {
        //                if (!dictionariAll.ContainsKey(list[i] + " " + list[i + 1]))
        //                {
        //                    dictionariAll.Add(list[i] + " " + list[i + 1], FrequentValue(text, list[i] + " " + list[i + 1]));
        //                }
        //            }
        //        }
        //    }
        //    return dictionariAll;
        //}

        //static string WordValMaxLexMin(KeyValuePair<string, int> pair)
        //{
        //    var valMax = 0;
        //    var wordMax = "";
        //    if (pair.Value > valMax)
        //    {
        //        valMax = pair.Value;
        //        wordMax = pair.Key;
        //    }
        //    else if (pair.Value == valMax && string.CompareOrdinal(pair.Key, wordMax) < 0)
        //    {
        //        wordMax = pair.Key;
        //    }
        //    return wordMax;
        //}

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();

            foreach (var list in text)
            {
                if (list.Count > 1)
                {
                    for (var i = 0; i < list.Count - 1; i++)
                    {
                        if (!result.ContainsKey(list[i]))
                        {
                            var valMax = 0;
                            string wordMax="";
                            foreach (var pair in FrequentValue(text, list[i].ToString()))
                            {
                                //wordMax = WordValMaxLexMin(pair);
                                if (pair.Value > valMax)
                                {
                                    valMax = pair.Value;
                                    wordMax = pair.Key;
                                }
                                else if (pair.Value == valMax && string.CompareOrdinal(pair.Key, wordMax) < 0)
                                {
                                    wordMax = pair.Key;
                                }
                            }
                            result.Add(list[i],wordMax);
                        }
                    }
                    
                    for (var i = 0; i < list.Count - 2; i++)
                    {
                        if (!result.ContainsKey(list[i] + " " + list[i + 1]))
                        {
                            var valMax = 0;
                            string wordMax = "";
                            foreach (var pair in FrequentValue(text, list[i] + " " + list[i + 1]))
                            {
                                //wordMax = WordValMaxLexMin(pair);
                                if (pair.Value > valMax)
                                {
                                    valMax = pair.Value;
                                    wordMax = pair.Key;
                                }
                                else if (pair.Value == valMax && string.CompareOrdinal(pair.Key, wordMax) < 0)
                                {
                                    wordMax = pair.Key;
                                }
                            }
                            result.Add(list[i] + " " + list[i + 1], wordMax);
                        }
                    }
                }
            }

            return result;
        }
   }
}