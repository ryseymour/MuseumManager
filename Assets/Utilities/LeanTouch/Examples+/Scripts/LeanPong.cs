using UnityEngine;

namespace Lean.Touch
{
	// This script shows you how you can check tos ee which part of the screen a finger is on, and work accordingly
	public class LeanPong : MonoBehaviour
	{
		[Tooltip("The transform for the left GameObject")]
		public Transform LeftObject;
		
		[Tooltip("The transform for the right GameObject")]
		public Transform RightObject;
		
		protected virtual void OnEnable()
		{
			// Hook the OnFingerSet event
			LeanTouch.OnFingerSet += OnFingerSet;
		}
		
		protected virtual void OnDisable()
		{
			// Unhook from the OnFingerSet event
			LeanTouch.OnFingerSet -= OnFingerSet;
		}
		
		public void OnFingerSet(LeanFinger finger)
		{
			if (finger.IsOverGui == false)
			{
				// Find the horizontal screen pixel limits for the left and right sides
				var middle = Screen.width / 2.0f;

				// Left side of the screen?
				if (finger.ScreenPosition.x < middle)
				{
					// Does the left object exist?
					if (LeftObject != null)
					{
						// Store old object position
						var position = LeftObject.position;

						// Write new y position from finger
						position.y = finger.GetWorldPosition(10.0f).y;

						// Update position
						LeftObject.position = position;
					}
				}

				// Right side?
				if (finger.ScreenPosition.x > middle)
				{
					// Does the right object exist?
					if (RightObject != null)
					{
						// Store old object position
						var position = RightObject.position;

						// Write new y position from finger
						position.y = finger.GetWorldPosition(10.0f).y;

						// Update position
						RightObject.position = position;
					}
				}
			}
			// NOTE: If you want to prevent fingers from crossing sides then you can check finger.StartScreenPosition first
		}
	}
}