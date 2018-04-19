using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanSwipeMove to be smooth
	public class LeanSwipeMoveSmooth : LeanSwipeMove
	{
		[Tooltip("How sharp the position value changes update")]
		public float Dampening = 3.0f;

		private Vector3 remainingDelta;

		protected override void FingerSwipe(LeanFinger finger)
		{
			// Store the current position
			var oldPosition = transform.localPosition;

			// Call LeanSwipeMove.FingerSwipe
			base.FingerSwipe(finger);

			// Add to remainingDelta
			remainingDelta += transform.localPosition - oldPosition;

			// Revert position
			transform.localPosition = oldPosition;
		}

		protected virtual void Update()
		{
			// Get t value
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Vector3.Lerp(remainingDelta, Vector3.zero, factor);

			// Shift this position by the change in delta
			transform.localPosition += remainingDelta - newDelta;

			// Update remainingDelta with the dampened value
			remainingDelta = newDelta;
		}
	}
}