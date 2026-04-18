using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

[SerializeField] private AudioMixer myMixer;


public GameObject musicSliderGO;
public GameObject fxSliderGO;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider fxSlider;

  

    void Awake()
    {
        musicSlider = musicSliderGO.GetComponent<Slider>();
        fxSlider= fxSliderGO.GetComponent<Slider>();     
    }


    void OnEnable()
    {
        Debug.Log("Cargando Volumen");
        cargarVolumen();
    }


    public void SetMusicVolume(float volume)
    {
        // El slider suele ir de 0.0001 a 1, pero el Mixer usa Decibelios (-80 a 0)
        myMixer.SetFloat("MusicVol", Mathf.Lerp(-80f, -10f, volume));
        PlayerPrefs.SetFloat("SavedMusicVolume", volume);
    }


    public void SetSFXVolume(float volume)
    {
        myMixer.SetFloat("FxVol", Mathf.Lerp(-80f, -10f, volume));
        PlayerPrefs.SetFloat("SavedFXVolume", volume);
    }


    private void cargarVolumen()
    {
        float musicVol = PlayerPrefs.GetFloat("SavedMusicVolume", 0.75f);
        float fxVol = PlayerPrefs.GetFloat("SavedFXVolume", 0.75f);
        
        // Aplicar los valores cargados
        SetMusicVolume(musicVol);
        SetSFXVolume(fxVol);

        musicSlider.value = musicVol;
        fxSlider.value = fxVol;
    }





   
}
