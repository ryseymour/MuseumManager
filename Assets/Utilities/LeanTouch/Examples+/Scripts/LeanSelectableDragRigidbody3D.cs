using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to drag this rigidbody when selected
	[RequireComponent(typeof(Rigidbody))]
	public class LeanSelectableDragRigidbody3D : LeanSelectableBehaviour
	{
		[Tooltip("The camera we will be used (None = MainCamera)")]
		public Camera Camera;

		private Vector2 screenOffset;

		private Rigidbody cachedRigidbody;

		protected override void OnSelect(LeanFinger finger)
		{
			base.OnSelect(finger);

			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera != null)
			{
				// Calculate finger offset
				var screenPosition = (Vector2)camera.WorldToScreenPoint(transform.position);

				screenOffset = screenPosition - finger.ScreenPosition;
			}
		}

		protected virtual void Update()
		{
			// Is this GameObject selected?
			if (Selectable.IsSelected == true)
			{
				// Does it have a selected finger?
				var finger = Selectable.SelectingFinger;

				if (finger != null)
				{
					// Make sure the camera exists
					var camera = LeanTouch.GetCamera(Camera, gameObject);

					if (camera != null)
					{
						// Store old position
						var oldPosition = transform.position;

						// Screen position of the transform and offset
						var screenPosition    = camera.WorldToScreenPoint(oldPosition);
						var newScreenPosition = finger.ScreenPosition + screenOffset;

						screenPosition.x = newScreenPosition.x;
						screenPosition.y = newScreenPosition.y;

						// Convert back to world space
						var newPosition = camera.ScreenToWorldPoint(screenPosition);

						// Apply velocity to move rigidbody toward target position
						if (cachedRigidbody == null) cachedRigidbody = GetComponent<Rigidbody>();

						cachedRigidbody.velocity = (newPosition - oldPosition) / Time.fixedDeltaTime;
					}
				}
			}
		}
	}
}