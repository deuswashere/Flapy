using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsApplier : MonoBehaviour
{
    [Header("Eklenecek Mixer Referansý")]
    public AudioMixer gameAudioMixer;  // Inspector'dan GameAudioMixer'ý sürükleyin

    private const string MUSIC_PARAM = "MusicVolume";
    private const string SFX_PARAM = "SfxVolume";
    private const string PREF_VOLUME = "prefVolume";

    void Start()
    {
        // 1) PlayerPrefs'ten kaydedilen slider deðerini al
        float savedVol = PlayerPrefs.GetFloat(PREF_VOLUME, 1f);

        // 2) Desibele dönüþtür ve mixer'a uygula
        float dB = Mathf.Log10(Mathf.Clamp(savedVol, 0.0001f, 1f)) * 20f;
        gameAudioMixer.SetFloat(MUSIC_PARAM, dB);
        gameAudioMixer.SetFloat(SFX_PARAM, dB);
    }
}
