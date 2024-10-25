using System;
using UnityEngine;

namespace _Scripts.Gameplay.Grapper
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        private Rigidbody _rb;
        public bool CanGrap { get; private set; }
        public bool IsGraped { get; private set; }
        public bool IsDelivered { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            GetComponent<MeshCollider>().convex = true;
        }

        public void Grap()
        {
            IsGraped = true;
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }

        public void UnGrap()
        {
            IsGraped = false;
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }

        public void Delivery()
        {
            CanGrap = false;
            IsDelivered = true;
        }
    }
}