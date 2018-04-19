using UnityEngine;

namespace Lean.Touch
{
	// This script will turn the current GameObject based on finger drags
	public class LeanDragTurn : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does turning require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("Rotation space")]
		public Space Space = Space.World;

		[Space(16.0f)]
		[Tooltip("Sensitivity of the turn")]
		public float HorizontalSensitivity = 0.25f;

		[Tooltip("The axis of the turning")]
		public Vector3 HorizontalAxis = Vector3.up;

		[Tooltip("Sensitivity of the turn")]
		public float VerticalSensitivity = 0.25f;

		[Tooltip("The axis of the turning")]
		public Vector3 VerticalAxis = Vector3.right;

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
			// If we require a selectable and it isn't selected, skip
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Get the fingers we want to use to rotate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
			
			// Get the scaled average movement vector of these fingers
			var drag = LeanGesture.GetScaledDelta(fingers);

			// The angle we want to rotate by in degrees
			var angleX = drag.x * HorizontalSensitivity;

			// Rotate around axis
			transform.Rotate(HorizontalAxis, angleX, Space);

			// The angle we want to rotate by in degrees
			var angleY = drag.y * VerticalSensitivity;

			// Rotate around axis
			transform.Rotate(VerticalAxis, angleY, Space);
		}
	}
}