using UnityEngine;
using UnityEngine.Events;

namespace PlayTree.Framework
{
	[DisallowMultipleComponent]
	public class PooledObject : MonoBehaviour
	{

		public UnityEvent OnCreate;
		public UnityEvent OnDelete;

		void OnEnable()
		{
			//OnCreate?.Invoke();
			if (OnCreate != null)
			{
				OnCreate.Invoke();
			}
		}

		void OnDisable()
		{
			//OnDelete?.Invoke();
			if (OnDelete != null)
			{
				OnDelete.Invoke();
			}
		}
	}

}