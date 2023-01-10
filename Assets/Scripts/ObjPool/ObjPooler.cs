using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjPooler : MonoBehaviour
    {
        private Stack<PooledObj> pool;

        [SerializeField]
        private PooledObj poolprefab;
        [SerializeField]
        private int count;


        private void Start()
        {
            pool = new Stack<PooledObj>();
            CreatePool(poolprefab, count);
        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape)) 
            {
                Get(new Vector3(Random.Range(-10f,10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)),Quaternion.identity);
            }
        }
        public void CreatePool(PooledObj pre, int count)
        {
            for (int i = 0; i < count; i++)
            {
                PooledObj instance = Instantiate(pre);
                instance.gameObject.SetActive(false);
                instance.pooler = this;
                pool.Push(instance);
            }
        }
        public PooledObj Get(Vector3 position, Quaternion rotate)
        {
            if (pool.Count > 0)
            {
                PooledObj instance = pool.Pop();
                instance.gameObject.SetActive(true);
                instance.transform.position = position;
                instance.transform.rotation = rotate;
                return instance;
            }
            else return null;
        }
        public void ReturnToPool(PooledObj poolobj)
        {
            poolobj.gameObject.SetActive(false);
            pool.Push(poolobj);
        }
    }
}