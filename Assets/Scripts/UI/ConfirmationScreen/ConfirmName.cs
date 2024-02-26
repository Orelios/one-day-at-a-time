using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmName : Singleton<ConfirmName>
{
    TextMeshProUGUI text;
    public RhythmStats confirmRef;

    public void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetAsReference(GameObject x)
    {
        confirmRef = x.GetComponent<RhythmStats>();
        if (string.IsNullOrEmpty(confirmRef.stats.activityName))
        {
            text.text = confirmRef.stats.name;
        }
        else
        {
            text.text = confirmRef.stats.activityName;
        }
    }
}
