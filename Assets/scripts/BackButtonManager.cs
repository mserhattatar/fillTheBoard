using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class BackButtonManager : MonoBehaviour
{
   [FormerlySerializedAs("_backButtonCount")] public int backButtonCount2;
   public static BackButtonManager instance;
   public GameObject backButton;

   private void Awake()
   {
      instance = this;
   }

   private void Start()
   {
      backButtonCount2 = GameManager.instance.backButtonCount;
   }

   private void Update()
   {
      BackButtonOnOf();
   }
   private void BackButtonOnOf()
   { 
      if (backButtonCount2 >=1 && !backButton.activeInHierarchy)
      {
         backButton.SetActive(true);
      }
      else if (backButtonCount2<1 && backButton.activeInHierarchy)
      {
         backButton.SetActive(false);
      }
   }

   public void BackButtonWrite()
   {
      if(ButtonListManager.instance.WriteList.Count <=0) return;
      ButtonListManager.instance.WriteList[ButtonListManager.instance.WriteList.Count-1].
         GetComponent<ButtonController>().UndoWrite();
      backButtonCount2 -= 1;
   }

   public void BackButtonCountAdd()
   {
      backButtonCount2 += 1;
   }
}
