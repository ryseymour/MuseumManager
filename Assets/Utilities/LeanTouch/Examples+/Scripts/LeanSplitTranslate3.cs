using UnityEngine;

namespace Lean.Touch
{
	// This script will translate the current GameObject based on which side of the screen fingers touch, and also translate at the center
	public class LeanSplitTranslate3 : MonoBehaviour
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

		[Tooltip("The width/height of the center area in pixels relative to the reference DPI")]
		public float CenterSize = 100.0f;

		[Tooltip("The movement per second you want this GameObject to move when pressing on the right or top half of the screen")]
		public Vector3 Translation = Vector3.right;

		[Tooltip("The movement per second you want this GameObject to move when pressing on the center the screen")]
		public Vector3 TranslationCenter = Vector3.up;

		[Tooltip("The space the translation is done using")]
		public Space Space;
		
		protected virtual void Update()
		{
			// Get the fingers we want to use to translate
			var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount);
			
			// Count positive and negative so opposite fingers cancel each other out
			var negative = 0;
			var positive = 0;
			var center   = 0;

			for (var i = 0; i < fingers.Count; i++)
			{
				var finger = fingers[i];

				if (IsCenter(finger) == true)
				{
					center += 1;
				}
				else if (IsPositive(finger) == true)
				{
					positive += 1;
				}
				else
				{
					negative += 1;
				}
			}

			if (center > 0)
			{
				transform.Translate(TranslationCenter * Time.deltaTime, Space);
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

		private bool IsCenter(LeanFinger finger)
		{
			switch (Axis)
			{
				case HorizontalOrVertical.Horizontal:
				{
					if (Mathf.Abs(finger.ScreenPosition.x - Screen.width * 0.5f) < CenterSize)
					{
						return true;
					}
				}
				break;

				case HorizontalOrVertical.Vertical:
				{
					if (Mathf.Abs(finger.ScreenPosition.y - Screen.height * 0.5f) < CenterSize)
					{
						return true;
					}
				}
				break;
			}

			return false;
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