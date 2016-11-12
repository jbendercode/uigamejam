using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseComponents : MonoBehaviour {

    bool isVR = false;
    bool isTablet = false;


	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "main") {
            isVR = true;
        }

        if (SceneManager.GetActiveScene().name == "maint")
        {
            isTablet = true;
        }
        //Debug.Log("VR" + isVR);
        toggleComponents();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void toggleComponents() {
        if (isVR)
        {
            gameObject.GetComponent<VRStandardAssets.ShootingGallery.ShootingTarget>().enabled = true;
            gameObject.GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().enabled = true;
        }
        else {
            gameObject.GetComponent<MoveEnemy>().enabled = true;
        }
    }
}
