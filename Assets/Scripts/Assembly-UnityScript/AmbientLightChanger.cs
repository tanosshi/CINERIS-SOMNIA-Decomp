using System;
using UnityEngine;

[Serializable]
public class AmbientLightChanger : MonoBehaviour
{
	public AmbientLightSet[] state;

	private int nowId;

	private bool fadeFlag;

	private Color firstColor;

	public AmbientLightChanger()
	{
		nowId = -1;
	}

	public virtual void Update()
	{
		if (fadeFlag)
		{
			float r = Mathf.Lerp(firstColor.r, state[nowId].lightColor.r, 1f / state[nowId].fadeTime);
			Color ambientLight = RenderSettings.ambientLight;
			float num = (ambientLight.r = r);
			Color color = (RenderSettings.ambientLight = ambientLight);
			float g = Mathf.Lerp(firstColor.g, state[nowId].lightColor.g, 1f / state[nowId].fadeTime);
			Color ambientLight2 = RenderSettings.ambientLight;
			float num2 = (ambientLight2.g = g);
			Color color3 = (RenderSettings.ambientLight = ambientLight2);
			float r2 = Mathf.Lerp(firstColor.b, state[nowId].lightColor.b, 1f / state[nowId].fadeTime);
			Color ambientLight3 = RenderSettings.ambientLight;
			float num3 = (ambientLight3.r = r2);
			Color color5 = (RenderSettings.ambientLight = ambientLight3);
			if (!(Mathf.Abs(RenderSettings.ambientLight.r - state[nowId].lightColor.r) > 0.01f))
			{
				RenderSettings.ambientLight = state[nowId].lightColor;
				fadeFlag = false;
			}
		}
	}

	public virtual void StartChangeAmbientLight(int id)
	{
		if (nowId != id)
		{
			firstColor = RenderSettings.ambientLight;
			nowId = id;
			fadeFlag = true;
		}
	}

	public virtual void Main()
	{
	}
}
