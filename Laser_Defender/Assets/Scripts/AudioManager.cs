using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] [Range(0, 1f)] float damageVolume = 1f;

    void Awake()
    {
        ManageSingleton();
    }

    public AudioManager GetInstance()
    {
        return instance;
    }

    public void PlayShootingSound()
    {
        PlaySound(shootingSound, shootingVolume);
    }

    public void PlayDamageSound()
    {
        PlaySound(damageSound, damageVolume);
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
