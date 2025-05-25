using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Referanslarý")]
    public Slider volumeSlider;    // Inspector’da Slider_Volume atayýn

    [Header("Audio Mixer")]
    public AudioMixer gameAudioMixer;   // Inspector’dan GameAudioMixer atayýn

    // Exposed parameter isimleri (AudioMixer’da tam olarak bu adlarla expose ettiðiniz parametreler)
    private const string MUSIC_PARAM = "MusicVolume";
    private const string SFX_PARAM = "SfxVolume";

    // PlayerPrefs anahtarý
    private const string PREF_VOLUME = "prefVolume";

    void Start()
    {
        // Önceki ayarý yükle (varsayýlan: 1)
        float savedVol = PlayerPrefs.GetFloat(PREF_VOLUME, 1f);
        volumeSlider.value = savedVol;

        // Ýlk uygulama
        ApplyVolume(savedVol);

        // Slider deðiþimlerini dinle
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        // Yeni deðeri kaydet ve uygula
        PlayerPrefs.SetFloat(PREF_VOLUME, value);
        ApplyVolume(value);
    }

    void ApplyVolume(float sliderValue)
    {
        // [0.0001,1] aralýðýnda logaritmik desibel dönüþümü
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;

        // Hem Music hem SFX parametrelerine uygula
        gameAudioMixer.SetFloat(MUSIC_PARAM, dB);
        gameAudioMixer.SetFloat(SFX_PARAM, dB);
    }
}
