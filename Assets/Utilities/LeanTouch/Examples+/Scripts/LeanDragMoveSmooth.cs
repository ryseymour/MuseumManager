using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanDragMove to be smooth
	public class LeanDragMoveSmooth : LeanDragMove
	{
		[Tooltip("How sharp the position value changes update")]
		public float Dampening = 3.0f;

		private Vector3 remainingDelta;

		protected override void Update()
		{
			// Store the current position
			var oldPosition = transform.localPosition;

			// Call LeanDragTurn.Update
			base.Update();

			// Add to remainingDelta
			remainingDelta += transform.localPosition - oldPosition;

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