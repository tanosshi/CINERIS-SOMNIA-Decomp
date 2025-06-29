using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_23_ChangeLightInfo : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StopFade_00241100 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024num_00241101;

			internal Event_23_ChangeLightInfo _0024self__00241102;

			public _0024(int num, Event_23_ChangeLightInfo self_)
			{
				_0024num_00241101 = num;
				_0024self__00241102 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__00241102.state[_0024num_00241101].time)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00241102.fadeFlag[_0024num_00241101])
					{
						if (_0024self__00241102.state[_0024num_00241101].changeRange)
						{
							_0024self__00241102.lights[_0024num_00241101].range = _0024self__00241102.state[_0024num_00241101].range;
						}
						if (_0024self__00241102.state[_0024num_00241101].changeColor)
						{
							_0024self__00241102.lights[_0024num_00241101].color = _0024self__00241102.state[_0024num_00241101].color;
						}
						if (_0024self__00241102.state[_0024num_00241101].changeIntensity)
						{
							_0024self__00241102.lights[_0024num_00241101].intensity = _0024self__00241102.state[_0024num_00241101].intensity;
						}
						if (_0024self__00241102.state[_0024num_00241101].changeSpotAngle)
						{
							_0024self__00241102.lights[_0024num_00241101].spotAngle = _0024self__00241102.state[_0024num_00241101].spotAngle;
						}
						_0024self__00241102.fadeFlag[_0024num_00241101] = false;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241103;

		internal Event_23_ChangeLightInfo _0024self__00241104;

		public _0024StopFade_00241100(int num, Event_23_ChangeLightInfo self_)
		{
			_0024num_00241103 = num;
			_0024self__00241104 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024num_00241103, _0024self__00241104);
		}
	}

	public CtrlLightInfo[] state;

	private Light[] lights;

	private bool[] fadeFlag;

	private int i;

	public virtual void Start()
	{
		lights = new Light[state.Length];
		fadeFlag = new bool[state.Length];
		for (i = 0; i < state.Length; i++)
		{
			lights[i] = (Light)state[i].targetLight.GetComponent(typeof(Light));
			fadeFlag[i] = false;
		}
	}

	public virtual void Update()
	{
		if (state.Length == 0)
		{
			return;
		}
		for (i = 0; i < state.Length; i++)
		{
			if (fadeFlag[i])
			{
				if (state[i].changeRange)
				{
					lights[i].range = Mathf.Lerp(lights[i].range, state[i].range, Time.deltaTime * 5f / state[i].time);
				}
				if (state[i].changeColor)
				{
					float r = Mathf.Lerp(lights[i].color.r, state[i].color.r, Time.deltaTime * 5f / state[i].time);
					Color color = lights[i].color;
					float num = (color.r = r);
					Color color2 = (lights[i].color = color);
					float g = Mathf.Lerp(lights[i].color.g, state[i].color.g, Time.deltaTime * 5f / state[i].time);
					Color color4 = lights[i].color;
					float num2 = (color4.g = g);
					Color color5 = (lights[i].color = color4);
					float b = Mathf.Lerp(lights[i].color.b, state[i].color.b, Time.deltaTime * 5f / state[i].time);
					Color color7 = lights[i].color;
					float num3 = (color7.b = b);
					Color color8 = (lights[i].color = color7);
				}
				if (state[i].changeIntensity)
				{
					lights[i].intensity = Mathf.Lerp(lights[i].intensity, state[i].intensity, Time.deltaTime * 5f / state[i].time);
				}
				if (state[i].changeSpotAngle)
				{
					lights[i].spotAngle = Mathf.Lerp(lights[i].spotAngle, state[i].spotAngle, Time.deltaTime * 5f / state[i].time);
				}
				StartCoroutine_Auto(StopFade(i));
			}
		}
	}

	public virtual void ChangeLightInfo(int num)
	{
		if (state[num].operation == DisableOrEnable.Disabled)
		{
			lights[num].enabled = false;
		}
		else
		{
			lights[num].enabled = true;
		}
		if (state[num].time == 0f)
		{
			if (state[num].changeRange)
			{
				lights[num].range = state[num].range;
			}
			if (state[num].changeColor)
			{
				lights[num].color = state[num].color;
			}
			if (state[num].changeIntensity)
			{
				lights[num].intensity = state[num].intensity;
			}
			if (state[num].changeSpotAngle)
			{
				lights[num].spotAngle = state[num].spotAngle;
			}
		}
		else
		{
			fadeFlag[num] = true;
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual IEnumerator StopFade(int num)
	{
		return new _0024StopFade_00241100(num, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
