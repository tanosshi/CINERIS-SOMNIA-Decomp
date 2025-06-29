using System;
using UnityEngine;

[Serializable]
public class TitlePhotoPosition : MonoBehaviour
{
	public int fileId;

	public float speed;

	public GameObject position1;

	public GameObject position2;

	public GameObject position3;

	public GameObject position4;

	private Vector3 toPosition;

	private TitleLoad cursor;

	private int temp;

	public virtual void Awake()
	{
		cursor = (TitleLoad)GameObject.Find("TitleManager").GetComponent(typeof(TitleLoad));
	}

	public virtual void Update()
	{
		temp = cursor.cursor1 - fileId;
		if (temp < 0)
		{
			temp += 4;
		}
		switch (temp)
		{
		case 0:
			toPosition = position1.transform.position;
			break;
		case 1:
			toPosition = position2.transform.position;
			break;
		case 2:
			toPosition = position3.transform.position;
			break;
		case 3:
			toPosition = position4.transform.position;
			break;
		}
		transform.position = Vector3.Lerp(transform.position, toPosition, speed * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
