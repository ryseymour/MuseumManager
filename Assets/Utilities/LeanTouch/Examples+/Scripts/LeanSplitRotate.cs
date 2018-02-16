using UnityEngine;

namespace Lean.Touch
{
	// This script will rotate the current GameObject based on which side of the screen fingers touch
	public class LeanSplitRotate : MonoBehaviour
	{
		public enum HorizontalOrVertical
		{
			Horizontal,
			Vertical
		}

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("The axis of the screen split")]
		public HorizontalOrVertical Axis;

		[Tooltip("The Euler angles per second you want this GameObject to move when pressing on the right or top half of the screen in degrees")]
		public Vector3 Rotation = Vector3.right;

		[Tooltip("The space the translation is done using")]
		public Space Space;

		protected virtual void Update()
		{
			// Get the fingers we want to use to rotate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
			
			// Count positive and negative so opposite fingers cancel each other out
			var negative = 0;
			var positive = 0;

			for (var i = 0; i < fingers.Count; i++)
			{
				if (IsPositive(fingers[i]) == true)
				{
					positive += 1;
				}
				else
				{
					negative += 1;
				}
			}

			if (positive > negative)
			{
				transform.Rotate(Rotation * Time.deltaTime, Space);
			}

			if (negative > positive)
			{
				transform.Rotate(-Rotation * Time.deltaTime, Space);
			}
		}

		private bool IsPositive(LeanFinger finger)
		{
			switch (Axis)
			{
				case HorizontalOrVertical.Horizontal:
				{
					if (finger.ScreenPosition.x > Screen.width * 0.5f)
					{
						return true;
					}
				}
				break;

				case HorizontalOrVertical.Vertical:
				{
					if (finger.ScreenPosition.y > Screen.height * 0.5f)
					{
						return true;
					}
				}
				break;
			}

			return false;
		}
	}
}