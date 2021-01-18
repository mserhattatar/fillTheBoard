using UnityEngine;

public class TouchMovment : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistanceHeight;  //minimum distance for a swipe on height
    private float dragDistanceWidth;   //minimum distance for a swipe on width 
    private bool _touchControlOn = false;

    void Start()
    {
        dragDistanceHeight = Screen.height * 10 / 100; //dragDistance is 10% height of the screen
        dragDistanceWidth = Screen.width * 10 / 100;  //dragDistance is 10% width of the screen
    }

    private void ClickTargetButton(int targetNumber)
    {
        var _ActiveButton = ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count - 1];        
        var targetlist = _ActiveButton.GetComponent<ButtonController>().targetButtonList;        
        if (!targetlist.ContainsKey(targetNumber)) return;
        var target = _ActiveButton.GetComponent<ButtonController>().targetButtonList[targetNumber];       
        target.GetComponent<ButtonController>().WriteNumber();
    }
    enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
    void Update()
    {
        if (_touchControlOn)
        {
            DetectTouchClickTarget();
        }
        if (ButtonListManager.instance.WriteList.Count > 0 && !_touchControlOn)
        {
            _touchControlOn = true;
        }        
    }

    private void DetectTouchClickTarget()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            // else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) //player moves with touchpad
            else if (touch.phase == TouchPhase.Ended)
            {
                // update the last position based on where they moved
                lp = touch.position;

                if (Mathf.Abs(lp.x - fp.x) > dragDistanceWidth && Mathf.Abs(lp.y - fp.y) > dragDistanceHeight)
                {
                    if (lp.y > fp.y)
                    {
                        if (lp.x > fp.x)  //If the movement was to the right)
                        {   //Right swipe //Up swipe
                            Debug.Log("Went Right Up swipe");
                            ClickTargetButton((int)Direction.RightUp);

                        }
                        else
                        {   //Left swipe //Up swipe
                            Debug.Log("Went Left //Up swipe");
                            ClickTargetButton((int)Direction.LeftUp);
                        }
                    }
                    else
                    {
                        if (lp.x > fp.x)  //If the movement was to the right)
                        {   //Right swipe //down swipe
                            Debug.Log("Went Right down swipe");
                            ClickTargetButton((int)Direction.RightDown);

                        }
                        else
                        {   //Left swipe //down swipe
                            Debug.Log("Went Left //down swipe");
                            ClickTargetButton((int)Direction.LeftDown);
                        }
                    }
                }
                //Check if drag distance is greater than 10% of the screen width
                else if (Mathf.Abs(lp.x - fp.x) > dragDistanceWidth)
                {
                    if ((lp.x > fp.x))  //If the movement was to the right)
                    {   //Right swipe
                        Debug.Log("Went Right");
                        ClickTargetButton((int)Direction.Right);

                    }
                    else
                    {   //Left swipe

                        Debug.Log("Went Left");
                        ClickTargetButton((int)Direction.Left);
                    }
                }
                //Check if drag distance is greater than 10% of the screen height
                else if (Mathf.Abs(lp.y - fp.y) > dragDistanceHeight)
                {

                    if (lp.y > fp.y)  //If the movement was up
                    {   //Up swipe
                        Debug.Log("Up Swipe");
                        ClickTargetButton((int)Direction.Up);
                    }
                    else
                    {   //Down swipe
                        Debug.Log("Down Swipe");
                        ClickTargetButton((int)Direction.Down);
                    }
                }
            }
        }
    }
   
}

