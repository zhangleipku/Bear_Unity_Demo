using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NewBehaviourScript : MonoBehaviour {

	public AudioSource sound_yamete;
	public AudioSource sound_kusuguri;
	public AudioSource sound_kuraiyo;
	public AudioSource sound_guruguru;

	int TouchCount;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite8_2;

	public Button button;

	private bool isFaceDown;
	private int frameCounter;
	private int shakeCounter;

	// Use this for initialization
	void Start () {
		TouchCount = 0;
		frameCounter = 0;
		shakeCounter = 0;
		isFaceDown = false; 
	}

	// Update is called once per frame
	void Update () {

		frameCounter++;

		if ( frameCounter % 50 == 0 ) {
			frameCounter = 0;
			return;
		}

		if ( Input.acceleration.magnitude > 2f ) {

			shakeCounter++;

			if (shakeCounter > 30) {
				shakeCounter = 0;
				if (!sound_guruguru.isPlaying) {
					sound_guruguru.Play ();
				}
				button.image.overrideSprite = sprite8_2;
			}
		}

		if ( Input.deviceOrientation == DeviceOrientation.FaceDown ) {
			if ( isFaceDown == false ) {
				sound_kuraiyo.Play ();
				isFaceDown = true;
			}
		} else {
			sound_kuraiyo.Stop ();
			isFaceDown = false;
		}
	}

	public void OnTouch() {
		
		TouchCount++;

		if ( TouchCount % 4 == 0 ) {
			TouchCount = 0;
			sound_yamete.Stop ();
			sound_kusuguri.Play ();
			button.image.overrideSprite = sprite4;
		} 
		else {
			button.image.overrideSprite = sprite1;
			sound_yamete.Play ();
		}

	}
}
