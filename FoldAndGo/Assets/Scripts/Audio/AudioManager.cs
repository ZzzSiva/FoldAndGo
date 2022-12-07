using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    private const string BACKGROUND_MUSIC = "BackgroundMusic";
    public const string  MISSILE_ALARM    = "Alarm";
    public const string  MISSILE_BOOST    = "MissileBoost";
    public const string  BUTTON_HOVER     = "ButtonHover";
    public const string  BUTTON_CLICK     = "ButtonClick";

    private void Awake() {
        if(instance != null) {
            Destroy(gameObject);
            return;
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach(Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip   = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch  = sound.pitch;
            sound.source.loop   = sound.loop;
        }
    }

    private void Start() {
        playSound(BACKGROUND_MUSIC);
    }

    public void playSound(string name) {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if(sound == null) {
            Debug.LogWarning("Sound: " + name + "not found !");
            return;
        }

        sound.source.Play();
    }

    public void stopSound(string name) {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if(sound == null) {
            Debug.LogWarning("Sound: " + name + "not found !");
            return;
        }

        sound.source.Stop();
    }
}
