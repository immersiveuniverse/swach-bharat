using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class MenuActivator : MonoBehaviour, ITrackableEventHandler
{
	public GameObject menu_10;
	public GameObject menu_100;
	public GameObject menu_500;
	public GameObject menu_2000;
	public GameObject menu_200;
	public GameObject menu_50;

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

	#region PUBLIC_METHODS

	/// <summary>
	///     Implementation of the ITrackableEventHandler function called when the
	///     tracking state changes.
	/// </summary>
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
			if(mTrackableBehaviour.TrackableName == "10"){
				menu_10.SetActive (true);
				menu_100.SetActive (false);
				menu_500.SetActive (false);
				menu_2000.SetActive (false);
				menu_50.SetActive (false);
				menu_200.SetActive (false);

			}
			else if(mTrackableBehaviour.TrackableName == "100"){
				menu_10.SetActive (false);
				menu_100.SetActive (true);
				menu_500.SetActive (false);
				menu_2000.SetActive (false);
				menu_50.SetActive (false);
				menu_200.SetActive (false);

			}
			else if(mTrackableBehaviour.TrackableName == "500"){
				menu_10.SetActive (false);
				menu_100.SetActive (false);
				menu_500.SetActive (true);
				menu_2000.SetActive (false);
				menu_50.SetActive (false);
				menu_200.SetActive (false);

			}
			else if(mTrackableBehaviour.TrackableName == "2000"){
				menu_10.SetActive (false);
				menu_100.SetActive (false);
				menu_500.SetActive (false);
				menu_2000.SetActive (true);
				menu_50.SetActive (false);
				menu_200.SetActive (false);

			}
			else if(mTrackableBehaviour.TrackableName == "200"){
				menu_10.SetActive (false);
				menu_100.SetActive (false);
				menu_500.SetActive (false);
				menu_2000.SetActive (false);
				menu_50.SetActive (false);
				menu_200.SetActive (true);

			}
			else if(mTrackableBehaviour.TrackableName == "50"){
				menu_10.SetActive (false);
				menu_100.SetActive (false);
				menu_500.SetActive (false);
				menu_2000.SetActive (false);
				menu_50.SetActive (true);
				menu_200.SetActive (false);

			}
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NO_POSE)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			//OnTrackingLost();
		}
		else
		{
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			//OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS

}
