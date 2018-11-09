using UnityEngine;
using System.Linq;
namespace PlayTree.Framework
{

	public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
	{
		static T instance;

		public T Instance
		{
			get
			{
				if(instance == null)
				{
					instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
				}

				return instance;
			}
		}
		
	}

}