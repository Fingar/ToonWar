using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioBGM
{
    public string Name = "bgm_type_song00";
    public AudioClip Clip;
    public float Volume = 1;
    public float Pan = 0;
    public float Pitch = 1;
}

[System.Serializable]
public class AudioSFX
{
    public string Name = "sfx_type_sound00";
    public AudioClip[] Clips;
    [Range(0, 1)]
    public float Volume = 1;
    [Range(0, 1)]
    public float RndVolume = 0;
    [Range(-1, 1)]
    public float Pan = 0;
    [Range(-3, 3)]
    public float Pitch = 1;
    [Range(0, 1)]
    public float RndPitch = 0;
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public List<AudioSFX> SoundEffects;
    public List<AudioBGM> BackgroundMusic;

    public AudioMixerGroup MixerGroupSFX;
    public AudioMixerGroup MixerGroupBGM;

    private Transform sfxParent;
    private Transform bgmParent;

    // Use this for initialization
    void Awake () {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        Instantiate();
    }

    AudioSFX GetSFXFromName(string name)
    {
        return SoundEffects.Find(x => x.Name == name);
    }

    AudioBGM GetBGMFromName(string name)
    {
        return BackgroundMusic.Find(x => x.Name == name);
    }

    void Instantiate()
    {
        sfxParent = new GameObject("Audio_SFX").transform;
        sfxParent.SetParent(transform);
        bgmParent = new GameObject("Audio_BGM").transform;
        bgmParent.SetParent(transform);
    }

    public void PlaySFX(string key)
    {
        AudioSFX sfx = GetSFXFromName(key);
        if(sfx != null)
        {
            GameObject g = new GameObject("" + sfx.Name);
            g.transform.SetParent(sfxParent);

            AudioSource a = g.AddComponent<AudioSource>();
            a.clip = sfx.Clips[Random.Range(0, sfx.Clips.Length - 1)];
            a.outputAudioMixerGroup = MixerGroupSFX;
            a.volume = sfx.Volume + Random.Range(-sfx.RndVolume, sfx.RndVolume);
            a.panStereo = sfx.Pan;
            a.pitch = sfx.Pitch + Random.Range(-sfx.RndPitch, sfx.RndPitch);
            a.Play();
            Destroy(g, a.clip.length);
        }
        else
            Debug.Log("SFX by the name: " + key + " was not found.");
    }

    public void PlayBGM(string key)
    {
        AudioBGM bgm = GetBGMFromName(key);
        if (bgm != null)
        {
            GameObject g = new GameObject("" + bgm.Name);
            g.transform.SetParent(bgmParent);

            AudioSource a = g.AddComponent<AudioSource>();
            a.clip = bgm.Clip;
            a.outputAudioMixerGroup = MixerGroupSFX;
            a.panStereo = bgm.Pan;
            a.Play();
            Destroy(g, a.clip.length);
        }
        else
            Debug.Log("BGM by the name: " + key + " was not found.");
    }
}
