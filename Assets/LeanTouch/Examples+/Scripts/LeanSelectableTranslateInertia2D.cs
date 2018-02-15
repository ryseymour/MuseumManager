using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to transform the current GameObject with inertia
	[RequireComponent(typeof(Rigidbody2D))]
	public class LeanSelectableTranslateInertia2D : LeanSelectableBehaviour
	{
		[Tooltip("The camera we will be used (None = MainCamera)")]
		public Camera Camera;

		[System.NonSerialized]
		private Rigidbody2D cachedRigidbody;

		protected virtual void Update()
		{
			if (Selectable.IsSelected == true)
			{
				// Make sure the camera exists
				var camera = LeanTouch.GetCamera(Camera, gameObject);

				if (camera != null)
				{
					if (cachedRigidbody == null) cachedRigidbody = GetComponent<Rigidbody2D>();

					// Screen position of the transform
					var screenPosition = camera.WorldToScreenPoint(transform.position);
			
					// Add the deltaPosition
					screenPosition += (Vector3)LeanGesture.GetScreenDelta();
			
					// Convert back to world space
					transform.position = camera.ScreenToWorldPoint(screenPosition);

					// Reset velocity
					cachedRigidbody.velocity = Vector2.zero;
				}
			}
		}

		protected override void OnSelectUp(LeanFinger finger)
		{
			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera != null)
			{
				if (cachedRigidbody == null) cachedRigidbody = GetComponent<Rigidbody2D>();

				// Convert this GameObject's world position into screen coordinates and store it in a temp variable
				var screenPosition = camera.WorldToScreenPoint(transform.position);
				
				// Modify screen position by the finger's delta screen position over the past 0.1 seconds
				screenPosition += (Vector3)finger.GetSnapshotScreenDelta(0.1f);
				
				// Convert the screen position into world coordinates and subtract it by the old position to find the world delta over the past 0.1 seconds
				var worldDelta = camera.ScreenToWorldPoint(screenPosition) - transform.position;
				
				// Set the velocity and divide it by 0.1, because velocity is applied over 1 second, and our delta is currently only for 0.1 second
				cachedRigidbody.velocity = worldDelta / 0.1f;
			}
		}
	}
}