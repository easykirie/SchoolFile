using System;
using UnityEngine;

namespace PlayTree.Framework
{
	[CreateAssetMenu(menuName = "Variable/Int")]
	public class IntVariable : ScriptableObject
	{

#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		[SerializeField]
		int value;

		Action<int, int> callback;

		public int Value
		{
			get { return value; }
			set
			{
				if (this.value == value)
				{
					return;
				}

				int pre = this.value;

				this.value = value;

				if (callback != null)
				{
					callback(pre, this.value);
				}
			}
		}

	}
}