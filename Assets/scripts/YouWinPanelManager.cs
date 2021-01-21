using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinPanelManager : MonoBehaviour
{
    public void CloseYouWinPanel()
    {
        this.gameObject.SetActive(false);
    }
}
