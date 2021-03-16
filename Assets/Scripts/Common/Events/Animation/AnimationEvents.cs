using UnityEngine;
using System;

public class AnimationEvents
{
    public delegate void StringEvent(GameObject obj, string condition, bool boolean);
    public static event StringEvent OnPlayAnimation;

    public static void TriggerOnPlayAnimation(GameObject obj, string condition, bool boolean)
    {
        OnPlayAnimation?.Invoke(obj, condition, boolean);
    }
}
