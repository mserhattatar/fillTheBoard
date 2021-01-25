using UnityEngine;

public class BackButtonManager : MonoBehaviour
{
   private bool isStepBackButtonOf;
   public int stepBackButtonCount;
   public static BackButtonManager instance;
   public GameObject backButton;
   private Animator anim;

    private void Awake()
    {
      instance = this;
    }

   private void Start()
   {
        stepBackButtonCount = 1;  //player have 1 step back
        anim = backButton.GetComponent<Animator>();
    }

   private void Update()
   {
        //Todo better
      StepBackButtonOf();       
   }    
   
   private void StepBackButtonOf()
    {   //close stepback button if there is no right to step back
        if (stepBackButtonCount <= 0 && !isStepBackButtonOf)
        {
            StepBackAnimation(false);
            ButtonManager.ButtonColorGrey(backButton);
            backButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = new Color(0.6132f, 0.6132f, 0.6132f, 1f);
            isStepBackButtonOf = true;
        }
   }
  
   public void BackButtonWrite()
   {//stepback button onclick func
      if (isStepBackButtonOf) return;
      if (ButtonListManager.instance.WriteList.Count <= 1) return;
        var writelist = ButtonListManager.instance.WriteList;
      writelist[writelist.Count - 1].GetComponent<ButtonController>().UndoWrite();
      stepBackButtonCount -= 1;
   }

    public void StepBackAnimation(bool tf)
    {
        anim.SetBool("StepBackAnimation", tf);
    }
}
