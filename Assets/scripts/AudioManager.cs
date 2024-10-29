using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioClip[] Birdflying;
    public AudioClip  WoodCollision;
    public AudioClip  Shooter;
    public AudioClip Gamestart;
    public AudioClip Gameend;
    public AudioClip Boom;
    public AudioClip BoomShoot;
    public void Awake()
    {
        Instance = this;
    }
    public void PlayBirdFlying(Vector3 position,bool isplay)
    {
        if (isplay == true)
        {
            int randomindex = Random.Range(0, Birdflying.Length);
            AudioClip ac = Birdflying[randomindex];
            AudioSource.PlayClipAtPoint(ac, position, 1f);
        }
    }
    public void PlayWoodCollision(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(WoodCollision, position, 1f);
    }
    public void PlayShooter(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(Shooter, position, 10f);
    }
    public void PlayGameStart(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(Gamestart, position, 1f);
    } 
    public void PlayGameEnd(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(Gameend, position, .3f);
    } 
    public void PlayBoom(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(Boom, position, 6f);
    }
    public void PlayBoomShoot(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(BoomShoot, position, 1f);
    }

}
