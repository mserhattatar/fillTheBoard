using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LangNamespace
{
   public enum Language
    {
        English,
        Turkish
    }
}


public class LanguageManager : MonoBehaviour
{

    public static LanguageManager instance;
    public int selectedLang;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        selectedLang = GameManager.instance.gameData.selectedLang;
    }

    private bool isSelectedLangTr()
    {
        return selectedLang == (int)LangNamespace.Language.Turkish;
    }
    private bool isSelectedLangEn()
    {
        return selectedLang == (int)LangNamespace.Language.English;
    }

    public void SelectEnLang()
    {
        if (isSelectedLangEn())
            return;
        selectedLang = (int)LangNamespace.Language.English;
        SetChangeLang();
    }
    public void SelectTrLang()
    {
        if (isSelectedLangTr())
            return;
        selectedLang = (int)LangNamespace.Language.Turkish;
        SetChangeLang();
    }
    public void TranslateText(Text _text, string enText, string trText)
    {
        _text.text = (selectedLang == (int)LangNamespace.Language.Turkish) ? trText : enText;
    }
    public void TranslateTextMesh(TextMeshProUGUI _text, string enText, string trText)
    {
        _text.text = (selectedLang == (int)LangNamespace.Language.Turkish) ? trText : enText;       
    }

    public void SetChangeLang()
    {
        FindObjectOfType<MainMenuText>().langChanged = true;
    }
}
