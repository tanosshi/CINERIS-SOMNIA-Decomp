using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Image Effects/Edge Detection/Crease Shading")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class Crease : PostEffectsBase
{
	public float intensity;

	public int softness;

	public float spread;

	public Shader blurShader;

	private Material blurMaterial;

	public Shader depthFetchShader;

	private Material depthFetchMaterial;

	public Shader creaseApplyShader;

	private Material creaseApplyMaterial;

	public Crease()
	{
		intensity = 0.5f;
		softness = 1;
		spread = 1f;
	}

	public override bool CheckResources()
	{
		CheckSupport(true);
		blurMaterial = CheckShaderAndCreateMaterial(blurShader, blurMaterial);
		depthFetchMaterial = CheckShaderAndCreateMaterial(depthFetchShader, depthFetchMaterial);
		creaseApplyMaterial = CheckShaderAndCreateMaterial(creaseApplyShader, creaseApplyMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		int width = source.width;
		int height = source.height;
		float num = 1f * (float)width / (1f * (float)height);
		float num2 = 0.001953125f;
		RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
		RenderTexture renderTexture = RenderTexture.GetTemporary(width / 2, height / 2, 0);
		Graphics.Blit(source, temporary, depthFetchMaterial);
		Graphics.Blit(temporary, renderTexture);
		for (int i = 0; i < softness; i++)
		{
			RenderTexture temporary2 = RenderTexture.GetTemporary(width / 2, height / 2, 0);
			blurMaterial.SetVector("offsets", new Vector4(0f, spread * num2, 0f, 0f));
			Graphics.Blit(renderTexture, temporary2, blurMaterial);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary2;
			temporary2 = RenderTexture.GetTemporary(width / 2, height / 2, 0);
			blurMaterial.SetVector("offsets", new Vector4(spread * num2 / num, 0f, 0f, 0f));
			Graphics.Blit(renderTexture, temporary2, blurMaterial);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary2;
		}
		creaseApplyMaterial.SetTexture("_HrDepthTex", temporary);
		creaseApplyMaterial.SetTexture("_LrDepthTex", renderTexture);
		creaseApplyMaterial.SetFloat("intensity", intensity);
		Graphics.Blit(source, destination, creaseApplyMaterial);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	public override void Main()
	{
	}
}
