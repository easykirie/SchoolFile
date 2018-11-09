﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayTree.Framework
{

	public class Singleton<T> where T : class, new()
	{
		static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new T();
				}
				return instance;
			}
		}

		protected Singleton()
		{
			Init();
		}

		protected virtual void Init() { }
	}

}