using UnityEngine;
using System;

public class ActionEvents
{
    public delegate void GameObjectEvent(GameObject obj);
    public static event GameObjectEvent OnShootBullet;

    public static void TriggerOnShootBullet(GameObject obj)
    {
        OnShootBullet?.Invoke(obj);
    }
}
