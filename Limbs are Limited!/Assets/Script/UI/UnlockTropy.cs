using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt;

public class UnlockTropy : MonoBehaviour {

    public int trophyID;

	// Use this for initialization

	void Start () {
        // Get the callback as soon as the user is signed-in.
        bool isSignedIn = GameJolt.API.GameJoltAPI.Instance.HasSignedInUser;
        if (!isSignedIn)
        {
            GameJolt.UI.GameJoltUI.Instance.ShowSignIn((bool signInSuccess) => {
                if (signInSuccess)
                {
                    GameJolt.API.Trophies.Unlock(trophyID, (bool success) => {
                        if (success)
                        {
                            Debug.Log("Success!");
                        }
                        else
                        {
                            Debug.Log("Something went wrong");
                        }
                    });
                }
                else
                {
                    Debug.Log("signIn fail");
                }
            });
        }
        else
        {
            GameJolt.API.Trophies.Unlock(trophyID, (bool success) => {
                if (success)
                {
                    Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Something went wrong");
                }
            });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
