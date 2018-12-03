using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPass : MonoBehaviour {

    public GameObject winTextPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            CharacterCtrl ownerScript = other.transform.root.GetComponent<CharacterCtrl>();
            if (ownerScript != null && ownerScript.enabled)
            {
                winTextPanel.SetActive(true);
            }
        }
    }
}
