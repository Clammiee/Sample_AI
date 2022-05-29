using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerRotation : PlayerInputs
{
    [Tooltip("Speed of rotation on Y axis")]
    [SerializeField] private float speed;
    private float angle = 0f;
    private float angleController = 0f;
    private GameObject virtualCursor;
    private UnityAction playerRotateType;

    private bool isMouse = false;

    private void Awake()
    {
        virtualCursor = GameObject.FindGameObjectWithTag("VirtualCursor");

        inputs = new Inputs();
        playerActions = inputs.Player;
        playerActions.Enable();
    }

    private void Start()
    {
        if (base.inputs.Player.VirtualMouseTrigger != null) inputs.Player.VirtualMouseTrigger.performed += ctx => VirtualMouseTurningPlayer();
        playerRotateType = null;
        playerRotateType = MouseTurningPlayer;
    }

    private void OnGUI()
    {
        if (Event.current.isMouse == true && isMouse == false)
        {

            playerRotateType = null;
            playerRotateType = MouseTurningPlayer;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            virtualCursor.SetActive(false);

            isMouse = true;
        }
        else if (base.inputs.Player.VirtualMouseTrigger != null && Event.current.isMouse == false && isMouse == true && base.inputs.Player.VirtualMouseTrigger.ReadValue<Vector2>() != Vector2.zero)
        {

            playerRotateType = null;
            playerRotateType = VirtualMouseTurningPlayer;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;

            if (base.inputs.Player.VirtualMouseTrigger != null) virtualCursor.SetActive(true);
            isMouse = false;
        }
    }

    void Update()
    {
        if (base.inputs.Player.VirtualMouseTrigger == null) return;

        if (playerRotateType != null) playerRotateType();
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
    
    private void VirtualMouseTurningPlayer()
    {

        if (virtualCursor.activeInHierarchy)
        {
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(virtualCursor.transform.position);
            angleController = AngleBetweenPoints(positionOnScreen, mouseOnScreen);

            if (Vector2.Distance(positionOnScreen, mouseOnScreen) > 0.01f)
            {
                rb.MoveRotation(Quaternion.Euler(new Vector3(0f, angleController, 0f)));
            }
            else
            {
                AnimationEvents.TriggerOnPlayAnimation(this.gameObject, "Run", false);
            }
        }
        
    }
}
