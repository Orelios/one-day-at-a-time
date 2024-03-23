using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractReference : Singleton<InteractReference>
{
    public GameObject bed;
    public GameObject task;
    void Start()
    {
        NotInteracting();
    }
    public void PlayerInteractBed()
    {
        bed.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        bed.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void PlayerInteractTask()
    {
        task.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        task.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void NotInteracting()
    {
        bed.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        bed.transform.GetChild(1).gameObject.SetActive(false);
        task.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        task.transform.GetChild(1).gameObject.SetActive(false);
    }

}