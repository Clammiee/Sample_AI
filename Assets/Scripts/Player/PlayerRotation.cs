using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : PlayerInputs
{
    [Tooltip("Speed of rotation on Y axis")]
    [SerializeField] private float speed;
    private float angle = 0f;

    void FixedUpdate()
    {
        MouseTurningPlayer();
    }

    private float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(b.x - a.x, b.y - a.y) * Mathf.Rad2Deg;
    }

    private void MouseTurningPlayer()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = AngleBetweenPoints(positionOnScreen, mouseOnScreen);

        if (Vector2.Distance(positionOnScreen, mouseOnScreen) > 0.01f)
        {
            rb.MoveRotation(Quaternion.Euler(new Vector3(0f, angle, 0f)));
        }
        else
        {
            AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", false);
        }
    }
}
