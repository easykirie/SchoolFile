using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{
	public struct RangedFloat
	{
		public float Min;
		public float Max;

		public float RandomValue
		{
			get
			{
				return Random.Range(Min, Max);
			}
		}
	}

}