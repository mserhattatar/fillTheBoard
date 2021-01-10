using System.Collections.Generic;
using UnityEngine;


public class ButtonListManager : MonoBehaviour
{
    public static ButtonListManager instance;
    
    public List<GameObject> Button10 = new List<GameObject>();
    public List<GameObject> Button20 = new List<GameObject>();
    public List<GameObject> Button30 = new List<GameObject>();
    public List<GameObject> Button40 = new List<GameObject>();
    public List<GameObject> Button50 = new List<GameObject>();
    public List<GameObject> Button60 = new List<GameObject>();
    public List<GameObject> Button70 = new List<GameObject>();
    public List<GameObject> Button80 = new List<GameObject>();
    public List<GameObject> Button90 = new List<GameObject>();
    public List<GameObject> Button100 = new List<GameObject>();
    
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
        GamePlate.Add(Button10);
        GamePlate.Add(Button20);
        GamePlate.Add(Button30);
        GamePlate.Add(Button40);
        GamePlate.Add(Button50);
        GamePlate.Add(Button60);
        GamePlate.Add(Button70);
        GamePlate.Add(Button80);
        GamePlate.Add(Button90);
        GamePlate.Add(Button100);
    }
    
    

   
}
