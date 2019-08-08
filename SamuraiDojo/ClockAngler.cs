using System;

namespace SamuraiDojo
{
    public class ClockAngler
    {
        public static int Matt_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }

        public static int JT_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = Math.Abs((minute - hour * 5) * 6);
            return angle;
        }

        public static int Dustin_CalculateAngleBetweenHands(int hour, int minute)
        {
            //comment to test push
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

        public static int Sanjog_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }

        public static int Jeff_CalculateAngleBetweenHands(int hour, int minute)
        {
            int angle = 0;
            return angle;
        }
    }
}