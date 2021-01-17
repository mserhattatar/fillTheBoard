using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance; 
    public int number;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        number = GameManager.instance.number;
        BlockButton();
    }

    public void NumberUpdate()
    {
        number += 1;
    }

    public void NumberBack()
    {
        number -= 1;
    }

    public static void ActiveButtonColor()
    {
        var _WriteList = ButtonListManager.instance.WriteList;

        if (_WriteList.Count < 0) return;
        
        ButtonColorPink(_WriteList[_WriteList.Count - 1]);
        _WriteList[_WriteList.Count - 1].GetComponent<ButtonController>().startSearchPotantialNextButton = true;
        //_WriteList[_WriteList.Count - 1].GetComponent<ButtonController>().SetActiveButtonCollor(true);


        if (_WriteList.Count < 2) return;

        //_WriteList[_WriteList.Count - 2].GetComponent<ButtonController>().SetActiveButtonCollor(false);
        ButtonColorRed(_WriteList[_WriteList.Count - 2]);
    }
    
    public static void ButtonStart(GameObject button)
    {
        ButtonColorDirtyWhite(button);
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 16f;
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " ";
        var myselfButton = button.GetComponent<Button>();
        myselfButton.onClick.AddListener(button.GetComponent<ButtonController>().WriteNumber);
    }
    
    public static void ButtonImage(GameObject button)
    {
        var carpi = Resources.Load<Sprite>("carpi");
        button.GetComponent<UnityEngine.UI.Image>().sprite = carpi;
        button.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        ButtonColorDirtyWhite(button);

    }
    
    public static void ButtonColorBlue(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        var colorBlue =  new Color (0.3450f, 0.5019f, 0.9058f, 1f);
        colorBlock.normalColor = colorBlue;
        colorBlock.highlightedColor = Color.cyan;
        colorBlock.pressedColor = colorBlue;
        colorBlock.selectedColor = colorBlue;
        colorBlock.disabledColor = colorBlue;
        button.GetComponent<Button>().colors = colorBlock;
    } 
    
    public static void ButtonColorDirtyWhite(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        var colorDirtyWhite = new Color(0.9333f, 0.8941f, 0.8549f, 1f);
        colorBlock.normalColor = colorDirtyWhite;
        colorBlock.highlightedColor = colorDirtyWhite;
        colorBlock.pressedColor = colorDirtyWhite;
        colorBlock.selectedColor = colorDirtyWhite;
        colorBlock.disabledColor = colorDirtyWhite;
        button.GetComponent<Button>().colors = colorBlock;
    }
    public static void ButtonColorGreen(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        
        var colorGreen = new Color(0.0745f, 0.5411f, 0.4235f, 1f);
        colorBlock.normalColor = colorGreen;
        colorBlock.highlightedColor = colorGreen;
        colorBlock.pressedColor = colorGreen;
        colorBlock.selectedColor = colorGreen;
        colorBlock.disabledColor = colorGreen;
        button.GetComponent<Button>().colors = colorBlock;
    }
    public static void ButtonColorGrey(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;

        var colorGrey = new Color(0.4150f, 0.4150f, 0.4150f, 0.2627f);
        colorBlock.normalColor = colorGrey;
        colorBlock.highlightedColor = colorGrey;
        colorBlock.pressedColor = colorGrey;
        colorBlock.selectedColor = colorGrey;
        colorBlock.disabledColor = colorGrey;
        button.GetComponent<Button>().colors = colorBlock;
    }

    private static void ButtonColorRed(GameObject button)
    {
        var colorRed =  new Color (0.9607f, 0.5843f, 0.3882f, 1f);
        var colorBlock = button.GetComponent<Button>().colors;
        colorBlock.normalColor = colorRed;
        colorBlock.highlightedColor = colorRed;
        colorBlock.pressedColor = colorRed;
        colorBlock.selectedColor = colorRed;
        colorBlock.disabledColor = colorRed;
        button.GetComponent<Button>().colors = colorBlock;
    }

    private static void ButtonColorPink(GameObject button)
    {
        var colorPink =  new Color (0.9647f, 0.3686f, 0.2313f, 1f);
        var colorBlock = button.GetComponent<Button>().colors;
        colorBlock.normalColor = colorPink;
        colorBlock.highlightedColor = colorPink;
        colorBlock.pressedColor = colorPink;
        colorBlock.selectedColor = colorPink;
        colorBlock.disabledColor = colorPink;
        button.GetComponent<Button>().colors = colorBlock;
    }
    public static void SetEmptyButtonAmount()
    {
        GameManager.instance.emptyButtonAmountAtLevelEnd = GameObject.FindGameObjectsWithTag("empty").Length;
    }
    
    private static void BlockButton()
    {
        int EmptyButtonAmount =GameManager.instance.emptyButtonAmountAtLevelEnd;

        while(EmptyButtonAmount > 0)
        {
            int randomNo = Random.Range(0, 49);

            if (!ButtonListManager.instance.EmtyNumberButton[randomNo].GetComponent<ButtonController>().lockButton)
            {
                ButtonListManager.instance.EmtyNumberButton[randomNo].GetComponent<ButtonController>().LockButton();
                EmptyButtonAmount--;
            }
        }       
    }
}
