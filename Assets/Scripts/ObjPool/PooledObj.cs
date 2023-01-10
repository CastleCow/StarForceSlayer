using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class PooledObj : MonoBehaviour
    {
        public ObjPooler pooler { get; set; }

        public void returnTo()
        {
            pooler.ReturnToPool(this);
        }
    }
}