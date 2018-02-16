using UnityEngine;
using System.Collections.Generic;

namespace Lean.Touch
{
	// This component detects swipes while the finger is touching the screen
	public class LeanFingerSwipeNoRelease : LeanFingerSwipe
	{
		// This class will store an association between a Finger and cooldown values
		[System.Serializable]
		public class Link
		{
			// The finger associated with this link
			public LeanFinger Finger;

			// Currently waiting for cooldown to finish?
			public bool Cooldown;

			// Current cooldown time in seconds
			public float CooldownTime;
		}

		[Tooltip("Allow multiple swipes for each finger press?")]
		public bool AllowMultiple;

		[Tooltip("If multiple swipes are allowed, this is the minimum amount of seconds between each OnFingerSwipe call")]
		public float MultipleSwipeDelay = 0.5f;

		// This stores all the links
		private List<Link> links = new List<Link>();

		protected override void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerSet += FingerSet;
			LeanTouch.OnFingerUp  += FingerUp;
		}

		protected override void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerSet -= FingerSet;
			LeanTouch.OnFingerUp  -= FingerUp;
		}

		protected virtual void Update()
		{
			// Loop through all links
			for (var i = 0; i < links.Count; i++)
			{
				var link = links[i];

				// Decrease cooldown?
				if (link.Cooldown == true && AllowMultiple == true)
				{
					link.CooldownTime -= Time.deltaTime;

					if (link.CooldownTime <= 0.0f)
					{
						link.Cooldown = false;
					}
				}
			}
		}

		public void FingerSet(LeanFinger finger)
		{
			// Get link and skip if on cooldown
			var link = GetLink(finger);

			if (link.Cooldown == true)
			{
				return;
			}

			// The scaled delta position magnitude required to register a swipe
			var swipeThreshold = LeanTouch.Instance.SwipeThreshold;

			// The amount of seconds we consider valid for a swipe
			var tapThreshold = LeanTouch.Instance.TapThreshold;

			// Get the scaled delta position between now, and 'swipeThreshold' seconds ago
			var recentDelta = finger.GetSnapshotScreenDelta(tapThreshold);

			// Has the finger recently swiped?
			if (recentDelta.magnitude > swipeThreshold)
			{
				CheckSwipe(finger, recentDelta);

				// Begin cooldown
				link.CooldownTime = MultipleSwipeDelay;
				link.Cooldown     = true;
			}
		}

		public void FingerUp(LeanFinger finger)
		{
			// Get link and reset cooldown
			var link = GetLink(finger);

			link.Cooldown = false;
		}

		private Link GetLink(LeanFinger finger)
		{
			// Loop through all links
			for (var i = 0; i < links.Count; i++)
			{
				var link = links[i];

				// Return if it matches
				if (link.Finger == finger)
				{
					return link;
				}
			}

			// Create link
			var newLink = new Link();

			newLink.Finger = finger;

			links.Add(newLink);

			return newLink;
		}
	}
}