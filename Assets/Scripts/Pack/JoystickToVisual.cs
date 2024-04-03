using UnityEngine;
using Unity.VisualScripting;

public class JoystickToBolt : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    // Update is called once per frame
    void Update()
    {
        Variables.Application.Set("joystickX", joystick.Horizontal);
        Variables.Application.Set("joystickY", joystick.Vertical);
    }
}