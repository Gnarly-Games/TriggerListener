using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerStayListener : MonoBehaviour
{
    [TagSelector]
    public string target;
    public UnityEvent<TriggerHit> triggerEvent;

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
            triggerEvent.Invoke(new TriggerHit { other = other.gameObject, self = gameObject });
        }
    }
}
