using System;
using UnityEngine;

[Serializable]
public class IvyController : MonoBehaviour
{
	public GameObject[] ivys;

	private int i;

	public virtual void Init()
	{
		for (i = 0; i < ivys.Length; i++)
		{
			ivys[i].renderer.material.SetFloat("_RevealSize", -1f);
		}
	}

	public virtual void Main()
	{
	}
}
