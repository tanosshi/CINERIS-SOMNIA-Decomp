using System;
using UnityEngine;

[Serializable]
public class Girl2Controller_Flower : MonoBehaviour
{
	public GameObject flowerObject;

	public virtual void FlowerGain(int id)
	{
		if (id == 0)
		{
			flowerObject.renderer.enabled = true;
		}
		else
		{
			flowerObject.renderer.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
