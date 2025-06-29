using UnityEngine;

public class NsInput : SingletonMonoBehaviour<NsInput>
{
	private bool mouseButtonFlag;

	private void LateUpdate()
	{
		if (mouseButtonFlag && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
		{
			mouseButtonFlag = false;
		}
	}

	public void SetMouseButtonFlag(bool flag)
	{
		mouseButtonFlag = flag;
	}

	public bool GetMouseButtonDown(int num)
	{
		if (!mouseButtonFlag && Input.GetMouseButtonDown(num))
		{
			mouseButtonFlag = true;
			return true;
		}
		return false;
	}

	public bool GetButtonDown(string buttonName)
	{
		if (cInput.GetText(buttonName, 1) == "Mouse0" || cInput.GetText(buttonName, 1) == "Mouse1" || cInput.GetText(buttonName, 2) == "Mouse0" || cInput.GetText(buttonName, 2) == "Mouse1")
		{
			if (!mouseButtonFlag && cInput.GetButtonDown(buttonName))
			{
				mouseButtonFlag = true;
				return true;
			}
			return false;
		}
		return cInput.GetButtonDown(buttonName);
	}
}
