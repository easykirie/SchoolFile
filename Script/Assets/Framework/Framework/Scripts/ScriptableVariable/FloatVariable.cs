
using System;
using UnityEngine;

namespace PlayTree.Framework
{
	[CreateAssetMenu(menuName = "Variable/Float")]
	public class FloatVariable : ScriptableObject
	{

#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		[SerializeField]
		float value;

		Action<float, float> callback;

		public float Value
		{
			get { return value; }
			set
			{
				if (this.value == value)
				{
					return;
				}

				float pre = this.value;

				this.value = value;

				if (callback != null)
				{
					callback(pre, this.value);
				}
			}
		}

	}
}