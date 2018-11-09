using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{

	public static class ObjectPooler
	{
		static Dictionary<string, List<GameObject>> pooledObjectList = new Dictionary<string, List<GameObject>>();

		//TODO : 한프레임에 하나씩 혹은 몇개씩 생성하는 방식으로 바꾸는게 좋아 보임

		public static void PreCreate(Pool pool)
		{
			PreCreate(pool.Prefab, pool.Holder, pool.Size);
			//for (int i = 0; i < pool.Size; i++)
			//{
			//	Make(pool.Prefab, pool.Holder);
			//}
		}

		public static void PreCreate(GameObject prefab, Transform holder, int size)
		{
			if (prefab.GetComponent<PooledObject>() == null)
			{
				Debug.LogError(prefab.name + " : " + "This GameObject hasn't PooledObject Component");
				return;
			}

			for (int i = 0; i < size; i++)
			{
				Make(prefab, holder);
			}
		}



		#region Create

		public static GameObject Create(Pool pool, Vector3 pos = default(Vector3), Quaternion rot = default(Quaternion), Action callback = null)
		{
			return Create(pool.Prefab, pos, rot, callback);
		}

		public static GameObject Create(GameObject prefab, Vector3 pos = default(Vector3), Quaternion rot = default(Quaternion), Action callback = null)
		{
			if (prefab.GetComponent<PooledObject>() == null)
			{
				Debug.LogError(prefab.name + " : " + "This GameObject hasn't PooledObject Component");
				return null;
			}

			GameObject obj = GetInactiveObject(prefab.name);

			if (obj == null)
			{
				if (pooledObjectList.ContainsKey(prefab.name) && pooledObjectList[prefab.name].Count > 0)
				{
					obj = Make(prefab, pooledObjectList[prefab.name][0].transform.parent);
				}
			}
			
			obj.transform.position = pos;
			obj.transform.rotation = rot;

			if(callback != null)
			{
				callback.Invoke();
			}

			obj.SetActive(true);

			return obj;
		}

		#endregion

		#region Delete

		public static void Delete(GameObject obj)
		{
			if (!pooledObjectList.ContainsKey(obj.name))
			{
				return;
			}

			obj.SetActive(false);

		}

		#endregion

		public static void Clear(Pool pool)
		{
			Clear(pool.Prefab);
		}

		public static void Clear(GameObject prefab)
		{
			if (!pooledObjectList.ContainsKey(prefab.name))
			{
				return;
			}
			int index = 0;
			foreach (GameObject obj in pooledObjectList[prefab.name])
			{
				UnityEngine.Object.Destroy(obj, GameTime.DeltaTime * index);
				index++;
			}

			pooledObjectList[prefab.name].Clear();
		}

		static GameObject GetInactiveObject(string key)
		{
			if (!pooledObjectList.ContainsKey(key))
			{
				return null;
			}

			return pooledObjectList[key].Find(x => x.activeSelf == false);
		}

		static GameObject Make(GameObject prefab, Transform holder)
		{

			GameObject instance = UnityEngine.Object.Instantiate(prefab, holder);
			instance.SetActive(false);
			instance.name = prefab.name;

			if (!pooledObjectList.ContainsKey(prefab.name))
			{
				pooledObjectList.Add(prefab.name, new List<GameObject>());
			}

			pooledObjectList[prefab.name].Add(instance);

			return null;
		}



	}

}