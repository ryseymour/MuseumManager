using UnityEngine;

namespace Lean.Touch
{
	// This modifies LeanDragTurn to be smooth
	public class LeanDragTurnSmooth : LeanDragTurn
	{
		[Tooltip("How sharp the rotation value changes update")]
		public float Dampening = 3.0f;

		private Quaternion remainingDelta;

		protected override void Update()
		{
			// Store the current rotation
			var oldRotation = transform.localRotation;

			// Call LeanDragTurn.Update
			base.Update();

			// Add to remainingDelta
			remainingDelta *= Quaternion.Inverse(oldRotation) * transform.localRotation;

			// Get t value
			var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

			// Dampen remainingDelta
			var newDelta = Quaternion.Slerp(remainingDelta, Quaternion.identity, factor);

			// Shift this rotation by the change in delta
			transform.localRotation = oldRotation * Quaternion.Inverse(newDelta) * remainingDelta;

			// Update remainingDelta with the dampened value
			remainingDelta = newDelta;
		}
	}
}