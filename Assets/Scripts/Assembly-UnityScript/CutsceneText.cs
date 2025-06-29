using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CutsceneText : MonoBehaviour
{
	public bool nowCutscene;

	public float number;

	public OneLinePassage[] text;

	private Player_Status status;

	private string textTemp;

	private int i;

	private bool prevNowCutscene;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		if (nowCutscene)
		{
			textTemp = string.Empty;
			if (status.language == 0)
			{
				for (i = 0; i < Extensions.get_length((System.Array)text[UnityBuiltins.parseInt(number)].passage_Jap); i++)
				{
					textTemp += text[UnityBuiltins.parseInt(number)].passage_Jap[i];
					if (Extensions.get_length((System.Array)text[UnityBuiltins.parseInt(number)].passage_Jap) - 1 != i)
					{
						textTemp += "\n";
					}
				}
			}
			else
			{
				for (i = 0; i < Extensions.get_length((System.Array)text[UnityBuiltins.parseInt(number)].passage_Eng); i++)
				{
					textTemp += text[UnityBuiltins.parseInt(number)].passage_Eng[i];
					if (Extensions.get_length((System.Array)text[UnityBuiltins.parseInt(number)].passage_Eng) - 1 != i)
					{
						textTemp += "\n";
					}
				}
			}
			guiText.text = textTemp;
			prevNowCutscene = nowCutscene;
		}
		else if (prevNowCutscene)
		{
			prevNowCutscene = false;
			if (guiText.text == textTemp)
			{
				guiText.text = string.Empty;
			}
		}
	}

	public virtual void SwitchFlag(bool flag)
	{
		if (flag)
		{
			nowCutscene = true;
		}
		else
		{
			nowCutscene = false;
		}
	}

	public virtual void ChangeNowCutscene(int flag)
	{
		if (flag == 0)
		{
			nowCutscene = false;
		}
		else
		{
			nowCutscene = true;
		}
	}

	public virtual void Main()
	{
	}
}
