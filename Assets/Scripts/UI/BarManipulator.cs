using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManipulator : Singleton<BarManipulator>
{
    public ProgressBar progressBar;
    public FocusBar focusBar;
    public NoteDetection detector;
    private bool changeBar = false;
    //[SerializeField] private bool perArrow = false;
    //[SerializeField] private bool perPattern = false;
    private void Awake()
    {
        progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
        focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
    }
    private void Update()
    {
        ChangeBar(); 
    }

    public void ChangeBar()
    {
        if(Player.Instance.canPress == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                detector.DestroyNote();
                if (PatternManager.Instance._patternIndex >= PatternManager.Instance._patterns.Length - 1)
                {
                    PatternManager.Instance.LoopPatternArray();
                }
                else
                {
                    PatternManager.Instance.StartCoroutine(PatternManager.
                        Instance.Pulse(PatternManager.Instance._patternCurrent));
                }
                if (changeBar == false) //will change to focus bar
                {
                    changeBar = true;
                    progressBar.currentProgressBarIndicator.gameObject.SetActive(false);
                    focusBar.currentFocusBarIndicator.gameObject.SetActive(true);
                }
                else if(changeBar == true) // will change to progress bar
                { 
                    changeBar = false;
                    progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
                    focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
                } 
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddLarge();
        }
    }

    public void AddSmall()
    {
        if (changeBar == false) { progressBar.AddProgressSmall(); }
        if(changeBar == true) { focusBar.AddProgressSmall(); }
    }

    public void AddMedium()
    {
        if (changeBar == false) { progressBar.AddProgressMedium(); }
        if (changeBar == true) { focusBar.AddProgressMedium(); }
    }

    public void AddLarge()
    {
        if (changeBar == false) { progressBar.AddProgressLarge(); }
        if (changeBar == true) { focusBar.AddProgressLarge(); }
    }

    public void SubtractSmall()
    {
        if (changeBar == false) { progressBar.SubtractProgressSmall(); }
        if (changeBar == true) { focusBar.SubtractProgressSmall(); }
    }

    public void SubtractMedium()
    {
        if (changeBar == false) { progressBar.SubtractProgressMedium(); }
        if (changeBar == true) { focusBar.SubtractProgressMedium(); }
    }

    public void SubtractLarge()
    {
        if (changeBar == false) { progressBar.SubtractProgressLarge(); }
        if (changeBar == true) { focusBar.SubtractProgressLarge(); }
    }
}
