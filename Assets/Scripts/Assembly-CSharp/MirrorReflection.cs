using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class MirrorReflection : MonoBehaviour
{
	public bool m_DisablePixelLights = true;

	public int m_TextureSize = 256;

	public float m_ClipPlaneOffset = 0.07f;

	public LayerMask m_ReflectLayers = -1;

	private Hashtable m_ReflectionCameras = new Hashtable();

	private RenderTexture m_ReflectionTexture;

	private int m_OldReflectionTextureSize;

	private static bool s_InsideRendering;

	public void OnWillRenderObject()
	{
		if (!base.enabled || !base.renderer || !base.renderer.sharedMaterial || !base.renderer.enabled)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current || s_InsideRendering)
		{
			return;
		}
		s_InsideRendering = true;
		Camera reflectionCamera;
		CreateMirrorObjects(current, out reflectionCamera);
		Vector3 position = base.transform.position;
		Vector3 up = base.transform.up;
		int pixelLightCount = QualitySettings.pixelLightCount;
		if (m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = 0;
		}
		UpdateCameraModes(current, reflectionCamera);
		float w = 0f - Vector3.Dot(up, position) - m_ClipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 reflectionMat = Matrix4x4.zero;
		CalculateReflectionMatrix(ref reflectionMat, plane);
		Vector3 position2 = current.transform.position;
		Vector3 position3 = reflectionMat.MultiplyPoint(position2);
		reflectionCamera.worldToCameraMatrix = current.worldToCameraMatrix * reflectionMat;
		Vector4 clipPlane = CameraSpacePlane(reflectionCamera, position, up, 1f);
		Matrix4x4 projection = current.projectionMatrix;
		CalculateObliqueMatrix(ref projection, clipPlane);
		reflectionCamera.projectionMatrix = projection;
		reflectionCamera.cullingMask = -17 & m_ReflectLayers.value;
		reflectionCamera.targetTexture = m_ReflectionTexture;
		GL.SetRevertBackfacing(true);
		reflectionCamera.transform.position = position3;
		Vector3 eulerAngles = current.transform.eulerAngles;
		reflectionCamera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
		reflectionCamera.Render();
		reflectionCamera.transform.position = position2;
		GL.SetRevertBackfacing(false);
		Material[] sharedMaterials = base.renderer.sharedMaterials;
		Material[] array = sharedMaterials;
		foreach (Material material in array)
		{
			if (material.HasProperty("_ReflectionTex"))
			{
				material.SetTexture("_ReflectionTex", m_ReflectionTexture);
			}
		}
		Matrix4x4 matrix4x = Matrix4x4.TRS(new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, new Vector3(0.5f, 0.5f, 0.5f));
		Vector3 lossyScale = base.transform.lossyScale;
		Matrix4x4 matrix4x2 = base.transform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1f / lossyScale.x, 1f / lossyScale.y, 1f / lossyScale.z));
		matrix4x2 = matrix4x * current.projectionMatrix * current.worldToCameraMatrix * matrix4x2;
		Material[] array2 = sharedMaterials;
		foreach (Material material2 in array2)
		{
			material2.SetMatrix("_ProjMatrix", matrix4x2);
		}
		if (m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = pixelLightCount;
		}
		s_InsideRendering = false;
	}

	private void OnDisable()
	{
		if ((bool)m_ReflectionTexture)
		{
			Object.DestroyImmediate(m_ReflectionTexture);
			m_ReflectionTexture = null;
		}
		foreach (DictionaryEntry reflectionCamera in m_ReflectionCameras)
		{
			Object.DestroyImmediate(((Camera)reflectionCamera.Value).gameObject);
		}
		m_ReflectionCameras.Clear();
	}

	private void UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
			Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
			if (!skybox || !skybox.material)
			{
				skybox2.enabled = false;
			}
			else
			{
				skybox2.enabled = true;
				skybox2.material = skybox.material;
			}
		}
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
	}

	private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		reflectionCamera = null;
		if (!m_ReflectionTexture || m_OldReflectionTextureSize != m_TextureSize)
		{
			if ((bool)m_ReflectionTexture)
			{
				Object.DestroyImmediate(m_ReflectionTexture);
			}
			m_ReflectionTexture = new RenderTexture(m_TextureSize, m_TextureSize, 16);
			m_ReflectionTexture.name = "__MirrorReflection" + GetInstanceID();
			m_ReflectionTexture.isPowerOfTwo = true;
			m_ReflectionTexture.hideFlags = HideFlags.DontSave;
			m_OldReflectionTextureSize = m_TextureSize;
		}
		reflectionCamera = m_ReflectionCameras[currentCamera] as Camera;
		if (!reflectionCamera)
		{
			GameObject gameObject = new GameObject("Mirror Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera), typeof(Skybox));
			reflectionCamera = gameObject.camera;
			reflectionCamera.enabled = false;
			reflectionCamera.transform.position = base.transform.position;
			reflectionCamera.transform.rotation = base.transform.rotation;
			reflectionCamera.renderingPath = RenderingPath.Forward;
			reflectionCamera.gameObject.AddComponent("FlareLayer");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			m_ReflectionCameras[currentCamera] = reflectionCamera;
		}
	}

	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 v = pos + normal * m_ClipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
	}

	private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(sgn(clipPlane.x), sgn(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
	}

	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}
}
