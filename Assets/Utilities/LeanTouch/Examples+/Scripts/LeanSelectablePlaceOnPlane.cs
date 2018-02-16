using UnityEngine;

namespace Lean.Touch
{
	// This script will place this GameObject on the surface of a plane when selected
	public class LeanSelectablePlaceOnPlane : LeanSelectableBehaviour
	{
		[Tooltip("The camera we will be used (None = MainCamera)")]
		public Camera Camera;

		[Tooltip("The plane the GameObject will be placed on")]
		public LeanPlane Plane;

		[Tooltip("Keep this GameObject placed on the line even when not dragging?")]
		public bool AutoSnap;

		private Vector2 screenOffset;

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
			// Does the plane exist?
			if (Plane != null)
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
							// Offset finger screen position
							var screenPosition = finger.ScreenPosition + screenOffset;

							// Find offset ray for this finger
							var ray = camera.ScreenPointToRay(screenPosition);

							// Move GameObject to closest point
							transform.position = Plane.GetClosest(ray);
						}
					}
				}

				if (AutoSnap == true)
				{
					// Move GameObject to closest point
					transform.position = Plane.GetClosest(transform.position);
				}
			}
		}
	}
}