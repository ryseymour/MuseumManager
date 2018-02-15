using UnityEngine;

namespace Lean.Touch
{
	// This component will keep this GameObject a certain distance away from the center with pinch or mouse wheel
	[ExecuteInEditMode]
	public class LeanCameraDolly : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force input with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The direction of the dolly")]
		public Vector3 Direction = -Vector3.forward;

		[Tooltip("The current dolly distance")]
		public float Distance = 10.0f;

		[Tooltip("Should the distance value get clamped?")]
		public bool DistanceClamp;

		[Tooltip("The minimum distance")]
		public float DistanceMin = 1.0f;

		[Tooltip("The maximum distance")]
		public float DistanceMax = 100.0f;

		[Tooltip("If you want the mouse wheel to simulate pinching then set the strength of it here")]
		[Range(-1.0f, 1.0f)]
		public float WheelSensitivity;

		[Tooltip("The layers the dolly should collide against")]
		public LayerMask CollisionLayers;

		[Tooltip("The radius of the dolly collider")]
		public float CollisionRadius = 0.1f;

		protected virtual void LateUpdate()
		{
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Change the distance based on pinch gesture
			Distance *= LeanGesture.GetPinchRatio(fingers, WheelSensitivity);

			// Limit distance to min/max values?
			if (DistanceClamp == true)
			{
				Distance = Mathf.Clamp(Distance, DistanceMin, DistanceMax);
			}

			// Reset position
			transform.localPosition = Vector3.zero;

			// Collide against stuff?
			if (CollisionLayers != 0)
			{
				var hit            = default(RaycastHit);
				var start          = transform.TransformPoint(Direction.normalized * DistanceMin);
				var direction      = transform.TransformDirection(Direction);
				var distanceSpread = DistanceMax - DistanceMin;

				if (Physics.SphereCast(start, CollisionRadius, direction, out hit, distanceSpread, CollisionLayers) == true)
				{
					Distance = DistanceMin + hit.distance;
				}
			}

			// Dolly back by on distance
			transform.Translate(Direction.normalized * Distance);
		}
	}
}