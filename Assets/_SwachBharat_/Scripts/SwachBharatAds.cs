using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SwachBharatAds : MonoBehaviour
{
    private readonly string _swachBharatUnityID = "3463018";
    private readonly string placementID = "bannerPlacement";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(_swachBharatUnityID, true);    
    }

    public void SimpleAd() {
        Advertisement.Show();
    }

    public void AutoAd() {
        StartCoroutine(ShowAutoAD());
    }
    
    
    IEnumerator ShowAutoAD()
    {
        while (!Advertisement.IsReady())
        {
            yield return new WaitForSeconds(10f);
        }
        Advertisement.Show();
    }
}
