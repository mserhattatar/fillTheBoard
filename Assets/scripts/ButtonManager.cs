using UnityEngine;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance; 
    
    public int numberToDisplay;
    public int LevelButtonMatrix;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LevelButtonMatrix = ButtonListManager.instance.Button1.Count;
        numberToDisplay = GameManager.instance.gameData.numberToDisplayDictionary[LevelButtonMatrix];
        BlockButton();
    }
    private void BlockButton()
    {//player move to next level and have empty button. take empty button count and block some buttons as many as this count
        int EmptyButtonAmount = GameManager.instance.gameData.emptyButtonAmountAtLevelEndDictionary[LevelButtonMatrix];

        while (EmptyButtonAmount > 0)
        {
            int _max = 7;
            switch (ButtonListManager.instance.Button1.Count)
            {
                case 7:
                    _max = 49;
                    break;
                case 8:
                    _max = 64;
                    break;
                case 9:
                    _max = 81;
                    break;
                case 10:
                    _max = 100;
                    break;
            }
            int randomNo = Random.Range(0, _max);

            //do not lock in locked boxes
            if (!ButtonListManager.instance.EmtyNumberButton[randomNo].GetComponent<ButtonController>().lockButton)
            {
                ButtonListManager.instance.EmtyNumberButton[randomNo].GetComponent<ButtonController>().LockButton();
                EmptyButtonAmount--;
            }
        }
    }
    public static void ButtonImage(GameObject button)
    {//block boxes image X
        var carpi = Resources.Load<Sprite>("carpi");
        button.GetComponent<UnityEngine.UI.Image>().sprite = carpi;
        button.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        ButtonColorDirtyWhite(button);
    }

    public void NumberUpdate()
    {//write number update by activebutton
        numberToDisplay += 1;
    }
    public void NumberBack()
    {
        numberToDisplay -= 1;
    }
    public static void InitButton(GameObject button)
    {//all boxes starting this value
        ButtonColorDirtyWhite(button);
        button.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = " ";
        var myselfButton = button.GetComponent<Button>();
        myselfButton.onClick.AddListener(button.GetComponent<ButtonController>().WriteNumber);
    }
    public static void SetNumberButtonFontSize(GameObject button)
    {// change write number text size in boxes. if number to large in box
        int size = 7;
        int minus =0;
        int N = instance.numberToDisplay;
        if (N >= 0)
        {
            if(N > 10000)
                minus = 4;
            else if (N > 1000)
                minus = 3;
            else if (N > 100)
                minus = 2;
            else if (N > 10)
                minus = 1;
            else 
                minus = 0;
        }
        switch (ButtonListManager.instance.Button1.Count)
        {
            case 7:
                size = 18 - minus;
                break;
            case 8:
                size = 16 - minus;
                break;
            case 9:
                size = 14 - minus;
                break;
            case 10:
                size = 14 - minus;
                break;
        }
        
        button.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().fontSize = size;               
    }

    //Buttons Collor
    public static void ActiveButtonColor()
    {
        var _WriteList = ButtonListManager.instance.WriteList;

        if (_WriteList.Count < 1) return;
        ButtonColorPink(_WriteList[_WriteList.Count - 1]);
        _WriteList[_WriteList.Count - 1].GetComponent<ButtonController>().startSearchPotantialNextButton = true;

        if (_WriteList.Count < 2) return;
        ButtonColorRed(_WriteList[_WriteList.Count - 2]);
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
}
