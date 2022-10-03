using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderExitListener : MonoBehaviour
{
    [TagSelector]
    public string target;
    public UnityEvent<ColliderHit> triggerEvent;

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
            triggerEvent.Invoke(new ColliderHit { collision = other, self = gameObject });
        }
    }
}
