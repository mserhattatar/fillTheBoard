using UnityEngine;

public class JoystickMovment : MonoBehaviour
{
    private Joystick _joystick;
    private Vector3 _joystickMovVector3;
    private bool _joystickOn;

    public GameObject JoystickGameObject;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (_joystickOn)
        {
            JoystickMovmentVector2();
        }
        if (ButtonListManager.instance.WriteList.Count > 0 && !_joystickOn)
        {
            Debug.Log("joystick açıldı");            
            JoystickGameObject.SetActive(true);
            _joystick = FindObjectOfType<Joystick>();
            _joystickOn = true;
        }       
    }

    private void JoystickMovmentVector2()
    {
        var joystickNewVector3 = new Vector3(_joystick.Horizontal * 10f, _joystick.Horizontal * 10f, 0);
        _joystickMovVector3 = joystickNewVector3;

        JosystickControl();
        Debug.Log("joystickçalışıyor");
    }   
       
    private void JosystickControl()
    {
        /*
    * sağ üst çapraz 6
    * sağ alt çapraz 8
    * sol üst çapraz 5
    * sol alt çapraz 7
    * sağ 2
    * sol 1
    * yukarı 3
    * aşağı  4
    */
        if (_joystickMovVector3.x > 0f && _joystickMovVector3.y > 0f)
        {
            //sağ üst çapraz
            ClickTargetButton("right-up");
            Debug.Log("right-up");
        }
        else if (_joystickMovVector3.x > 0f && _joystickMovVector3.y < 0f)
        {
            //sağ alt çapraz
            ClickTargetButton("right-down");
            Debug.Log("right-down");
        }
        else if (_joystickMovVector3.x < 0f && _joystickMovVector3.y > 0f)
        {
            //sol üst çapraz
            ClickTargetButton("left-up");
            Debug.Log("left-up");
        }
        else if (_joystickMovVector3.x < 0f && _joystickMovVector3.y < 0f)
        {
            //sol alt çapraz
            ClickTargetButton("left-down");
            Debug.Log("left-down");
        }
        else if(_joystickMovVector3.x > _joystickMovVector3.y)
        {
            if(_joystickMovVector3.x > 0f)
            {
                //ToDo right
                ClickTargetButton("right");
                
            }
            else
            {
                //ToDo left
                ClickTargetButton("left");
               
            }
        }
        else if (_joystickMovVector3.x < _joystickMovVector3.y)
        {
            if (_joystickMovVector3.y > 0f)
            {
                //ToDo up
                ClickTargetButton("up");
               
            }
            else
            {
                //ToDo down
                ClickTargetButton("down");
                
            }
        }       
    }
    private void ClickTargetButton(string targetNumber)
    {
        var _ActiveButton = ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count - 1];
        var target = _ActiveButton.GetComponent<ButtonController>().targetButtonList[targetNumber];
        target.GetComponent<ButtonController>().WriteNumber();
        Debug.Log(target.name);
    }
}
