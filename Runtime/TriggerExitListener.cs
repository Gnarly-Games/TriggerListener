using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public namespace Gnarly
{
    [RequireComponent(typeof(Collider))]
    public class TriggerExitListener : MonoBehaviour
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

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(target))
            {
                triggerEvent.Invoke(other.gameObject);
            }
        }
    }
}