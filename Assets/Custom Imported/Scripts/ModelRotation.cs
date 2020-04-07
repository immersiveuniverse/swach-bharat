using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ModelRotation : MonoBehaviour {


	Animator animPlayPause;
	VideoPlayer videoPlay;

	public GameObject TextObjects;

	bool isPlay = false;
	bool isShow = false;
	bool isVideo = false;

	public Button btnPlay;
	public Text txtPlay;
	public Sprite spritePlay;
	public Sprite spritePause;

	public Button btnHide;
	public Text txtHide;
	public Sprite spriteHide;
	public Sprite spriteShow;


	Vector3 initialPosition;
	Vector3 initialRotation;
	Vector3 initialScale;


	void Start(){
		animPlayPause = GetComponent<Animator> ();
		videoPlay = GetComponent<VideoPlayer> ();

		//initialPosition = transform.position;
		//initialRotation = transform.eulerAngles;
		//initialScale = transform.localScale;

	}

	public void PlayPauseAnim(){
		if(isPlay){
			animPlayPause.enabled = false;

			btnPlay.GetComponent<Image> ().sprite = spritePlay;
			txtPlay.text = "Play";

			isPlay = false;
		}else{
			animPlayPause.enabled = true;

			btnPlay.GetComponent<Image> ().sprite = spritePause;
			txtPlay.text = "Pause";

			isPlay = true;
		}
	}

	public void PlayPauseVideo(){
		if(isVideo){
			//animPlayPause.enabled = false;
			videoPlay.enabled = false;
			btnPlay.GetComponent<Image> ().sprite = spritePlay;
			txtPlay.text = "Play";

			isVideo = false;
		}else{
			//animPlayPause.enabled = true;
			videoPlay.enabled = true;
			btnPlay.GetComponent<Image> ().sprite = spritePause;
			txtPlay.text = "Pause";

			isVideo = true;
		}
	}

	public void HideShow(){
		if(isShow){
			TextObjects.SetActive (false);
			btnHide.GetComponent<Image> ().sprite = spriteShow;
			txtHide.text = "Show";

			isShow = false;
		}else{
			TextObjects.SetActive (true);

			btnHide.GetComponent<Image> ().sprite = spriteHide;
			txtHide.text = "Hide";

			isShow = true;
		}
	}

	public void ResetModel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}
