using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	// This script will fire an event if 
	public class LeanFingerHeldAction : MonoBehaviour
	{
		// Event signature
		[System.Serializable] public class FingerEvent : UnityEvent<LeanFinger> {}

		[Tooltip("The minimum amount of seconds the target finger must have been pressed to call the event")]
		public float MinimumAge = 1.0f;

		// Called when a calling finger has been held for more than the target amount
		public FingerEvent OnFingerHeld;

		public void OnFinger(LeanFinger finger)
		{
			if (finger.Age >= MinimumAge)
			{
				OnFingerHeld.Invoke(finger);
			}
		}
	}
}