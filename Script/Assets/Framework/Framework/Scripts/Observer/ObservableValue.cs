using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{

	public class ObservableValue<T>
	{
		#region 변수

		T previous;
		T current;

		Action<T, T> callback = null;

		#endregion

		#region 프로퍼티

		public T PreValue
		{
			get { return previous; }
		}

		public T Value
		{
			get { return current; }
			set
			{
				if (previous.Equals(value))
				{
					return;
				}

				previous = current;

				current = value;

				if (callback != null)
				{
					callback(previous, current);
				}
			}
		}

		#endregion

		#region 생성자

		public ObservableValue(T value)
		{
			current = value;
		}

		public ObservableValue(T pre, T value)
		{
			previous = pre;
			value = value;
		}

		#endregion

		#region 메서드

		public void Register(Action<T, T> callback)
		{
			this.callback += callback;
		}

		public void Unregister(Action<T, T> callback)
		{
			this.callback -= callback;
		}

		#endregion

	}

}