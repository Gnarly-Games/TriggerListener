using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public namespace Gnarly
{
    [RequireComponent(typeof(Collider))]
    public class ColliderStayListener : MonoBehaviour
    {
        [Tag]
        public string target;
        public UnityEvent<GameObject> triggerEvent;

        private void Start()
        {
            var collider = GetComponent<Collider>();
            if (collider.isTrigger)
                Debug.LogError($"{gameObject.name} collider must be not a trigger");
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(target))
            {
                triggerEvent.Invoke(other.gameObject);
            }
        }
    }
}