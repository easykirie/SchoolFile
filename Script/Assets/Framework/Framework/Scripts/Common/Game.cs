using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{
	/// <summary>
	/// Game.
	/// 업데이트 관련 함수 기능을 최적화 한 모듈.
	/// </summary>

	public class Game : MonoBehaviour
	{

		List<IUpdatable> updatables = new List<IUpdatable>();
		List<IFixedUpdatable> fixedUpdatables = new List<IFixedUpdatable>();
		List<ILateUpdatable> lateUpdatables = new List<ILateUpdatable>();

		static Game instance;

		public static Game Instance
		{
			get
			{
				if (instance == null)
				{
					Init();
				}

				return instance;
			}
		}



		public static void Init()
		{
			GameObject obj = new GameObject("Game");
			instance = obj.AddComponent<Game>();
		}


		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				DestroyImmediate(gameObject);
			}
		}

		void Update()
		{
			foreach (IUpdatable u in updatables)
			{
				u.OnUpdate(GameTime.DeltaTime);
			}
		}

		void FixedUpdate()
		{

		}

		void LateUpdate()
		{

		}
	}
}
