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
        // TODO add comment
        if(ButtonListManager.instance.WriteList.Count < 0) return;
        
        ButtonColorPink(ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count - 1]);
        ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count - 1].GetComponent<ButtonController>().startSearchPotantialNextButton = true;
        // TODO add comment
        if (ButtonListManager.instance.WriteList.Count < 2) return;
        
        ButtonColorRed(ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count - 2]);
    }
    
    public static void ButtonStart(GameObject button)
    {
        ButtonColorwhite(button);
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 8f;
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " ";
        var myselfButton = button.GetComponent<Button>();
        myselfButton.onClick.AddListener(button.GetComponent<ButtonController>().WriteNumber);
    }
    
    public static void ButtonImage(GameObject button)
    {
        var carpi = Resources.Load<Sprite>("carpi");
        var suitHealth = button.GetComponent<UnityEngine.UI.Image>().sprite = carpi;
    }
    
    public static void ButtonColorBlue(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        var colorBlue =  new Color (0.0f, 0.75f, 1f, 1f);
        colorBlock.normalColor = colorBlue;
        colorBlock.highlightedColor = Color.cyan;
        button.GetComponent<Button>().colors = colorBlock;
    } 
    
    public static void ButtonColorwhite(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        colorBlock.normalColor = Color.white;
        colorBlock.highlightedColor = Color.white;
        colorBlock.pressedColor = Color.white;
        colorBlock.selectedColor = Color.white;
        colorBlock.disabledColor = Color.white;
        button.GetComponent<Button>().colors = colorBlock;
    }
    
    public static void ButtonColorGray(GameObject button)
    {
        var colorBlock = button.GetComponent<Button>().colors;
        colorBlock.normalColor = Color.gray;
        colorBlock.highlightedColor = Color.gray;
        colorBlock.pressedColor = Color.gray;
        colorBlock.selectedColor = Color.gray;
        colorBlock.disabledColor = Color.gray;
        button.GetComponent<Button>().colors = colorBlock;
    }

    private static void ButtonColorRed(GameObject button)
    {
        var colorRed =  new Color (0.9716981f, 0.7287736f, 0.7287736f, 1f);
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
        var colorPink =  new Color (0.67862f, 0.05598078f, 0.6981132f, 1f);
        var colorBlock = button.GetComponent<Button>().colors;
        colorBlock.normalColor = colorPink;
        colorBlock.highlightedColor = colorPink;
        colorBlock.pressedColor = colorPink;
        colorBlock.selectedColor = colorPink;
        colorBlock.disabledColor = colorPink;
        button.GetComponent<Button>().colors = colorBlock;
    }

    public static void SetBackButtonNumberInButtons()
    {
        for (int i=0; i < 1; i++)
        {
            int emptybuttoncount =GameManager.instance.emptyButtonCount;
            int buttonNo = Random.Range(0, emptybuttoncount -1);
            ButtonListManager.instance.EmtyNumberButton[buttonNo].GetComponent<ButtonController>().setBackButtonNumber = true;
        }
    }
    
    public static void SetFreeButtonNumbers()
    {
        GameManager.instance.emptyButtonCount = 0;
        foreach (var FreeButton in GameObject.FindGameObjectsWithTag("empty"))
        {
            GameManager.instance.emptyButtonCount += 1;
        }
    }
    
    private static void BlockButton()
    {
        int emptybuttoncount =GameManager.instance.emptyButtonCount;
        for (int i=0; i<emptybuttoncount; i++)
        {
            int buttonNo = Random.Range(0, 49);
            ButtonListManager.instance.EmtyNumberButton[buttonNo].GetComponent<ButtonController>().LockButton();
            SetBackButtonNumberInButtons();
        }
    }
}
