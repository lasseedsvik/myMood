using System;
using System.Collections.Generic;
using System.Text;

namespace myMood.Helpers
{
    public class SmileyHelper
    {
        public static string GetSmileyImage(double value)
        {
            string smiley;

            if (value < 1)
                smiley = "ic_sentiment_very_dissatisfied_black_24dp.png";
            else if (value >= 1 & value < 2)
                smiley = "ic_sentiment_dissatisfied_black_24dp.png";
            else if (value >= 2 & value < 3)
                smiley = "ic_sentiment_neutral_black_24dp.png";
            else if (value >= 3 & value < 4)
                smiley = "ic_sentiment_satisfied_black_24dp.png";
            else
                smiley = "ic_mood_black_24dp.png";

            return smiley;
        }

        public static string GetReverseSmileyImage(double value)
        {
            string smiley;

            if (value < 1)
                smiley = "ic_mood_black_24dp.png";
            else if (value >= 1 & value < 2)
                smiley = "ic_sentiment_satisfied_black_24dp.png";
            else if (value >= 2 & value < 3)
                smiley = "ic_sentiment_neutral_black_24dp.png";
            else if (value >= 3 & value < 4)
                smiley = "ic_sentiment_dissatisfied_black_24dp.png";
            else
                smiley = "ic_sentiment_very_dissatisfied_black_24dp.png";

            return smiley;
        }
    }
}
