using UnityEngine;

namespace Lean.Touch
{
	// This script will turn the current GameObject based on the twist gesture
	public class LeanTwistTurn : MonoBehaviour
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
		public float TwistSensitivity = 1.0f;

		[Tooltip("The axis of the turning")]
		public Vector3 TwistAxis = Vector3.up;

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
			// If we require a selectable and it isn't selected, cancel turn
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Get the fingers we want to use to rotate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
			
			// The twist angle based on these fingers
			var twist = LeanGesture.GetTwistDegrees(fingers) * TwistSensitivity;

			// Rotate around axis
			transform.Rotate(TwistAxis, twist, Space);
		}
	}
}