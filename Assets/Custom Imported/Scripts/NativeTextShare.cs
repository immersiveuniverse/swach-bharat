using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NativeTextShare : MonoBehaviour {

	string shareSubject = "Amartya";
	string shareMessage ="Amartya means immortal in our sanskrit language." +
		"This application is created to aware the masses about the freedom fighters that laid their lives for the freedom of our India. " +
		"Their contribution is a tribute towards the nation building & we as Indians have to carry that legacy to make their vision about India a reality."+
		"https://play.google.com/store/apps/details?id=com.ic.arjana";

	public void OnAndroidTextSharingClick()
	{

		StartCoroutine(ShareTextInAnroid());

	}


	IEnumerator ShareTextInAnroid () {
		yield return new WaitForEndOfFrame();
		#if UNITY_ANDROID
		if (!Application.isEditor) {
			//Create intent for action send
			AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
			intentObject.Call<AndroidJavaObject> 
			("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));

			//put text and subject extra
			intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
			intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), shareSubject);
			intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), shareMessage);

			//call createChooser method of activity class
			AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
			AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, "Your Support Means A Lot | Thanks");
			currentActivity.Call ("startActivity", chooser);
		#endif
		}
	}
}