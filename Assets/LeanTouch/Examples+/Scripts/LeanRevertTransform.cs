using UnityEngine;

namespace Lean.Touch
{
	// This script will revert the transform of the current GameObject when the target selectable isn't selected
	public class LeanRevertTransform : MonoBehaviour
	{
		[Tooltip("Does translation require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("How quickly this object moves to its original transform")]
		public float Dampening = 10.0f;

		public bool RevertPosition = true;
		public bool RevertRotation = true;
		public bool RevertScale    = true;

		[SerializeField]
		[HideInInspector]
		private Vector3 originalPosition;

		[SerializeField]
		[HideInInspector]
		private Quaternion originalRotation;

		[SerializeField]
		[HideInInspector]
		private Vector3 originalScale;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

		protected virtual void Awake()
		{
			originalPosition = transform.localPosition;
			originalRotation = transform.localRotation;
			originalScale    = transform.localScale;
		}

		protected virtual void Update()
		{
			if (RequiredSelectable != null && RequiredSelectable.isActiveAndEnabled == true && RequiredSelectable.IsSelected == false)
			{
				// Get t value
				var factor = LeanTouch.GetDampenFactor(Dampening, Time.deltaTime);

				if (RevertPosition == true)
				{
					transform.localPosition = Vector3. Lerp(transform.localPosition, originalPosition, factor);
				}

				if (RevertRotation == true)
				{
					transform.localRotation = Quaternion.Slerp(transform.localRotation, originalRotation, factor);
				}

				if (RevertScale == true)
				{
					transform.localScale = Vector3. Lerp(transform.localScale, originalScale, factor);
				}
			}
		}
	}
}