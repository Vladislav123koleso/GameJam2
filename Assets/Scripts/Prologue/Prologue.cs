
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Prologue : MonoBehaviour
{
    [SerializeField] private bool playStart;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<string> strings = new List<string>();
    [SerializeField] private List<AudioClip> audioClip = new List<AudioClip>();

    private AudioSource audioSource;
    [SerializeField] private Image Image;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private AudioMixer audioMixerMusic;

    [SerializeField] private UnityEvent EndPrologue;

    private int index = 0;

    private void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (playStart)
        {
            gameObject.SetActive(true);
            DrawAndPlay();
            audioMixerMusic.SetFloat("MasterVolume", -25);
        }
    }

    private void DrawAndPlay()
    {
        Image.sprite = sprites[index];
        text.text = strings[index];
        if (audioClip[index] != null)
        {
            audioSource.clip = audioClip[index];
            audioSource.Play();
        }

    }
    public void NextPage()
    {
        index += 1;
        if (index < sprites.Count)
        {
            DrawAndPlay();
        }
        else
        {
            gameObject.SetActive(false);
            audioMixerMusic.SetFloat("MasterVolume", -10);
            EndPrologue.Invoke();
        }
    }

    public void StartPrologue()
    {
        gameObject.SetActive(true);
        DrawAndPlay();
        audioMixerMusic.SetFloat("MasterVolume", -25);
    }
}
