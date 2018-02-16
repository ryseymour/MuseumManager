#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
	#define UNITY_OLD_LINE_RENDERER
#endif
using UnityEngine;
using System.Collections.Generic;

namespace Lean.Touch
{
	// This script will draw the path each finger has taken since it started being pressed
	public class LeanFingerTrailFade : MonoBehaviour
	{
		// This class will store an association between a finger and a LineRenderer instance
		[System.Serializable]
		public class Link
		{
			// The finger associated with this link
			public LeanFinger Finger;

			// The LineRenderer instance associated with this link
			public LineRenderer Line;

			// The amount of seconds until this link disappears
			public float Life;
		}

		[Tooltip("The line prefab")]
		public LineRenderer LinePrefab;

		[Tooltip("The distance from the camera the line points will be spawned in world space")]
		public float Distance = 1.0f;

		[Tooltip("How many seconds it takes for each line to disappear after a finger is released")]
		public float FadeTime = 1.0f;

		[Tooltip("The maximum amount of fingers used")]
		public int MaxLines;

		public Color StartColor = Color.white;

		public Color EndColor = Color.white;

		[Tooltip("The camera the translation will be calculated using (default = MainCamera)")]
		public Camera Camera;

		// This stores all the links between fingers and LineRenderer instances
		private List<Link> links = new List<Link>();
	
		protected virtual void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerDown += FingerDown;
			LeanTouch.OnFingerSet  += FingerSet;
			LeanTouch.OnFingerUp   += FingerUp;
		}

		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerDown += FingerDown;
			LeanTouch.OnFingerSet  += FingerSet;
			LeanTouch.OnFingerUp   += FingerUp;
		}

		protected virtual void Update()
		{
			// Loop through all links
			for (var i = 0; i < links.Count; i++)
			{
				var link = links[i];

				// Has this link's finger been unlinked? (via OnFingerUp)
				if (link.Finger == null)
				{
					// Remove life from the link
					link.Life -= Time.deltaTime;

					// Is the link still alive?
					if (link.Life > 0.0f)
					{
						// Make sure FadeTime is set to prevent divide by 0
						if (FadeTime > 0.0f)
						{
							// Find the life to FadeTime 0..1 ratio
							var ratio = link.Life / FadeTime;

							// Copy the start & end colors and fade them by the ratio
							var color0 = StartColor;
							var color1 =   EndColor;
							
							color0.a *= ratio;
							color1.a *= ratio;

							// Write the new colors
#if UNITY_OLD_LINE_RENDERER
							link.Line.SetColors(color0, color1);
#else
							link.Line.startColor = color0;
							link.Line.endColor   = color1;
#endif
						}
					}
					// Kill the link?
					else
					{
						// Remove link from list
						links.Remove(link);

						// Destroy line GameObject
						Destroy(link.Line.gameObject);
					}
				}
			}
		}

		// Override the WritePositions method from LeanDragLine
		protected virtual void WritePositions(LineRenderer line, LeanFinger finger)
		{
			// Reserve one vertex for each snapshot
#if UNITY_OLD_LINE_RENDERER
			line.SetVertexCount(finger.Snapshots.Count);
#else
			line.positionCount = finger.Snapshots.Count;
#endif
			
			// Loop through all snapshots
			for (var i = 0; i < finger.Snapshots.Count; i++)
			{
				var snapshot = finger.Snapshots[i];
				
				// Get the world postion of this snapshot
				var position = snapshot.GetWorldPosition(Distance, Camera);

				// Write position
				line.SetPosition(i, position);
			}
		}

		private void FingerDown(LeanFinger finger)
		{
			if (MaxLines > 0 && links.Count >= MaxLines)
			{
				return;
			}

			// Make new link
			var link = new Link();

			// Assign this finger to this link
			link.Finger = finger;

			// Create LineRenderer instance for this link
			link.Line = Instantiate(LinePrefab);

			// Add new link to list
			links.Add(link);
		}

		private void FingerSet(LeanFinger finger)
		{
			// Try and find the link for this finger
			var link = FindLink(finger);

			// Link exists?
			if (link != null && link.Line != null)
			{
				WritePositions(link.Line, link.Finger);
			}
		}

		private void FingerUp(LeanFinger finger)
		{
			// Try and find the link for this finger
			var link = FindLink(finger);

			// Link exists?
			if (link != null)
			{
				// Unlink finger
				link.Finger = null;

				// Assign life
				link.Life = FadeTime;
			}
		}

		// Searches through all links for the one associated with the input finger
		private Link FindLink(LeanFinger finger)
		{
			for (var i = 0; i < links.Count; i++)
			{
				var link = links[i];

				if (link.Finger == finger)
				{
					return link;
				}
			}

			return null;
		}
	}
}