using System;
using Aubergine;
using UnityEngine;

[Serializable]
public class FakeHDRController : MonoBehaviour
{
	public FakeHDRTarget[] targets;

	private Transform mainCamera;

	private PP_FakeHDR fakeHDR;

	private float distance;

	private int i;

	private int id;

	private float distanceTemp;

	public virtual void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera").transform;
		fakeHDR = (PP_FakeHDR)mainCamera.GetComponent(typeof(PP_FakeHDR));
	}

	public virtual void Update()
	{
		id = 0;
		distance = 999999f;
		distanceTemp = 0f;
		for (i = 0; i < targets.Length; i++)
		{
			distanceTemp = Vector3.Distance(targets[i].targetTransform.position, mainCamera.position);
			if (!(distanceTemp >= distance))
			{
				id = i;
				distance = distanceTemp;
			}
		}
		if (!(distance > targets[id].minDistance))
		{
			fakeHDR.multiplier = Mathf.Lerp(fakeHDR.multiplier, targets[id].minAmount, 4f * Time.deltaTime);
		}
		else if (!(distance < targets[id].maxDistance))
		{
			fakeHDR.multiplier = Mathf.Lerp(fakeHDR.multiplier, targets[id].maxAmount, 4f * Time.deltaTime);
		}
		else
		{
			fakeHDR.multiplier = Mathf.Lerp(fakeHDR.multiplier, (targets[id].maxAmount - targets[id].minAmount) * ((distance - targets[id].minDistance) / (targets[id].maxDistance - targets[id].minDistance)) + targets[id].minAmount, 2f * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
