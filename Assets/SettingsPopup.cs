using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {

    public Toggle difficultyToggle;
    public AudioMixer master;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenPopup()
    {
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void SetVolumeMusic(Slider slider)
    {
        float vol = slider.value;
        master.SetFloat("Music", vol);
    }

    public void SetVolumeAmbient(Slider slider)
    {
        float vol = slider.value;
        master.SetFloat("Ambient", vol);
    }

    public void SetVolumeSfx(Slider slider)
    {
        float vol = slider.value;
        master.SetFloat("Sfx", vol);
    }

}
