using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ActionTrigger : MonoBehaviour
{
	public GameObject target;

	public bool itemFlag;

	public int[] itemId;

	private Transform myTransform;

	private Transform playerTransform;

	private Vector3 moveDirection;

	private Player_Controller controller;

	private Player_Status status;

	private bool actionFlag;

	private int i;

	private GameObject windowObject;

	private GameObject textObject;

	private string[] actionTextJap;

	private string[] actionTextEng;

	public ActionTrigger()
	{
		moveDirection = Vector3.zero;
		actionTextJap = new string[4] { "調べる", "開ける", "話す", "隠れる" };
		actionTextEng = new string[4] { "Examine", "Open", "Talk", "Hide" };
	}

	public virtual void Awake()
	{
		myTransform = transform;
		controller = (Player_Controller)GameObject.FindWithTag("Player").GetComponent(typeof(Player_Controller));
		playerTransform = controller.gameObject.transform;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		windowObject = GameObject.Find("ActionWindow");
		textObject = GameObject.Find("ActionText");
	}

	public virtual void Update()
	{
		if (target != null)
		{
			if (!target.activeInHierarchy)
			{
				target = null;
				return;
			}
			if (!status.nowEventing && controller.isControllable && !status.nowPausing)
			{
				if (SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Action") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Action"))
				{
					target.SendMessage("ActionButton", SendMessageOptions.DontRequireReceiver);
				}
				if (Application.loadedLevelName != "[00-]fore_manor1")
				{
					if (windowObject != null)
					{
						float a = Mathf.Lerp(windowObject.guiTexture.color.a, 0.5f, 8f * Time.deltaTime);
						Color color = windowObject.guiTexture.color;
						float num = (color.a = a);
						Color color2 = (windowObject.guiTexture.color = color);
					}
					if (textObject != null)
					{
						float a2 = Mathf.Lerp(textObject.guiText.color.a, 1f, 8f * Time.deltaTime);
						Color color4 = textObject.guiText.color;
						float num2 = (color4.a = a2);
						Color color5 = (textObject.guiText.color = color4);
					}
				}
			}
			else
			{
				if (windowObject != null)
				{
					float a3 = Mathf.Lerp(windowObject.guiTexture.color.a, 0f, 32f * Time.deltaTime);
					Color color7 = windowObject.guiTexture.color;
					float num3 = (color7.a = a3);
					Color color8 = (windowObject.guiTexture.color = color7);
				}
				if (textObject != null)
				{
					float a4 = Mathf.Lerp(textObject.guiText.color.a, 0f, 32f * Time.deltaTime);
					Color color10 = textObject.guiText.color;
					float num4 = (color10.a = a4);
					Color color11 = (textObject.guiText.color = color10);
				}
			}
		}
		else
		{
			if (windowObject != null)
			{
				float a5 = Mathf.Lerp(windowObject.guiTexture.color.a, 0f, 16f * Time.deltaTime);
				Color color13 = windowObject.guiTexture.color;
				float num5 = (color13.a = a5);
				Color color14 = (windowObject.guiTexture.color = color13);
			}
			if (textObject != null)
			{
				float a6 = Mathf.Lerp(textObject.guiText.color.a, 0f, 16f * Time.deltaTime);
				Color color16 = textObject.guiText.color;
				float num6 = (color16.a = a6);
				Color color17 = (textObject.guiText.color = color16);
			}
		}
		if (status.nowPausing || Mathf.Approximately(Time.timeScale, 0f))
		{
			if (windowObject != null)
			{
				float a7 = 0f;
				Color color19 = windowObject.guiTexture.color;
				float num7 = (color19.a = a7);
				Color color20 = (windowObject.guiTexture.color = color19);
			}
			if (textObject != null)
			{
				float a8 = 0f;
				Color color22 = textObject.guiText.color;
				float num8 = (color22.a = a8);
				Color color23 = (textObject.guiText.color = color22);
			}
		}
	}

	public virtual void SetActionTarget(EventBase targetObj)
	{
		moveDirection = myTransform.TransformDirection(Vector3.forward);
		if (target == null)
		{
			target = targetObj.gameObject;
			if (targetObj.pages[targetObj.GetActivePage()].itemId.Length != 0)
			{
				SetItemInfo(targetObj.pages[targetObj.GetActivePage()].itemId);
			}
			if (targetObj.pages[targetObj.GetActivePage()].trigger == Trigger.ActionButton && textObject != null)
			{
				if (status.language == 0)
				{
					textObject.guiText.text = actionTextJap[(int)targetObj.pages[targetObj.GetActivePage()].actionText];
				}
				else
				{
					textObject.guiText.text = actionTextEng[(int)targetObj.pages[targetObj.GetActivePage()].actionText];
				}
			}
		}
		else if (target != targetObj.gameObject)
		{
			if (Vector3.Distance(target.transform.position, playerTransform.position) <= Vector3.Distance(targetObj.transform.position, playerTransform.position))
			{
				return;
			}
			target = targetObj.gameObject;
			if (targetObj.pages[targetObj.GetActivePage()].itemId.Length != 0)
			{
				SetItemInfo(targetObj.pages[targetObj.GetActivePage()].itemId);
			}
			if (targetObj.pages[targetObj.GetActivePage()].trigger == Trigger.ActionButton && textObject != null)
			{
				if (status.language == 0)
				{
					textObject.guiText.text = actionTextJap[(int)targetObj.pages[targetObj.GetActivePage()].actionText];
				}
				else
				{
					textObject.guiText.text = actionTextEng[(int)targetObj.pages[targetObj.GetActivePage()].actionText];
				}
			}
		}
		else
		{
			if (targetObj.pages[targetObj.GetActivePage()].itemId.Length == 0)
			{
				return;
			}
			if (!itemFlag)
			{
				SetItemInfo(targetObj.pages[targetObj.GetActivePage()].itemId);
			}
			else
			{
				if (itemId.Length != targetObj.pages[targetObj.GetActivePage()].itemId.Length)
				{
					return;
				}
				for (i = 0; i < itemId.Length; i++)
				{
					if (itemId[i] != targetObj.pages[targetObj.GetActivePage()].itemId[i])
					{
						SetItemInfo(targetObj.pages[targetObj.GetActivePage()].itemId);
						break;
					}
				}
			}
		}
	}

	public virtual void DeleteActionTarget(EventBase targetObj)
	{
		if (target != null && target == targetObj.gameObject)
		{
			target = null;
			if (targetObj.pages[targetObj.GetActivePage()].itemId.Length != 0)
			{
				DeleteItemInfo();
			}
		}
	}

	public virtual void SetItemInfo(int[] id)
	{
		itemFlag = true;
		itemId = new int[Extensions.get_length((System.Array)id)];
		for (i = 0; i < Extensions.get_length((System.Array)id); i++)
		{
			itemId[i] = id[i];
		}
	}

	public virtual void DeleteItemInfo()
	{
		itemFlag = false;
		itemId = null;
	}

	public virtual void Main()
	{
	}
}
