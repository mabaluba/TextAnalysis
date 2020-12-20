using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
       static List<string> WordsList(string sentenceL)  //метод типа List<string> принимает предложение в нижнем регистре
        {
            var separatorsArr = new List<char>();       //заводим новый лист типа char для сепараторов, по которым будет разито предложение на отдельные слова
            foreach (var symbol in sentenceL)           //для каждого символа в предложении находим любой символ не являющийся буквой или символом апострофа
            {
                if (!(char.IsLetter(symbol) || symbol == '\'') && !separatorsArr.Contains(symbol))// а так же добавляем условие, чтобы не было дубликатов
                    separatorsArr.Add(symbol);          //добавляем в лист символы для сепаратора(разделителя на слова) из предложения
            }
            //var wordArr = sentenceL.Split(separatorsArr.ToArray(), StringSplitOptions.RemoveEmptyEntries);//создаем массив для слов и разбиваем                                                           предложение используя лист сепараторов, переведенных в массив(должен быть массив, а не лист, а в лист                                               удобно добавлять без задавания конечной длинны)
            var wordList = new List<string>(sentenceL.Split(separatorsArr.ToArray(), StringSplitOptions.RemoveEmptyEntries));
            //wordList.AddRange(sentenceL.Split(separatorsArr.ToArray(), StringSplitOptions.RemoveEmptyEntries));//кладем массив слов в лист
            return wordList;                            //возвращаем лист слов
       }

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();//заводится лист листов
            var sentences = new List<string>();          //объявляется лист для отдельных предложений
            sentences.AddRange(text.Split(new char[]
            {
                '.', '!', '?', ';', ':', '(', ')'
            }, StringSplitOptions.RemoveEmptyEntries)); //в лист для предложений кладется весь разбитый(по символам) text на массив предложений типа string
            foreach (var sentence in sentences)         //для каждого элемента массива - предложения - из всех предложений
            {
                var sentenceLower = sentence.ToLower(); //заводим новую переменную для предложения - переводим все символы предложения в нижний регистр
                if(WordsList(sentenceLower).Count!=0)   //берем предложение, переведенное в нижний регистр, и используем метод, который возвращает лист                                                   слов.Исключаем из последовательности слов пустые значения.
                    sentencesList.Add(WordsList(sentenceLower));//добавляем в лист (листов) последовательность(лист) слов из каждого предложения
            }
            return sentencesList;                       //возвращаем лист листов - лист предложений, каждое предложение разбито на лист слов
        }
    }
}