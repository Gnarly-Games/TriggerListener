using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerExitListener : MonoBehaviour
{
    [TagSelector]
    public string targetTag;
    public UnityEvent<TriggerHit> triggerEvent;

    private void Start()
    {
        var collider = GetComponent<Collider>();
        if (!collider.isTrigger)
            Debug.LogError($"{gameObject.name} collider must be a trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            triggerEvent.Invoke(new TriggerHit { other = other.gameObject, self = gameObject });
        }
    }
}
