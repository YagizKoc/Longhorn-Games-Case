using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    public void ChangeGraphicsQuality() {

        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    private void Awake()
    {
        //graphicsDropdown = GameObject.Find("Dropdown")?.GetComponent<TMP_Dropdown>();

    }

    public void ChangeMasterVolume()
    {
        Debug.Log("Master volume changed: " + masterVol.value);
        mainAudioMixer.SetFloat("MasterVol", masterVol.value);
        
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", musicVol.value);
        Debug.Log("Master volume changed: " + masterVol.value);
    }

    public void ChangeSfxVolume()
    {
        mainAudioMixer.SetFloat("EffectsVol", sfxVol.value);
        Debug.Log("Master volume changed: " + masterVol.value);
    }
}
