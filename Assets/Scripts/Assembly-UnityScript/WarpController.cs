using System;
using UnityEngine;

[Serializable]
public class WarpController : MonoBehaviour
{
	public GameObject[] target;

	public Vector3[] addPosition;

	public Bloom bloom;

	public ColorCorrectionCurves colorCorrection;

	public NoiseAndGrain noise;

	private Player_Controller controller;

	public virtual void Start()
	{
		controller = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
	}

	public virtual void StartWarp(int id)
	{
		int num = default(int);
		for (num = 0; num < target.Length; num++)
		{
			target[num].transform.position = target[num].transform.position + addPosition[id];
			if (target[num].tag == "Player")
			{
				controller.AddLookAtPoint(addPosition[id]);
			}
			if (target[num].tag == "MainCamera")
			{
				if (id % 2 == 0)
				{
					colorCorrection.enabled = true;
					noise.enabled = true;
					bloom.bloomThreshhold = 0.01f;
				}
				else
				{
					colorCorrection.enabled = false;
					noise.enabled = false;
					bloom.bloomThreshhold = 0.18f;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
