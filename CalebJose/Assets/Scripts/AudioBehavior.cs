using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehavior : MonoBehaviour
{
    public static AudioSource Source;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Source = audioSource;
    }
}
