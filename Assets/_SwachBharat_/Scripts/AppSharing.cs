using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.IO;

public class AppSharing : MonoBehaviour
{

    string shareSubject = "Swach Bharat";
    string shareMessage = "Experience 3D & AR Games with Swach Bharat Mission." +
        "Our Swach Bharat app gamifies the educational content into fun and challenging 3D Games including Augmented Reality based Games also." +
        "Our goal is to educate our Users regarding Swach Bharat through interactive medium without boring them with facts and figures." +
        "https://play.google.com/store/apps/details?id=com.vrarmr.swachbharat";

    public void OnAndroidTextSharingClick()
    {

        StartCoroutine(ShareTextInAnroid());

    }

    public void OnRatingUs() {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.vrarmr.swachbharat");
    }

    public void DownloadLogo() {
        Application.OpenURL("https://en.wikipedia.org/wiki/Swachh_Bharat_Mission#/media/File:Swachh_Bharat_Abhiyan_logo.jpg");
    }

    IEnumerator ShareTextInAnroid()
    {
        yield return new WaitForEndOfFrame();
        #if UNITY_ANDROID
        if (!Application.isEditor)
        {
            //Create intent for action send
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>
            ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            //put text and subject extra
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            //call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Users like You, motivates We to strive for best");
            currentActivity.Call("startActivity", chooser);
        #endif
        }
    }
}