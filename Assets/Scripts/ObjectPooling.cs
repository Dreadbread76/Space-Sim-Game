using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[System.Serializable]
public class ObjectPooling <T> where T:Component
{
   [SerializeField]
   private T prefab;
   [SerializeField]
   private Stack<T> pool;

   private int count;
   public ObjectPooling()
   {
      Awake();
   }
   private void Awake()
   {
      if (pool == null)
      {
         pool = new Stack<T>();
      }
   }

   public T Spawn(T prefab, Transform parent = null)
   {
      if (pool.Count == 0)
      {
         return Object.Instantiate(prefab, parent);
      }

      T prefabGO = pool.Pop();
      prefabGO.gameObject.SetActive(true);
      prefabGO.transform.parent = parent;
      count++;
      return prefabGO;
   }
   
   public T Spawn(T prefab, Vector3 position, Quaternion rotation, Transform parent = null)
   {
      
      if (pool.Count == 0)
      {
         return Object.Instantiate(prefab, position, rotation, parent);
      }

      T prefabGO = pool.Pop();
      prefabGO.gameObject.SetActive(true);
      prefabGO.transform.position = position;
      prefabGO.transform.rotation = rotation;
      prefabGO.transform.parent = parent;
      count++;
      return prefabGO;
   }

   public void Despawn(T go)
   {
      go.gameObject.SetActive(false);
      pool.Push(go);
   }
}
