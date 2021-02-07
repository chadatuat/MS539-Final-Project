// CWW
// MS539 Final Project
// Current functionality - this chat contains bad words (I'm not going to get too vulgar in a school project
// in a practical sense, I might import a public list at some point)
// and replaces these with random characters that convey the point without being vulgar.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public class Chat
    {
        public static List<String> lsBadWords = new List<String>();
        public static List<Char> lsReplacementChars = new List<char>();
        private static Random _myRandom = new Random();
        private static string sMainChatContents = "";

        public Chat()
        {
            lsBadWords.Add("poop");
            lsBadWords.Add("fart");
            lsBadWords.Add("jerk");
            lsBadWords.Add("turd");
            lsBadWords.Add("butt");
            lsReplacementChars.Add('!');
            lsReplacementChars.Add('@');
            lsReplacementChars.Add('#');
            lsReplacementChars.Add('$');
            lsReplacementChars.Add('%');
            lsReplacementChars.Add('^');
            lsReplacementChars.Add('&');
            lsReplacementChars.Add('*');
            lsReplacementChars.Add('(');
            lsReplacementChars.Add(')');
            lsReplacementChars.Add('-');
            lsReplacementChars.Add('=');
            lsReplacementChars.Add('+');
            lsReplacementChars.Add('/');
            lsReplacementChars.Add('}');
            lsReplacementChars.Add('{');
        }

        public static string SMainChatContents { get => sMainChatContents; set => sMainChatContents = value; }

        public string AddChatLine(String sInput)
        {
            if (sMainChatContents.Length > 0)
            {
                SMainChatContents += System.Environment.NewLine;
            }
            return SMainChatContents += ReplaceBadWords(sInput);
        }

        public String ReplaceBadWords(String sInput)
        {
            String sReturnMe = sInput.Trim();
            bool bHasBadLanguage = true;            
            foreach (String sThisBadWord in lsBadWords)
            {
                bHasBadLanguage = true;
                do
                {
                    bHasBadLanguage = false;
                    if (sReturnMe.ToUpper().Contains(sThisBadWord.ToUpper()))
                    {
                        bHasBadLanguage = true;
                        sReturnMe = Regex.Replace(sReturnMe, sThisBadWord, sMakeReplacement(sThisBadWord.Length), RegexOptions.IgnoreCase);                        
                    }
                } while (bHasBadLanguage);

            }
            return sReturnMe;
        }

        private String sMakeReplacement(int iLength)
        {
            String sReturnMe = "";
            for (int i = 0; i < iLength; i++)
            {
                sReturnMe += lsReplacementChars[_myRandom.Next(5000) % lsReplacementChars.Count];
            }
            return sReturnMe;
        }

    }
}
