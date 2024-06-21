using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource[] audioSources = new AudioSource[2];
    // Start is called before the first frame update
    void Start()
    {
        audioSources[0].Play();
        double delayTime = audioSources[0].clip.length;
        STimer timer = gameObject.AddComponent<STimer>();
        timer.StartTimer((float)delayTime, () =>
        {
            Destroy(audioSources[0]);
            audioSources[1].Play();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
