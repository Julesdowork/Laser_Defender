using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] [Range(0, 1f)] float damageVolume = 1f;

    public void PlayShootingSound()
    {
        PlaySound(shootingSound, shootingVolume);
    }

    public void PlayDamageSound()
    {
        PlaySound(damageSound, damageVolume);
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
