using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusBar : MonoBehaviour
{
    public Image currentFocusBarIndicator; 
    Image image;
    [SerializeField] private float maxProgress = 100.0f;
    [SerializeField] private float progress;
    [SerializeField] private float progressDecPerSec = 1.0f;
    [SerializeField] private float small;
    [SerializeField] private float medium;
    [SerializeField] private float large;

    void Start()
    {
        image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        image.fillAmount = progress / maxProgress;
    }

    // Update is called once per frame
    void Update()
    {
        progress -= Time.deltaTime * progressDecPerSec;
        if (progress <= 0)
        {
            progress = 0.0f;
        }
        if (progress >= 100)
        {
            progress = 100.0f;
            //EndRhythmScreen.Instance.StopGame();
        }
        image.fillAmount = progress / maxProgress;
    }

    public void AddProgressSmall()
    {
        progress += small;
    }

    public void AddProgressMedium()
    {
        progress += medium;
    }

    public void AddProgressLarge()
    {
        progress += large;
    }

    public void SubtractProgressSmall()
    {
        progress -= small;
    }

    public void SubtractProgressMedium()
    {
        progress -= medium;
    }

    public void SubtractProgressLarge()
    {
        progress -= large;
    }

    public float GetProgress()
    {
        return progress;
    }
}