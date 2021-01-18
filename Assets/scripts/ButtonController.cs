using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private int _gameObjectİndex;
    private bool _lockButtonWrite;
    private Animator _ButtonAnimator;

    [HideInInspector]
    public bool lockButton;
    [HideInInspector]
    public bool startSearchPotantialNextButton;
    [HideInInspector]
    public bool setBackButtonNumber;
    public Text emptytext;

    public Dictionary<int, GameObject> targetButtonList = new Dictionary<int, GameObject>();

    private void Start()
    {
        ButtonManager.ButtonStart(gameObject);
        _ButtonAnimator = this.GetComponent<Animator>();
    }
    
    private void Update()
    {
       NextButtons();
    }

   
    public void WriteNumber()
    {
        if (lockButton) return;
        if (_lockButtonWrite) return;
        lockButton = true;
        _lockButtonWrite = true;
        FindButtonİndex();
        ButtonManager.SetNumberButtonFontSize(gameObject);
        emptytext.text = ButtonManager.instance.numberToDisplay.ToString();
        ButtonManager.instance.NumberUpdate();
        gameObject.tag = "full";
        ButtonListManager.instance.WriteList.Add(gameObject);
        ButtonManager.ActiveButtonColor();
        LevelManager.instance.SetNextLevel(this.targetButtonList.Count);       
        startSearchPotantialNextButton = true;
        
    }
    
    public void LockButton()
    {        
        emptytext.text = " ";
        gameObject.tag = "full";
        ButtonManager.ButtonImage(gameObject);
        lockButton = true;
        _lockButtonWrite = true;
    }
    
    public void UndoWrite()
    {
        lockButton = false;
        _lockButtonWrite = false;
        ButtonManager.ButtonStart(gameObject);
        ButtonManager.instance.NumberBack();
        gameObject.tag = "empty";
        ButtonListManager.instance.WriteList.RemoveAt(ButtonListManager.instance.WriteList.Count - 1);
        ButtonManager.ActiveButtonColor();
    }
    public void SetActiveButtonCollor(bool active)
    {
        _ButtonAnimator.SetBool("isActiveButtonCollor", active);
    }
   
    private void FindButtonİndex()
    {
        for (var i=0; i< ButtonListManager.instance.GamePlate.Count; i++)
        {
            for (var j=0; j<ButtonListManager.instance.GamePlate[i].Count; j++)
            {
                if (ButtonListManager.instance.GamePlate[i][j] == gameObject)
                {
                    FindPotantialTargetButton(i, j);
                    return;
                }
            }
        }
    }
    /*
               SUTUN(X)
      SATIR(Y) 1234567
               123X567      
    
     */
    private void FindPotantialTargetButton(int satir, int sutun)
    {
        int _max =7;
        switch(ButtonListManager.instance.Button1.Count)
        {
            case 7:
                _max = 7;
                break;
            case 8:
                _max = 8;
                break;
            case 9:
                _max = 9;
                break;
            case 10:
                _max = 10;
                break;            
        }


        targetButtonList.Clear();
        // sol -- satir, sutun-3
        if (sutun - 3 >= 0)
            AddToTargetButtonList((int)Direction.Left, satir, sutun - 3);

        // sag -- satir, sutun +3
        if (sutun + 3 < _max)
            AddToTargetButtonList((int)Direction.Right, satir, sutun + 3);

        // yukari -- satir - 3, sutun 
        if (satir - 3 >= 0)
            AddToTargetButtonList((int)Direction.Up, satir - 3, sutun);

        // aşağı -- satir + 3, sutun 
        if (satir + 3 < _max)
            AddToTargetButtonList((int)Direction.Down, satir + 3, sutun);



        // sol-yukari 
        if (satir - 2 >= 0 && sutun - 2 >= 0 )
            AddToTargetButtonList((int)Direction.LeftUp, satir - 2, sutun - 2);

        // sag yukari
        if (satir - 2 >= 0 && sutun + 2 < _max)
            AddToTargetButtonList((int)Direction.RightUp, satir - 2, sutun + 2);

        // sol-aşağı 
        if (satir + 2 < _max && sutun - 2 >= 0)
            AddToTargetButtonList((int)Direction.LeftDown, satir + 2, sutun - 2);

        // sag aşağı
        if (satir + 2 < _max && sutun + 2 < _max)
            AddToTargetButtonList((int)Direction.RightDown, satir + 2, sutun + 2);
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

    private void AddToTargetButtonList(int direction, int satir, int sutun)
    {        
        var target = ButtonListManager.instance.GamePlate[satir][sutun];
        if (!target.GetComponent<ButtonController>()._lockButtonWrite)
        {
            targetButtonList.Add(direction, target);
        }
    }

    private void NextButtons()
    {
        if (!startSearchPotantialNextButton) return;

        foreach (var t in GameObject.FindGameObjectsWithTag("empty"))
        {
            t.GetComponent<ButtonController>().lockButton = true;
            t.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            ButtonManager.ButtonColorDirtyWhite(t);
        }

        foreach (KeyValuePair<int, GameObject> t in targetButtonList)
        {
            t.Value.GetComponent<ButtonController>().lockButton = false;
            ButtonManager.ButtonColorBlue(t.Value);
        }
        startSearchPotantialNextButton = false;
    }

    private GameObject getButtonOn(int direction)
    {
        return targetButtonList[direction];
    }
}
