using UnityEngine;

namespace Lean.Touch
{
	// This script will smoothly turn the current GameObject in steps based on finger drags
	public class LeanDragTurnStepSmooth : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Rotation space")]
		public Space Space = Space.World;

		[Tooltip("How quickly this object rotates to its target rotation")]
		public float Dampening = 10.0f;

		[Space(16.0f)]
		[Tooltip("The amount of scaled pixels the finger must move for the turn to step (0 = no rotation)")]
		public float HorizontalThreshold = 10.0f;

		[Tooltip("The euler rotation in degrees")]
		public Vector3 HorizontalRotation = new Vector3(0.0f, 45.0f, 0.0f);

		[Tooltip("The amount of scaled pixels the finger must move for the turn to step (0 = no rotation)")]
		public float VerticalThreshold = 10.0f;

		[Tooltip("The euler rotation in degrees")]
		public Vector3 VerticalRotation = new Vector3(45.0f, 0.0f, 0.0f);
		
		private Vector2 activeScaledDelta;

		private Vector3 remainingRotation;

		protected virtual void Update()
		{
			// Get the fingers we want to use to rotate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
			
			// Active?
			if (fingers.Count > 0)
			{
				// Add the scaled average movement vector of these fingers
				activeScaledDelta += LeanGesture.GetScaledDelta(fingers);

				// Prevent division by zero
				if (HorizontalThreshold != 0.0f)
				{
					var stepX = (int)(activeScaledDelta.x / HorizontalThreshold);

					if (stepX != 0)
					{
						remainingRotation += HorizontalRotation * stepX;

						activeScaledDelta.x -= stepX * HorizontalThreshold;
					}
				}

				// Prevent division by zero
				if (VerticalThreshold != 0.0f)
				{
					var stepY = (int)(activeScaledDelta.y / VerticalThreshold);

					if (stepY != 0)
					{
						remainingRotation += VerticalRotation * stepY;

						activeScaledDelta.y -= stepY * VerticalThreshold;
					}
				}
			}
			// Reset
			else
			{
				activeScaledDelta.x = 0.0f;
				activeScaledDelta.y = 0.0f;
			}

			// Get t value
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Store old rotation
			var oldRotation = remainingRotation;

			// Dampen remaining
			remainingRotation = Vector3.Lerp(remainingRotation, Vector3.zero, factor);

			// Rotate by delta
			transform.Rotate(oldRotation - remainingRotation, Space);
		}
	}
}