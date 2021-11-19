using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoreData
{
    public static int OrangeItemCount{get; set;}

    public static int PurpleItemCount { get; set; }

    public static int GreenItemCount { get; set; }

    public static int MaxOrange { get; set; }

    public static int MaxPurple { get; set; }

    public static int MaxGreen { get; set; }

    public static bool IsSwimming { get; set; }

    public static bool ShowOrange { get; set; }

    public static bool ShowPurple { get; set; }

    public static float PurpleTimer { get; set; }
    public static float OrangeTimer { get; set; }

    public static bool OrangeComplete { get; set; }

    public static bool PurpleComplete { get; set; }
}
