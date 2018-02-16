using UnityEngine;

namespace Lean.Touch
{
	// This script shows how you can spawn a new prefab by dragging it out of a UI element
	[RequireComponent(typeof(RectTransform))]
	public class LeanDragSpawnUI : MonoBehaviour
	{
		[Tooltip("The prefab that will spawn when dragging this UI element")]
		public LeanSpawnable Prefab;

		[Tooltip("The distance the prefabs are spawned from the dragging finger in world space")]
		public float Distance = 10.0f;
		
		protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerDown += OnFingerDown;
		}
		
		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerDown -= OnFingerDown;
		}
		
		public void OnFingerDown(LeanFinger finger)
		{
			// Does the prefab exist?
			if (Prefab != null)
			{
				// Get the RaycastResults under this finger's current position
				var results = LeanTouch.RaycastGui(finger.ScreenPosition);

				if (results.Count > 0)
				{
					// Is this finger over this UI element?
					if (results[0].gameObject == gameObject)
					{
						// Spawn prefab
						var instance = Instantiate(Prefab);

						// Assign finger
						instance.SpawnFinger = finger;

						// Assign distance
						instance.Distance = Distance;
					}
				}
			}
		}
	}
}