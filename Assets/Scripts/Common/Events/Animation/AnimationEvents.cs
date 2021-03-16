//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEvents
{
    public delegate void StringEvent(string condition, bool boolean);
    public static event StringEvent OnPlayAnimation;

    public static void TriggerOnPlayAnimation(string condition, bool boolean)
    {
        OnPlayAnimation?.Invoke(condition, boolean);
    }
}
