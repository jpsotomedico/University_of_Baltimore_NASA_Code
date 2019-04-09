using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioPeer : MonoBehaviour {

    public AudioSource _audioSource;
    //microphone input
    public AudioClip _audioClip;
    public bool _useMicrophone;

    // Use this for initialization
    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
        if (_useMicrophone)
        {

        }
        if (!_useMicrophone)
        {
            _audioSource.clip = _audioClip;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
