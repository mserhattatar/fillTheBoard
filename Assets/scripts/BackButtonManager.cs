using UnityEngine;

public class BackButtonManager : MonoBehaviour
{
   private bool buttonOnOf;
   public int backButtonCount2;
   public static BackButtonManager instance;
   public GameObject backButton;

   private void Awake()
   {
      instance = this;
   }

   private void Start()
   {
        backButtonCount2 = 1;
    }

   private void Update()
   {
      BackButtonOnOf();
   }
   
   private void BackButtonOnOf()
   {    
      if (backButtonCount2 <= 0 && !buttonOnOf)
        {
            print(backButtonCount2 +"back button of");
            ButtonManager.ButtonColorDirtyWhite(backButton);
            buttonOnOf = true;
        }
   }
  
   public void BackButtonWrite()
   {
        if (buttonOnOf) return;
      if (ButtonListManager.instance.WriteList.Count <= 1) return;
      ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count-1].
      GetComponent<ButtonController>().UndoWrite();
      backButtonCount2 -= 1;
   }
}
