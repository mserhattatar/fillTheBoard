using System.Collections.Generic;
using UnityEngine;


public class ButtonListManager : MonoBehaviour
{
    public static ButtonListManager instance;
    
    public List<GameObject> Button1 = new List<GameObject>();
    public List<GameObject> Button2 = new List<GameObject>();
    public List<GameObject> Button3 = new List<GameObject>();
    public List<GameObject> Button4 = new List<GameObject>();
    public List<GameObject> Button5 = new List<GameObject>();
    public List<GameObject> Button6 = new List<GameObject>();
    public List<GameObject> Button7 = new List<GameObject>(); 
    
    public List<GameObject> EmtyNumberButton = new List<GameObject>();
    public List<List<GameObject>> GamePlate = new List<List<GameObject>>();
    public List<GameObject> WriteList = new List<GameObject>();
    
    private void Awake()
    {
        instance = this;
        AddGamePlate();
    }
    
    private void AddGamePlate()
    {
        GamePlate.Add(Button1);
        GamePlate.Add(Button2);
        GamePlate.Add(Button3);
        GamePlate.Add(Button4);
        GamePlate.Add(Button5);
        GamePlate.Add(Button6);
        GamePlate.Add(Button7);
    }
}
