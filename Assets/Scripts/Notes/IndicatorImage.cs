using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorImage : Singleton<IndicatorImage>
{
    public Sprite[] images;
    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeIndicatorImage(Arrows arrow)
    {
        switch (arrow)
        {
            case Arrows.None:
                GetComponent<Image>().sprite = images[0];
                break;
            case Arrows.Up:
                GetComponent<Image>().sprite = images[1];
                break;
            case Arrows.Down:
                GetComponent<Image>().sprite = images[2];
                break;
            case Arrows.Left:
                GetComponent<Image>().sprite = images[3];
                break;
            case Arrows.Right:
                GetComponent<Image>().sprite = images[4];
                break;
        }
    }
}
