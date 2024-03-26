using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRhythmMentalHealth : MonoBehaviour
{
    private float currentMentalHealth;
    private float valueToAdd;

    TextMeshProUGUI text;

    void OnEnable()
    {
        currentMentalHealth = PlayerData.Instance.mentalHealth;

        float min = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.mentalHealthMin;
        float max = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.mentalHealthMax;
        valueToAdd = min + ((max - min) * (EndRhythmScreen.Instance.successPercent / 100));

        //change PlayerData value
        Mathf.Round(valueToAdd);
        PlayerData.Instance.AddMentalHealth(valueToAdd);
        ChangeIcons();
        
    }

    private void ChangeIcons()
    {
        if (valueToAdd <= -25)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else if (valueToAdd <= -15)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= -9)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 9)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

            transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(4).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            transform.GetChild(5).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 15)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

            transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(4).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(5).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 25)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

            transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(4).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(5).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

    }
}
