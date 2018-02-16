using UnityEngine;
using Lean.Touch;

namespace Lean.Touch
{
	public interface IDroppable
	{
		void OnDrop(GameObject droppedGameObject, LeanFinger finger);
	}
}