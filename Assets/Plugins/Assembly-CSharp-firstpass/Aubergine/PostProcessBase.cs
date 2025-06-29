using UnityEngine;

namespace Aubergine
{
	[AddComponentMenu("")]
	public abstract class PostProcessBase : MonoBehaviour
	{
		protected Shader shader;

		private Material m_Material;

		protected Material material
		{
			get
			{
				if (m_Material == null)
				{
					m_Material = new Material(shader);
					m_Material.hideFlags = HideFlags.HideAndDontSave;
				}
				return m_Material;
			}
		}

		protected void OnEnable()
		{
			if (!SystemInfo.supportsImageEffects)
			{
				base.enabled = false;
			}
			else if (!shader || !shader.isSupported)
			{
				base.enabled = false;
			}
		}

		protected void OnDisable()
		{
			if ((bool)m_Material)
			{
				Object.DestroyImmediate(m_Material);
			}
		}
	}
}
