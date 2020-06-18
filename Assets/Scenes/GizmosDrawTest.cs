using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosDrawTest : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(transform.position, new Vector3(50, 50, 1));
        }
        
        //和 ondrawGizmos 可同时进行
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 10);
            Debug.Log("scene Name:"+this.gameObject.scene.name);
        }
    }
}