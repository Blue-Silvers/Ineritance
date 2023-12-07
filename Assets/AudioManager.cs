using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private float Volume = 1.0f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI VolumeTxt;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            Volume = PlayerPrefs.GetFloat("Volume");
        }
        volumeSlider.value = Volume;
        ModifyVolume();
    }

    public void ModifyVolume()
    {
        Volume = volumeSlider.value;
        VolumeTxt.text = string.Format("{0:00}", Volume * 100);
        audioSource.volume = Volume;
        PlayerPrefs.SetFloat("Volume", Volume);
    }
}
