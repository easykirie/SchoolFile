using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{
	public class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T>
	{
		static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();
				}

				return instance;
			}
		}

		protected virtual void Awake()
		{
			if (instance == null)
			{
				instance = GetComponent<T>();
			}
			else if (instance.gameObject != gameObject)
			{
				Destroy(gameObject);
			}
		}
	}

}