using UnityEngine;

namespace Lean.Touch
{
	// This script will place this GameObject along a line renderer path when selected
	[ExecuteInEditMode]
	public class LeanSelectablePlaceOnPath : LeanSelectableBehaviour
	{
		[Tooltip("The camera we will be used (None = MainCamera)")]
		public Camera Camera;

		[Tooltip("The path this GameObject will be placed along")]
		public LeanPath Path;

		[Tooltip("The amount of lines between each path point")]
		public int Smoothing = 1;

		[Tooltip("Keep this GameObject placed on the path even when not dragging?")]
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
			// Does the path exist?
			if (Path != null)
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

							// Move GameObject to closest point, if one was found
							var closestPoint = default(Vector3);

							if (Path.TryGetClosest(ray, ref closestPoint, Smoothing) == true)
							{
								transform.position = closestPoint;
							}
						}
					}
				}

				if (AutoSnap == true)
				{
					// Move GameObject to closest point, if one was found
					var closestPoint = default(Vector3);

					if (Path.TryGetClosest(transform.position, ref closestPoint, Smoothing) == true)
					{
						transform.position = closestPoint;
					}
				}
			}
		}
	}
}