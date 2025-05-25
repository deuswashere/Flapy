using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Referanslarý")]
    public Slider volumeSlider;    // Inspector’da Slider_Volume atayýn
    public Toggle musicToggle;     // Inspector’da Toggle_Music atayýn

    [Header("Audio Mixer")]
    public AudioMixer gameAudioMixer;   // Inspector’dan GameAudioMixer atayýn

    // Exposed parameter isimleri
    private const string MUSIC_PARAM = "MusicVolume";
    private const string SFX_PARAM = "SfxVolume";

    // PlayerPrefs anahtarlarý
    private const string PREF_VOLUME = "prefVolume";
    private const string PREF_MUSIC_ON = "prefMusicOn";

    void Start()
    {
        // Önceki ayarlarý yükle (varsayýlan: ses = 1, müzik açýk)
        float savedVol = PlayerPrefs.GetFloat(PREF_VOLUME, 1f);
        bool savedMusicOn = PlayerPrefs.GetInt(PREF_MUSIC_ON, 1) == 1;

        volumeSlider.value = savedVol;
        musicToggle.isOn = savedMusicOn;

        // Ýlk uygulama
        ApplyVolume(savedVol);
        ApplyMusicToggle(savedMusicOn);

        // Dinleyicileri baðla
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    void OnVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat(PREF_VOLUME, value);
        ApplyVolume(value);
    }

    void OnMusicToggleChanged(bool isOn)
    {
        PlayerPrefs.SetInt(PREF_MUSIC_ON, isOn ? 1 : 0);
        ApplyMusicToggle(isOn);
    }

    void ApplyVolume(float sliderValue)
    {
        // Slider deðeri [0.0001,1] aralýðýnda olmalý
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;

        // SFX kanalý her zaman slider ile kontrol edilir
        gameAudioMixer.SetFloat(SFX_PARAM, dB);

        // Music kanalý yalnýzca toggle açýkken slider deðerini alýr
        if (musicToggle.isOn)
            gameAudioMixer.SetFloat(MUSIC_PARAM, dB);
    }

    void ApplyMusicToggle(bool isOn)
    {
        if (isOn)
        {
            // Toggle açýldýysa slider’daki mevcut deðeri uygula
            float sliderValue = volumeSlider.value;
            float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
            gameAudioMixer.SetFloat(MUSIC_PARAM, dB);
        }
        else
        {
            // Toggle kapatýldýysa müziði tamamen sessize al
            gameAudioMixer.SetFloat(MUSIC_PARAM, -80f);
        }
    }
}
