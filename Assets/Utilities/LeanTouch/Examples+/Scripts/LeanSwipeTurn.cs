using UnityEngine;

namespace Lean.Touch
{
	// This script will turn the current GameObject based on finger swipes
	public class LeanSwipeTurn : MonoBehaviour
	{
		public enum ClampType
		{
			None,
			Normalize,
			Direction4
		}

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Does rotation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("Rotation space")]
		public Space Space = Space.World;

		[Tooltip("Should the swipe delta values be modified before use?")]
		public ClampType Clamp;

		[Space(16.0f)]
		[Tooltip("Sensitivity of the turn")]
		public float HorizontalSensitivity = 0.25f;

		[Tooltip("The axis of the rotation")]
		public Vector3 HorizontalAxis = Vector3.right;

		[Tooltip("Sensitivity of the turn")]
		public float VerticalSensitivity = 0.25f;

		[Tooltip("The axis of the rotation")]
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

		protected virtual void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerSwipe += FingerSwipe;
		}

		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerSwipe -= FingerSwipe;
		}

		protected virtual void FingerSwipe(LeanFinger finger)
		{
			// If we require a selectable and it isn't selected, cancel
			if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
			{
				return;
			}

			// Ignore GUI finger?
			if (IgnoreGuiFingers == true && finger.StartedOverGui == true)
			{
				return;
			}

			// Get the scaled average movement vector of these fingers
			var swipe = finger.SwipeScaledDelta;

			// Sign the delta values?
			switch (Clamp)
			{
				case ClampType.Normalize:
				{
					swipe = swipe.normalized;
				}
				break;

				case ClampType.Direction4:
				{
					if (swipe.x < -Mathf.Abs(swipe.y))
					{
						swipe = -Vector2.right;
					}

					if (swipe.x > Mathf.Abs(swipe.y))
					{
						swipe = Vector2.right;
					}

					if (swipe.y < -Mathf.Abs(swipe.x))
					{
						swipe = -Vector2.up;
					}

					if (swipe.y > Mathf.Abs(swipe.x))
					{
						swipe = Vector2.up;
					}
				}
				break;
			}

			// The angle we want to rotate by in degrees
			var speedX = swipe.x * HorizontalSensitivity;

			// Rotate along axis
			transform.Rotate(HorizontalAxis.normalized * speedX, Space);

			// The angle we want to rotate by in degrees
			var speedY = swipe.y * VerticalSensitivity;

			// Rotate along axis
			transform.Rotate(VerticalAxis.normalized * speedY, Space);
		}
	}
}