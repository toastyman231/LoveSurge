using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject[] tabs;
    int pageNum = 1;
    public void OnSelect()
    {
        instructions.SetActive(true);
    }
    public void onExitSelect()
    {
        instructions.SetActive(false);
    }

    public void TurnOnTabs(int t)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[t - 1].SetActive(true); 
    }
}
