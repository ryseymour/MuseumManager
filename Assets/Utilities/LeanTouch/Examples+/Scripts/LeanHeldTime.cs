using UnityEngine;
using UnityEngine.UI;

namespace Lean.Touch
{
	// This component can be used with LeanSelect's Re
	public class LeanHeldTime : MonoBehaviour
	{
		[Tooltip("The text element we will modify")]
		public Text NumberText;

		[Tooltip("The amount of times this GameObject has been reselected")]
		public int ReselectCount;

		// The finger that selected this
		private LeanFinger selectingFinger;
		
		public void OnSelect(LeanFinger finger)
		{
			selectingFinger = finger;
		}

		public void OnDeselect()
		{
			selectingFinger = null;

			NumberText.text = "";
		}

		protected virtual void Update()
		{
			if (selectingFinger != null)
			{
				NumberText.text = selectingFinger.Age.ToString("0.0");
			}
		}
	}
}