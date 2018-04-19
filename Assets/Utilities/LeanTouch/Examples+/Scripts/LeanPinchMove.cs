using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to move the current GameObject (e.g. camera) along a specific axis by pinching your fingers
	public class LeanPinchMove : MonoBehaviour
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("Translation space")]
		public Space Space = Space.World;

		[Tooltip("If you want the mouse wheel to simulate pinching then set the strength of it here")]
		[Range(-1.0f, 1.0f)]
		public float WheelSensitivity;

		[Tooltip("The pinch sensitivity")]
		public float Sensitivity = 10.0f;

		[Tooltip("The axis of the translation")]
		public Vector3 Axis = Vector3.forward;

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

			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);

			// Get the world delta of all the fingers
			var pinch = LeanGesture.GetPinchRatio(fingers, WheelSensitivity);

			// Translate the GameObject along Axis based on the pinch ratio
			transform.Translate(Axis * (pinch - 1.0f) * Sensitivity, Space);
		}
	}
}