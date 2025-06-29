using System;
using UnityEngine;

[Serializable]
public class ButterflyController : MonoBehaviour
{
	public GameObject wingL;

	public GameObject wingR;

	public float openMaxSlow;

	public float openMinSlow;

	public float closeMaxSlow;

	public float closeMinSlow;

	public float slowSpeedMax;

	public float slowSpeedMin;

	public float openMaxFast;

	public float openMinFast;

	public float closeMaxFast;

	public float closeMinFast;

	public float fastSpeedMax;

	public float fastSpeedMin;

	private bool openFlag;

	private float speed;

	private float amount;

	private bool fastFlag;

	private int fastCount;

	public virtual void Start()
	{
		ChangeFlag();
	}

	public virtual void Update()
	{
		float z = Mathf.LerpAngle(wingL.transform.localEulerAngles.z, amount, speed * Time.deltaTime);
		Vector3 localEulerAngles = wingL.transform.localEulerAngles;
		float num = (localEulerAngles.z = z);
		Vector3 vector = (wingL.transform.localEulerAngles = localEulerAngles);
		float z2 = Mathf.LerpAngle(wingR.transform.localEulerAngles.z, 0f - amount, speed * Time.deltaTime);
		Vector3 localEulerAngles2 = wingR.transform.localEulerAngles;
		float num2 = (localEulerAngles2.z = z2);
		Vector3 vector3 = (wingR.transform.localEulerAngles = localEulerAngles2);
		if (!(Mathf.Abs(wingL.transform.localEulerAngles.z - amount) > 2f))
		{
			ChangeFlag();
		}
	}

	public virtual void ChangeFlag()
	{
		if (!fastFlag)
		{
			speed = UnityEngine.Random.Range(slowSpeedMin, slowSpeedMax);
			if (!openFlag)
			{
				amount = UnityEngine.Random.Range(openMinSlow, openMaxSlow);
				openFlag = true;
			}
			else
			{
				amount = UnityEngine.Random.Range(closeMinSlow, closeMaxSlow);
				openFlag = false;
			}
			if (!(UnityEngine.Random.Range(0f, 100f) > 20f))
			{
				fastCount = UnityEngine.Random.Range(8, 9);
				fastFlag = true;
			}
		}
		else
		{
			speed = UnityEngine.Random.Range(fastSpeedMin, fastSpeedMax);
			if (!openFlag)
			{
				amount = UnityEngine.Random.Range(openMinFast, openMaxFast);
				openFlag = true;
			}
			else
			{
				amount = UnityEngine.Random.Range(closeMinFast, closeMaxFast);
				openFlag = false;
			}
			fastCount--;
			if (fastCount <= 0)
			{
				fastFlag = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
