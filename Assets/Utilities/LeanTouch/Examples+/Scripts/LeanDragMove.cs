using UnityEngine;

namespace Lean.Touch
{
	// This script will move the current GameObject based on finger drags
	public class LeanDragMove : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force translation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("The transform the translation should be done relative to")]
		public Transform RelativeTo;

		[Space(16.0f)]
		[Tooltip("Sensitivity of the translation")]
		public float HorizontalSensitivity = 0.25f;

		[Tooltip("The axis of the translation")]
		public Vector3 HorizontalAxis = Vector3.right;

		[Tooltip("Sensitivity of the translation")]
		public float VerticalSensitivity = 0.25f;

		[Tooltip("The axis of the translation")]
		public Vector3 VerticalAxis = Vector3.up;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

		protected virtual void Update()
		{
			// If we require a selectable and it isn't selected, cancel
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Get the fingers we want to use to translate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the scaled average movement vector of these fingers
			var drag = LeanGesture.GetScaledDelta(fingers);

			// Find the rotation
			var rotation = Quaternion.identity;

			if (RelativeTo != null)
			{
				rotation = RelativeTo.rotation;
			}

			// The distance we want to translate by in degrees
			var speedX = drag.x * HorizontalSensitivity;

			// Translate along axis
			transform.position += rotation * HorizontalAxis.normalized * speedX;

			// The angle we want to translate by in degrees
			var speedY = drag.y * VerticalSensitivity;

			// Translate along axis
			transform.position += rotation * VerticalAxis.normalized * speedY;
		}
	}
}