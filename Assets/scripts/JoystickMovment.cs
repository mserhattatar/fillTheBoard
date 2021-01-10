using UnityEngine;

public class JoystickMovment : MonoBehaviour
{
    private Joystick _joystick;
    private Vector2 _joystickMovVector2;

    public static JoystickMovment instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        /*JoystickControl();*/
    }
    private void JoystickControl()
    {
        _joystickMovVector2.x = _joystick.Horizontal;
        _joystickMovVector2.y = _joystick.Vertical;
    }
}
