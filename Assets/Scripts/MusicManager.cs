using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    AudioSource _backMusicSource = null;
    AudioSource _SoundSource = null;
    public static MusicManager _instance;

	// Use this for initialization
	void Start () {
        _instance = this;
        _backMusicSource = gameObject.GetComponent<AudioSource>();
        _backMusicSource.loop = true;

        _SoundSource = gameObject.GetComponent<AudioSource>();

        PlayMusic("sound/game_music");
	}

    public void PlayMusic(string musicPath)
    {
        AudioClip clip = Resources.Load(musicPath, typeof(AudioClip)) as AudioClip;
        _backMusicSource.clip = clip;
        _backMusicSource.Play();
    }

    public void StopBGM()
    {
        _backMusicSource.Stop();
    }

    public void PlaySound(string soundPath)
    {
        AudioClip clip = Resources.Load(soundPath) as AudioClip;
        _SoundSource.PlayOneShot(clip);
    }
}
