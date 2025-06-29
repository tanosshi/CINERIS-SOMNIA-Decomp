using System;
using UnityEngine;

[Serializable]
public class MoveRoute
{
	public bool changePosition;

	public Vector3 constantPosition;

	public bool usePath;

	public bool orientToPath;

	public string pathName;

	public bool useEaseInOut;

	public bool useSpeed;

	public float speed;

	public float positionTime;

	public bool changeRotation;

	public Vector3 constantRotation;

	public float rotationTime;

	public bool changeLookAhead;

	public GameObject lookTarget;

	public bool changeAnimation;

	public int animationId;

	public float startWaitTime;
}
