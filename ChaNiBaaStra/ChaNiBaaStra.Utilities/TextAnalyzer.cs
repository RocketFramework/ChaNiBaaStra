using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChaNiBaaStra.Utilities
{
    public class TextAnalyzer
    {
        public class stringItem
        {
            public stringItem(int c, string s)
            {
                Count = c;
                Text = s;
                IsFreezed = false;
                Words = Text.Split(new char[] { ' ' });
                cleanWords();
            }
            public int Count;
            public string Text;
            public string[] Words;
            public bool IsFreezed;

            private void cleanWords()
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < Words.Length; i++)
                {
                    if (!(Words[i].Contains("(descendent)") ||
                        Words[i].Contains("(Ascendant)") ||
                        Words[i].Contains("house") ||
                        Words[i].Contains("sits") ||
                        Words[i].Contains("directly") ||
                        Words[i].Contains("accross") ||
                        (Words[i] == "from") ||
                        (Words[i] == "the") ||
                        Words[i].Contains("first") ||
                        Words[i].Contains("house") ||
                        (Words[i] == "also") ||
                        (Words[i] == "as") ||
                        Words[i].Contains("It's") ||
                        (Words[i] == "your") ||
                        (Words[i] == "is") ||
                        (Words[i] == "all") ||
                        Words[i].Contains("kinds") ||
                        (Words[i]== "of") || (Words[i] == "if") ||
                        (Words[i] == "and") || (Words[i] == "even") ||
                        (Words[i] == "by") || Words[i].Contains("House") ||
                        (Words[i] == "The") || (Words[i] == "A") ||
                        (Words[i] == "it") || (Words[i] == "As") ||
                        Words[i].Contains("planet") || (Words[i] == "but") ||
                        (Words[i] == "like") || (Words[i] == "will") ||
                        Words[i].Contains("takes") || (Words[i] == "get") ||
                        (Words[i] == "be") || (Words[i] == "As") ||
                        (Words[i] == "a") || (Words[i] == "or") ||
                        Words[i].Contains("may") || Words[i].Contains("people") ||
                        (Words[i] == "for") || Words[i].Contains("time") ||
                        Words[i].Contains("Many") || Words[i].Contains("would") ||
                        (Words[i] == "not") || (Words[i] == "th") ||
                        (Words[i] == "So") || Words[i].Contains("When") ||
                        (Words[i] == "you") || (Words[i] == "in") ||
                        (Words[i] == "to") || (Words[i] == "It") ||
                        Words[i].Contains("things") || string.IsNullOrWhiteSpace(Words[i])
                        || string.IsNullOrEmpty(Words[i]) || temp.Contains(Words[i])))
                    {
                        temp.Add(Words[i]);
                    }
                }
                Words = temp.ToArray();
            }
        }

        private List<stringItem> wholeText = new List<stringItem>();
        public TextAnalyzer() { }

        public void AddString(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            string[] temp = text.Split(new char[] { '.', '=', ';', });
            for (int i = 0; i < temp.Length; i++)
            {
                if (string.IsNullOrEmpty(temp[i])
                    || temp[i] == "Rashi Data"
                    || temp[i] == "Planet Data"
                    || temp[i] == "Planet On House"
                    || temp[i].Trim(' ') == ""
                    || temp[i].Trim(new char[] { '\r', '\n' }) == "")
                    continue;
                stringItem sItem = new stringItem(0, temp[i]);
                wholeText.Add(sItem);
            }

            foreach (stringItem itemOutside in wholeText)
            {
                itemOutside.IsFreezed = true;
                foreach (stringItem itemInside in wholeText)
                    if (!itemInside.IsFreezed)
                        for (int j = 0; j < itemInside.Words.Length; j++)
                            if (itemOutside.Text.Contains(itemInside.Words[j]))
                                itemOutside.Count++;
                itemOutside.IsFreezed = false;
            }
        }

        public string GetSummary()
        {
            if (wholeText == null || wholeText.Count == 0)
                return "";
            wholeText = wholeText.OrderByDescending(x => x.Count).ToList();
            string s = "";
            for (int i = 0; i < ((wholeText.Count > 20) ? 20 : wholeText.Count); i++)
                s += wholeText[i].Text +"\r\n";
            return s;
        }

        public void Reset()
        {
            wholeText.Clear();
        }
    }
}
