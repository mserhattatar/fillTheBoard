using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private int _gameObjectİndex;
    private bool _lockButtonWrite;
    public bool lockButton;
    public bool startSearchPotantialNextButton;
    public bool setBackButtonNumber;
    public TextMeshProUGUI emptytext;

    public Dictionary<string, GameObject> targetButtonList = new Dictionary<string, GameObject>();

    private void Start()
    {
        ButtonManager.ButtonStart(gameObject); 
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
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 16f;
        emptytext.text = ButtonManager.instance.number.ToString();
        ButtonManager.instance.NumberUpdate();
        gameObject.tag = "full";
        ButtonListManager.instance.WriteList.Add(gameObject);
        ButtonManager.ActiveButtonColor();
        LevelManager.instance.SetNextLevel(this.targetButtonList.Count);       
        startSearchPotantialNextButton = true;
        
    }
    
    public void LockButton()
    {
        ButtonManager.ButtonColorGreen(gameObject);
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

    private void FindPotantialTargetButton(int satir, int sutun)
    {
        // sol -- satir, sutun-3
        if (sutun - 3 >= 0)
            AddToTargetButtonList("left", satir, sutun - 3);

        // sag -- satir, sutun +3
        if (sutun + 3 < 7)
            AddToTargetButtonList("right", satir, sutun + 3);

        // yukari -- satir - 3, sutun 
        if (satir - 3 >= 0)
            AddToTargetButtonList("up", satir - 3, sutun);

        // aşağı -- satir + 3, sutun 
        if (satir + 3 < 7)
            AddToTargetButtonList("down", satir + 3, sutun);

        // sol-yukari i-2,j-2
        if (sutun - 2 >= 0 && satir - 2 >= 0)
            AddToTargetButtonList("left-up", satir - 2, sutun - 2);

        // sag yukari i-2, j+2
        if (sutun - 2 >= 0 && satir + 2 < 7)
            AddToTargetButtonList("right-up", satir + 2, sutun - 2);

        // sol-aşağı i+2,j-2
        if (sutun + 2 < 7 && satir - 2 >= 0)
            AddToTargetButtonList("left-down", satir - 2, sutun + 2);

        // sag aşağı i+2, j+2
        if (sutun + 2 < 7 && satir + 2 < 7)
            AddToTargetButtonList("right-down", satir + 2, sutun + 2);
    }

    private void AddToTargetButtonList(string direction, int satir, int sutun)
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
            t.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
            ButtonManager.ButtonColorDirtyWhite(t);
        }

        foreach (KeyValuePair<string, GameObject> t in targetButtonList)
        {
            t.Value.GetComponent<ButtonController>().lockButton = false;
            ButtonManager.ButtonColorBlue(t.Value);
        }
        startSearchPotantialNextButton = false;
    }

    private GameObject getButtonOn(string direction)
    {
        return targetButtonList["direction"];
    }
}
