#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
	#define UNITY_OLD_LINE_RENDERER
#endif
using UnityEngine;
using System.Collections.Generic;

namespace Lean.Touch
{
	// This script will draw a line between the start and current finger points and change the thickness based on the distance
	public class LeanFingerThrowUnderOnPlane : MonoBehaviour
	{
		// This class will store an association between a Finger and a LineRenderer instance
		[System.Serializable]
		public class Link
		{
			// The finger associated with this link
			public LeanFinger Finger;

			// The LineRenderer instance associated with this link
			public LineRenderer Line;

			// The GameObject that will be thrown
			public GameObject Target;
		}

		public enum SelectType
		{
			Raycast3D,
			Overlap2D
		}

		public enum SearchType
		{
			GetComponent,
			GetComponentInParent,
			GetComponentInChildren
		}

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;

		public SelectType SelectUsing;

		[Tooltip("This stores the layers we want the raycast/overlap to hit (make sure this GameObject's layer is included!)")]
		public LayerMask LayerMask = Physics.DefaultRaycastLayers;

		[Tooltip("How should the selected GameObject be searched for the LeanSelectable component?")]
		public SearchType Search;

		[Tooltip("The line prefab")]
		public LineRenderer LinePrefab;

		[Tooltip("The thickness scale per unit")]
		public float ThicknessScale = 0.1f;

		[Tooltip("Limit the length (0 = none)")]
		public float LengthLimit;

		[Tooltip("The maximum amount of fingers used")]
		public int MaxLines;

		[Tooltip("Invert the throw indicator direction?")]
		public bool Invert;

		[Tooltip("The strength of the throw")]
		public float ThrowForce = 1.0f;

		[Tooltip("The normal of the plane in world space")]
		public Vector3 PlaneNormal = Vector3.up;

		[Tooltip("The camera the translation will be calculated using (None = MainCamera)")]
		public Camera Camera;

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
			LeanTouch.OnFingerDown -= FingerDown;
			LeanTouch.OnFingerSet  -= FingerSet;
			LeanTouch.OnFingerUp   -= FingerUp;
		}

		// Override the WritePositions method from LeanDragLine
		protected virtual void WritePositions(Link link)
		{
			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera == null)
			{
				return;
			}

			// Get start and current world position of finger
			var targetCenter = link.Target.transform.position;
			var ray          = camera.ScreenPointToRay(link.Finger.ScreenPosition);
			var plane        = new Plane(PlaneNormal, targetCenter);
			var hitDistance  = 0.0f; plane.Raycast(ray, out hitDistance);
			var start        = link.Target.transform.position;
			var end          = ray.GetPoint(hitDistance);
			var distance     = Vector3.Distance(start, end);

			// Limit the length?
			if (LengthLimit > 0.0f && distance > LengthLimit)
			{
				var direction = Vector3.Normalize(end - start);

				distance = LengthLimit;
				end      = start + direction * distance;
			}

			if (Invert == true)
			{
				end = start + (start - end);
			}

			// Write positions
			var thickness = distance * ThicknessScale;

#if UNITY_OLD_LINE_RENDERER
			link.Line.SetVertexCount(2);

			link.Line.SetWidth(thickness, thickness);
#else
			link.Line.positionCount = 2;

			link.Line.startWidth = thickness;
			link.Line.endWidth   = thickness;
#endif
			link.Line.SetPosition(0, start);
			link.Line.SetPosition(1, end);
		}

		private void FingerDown(LeanFinger finger)
		{
			if (MaxLines > 0 && links.Count >= MaxLines)
			{
				return;
			}

			var component = FindComponentUnder(finger);

			if (component != null)
			{
				// Make new link
				var link = new Link();

				// Assign this finger to this link
				link.Finger = finger;

				// Create LineRenderer instance for this link
				link.Line = Instantiate(LinePrefab);

				link.Target = component.gameObject;

				// Add new link to list
				links.Add(link);
			}
		}

		private void FingerSet(LeanFinger finger)
		{
			// Try and find the link for this finger
			var link = FindLink(finger);

			// Link exists?
			if (link != null && link.Line != null && link.Target != null)
			{
				WritePositions(link);
			}
		}

		private void FingerUp(LeanFinger finger)
		{
			// Try and find the link for this finger
			var link = FindLink(finger);

			// Link exists?
			if (link != null)
			{
				// Remove link from list
				links.Remove(link);

				// Destroy line GameObject
				if (link.Line != null)
				{
					Destroy(link.Line.gameObject);
				}

				Throw(link);
			}
		}

		private Component FindComponentUnder(LeanFinger finger)
		{
			var component = default(Component);

			switch (SelectUsing)
			{
				case SelectType.Raycast3D:
				{
					// Get ray for finger
					var ray = finger.GetRay();

					// Stores the raycast hit info
					var hit = default(RaycastHit);

					// Was this finger pressed down on a collider?
					if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
					{
						component = hit.collider;
					}
				}
				break;

				case SelectType.Overlap2D:
				{
					// Find the position under the current finger
					var point = finger.GetWorldPosition(1.0f);

					// Find the collider at this position
					component = Physics2D.OverlapPoint(point, LayerMask);
				}
				break;
			}

			return component;
		}

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

		private void Throw(Link link)
		{
			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera == null)
			{
				return;
			}

			// Start and end points of the drag
			var targetCenter = link.Target.transform.position;
			var ray          = camera.ScreenPointToRay(link.Finger.ScreenPosition);
			var plane        = new Plane(PlaneNormal, targetCenter);
			var hitDistance  = 0.0f; plane.Raycast(ray, out hitDistance);
			var start        = link.Target.transform.position;
			var end          = ray.GetPoint(hitDistance);
			var distance     = Vector3.Distance(start, end);

			// Limit the length?
			if (LengthLimit > 0.0f && distance > LengthLimit)
			{
				var direction = Vector3.Normalize(end - start);

				distance = LengthLimit;
				end      = start + direction * distance;
			}

			if (start != end)
			{
				// Vector between points
				var direction = end - start;

				// Apply 3D force?
				var rigidbody3D = link.Target.GetComponent<Rigidbody>();

				if (rigidbody3D != null)
				{
					rigidbody3D.velocity = direction * ThrowForce;
				}

				// Apply 2D force?
				var rigidbody2D = link.Target.GetComponent<Rigidbody2D>();

				if (rigidbody2D != null)
				{
					rigidbody2D.velocity = direction * ThrowForce;
				}
			}
		}
	}
}