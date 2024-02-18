using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndRhythmMentalHealth : MonoBehaviour
{
    private float currentMentalHealth;
    private float valueToAdd;

    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        currentMentalHealth = PlayerData.Instance.mentalHealth;
        valueToAdd = EndRhythmScreen.Instance.GetComponent<ManagementModifier>().changeInMentalHealth / (EndRhythmScreen.Instance.successPercent / 100);
        //change PlayerData value
        PlayerData.Instance.AddMentalHealth(valueToAdd);

        text.text = "Mental Health: " + currentMentalHealth + " + " + valueToAdd + " = " + PlayerData.Instance.mentalHealth;

        
    }
}
