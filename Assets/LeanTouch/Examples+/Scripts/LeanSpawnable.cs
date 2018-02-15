using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	// This script can be attached to prefabs so they can be used with the LeanDragSpawnUI script
	public class LeanSpawnable : MonoBehaviour
	{
		// Event signature
		[System.Serializable] public class LeanFingerEvent : UnityEvent<LeanFinger> {}

		// Called when this spawnable is released from the spawning finger
		public LeanFingerEvent OnReleased;

		// The distance from the finger this object is placed in world space
		[HideInInspector]
		public float Distance;

		// The finger used to spawn this
		[HideInInspector]
		public LeanFinger SpawnFinger;
		
		protected virtual void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerUp += OnFingerUp;
		}
		
		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerUp -= OnFingerUp;
		}

		protected virtual void Update()
		{
			// Does the spawn finger exist?
			if (SpawnFinger != null)
			{
				transform.position = SpawnFinger.GetWorldPosition(Distance);
			}
		}
		
		public void OnFingerUp(LeanFinger finger)
		{
			// Was the spawning finger released?
			if (finger == SpawnFinger)
			{
				// Run the OnReleased event
				OnReleased.Invoke(finger);
				
				// Reset the spawn finger
				SpawnFinger = null;
			}
		}
	}
}