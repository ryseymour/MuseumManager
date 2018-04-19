using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	// This script fires events when the selectable has been held down for a certain amount of time
	public class LeanSelectableHeld : LeanSelectableBehaviour
	{
		// Event signature
		[System.Serializable] public class SelectableEvent : UnityEvent<LeanSelectable> {}

		[Tooltip("The finger must be held for this many seconds")]
		public float MinimumAge = 1.0f;

		// Called on the first frame the conditions are met
		public SelectableEvent onSelectableHeldDown;

		// Called on every frame the conditions are met
		public SelectableEvent onSelectableHeldSet;

		// Called on the last frame the conditions are met
		public SelectableEvent onSelectableHeldUp;

		private bool lastSet;

		protected virtual void Update()
		{
			// Has this selectable been held down for more than MinimumAge?
			var set = Selectable.IsSelected == true && Selectable.SelectingFinger != null && Selectable.SelectingFinger.Age > MinimumAge;

			// If this is the first frame of set, call down
			if (set == true && lastSet == false)
			{
				onSelectableHeldDown.Invoke(Selectable);
			}

			// Call set every time if set
			if (set == true)
			{
				onSelectableHeldSet.Invoke(Selectable);
			}

			// Store last value
			lastSet = set;
		}

		protected override void OnSelect(LeanFinger finger)
		{
			// Reset value
			lastSet = false;
		}

		protected override void OnSelectUp(LeanFinger finger)
		{
			OnDeselect();
		}

		protected override void OnDeselect()
		{
			if (lastSet == true)
			{
				onSelectableHeldUp.Invoke(Selectable);
			}
		}
	}
}