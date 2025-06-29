using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TVController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Noise_00241390 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_0024804_00241391;

			internal Vector2 _0024_0024805_00241392;

			internal float _0024_0024806_00241393;

			internal Vector2 _0024_0024807_00241394;

			internal float _0024_0024808_00241395;

			internal Vector2 _0024_0024809_00241396;

			internal float _0024_0024810_00241397;

			internal Vector2 _0024_0024811_00241398;

			internal TVController _0024self__00241399;

			public _0024(TVController self_)
			{
				_0024self__00241399 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				float num5;
				Vector2 vector7;
				float num6;
				Vector2 vector8;
				float num7;
				Vector2 vector10;
				float num8;
				Vector2 vector11;
				switch (_state)
				{
				default:
					_0024self__00241399.random = UnityEngine.Random.Range(32, 31);
					_0024self__00241399.i = 0;
					goto IL_018f;
				case 2:
					if (!_0024self__00241399.switchFlag)
					{
						goto IL_01aa;
					}
					_0024self__00241399.i++;
					goto IL_018f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_018f:
					if (_0024self__00241399.i <= _0024self__00241399.random)
					{
						_0024self__00241399.random2 = UnityEngine.Random.Range(-1f, 1f);
						float num = (_0024_0024804_00241391 = _0024self__00241399.random2);
						Vector2 vector = (_0024_0024805_00241392 = _0024self__00241399.noiseMaterial.renderer.material.mainTextureOffset);
						float num2 = (_0024_0024805_00241392.y = _0024_0024804_00241391);
						Vector2 vector2 = (_0024self__00241399.noiseMaterial.renderer.material.mainTextureOffset = _0024_0024805_00241392);
						float num3 = (_0024_0024806_00241393 = _0024self__00241399.random2);
						Vector2 vector4 = (_0024_0024807_00241394 = _0024self__00241399.pictureMaterial.renderer.material.mainTextureOffset);
						float num4 = (_0024_0024807_00241394.y = _0024_0024806_00241393);
						Vector2 vector5 = (_0024self__00241399.pictureMaterial.renderer.material.mainTextureOffset = _0024_0024807_00241394);
						result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.1f))) ? 1 : 0);
						break;
					}
					goto IL_01aa;
					IL_01aa:
					num5 = (_0024_0024808_00241395 = 0f);
					vector7 = (_0024_0024809_00241396 = _0024self__00241399.noiseMaterial.renderer.material.mainTextureOffset);
					num6 = (_0024_0024809_00241396.y = _0024_0024808_00241395);
					vector8 = (_0024self__00241399.noiseMaterial.renderer.material.mainTextureOffset = _0024_0024809_00241396);
					num7 = (_0024_0024810_00241397 = 0f);
					vector10 = (_0024_0024811_00241398 = _0024self__00241399.pictureMaterial.renderer.material.mainTextureOffset);
					num8 = (_0024_0024811_00241398.y = _0024_0024810_00241397);
					vector11 = (_0024self__00241399.pictureMaterial.renderer.material.mainTextureOffset = _0024_0024811_00241398);
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TVController _0024self__00241400;

		public _0024Noise_00241390(TVController self_)
		{
			_0024self__00241400 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241400);
		}
	}

	[Serializable]
	internal sealed class _0024NoiseShort_00241401 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_0024812_00241402;

			internal Vector2 _0024_0024813_00241403;

			internal float _0024_0024814_00241404;

			internal Vector2 _0024_0024815_00241405;

			internal float _0024_0024816_00241406;

			internal Vector2 _0024_0024817_00241407;

			internal float _0024_0024818_00241408;

			internal Vector2 _0024_0024819_00241409;

			internal TVController _0024self__00241410;

			public _0024(TVController self_)
			{
				_0024self__00241410 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				float num5;
				Vector2 vector7;
				float num6;
				Vector2 vector8;
				float num7;
				Vector2 vector10;
				float num8;
				Vector2 vector11;
				switch (_state)
				{
				default:
					_0024self__00241410.random = UnityEngine.Random.Range(8, 9);
					_0024self__00241410.i = 0;
					goto IL_018e;
				case 2:
					if (!_0024self__00241410.switchFlag)
					{
						goto IL_01a9;
					}
					_0024self__00241410.i++;
					goto IL_018e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_018e:
					if (_0024self__00241410.i <= _0024self__00241410.random)
					{
						_0024self__00241410.random2 = UnityEngine.Random.Range(-1f, 1f);
						float num = (_0024_0024812_00241402 = _0024self__00241410.random2);
						Vector2 vector = (_0024_0024813_00241403 = _0024self__00241410.noiseMaterial.renderer.material.mainTextureOffset);
						float num2 = (_0024_0024813_00241403.y = _0024_0024812_00241402);
						Vector2 vector2 = (_0024self__00241410.noiseMaterial.renderer.material.mainTextureOffset = _0024_0024813_00241403);
						float num3 = (_0024_0024814_00241404 = _0024self__00241410.random2);
						Vector2 vector4 = (_0024_0024815_00241405 = _0024self__00241410.pictureMaterial.renderer.material.mainTextureOffset);
						float num4 = (_0024_0024815_00241405.y = _0024_0024814_00241404);
						Vector2 vector5 = (_0024self__00241410.pictureMaterial.renderer.material.mainTextureOffset = _0024_0024815_00241405);
						result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.1f))) ? 1 : 0);
						break;
					}
					goto IL_01a9;
					IL_01a9:
					num5 = (_0024_0024816_00241406 = 0f);
					vector7 = (_0024_0024817_00241407 = _0024self__00241410.noiseMaterial.renderer.material.mainTextureOffset);
					num6 = (_0024_0024817_00241407.y = _0024_0024816_00241406);
					vector8 = (_0024self__00241410.noiseMaterial.renderer.material.mainTextureOffset = _0024_0024817_00241407);
					num7 = (_0024_0024818_00241408 = 0f);
					vector10 = (_0024_0024819_00241409 = _0024self__00241410.pictureMaterial.renderer.material.mainTextureOffset);
					num8 = (_0024_0024819_00241409.y = _0024_0024818_00241408);
					vector11 = (_0024self__00241410.pictureMaterial.renderer.material.mainTextureOffset = _0024_0024819_00241409);
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TVController _0024self__00241411;

		public _0024NoiseShort_00241401(TVController self_)
		{
			_0024self__00241411 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241411);
		}
	}

	public GameObject channelObject;

	public GameObject noiseMaterial;

	public GameObject pictureMaterial;

	public AudioClip audioSwitch;

	public GameObject noiseAudioObject;

	public bool pictureFlag;

	private bool switchFlag;

	private int i;

	private int random;

	private float random2;

	private float remainingTime;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		if (status.switches[30] == 1)
		{
			switchFlag = true;
			float a = 1f;
			Color color = noiseMaterial.renderer.material.color;
			float num = (color.a = a);
			Color color2 = (noiseMaterial.renderer.material.color = color);
			noiseAudioObject.audio.volume = 0.6f;
			remainingTime = UnityEngine.Random.Range(2f, 16f);
		}
	}

	public virtual void Update()
	{
		if (!switchFlag)
		{
			float z = Mathf.Lerp(channelObject.transform.localEulerAngles.z, 0f, 0.4f);
			Vector3 localEulerAngles = channelObject.transform.localEulerAngles;
			float num = (localEulerAngles.z = z);
			Vector3 vector = (channelObject.transform.localEulerAngles = localEulerAngles);
			float a = Mathf.Lerp(noiseMaterial.renderer.material.color.a, 0f, 0.1f);
			Color color = noiseMaterial.renderer.material.color;
			float num2 = (color.a = a);
			Color color2 = (noiseMaterial.renderer.material.color = color);
			float a2 = Mathf.Lerp(pictureMaterial.renderer.material.color.a, 0f, 0.1f);
			Color color4 = pictureMaterial.renderer.material.color;
			float num3 = (color4.a = a2);
			Color color5 = (pictureMaterial.renderer.material.color = color4);
			noiseAudioObject.audio.volume = Mathf.Lerp(noiseAudioObject.audio.volume, 0f, 0.1f);
			return;
		}
		float z2 = Mathf.Lerp(channelObject.transform.localEulerAngles.z, 90f, 0.4f);
		Vector3 localEulerAngles2 = channelObject.transform.localEulerAngles;
		float num4 = (localEulerAngles2.z = z2);
		Vector3 vector3 = (channelObject.transform.localEulerAngles = localEulerAngles2);
		if (!pictureFlag)
		{
			float a3 = Mathf.Lerp(noiseMaterial.renderer.material.color.a, 1f, 0.002f);
			Color color7 = noiseMaterial.renderer.material.color;
			float num5 = (color7.a = a3);
			Color color8 = (noiseMaterial.renderer.material.color = color7);
		}
		else
		{
			float a4 = Mathf.Lerp(noiseMaterial.renderer.material.color.a, 0.78f, 0.01f);
			Color color10 = noiseMaterial.renderer.material.color;
			float num6 = (color10.a = a4);
			Color color11 = (noiseMaterial.renderer.material.color = color10);
			float a5 = Mathf.Lerp(pictureMaterial.renderer.material.color.a, 1f, 0.002f);
			Color color13 = pictureMaterial.renderer.material.color;
			float num7 = (color13.a = a5);
			Color color14 = (pictureMaterial.renderer.material.color = color13);
		}
		noiseAudioObject.audio.volume = Mathf.Lerp(noiseAudioObject.audio.volume, 0.6f, 0.002f);
		float y = Mathf.Lerp(noiseMaterial.renderer.material.mainTextureOffset.y, 0f, 0.004f);
		Vector2 mainTextureOffset = noiseMaterial.renderer.material.mainTextureOffset;
		float num8 = (mainTextureOffset.y = y);
		Vector2 vector5 = (noiseMaterial.renderer.material.mainTextureOffset = mainTextureOffset);
		float y2 = Mathf.Lerp(pictureMaterial.renderer.material.mainTextureOffset.y, 0f, 0.004f);
		Vector2 mainTextureOffset2 = pictureMaterial.renderer.material.mainTextureOffset;
		float num9 = (mainTextureOffset2.y = y2);
		Vector2 vector7 = (pictureMaterial.renderer.material.mainTextureOffset = mainTextureOffset2);
		remainingTime -= 1f * Time.deltaTime;
		if (!(remainingTime > 0f))
		{
			remainingTime = UnityEngine.Random.Range(2f, 16f);
			StartCoroutine_Auto(NoiseShort());
		}
	}

	public virtual void ChangeSwitch()
	{
		audio.PlayOneShot(audioSwitch);
		if (!switchFlag)
		{
			switchFlag = true;
			StartCoroutine_Auto(Noise());
			remainingTime = UnityEngine.Random.Range(8f, 16f);
			status.switches[30] = 1;
		}
		else
		{
			switchFlag = false;
			pictureFlag = false;
			status.switches[30] = 0;
		}
	}

	public virtual void PictureEvent()
	{
		status.switches[30] = 1;
		pictureFlag = true;
		switchFlag = true;
		StartCoroutine_Auto(Noise());
		remainingTime = UnityEngine.Random.Range(8f, 16f);
	}

	public virtual IEnumerator Noise()
	{
		return new _0024Noise_00241390(this).GetEnumerator();
	}

	public virtual IEnumerator NoiseShort()
	{
		return new _0024NoiseShort_00241401(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
