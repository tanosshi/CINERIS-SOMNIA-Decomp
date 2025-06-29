using System;
using UnityEngine;

[Serializable]
public class StaffrollController : MonoBehaviour
{
	public float startPosition;

	public float fixedPosition;

	public float playTime;

	public float endPosition;

	public bool trueEnding;

	private Transform myTransform;

	private float firstPosition;

	public bool isPlaying;

	private float nowTime;

	private Player_Status status;

	public virtual void Awake()
	{
		myTransform = transform;
		float y = startPosition - fixedPosition - (float)(Screen.height / 2);
		Vector3 position = myTransform.position;
		float num = (position.y = y);
		Vector3 vector = (myTransform.position = position);
		firstPosition = myTransform.position.y;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		if (isPlaying)
		{
			if (!(nowTime < playTime))
			{
				nowTime = playTime;
			}
			else
			{
				nowTime += 1f * Time.deltaTime;
			}
			float y = Mathf.Lerp(firstPosition, endPosition, nowTime / playTime);
			Vector3 position = myTransform.position;
			float num = (position.y = y);
			Vector3 vector = (myTransform.position = position);
		}
	}

	public virtual void Play()
	{
		nowTime = 0f;
		isPlaying = true;
		if (trueEnding)
		{
			status.bootFlag = false;
		}
		else
		{
			status.bootFlag = true;
		}
	}

	public virtual void Main()
	{
	}
}
