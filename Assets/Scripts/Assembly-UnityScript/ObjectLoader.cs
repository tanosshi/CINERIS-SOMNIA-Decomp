using System;
using UnityEngine;

[Serializable]
public class ObjectLoader : MonoBehaviour
{
	public GameObject prefab;

	public virtual void Awake()
	{
		GameObject gameObject = GameObject.Find("StatusObjects(Clone)");
		if (null == gameObject)
		{
			UnityEngine.Object.Instantiate(prefab);
		}
		UnityEngine.Object.Destroy(this);
	}

	public virtual void Main()
	{
	}
}
