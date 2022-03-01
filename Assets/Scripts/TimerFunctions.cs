using System.Collections;
using UnityEngine;

namespace TimeFunctions
{
    public class TimerFunctions
    {
        public float currentTime = 0;
        public TimerFunctions()
        {
            currentTime = 0;
        }

        public bool Timer(float setTimer)
        {
            currentTime += Time.deltaTime;
            if(currentTime > setTimer)
            {
                currentTime = 0;
                return true;
            }

            return false;
        }
    }
}