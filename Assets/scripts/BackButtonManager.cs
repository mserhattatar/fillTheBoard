using UnityEngine;

public class BackButtonManager : MonoBehaviour
{
   private bool buttonOnOf;
   public int backButtonCount2;
   public static BackButtonManager instance;
   public GameObject backButton;
   public Animator anim;

    private void Awake()
   {
      instance = this;
   }

   private void Start()
   {
        backButtonCount2 = 1;
        anim = backButton.GetComponent<Animator>();
    }

   private void Update()
   {
      BackButtonOnOf();

       
   }    
   
   private void BackButtonOnOf()
   {    
      if (backButtonCount2 <= 0 && !buttonOnOf)
        {
            anim.SetBool("StepBackAnimation", false);
            print(backButtonCount2 +"back button of");
            ButtonManager.ButtonColorGrey(backButton);
            backButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = new Color(0.6132f, 0.6132f, 0.6132f, 1f);
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

    public void StepBackAnimation()
    {
        anim.SetBool("StepBackAnimation", true);
    }
}
