﻿/**
 * Umbra Space Industries Resource Converter
 * 
 * This is a derivative work of Thunder Aerospace Corporation's library for  
 * the Kerbal Space Program, which is (c) 2013, Taranis Elsu, who retains the copyright for 
 * all unmodified portions of this work.  Enhancements and extensions are (c) 2014 Bob Palmer.  
 *  
 * Kerbal Space Program is Copyright (C) 2013 Squad. See http://kerbalspaceprogram.com/. This
 * project is in no way associated with nor endorsed by Squad.
 * 
 * This code is licensed under the Attribution-NonCommercial-ShareAlike 3.0 (CC BY-NC-SA 3.0)
 * creative commons license. See <http://creativecommons.org/licenses/by-nc-sa/3.0/legalcode>
 * for full details.
 * 
 * Attribution — You are free to modify this code, so long as you mention that the resulting
 * work is based upon or adapted from this code.
 * 
 * Non-commercial - You may not use this work for commercial purposes.
 * 
 * Share Alike — If you alter, transform, or build upon this work, you may distribute the
 * resulting work only under the same or similar license to the CC BY-NC-SA 3.0 license.
 * 
 * Note that Thunder Aerospace Corporation and Umbra Space Industries are ficticious entities 
 * created for entertainment purposes. It is in no way meant to represent a real entity.
 *  Any similarity to a real entity is purely coincidental.
 */

using KSP.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace USI
{
    public static class Utilities
    {
        const int SECONDS_PER_MINUTE = 60;
        const int SECONDS_PER_HOUR = 3600;
        const int SECONDS_PER_DAY = 6 * SECONDS_PER_HOUR;

        public static int MaxDeltaTime 
        { 
            get { return SECONDS_PER_DAY; }
        }
        public static int ElectricityMaxDeltaTime 
        { 
            get { return 1; } 
        }

        public static string Electricity { get { return "ElectricCharge"; } }

        public static int ElectricityId
        {
            get
            {
                return PartResourceLibrary.Instance.GetDefinition(Electricity).id;
            }
        }

        public static double GetValue(ConfigNode config, string name, double currentValue)
        {
            double newValue;
            if (config.HasValue(name) && double.TryParse(config.GetValue(name), out newValue))
            {
                return newValue;
            }
            else
            {
                return currentValue;
            }
        }


        public static string FormatTime(double time)
        {
            time = (int)time;

            string result = "";
            if (time < 0)
            {
                result += "-";
                time = -time;
            }

            int days = (int)(time / SECONDS_PER_DAY);
            time -= days * SECONDS_PER_DAY;

            int hours = (int)(time / SECONDS_PER_HOUR);
            time -= hours * SECONDS_PER_HOUR;

            int minutes = (int)(time / SECONDS_PER_MINUTE);
            time -= minutes * SECONDS_PER_MINUTE;

            int seconds = (int)time;

            if (days > 0)
            {
                result += days.ToString("#0") + ":";
            }
            result += hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
            return result;
        }


        public static string FormatValue(double ratio, int p)
        {
            //???
            return Math.Round(ratio, p).ToString();
        }
    }
}
