using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionExitListener : MonoBehaviour
{
    [TagSelector]
    public string targetTag;
    public UnityEvent<ColliderHit> triggerEvent;

    private void Start()
    {
        var collider = GetComponent<Collider>();
        if (collider.isTrigger)
            Debug.LogError($"{gameObject.name} collider must be not a trigger");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(targetTag))
        {
            triggerEvent.Invoke(new ColliderHit { collision = other, self = gameObject });
        }
    }
}
