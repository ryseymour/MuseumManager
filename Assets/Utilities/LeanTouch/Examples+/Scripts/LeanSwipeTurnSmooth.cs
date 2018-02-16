using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanSwipeTurn to be smooth
	public class LeanSwipeTurnSmooth : LeanSwipeTurn
	{
		[Tooltip("How sharp the position value changes update")]
		public float Dampening = 3.0f;

		private Quaternion remainingDelta = Quaternion.identity;

		protected override void FingerSwipe(LeanFinger finger)
		{
			// Store the current position
			var oldRotation = transform.localRotation;

			// Call LeanSwipeMove.FingerSwipe
			base.FingerSwipe(finger);

			// Add to remainingDelta
			remainingDelta *= Quaternion.Inverse(oldRotation) * transform.localRotation;

			// Revert position
			transform.localRotation = oldRotation;
		}

		protected virtual void Update()
		{
			// Get t value
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Quaternion.Slerp(remainingDelta, Quaternion.identity, factor);

			// Shift this rotation by the change in delta
			transform.localRotation *= Quaternion.Inverse(newDelta) * remainingDelta;

			// Update remainingDelta with the dampened value
			remainingDelta = newDelta;
		}
	}
}