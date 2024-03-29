using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManipulatorNoTab : Singleton<BarManipulatorNoTab>
{
    public ProgressBar progressBar;
    public FocusBar focusBar;
    public NoteDetection detector;
    public float progressDecPerSecFocusBar;
    private void Start()
    {
        focusBar.progressDecPerSec = progressDecPerSecFocusBar;
    }
    private void Update()
    {
        if (FocusBar.Instance.GetComponent<Image>().fillAmount >= 1)
        {
            EndRhythmScreen.Instance.StopGame();
        }

        if(FocusBar.Instance.GetComponent<Image>().fillAmount >= 0.66f)
        {
            CatSpriteChanger.Instance.CatTired();
        }
    }
    public void AddSmall()
    {
        progressBar.AddProgressSmall();
        focusBar.AddProgressMedium();
    }

    public void AddMedium()
    {
        progressBar.AddProgressMedium();
        focusBar.AddProgressLarge();
    }

    public void AddLarge()
    {
        progressBar.AddProgressLarge();
        focusBar.AddProgressLarge();
    }

    public void SubtractSmall()
    {
        progressBar.SubtractProgressSmall();
        focusBar.SubtractProgressSmall();
    }

    public void SubtractMedium()
    {
        progressBar.SubtractProgressMedium();
        focusBar.SubtractProgressMedium();
    }

    public void SubtractLarge()
    {
        progressBar.SubtractProgressLarge();
        focusBar.SubtractProgressLarge();
    }

    public void PlayerMiss()
    {
        progressBar.SubtractProgressMedium();
        focusBar.AddProgressLarge();
    }
}
