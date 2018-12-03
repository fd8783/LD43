using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour {

    public Transform spawnPlayer;

    private CharacterCtrl curPlayerScript;
    private AudioSource spawnSound;

	// Use this for initialization
	void Awake ()
    {
        spawnSound = GetComponent<AudioSource>();
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Spawn();
        }
	}

    void Spawn()
    {
        if (curPlayerScript != null && curPlayerScript.enabled)
        {
            curPlayerScript.Death();
        }
        curPlayerScript = Instantiate(spawnPlayer, transform.position, spawnPlayer.rotation).GetComponent<CharacterCtrl>();
        if (spawnSound.isPlaying)
        {
            spawnSound.Stop();
        }
        spawnSound.pitch = Random.Range(0.8f, 1.1f);
        spawnSound.volume = Random.Range(0.7f, 1f);
        spawnSound.Play();
    }
}
