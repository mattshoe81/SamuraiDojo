using System;
using SamuraiDojo.Attributes;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Challenges
{
    [Challenge("Angler of Time")]
    public class ClockAngler
    {
        [Sensei(Samurai.MATT)]
        [SolutionBy(Samurai.MATT)]
        public static int Matt_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }
        
        [SolutionBy(Samurai.JT)]
        public static int JT_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }

        [Winner(Samurai.DUSTIN)]
        [SolutionBy(Samurai.DUSTIN)]
        public static int Dustin_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;

            if (hour == 12)
            {
                hour = 0;
            }

            int minuteHandPositionInDegrees = minute * 6;
            int hourHandPartialMovement = minute / 2;
            int hourHandPositionInDegrees = (hour * 30) + hourHandPartialMovement;

            angle = Math.Abs(minuteHandPositionInDegrees - hourHandPositionInDegrees);

            return angle;
        }

        [SolutionBy(Samurai.SANJOG)]
        public static int Sanjog_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }

        [SolutionBy(Samurai.JEFF)]
        public static int Jeff_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }
    }
}