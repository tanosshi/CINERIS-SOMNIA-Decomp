using System;
using UnityEngine;

[Serializable]
public class HideCameraController : MonoBehaviour
{
	public float horizontalDistance;

	public float verticalDistance;

	public float horizontalAngle;

	public float verticalAngle;

	public float speed;

	public float rotateSpeed;

	private float h;

	private float v;

	private float c_h;

	private float c_v;

	private Vector3 firstPosition;

	private Vector3 firstRotation;

	private bool hideFlag;

	public virtual void Start()
	{
		firstPosition = transform.localPosition;
		firstRotation = transform.localEulerAngles;
	}

	public virtual void Update()
	{
		if (!hideFlag)
		{
			return;
		}
		if (!(transform.localEulerAngles.y >= 180f))
		{
			if (!(transform.localEulerAngles.y <= horizontalAngle))
			{
				float y = horizontalAngle;
				Vector3 localEulerAngles = transform.localEulerAngles;
				float num = (localEulerAngles.y = y);
				Vector3 vector = (transform.localEulerAngles = localEulerAngles);
			}
		}
		else if (!(transform.localEulerAngles.y >= 360f - horizontalAngle))
		{
			float y2 = 360f - horizontalAngle;
			Vector3 localEulerAngles2 = transform.localEulerAngles;
			float num2 = (localEulerAngles2.y = y2);
			Vector3 vector3 = (transform.localEulerAngles = localEulerAngles2);
		}
		if (!(transform.localEulerAngles.x >= 180f))
		{
			if (!(transform.localEulerAngles.x <= verticalAngle))
			{
				float x = verticalAngle;
				Vector3 localEulerAngles3 = transform.localEulerAngles;
				float num3 = (localEulerAngles3.x = x);
				Vector3 vector5 = (transform.localEulerAngles = localEulerAngles3);
			}
		}
		else if (!(transform.localEulerAngles.x >= 360f - verticalAngle))
		{
			float x2 = 360f - verticalAngle;
			Vector3 localEulerAngles4 = transform.localEulerAngles;
			float num4 = (localEulerAngles4.x = x2);
			Vector3 vector7 = (transform.localEulerAngles = localEulerAngles4);
		}
	}

	public virtual void FixedUpdate()
	{
		if (hideFlag)
		{
			h = Mathf.Clamp(cInput.GetAxisRaw("Horizontal") + cInput.GetAxisRaw("J_Horizontal"), -1f, 1f);
			v = Mathf.Clamp(cInput.GetAxisRaw("Vertical") + cInput.GetAxisRaw("J_Vertical"), -1f, 1f);
			transform.localPosition = Vector3.Lerp(transform.localPosition, firstPosition + new Vector3(h * horizontalDistance, v * verticalDistance, 0f), Time.deltaTime * speed);
			c_h = Mathf.Clamp(cInput.GetAxis("Mouse X") + cInput.GetAxis("J_Mouse X"), -1f, 1f);
			c_v = Mathf.Clamp(cInput.GetAxis("Mouse Y") + cInput.GetAxis("J_Mouse Y"), -1f, 1f);
			transform.localEulerAngles += new Vector3(0f - c_v, c_h, 0f) * Time.deltaTime * rotateSpeed;
		}
	}

	public virtual void ChangeHideFlag(int flag)
	{
		if (flag == 1)
		{
			hideFlag = true;
		}
		else
		{
			hideFlag = false;
		}
	}

	public virtual void Main()
	{
	}
}
