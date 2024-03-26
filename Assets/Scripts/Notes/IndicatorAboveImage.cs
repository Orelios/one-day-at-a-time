using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorAboveImage : Singleton<IndicatorAboveImage>
{
    public Sprite[] aboveImageIndicator; 
    public float returnDelay;
    //public bool preserveAspect
    public void Start()
    {
        GetComponent<Image>().sprite = aboveImageIndicator[4];
    }
    public void ChangeAboveIndicatorImage()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            GetComponent<Image>().sprite = aboveImageIndicator[0];
            GetComponent<Image>().preserveAspect = true;
            SoundEffectManager.Instance.PlayEarlySound();
            //CatSpriteChanger.Instance.CatEarlyOrLate();
            //GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            GetComponent<Image>().sprite = aboveImageIndicator[1];
            GetComponent<Image>().preserveAspect = true;
            SoundEffectManager.Instance.PlayPerfectSound();
            //CatSpriteChanger.Instance.CatPerfect();
            //GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            GetComponent<Image>().sprite = aboveImageIndicator[2];
            GetComponent<Image>().preserveAspect = true;
            SoundEffectManager.Instance.PlayLateSound();
            //CatSpriteChanger.Instance.CatEarlyOrLate();
            //GetComponent<SpriteRenderer>().color = Color.blue;
        }
        StartCoroutine(RetrunToOriginal());
    }

    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(returnDelay);
        //GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Image>().sprite = aboveImageIndicator[4];
        GetComponent<Image>().preserveAspect = true;
    }

    public void MissChangeAboveIndicatorImage()
    {
        GetComponent<Image>().sprite = aboveImageIndicator[3];
        GetComponent<Image>().preserveAspect = true;
        //GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(RetrunToOriginal());
    }
}
