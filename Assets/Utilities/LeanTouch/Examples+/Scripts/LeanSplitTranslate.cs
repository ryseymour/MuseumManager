using UnityEngine;

namespace Lean.Touch
{
	// This script will translate the current GameObject based on which side of the screen fingers touch
	public class LeanSplitTranslate : MonoBehaviour
	{
		public enum HorizontalOrVertical
		{
			Horizontal,
			Vertical
		}

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		[Tooltip("Allows you to force translation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;
		
		[Tooltip("The axis of the screen split")]
		public HorizontalOrVertical Axis;

		[Tooltip("The movement per second you want this GameObject to move when pressing on the right or top half of the screen")]
		public Vector3 Translation = Vector3.right;

		[Tooltip("The space the translation is done using")]
		public Space Space;
		
		protected virtual void Update()
		{
			// Get the fingers we want to use to translate
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
				transform.Translate(Translation * Time.deltaTime, Space);
			}

			if (negative > positive)
			{
				transform.Translate(-Translation * Time.deltaTime, Space);
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