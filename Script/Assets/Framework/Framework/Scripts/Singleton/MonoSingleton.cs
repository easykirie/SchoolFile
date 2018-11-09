using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{

	public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{

		static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();

					if (instance == null)
					{
						instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
					}
				}

				return instance;
			}
		}

		protected virtual void Awake()
		{
			if (instance == null)
			{
				instance = GetComponent<T>();
				DontDestroyOnLoad(gameObject);
			}
			else if (instance.gameObject != gameObject)
			{
				Destroy(gameObject);
			}
		}
	}

}