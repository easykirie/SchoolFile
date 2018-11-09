using System.Collections.Generic;
using UnityEngine;
namespace PlayTree.EventSystem
{
	[CreateAssetMenu(menuName ="Game/GameEvent")]
	public class GameEvent : ScriptableObject
	{
		readonly List<GameEventListener> listeners = new List<GameEventListener>();

		public void Post()
		{
			for (int i = listeners.Count - 1; i >= 0; i--)
			{
				listeners[i].OnPost();
			}
		}

		public void Register(GameEventListener listener)
		{
			if (!listeners.Contains(listener))
			{
				listeners.Add(listener);
			}
		}


		public void Unregister(GameEventListener listener)
		{
			if (listeners.Contains(listener))
			{
				listeners.Remove(listener);
			}
		}
	}

}