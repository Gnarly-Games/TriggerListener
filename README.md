
# Trigger Listener

This component receives Trigger events from your collider and then converts them to **UnityEvents**.

## Installation
You can install via git url by adding this entry in your **manifest.json**
```
"dependencies": {
	"com.gnarlygamesudio.triggerlistener": "https://github.com/Gnarly-Games/TriggerListener.git",
	...
}
```


## Example
Add component to collider object 

![inspector](https://i.ibb.co/8dnVhy0/Screenshot-2022-10-03-123215.png)

Then you can receive from script
```csharp
public  class  TestScript : MonoBehaviour
{
	public  void  OnTrapEnter(TriggerHit  hit)
	{
		Debug.LogError($"Trap Enter {hit.other.name} - {hit.self.name}");
	}
}
```

## Code view

```csharp
[RequireComponent(typeof(Collider))]
public  class  TriggerEnterListener : MonoBehaviour
{
	[TagSelector]
	public  string  targetTag;
	public  UnityEvent<TriggerHit> triggerEvent;

	private  void  Start()
	{
		var  collider  =  GetComponent<Collider>();
		if (!collider.isTrigger)
		Debug.LogError($"{gameObject.name} collider must be a trigger");
	}

	private  void  OnTriggerEnter(Collider  other)
	{
		if (other.CompareTag(targetTag))
		{
			triggerEvent.Invoke(new  TriggerHit { other  =  other.gameObject, self  =  gameObject });
		}
	}
}
```
Also you can find **TriggerExitListener**, **TriggerStayListener**, **ColliderEnterListener**, **ColliderExitListener** and **ColliderStayListener** then use the same way.
