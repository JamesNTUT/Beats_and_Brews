using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class RecordPlayer : MonoBehaviour
{
    public GameObject _record;
    public GameObject[] _record2;
    public static RecordPlayer Instance {get; private set;}
    public AudioClip[] _songList;
    public AudioSource _songPlaying;
    public int _songNumber = 0;
    public bool _songIsPlaying = false;
    public GameObject _stopUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("RecordPlayer Instance is set");
        }
    }

    void Update()
    {
        _record.transform.Rotate(0,2,0);
    }

    public void RecordUpdate1()
    {
        _songNumber = 0;
    }
    public void RecordUpdate2()
    {
        _songNumber = 1;
    }
    public void RecordUpdate3()
    {
        _songNumber = 2;
    }

    public void PlayRecord()
    {
        Debug.Log("Record is Playing");
        GameObject _objWithScript = GameObject.Find("Player");
        if (_objWithScript != null)
        {
            Crosshair _Script = _objWithScript.GetComponent<Crosshair>();
            _record = _Script._recordPlaying;
            _songIsPlaying = true;
        }
        if(_songIsPlaying == true)
        {
            Debug.Log("Cock");
            _songPlaying = GetComponent<AudioSource>();
            _songPlaying.clip = _songList[_songNumber];
            _songPlaying.Play();
        }
    }
    public void StopRecord()
    {
        Debug.Log("Record stopped playing");
        _songIsPlaying = false;
        if (_songIsPlaying == false)
        {
            _songPlaying.Pause();
            Renew();
        }
    }

    public void Renew()
    {
        Instantiate(_record2[_songNumber]);
    }
}
