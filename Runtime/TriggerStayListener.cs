using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public namespace Gnarly
{
    [RequireComponent(typeof(Collider))]
    public class TriggerStayListener : MonoBehaviour
    {
        [Tag]
        public string target;
        public UnityEvent<GameObject> triggerEvent;

        private void Start()
        {
            var collider = GetComponent<Collider>();
            if (!collider.isTrigger)
                Debug.LogError($"{gameObject.name} collider must be a trigger");
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(target))
            {
                triggerEvent.Invoke(other.gameObject);
            }
        }
    }
}