using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public ProgressBar progressBar;
    [SerializeField] private float[] progressLevels = {33.0f, 66.0f};
    public AudioSource[] audios;

    void Update()
    {
        float audioTime = GetComponentInParent<AudioSource>().time;
        for (int i = 0; i < audios.Length; i++)
        {
            if (progressBar.GetProgress() >= progressLevels[i] && !audios[i].isPlaying)
            {
                audios[i].time = audioTime;
                audios[i].Play();
            }
            if (progressBar.GetProgress() < progressLevels[i] && audios[i].isPlaying)
            {
                audios[i].Stop();
            }
        }
    }
}