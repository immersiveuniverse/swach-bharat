using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class TargetController : MonoBehaviour, ITrackableEventHandler {

	#region PROTECTED_MEMBER_VARIABLES
	protected TrackableBehaviour mTrackableBehaviour;
	protected TrackableBehaviour.Status m_PreviousStatus;
	protected TrackableBehaviour.Status m_NewStatus;
	#endregion // PROTECTED_MEMBER_VARIABLES


	#region UNITY_MONOBEHAVIOUR_METHODS
	protected virtual void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
	}

	protected virtual void OnDestroy()
	{
		if (mTrackableBehaviour)
			mTrackableBehaviour.UnregisterTrackableEventHandler(this);
	}
	#endregion // UNITY_MONOBEHAVIOUR_METHODS

	public GameObject[] imageTargets;
	#region PUBLIC_METHODS
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		m_PreviousStatus = previousStatus;
		m_NewStatus = newStatus;

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			Debug.Log("ADSO Controller" + mTrackableBehaviour.TrackableName + " found");

			if(mTrackableBehaviour.TrackableName == "10"){
				imageTargets[1].SetActive (false);
				imageTargets[0].SetActive (true);
			}

			else if(mTrackableBehaviour.TrackableName == "100"){
				imageTargets[1].SetActive (true);
				imageTargets[0].SetActive (false);
			}

			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NO_POSE)
		{
			Debug.Log("ADSO " + mTrackableBehaviour.TrackableName + " lost");
			OnTrackingLost();
		}
		else
		{
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS

	#region PROTECTED_METHODS

	protected virtual void OnTrackingFound()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		// Enable rendering:
		foreach (var component in rendererComponents)
			component.enabled = true;

		// Enable colliders:
		foreach (var component in colliderComponents)
			component.enabled = true;

		// Enable canvas':
		foreach (var component in canvasComponents)
			component.enabled = true;
	}


	protected virtual void OnTrackingLost()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		// Disable rendering:
		foreach (var component in rendererComponents)
			component.enabled = false;

		// Disable colliders:
		foreach (var component in colliderComponents)
			component.enabled = false;

		// Disable canvas':
		foreach (var component in canvasComponents)
			component.enabled = false;
	}

	#endregion // PROTECTED_METHODS
}
