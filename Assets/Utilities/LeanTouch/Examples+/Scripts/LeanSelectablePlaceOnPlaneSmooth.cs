using UnityEngine;

namespace Lean.Touch
{
	// This script modifies LeanSelectablePlaceOnPlane to be smooth
	public class LeanSelectablePlaceOnPlaneSmooth : LeanSelectablePlaceOnPlane
	{
		[Tooltip("How sharp the position value changes update")]
		public float Dampening = 3.0f;

		private Vector3 remainingDelta;

		protected override void Update()
		{
			// Store the old position
			var oldPosition = transform.localPosition;

			// Call LeanSelectablePlaceOnPlane.Update
			base.Update();

			// Store the new position
			var newPosition = transform.localPosition;

			// Update remainingDelta if the position changed
			if (newPosition != oldPosition)
			{
				remainingDelta = newPosition - oldPosition;
			}

			// Get t value
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Vector3.Lerp(remainingDelta, Vector3.zero, factor);

			// Shift this position by the change in delta
			transform.localPosition = oldPosition + remainingDelta - newDelta;

			// Update remainingDelta with the dampened value
			remainingDelta = newDelta;
		}
	}
}