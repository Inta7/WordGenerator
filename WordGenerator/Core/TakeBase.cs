using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WordGenerator.Core
{
    public class TakeBase
    {

        AppDBContext appDBContext = new AppDBContext();
        
        private int number = 0;
        public TakeBase()
        {
            appDBContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(20));
        }

        public string word { get; set; }


        public void TakeWord()
        {
            var text = (from test in appDBContext.Ruswords
                        where test.Word == word
                        select test.Word).FirstOrDefault();

            if (text == null)
            {
                Sorter sorter = new Sorter(word);
                var AllWords = sorter.Sorting().ToHashSet();

                var dbWords = appDBContext.Ruswords.Where(word => AllWords.Contains(word.Word)).ToList();

                foreach (var Result in dbWords)
                {
                    number++;
                    Console.WriteLine("Слово № " + number + ":");
                    Console.WriteLine(Result.Word);
                }
            }
        }
    }
}
