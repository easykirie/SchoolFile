using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayTree.EventSystem
{

	public class GameEventListener : MonoBehaviour
	{

		public GameEvent Event;

		public UnityEvent Response;

		public void OnPost()
		{
			if(Response != null)
			{
				Response.Invoke();
			}
		}
	}

}