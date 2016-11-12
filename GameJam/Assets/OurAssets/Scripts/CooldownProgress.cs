using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownProgress : MonoBehaviour {

	public Transform loadingBar;
	public Transform icon;
	public Sprite loadingBarInactive;
	public Sprite loadingBarActive;
	public Sprite inactiveMaterial;
	public Sprite activeMaterial;
	public bool clicked;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;
	
	// Update is called once per frame
	void Update () {
		if (clicked) {
			icon.GetComponent<Button> ().interactable = false;
			if (currentAmount < 100) {
				currentAmount += speed * Time.deltaTime;
			} else {
				icon.GetComponent<Image> ().sprite = activeMaterial;
				this.GetComponent<Image> ().sprite = loadingBarActive;
				icon.GetComponent<Button> ().interactable = true;
				clicked = false;
				currentAmount = 0;
			}
			loadingBar.GetComponent<Image> ().fillAmount = currentAmount / 100;
		}
	}

	public void clickBtn(){
		clicked = true;
		icon.GetComponent<Image> ().sprite = inactiveMaterial;
	}
}
