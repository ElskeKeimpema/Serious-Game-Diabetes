using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private bool isPlaying;

    public bool IsPlaying{
        get{ return isPlaying; }
    }

    // Update is called once per frame
    void Update () {
        // If the player is playing in a level the method SetCamPos() is called
        if (isPlaying)
        {
            SetCamPos();
        }
	}

    // Set the camera position
    void SetCamPos() {
        transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
