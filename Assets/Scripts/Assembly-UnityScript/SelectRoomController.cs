using System;
using UnityEngine;

[Serializable]
public class SelectRoomController : MonoBehaviour
{
	public GameObject commonTarget;

	public GameObject autoPlayObject;

	public float zoomSpeed;

	private bool nowSelect;

	private Player_Status status;

	private Camera_Controller cameraController;

	private Camera mainCamera;

	private bool zoomFlag;

	private Transform playerTransform;

	private int selectId;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		playerTransform = GameObject.FindWithTag("Player").transform;
		mainCamera = GameObject.FindWithTag("MainCamera").camera;
		cameraController = (Camera_Controller)mainCamera.GetComponent("Camera_Controller");
		for (i = 0; i < 290; i++)
		{
			status.item[i] = 0;
			status.file[i] = 0;
		}
		status.switches[390] = 0;
		status.switches[411] = 0;
	}

	public virtual void Update()
	{
		float y = mainCamera.transform.rotation.eulerAngles.y;
		Quaternion rotation = playerTransform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector = (rotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (playerTransform.rotation = rotation);
		if (status.nowPausing)
		{
			autoPlayObject.SetActive(false);
		}
		if (nowSelect)
		{
			if ((cInput.GetAxis("Mouse X") != 0f || cInput.GetAxis("Mouse Y") != 0f) && !Screen.showCursor)
			{
				Screen.lockCursor = false;
				Screen.showCursor = true;
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
			{
				nowSelect = false;
				SelectComplete(selectId);
			}
			if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetMouseButtonDown(1))
			{
				EndSelect();
			}
			if (selectId == 1)
			{
				if ((cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f)) && status.switches[15] == 0)
				{
					selectId = 3;
				}
				else
				{
					float axisRaw = cInput.GetAxisRaw("Vertical");
					if (axisRaw == 0f)
					{
						axisRaw = cInput.GetAxisRaw("J_Vertical");
					}
					if (axisRaw == 0f)
					{
						axisRaw = cInput.GetAxisRaw("DPad_Vertical");
					}
					if (!(axisRaw > -0.1f) && status.switches[14] == 0)
					{
						selectId = 2;
					}
				}
			}
			else if (selectId == 2)
			{
				float axisRaw2 = cInput.GetAxisRaw("Vertical");
				if (axisRaw2 == 0f)
				{
					axisRaw2 = cInput.GetAxisRaw("J_Vertical");
				}
				if (axisRaw2 == 0f)
				{
					axisRaw2 = cInput.GetAxisRaw("DPad_Vertical");
				}
				if (!(axisRaw2 < 0.1f) && status.switches[15] == 0)
				{
					selectId = 3;
				}
				else
				{
					float axisRaw3 = cInput.GetAxisRaw("Vertical");
					if (axisRaw3 == 0f)
					{
						axisRaw3 = cInput.GetAxisRaw("J_Vertical");
					}
					if (axisRaw3 == 0f)
					{
						axisRaw3 = cInput.GetAxisRaw("DPad_Vertical");
					}
					if (!(axisRaw3 < 0.1f) && status.switches[13] == 0)
					{
						selectId = 1;
					}
				}
			}
			else if (selectId == 3)
			{
				float axisRaw4 = cInput.GetAxisRaw("Horizontal");
				if (axisRaw4 == 0f)
				{
					axisRaw4 = cInput.GetAxisRaw("J_Horizontal");
				}
				if (axisRaw4 == 0f)
				{
					axisRaw4 = cInput.GetAxisRaw("DPad_Horizontal");
				}
				if (!(axisRaw4 > -0.1f) && status.switches[13] == 0)
				{
					selectId = 1;
				}
				else
				{
					float axisRaw5 = cInput.GetAxisRaw("Vertical");
					if (axisRaw5 == 0f)
					{
						axisRaw5 = cInput.GetAxisRaw("J_Vertical");
					}
					if (axisRaw5 == 0f)
					{
						axisRaw5 = cInput.GetAxisRaw("DPad_Vertical");
					}
					if (!(axisRaw5 > -0.1f) && status.switches[14] == 0)
					{
						selectId = 2;
					}
				}
			}
		}
		if (zoomFlag)
		{
			mainCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
		}
	}

	public virtual void StartSelect()
	{
		nowSelect = true;
		if (status.switches[13] == 0)
		{
			selectId = 1;
		}
		else if (status.switches[15] == 0)
		{
			selectId = 3;
		}
		else if (status.switches[14] == 0)
		{
			selectId = 2;
		}
		else
		{
			selectId = 4;
		}
	}

	public virtual void EndSelect()
	{
		nowSelect = false;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		commonTarget.SendMessage("CommonAction", (object)0);
	}

	public virtual void SelectComplete(int id)
	{
		nowSelect = false;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		commonTarget.SendMessage("CommonAction", id);
		cameraController.enabled = false;
		zoomFlag = true;
	}

	public virtual bool ShowSelectFlag()
	{
		return nowSelect;
	}

	public virtual int ShowSelectId()
	{
		return selectId;
	}

	public virtual void SetSelectId(int id)
	{
		selectId = id;
	}

	public virtual void Main()
	{
	}
}
