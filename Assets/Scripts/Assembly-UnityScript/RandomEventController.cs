using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class RandomEventController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StartRandomEvent_00241349 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal int _0024_0024switch_0024186_00241350;

			internal RandomEventController _0024self__00241351;

			public _0024(RandomEventController self_)
			{
				_0024self__00241351 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00241351.random != -1)
					{
						_0024self__00241351.random = UnityEngine.Random.Range(0, 7);
						_0024_0024switch_0024186_00241350 = _0024self__00241351.random;
						if (_0024_0024switch_0024186_00241350 == 0)
						{
							if (_0024self__00241351.status.switches[22] == 0)
							{
								_0024self__00241351.status.switches[22] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else if (_0024_0024switch_0024186_00241350 == 1)
						{
							if (_0024self__00241351.status.switches[23] == 0)
							{
								_0024self__00241351.status.switches[23] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else if (_0024_0024switch_0024186_00241350 == 2)
						{
							if (_0024self__00241351.status.switches[24] == 0)
							{
								_0024self__00241351.status.switches[24] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else if (_0024_0024switch_0024186_00241350 == 3)
						{
							if (_0024self__00241351.status.switches[25] == 0)
							{
								_0024self__00241351.status.switches[25] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else if (_0024_0024switch_0024186_00241350 == 4)
						{
							if (_0024self__00241351.status.switches[26] == 0)
							{
								_0024self__00241351.status.switches[26] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else if (_0024_0024switch_0024186_00241350 == 5)
						{
							if (_0024self__00241351.status.switches[27] == 0)
							{
								_0024self__00241351.status.switches[27] = 1;
								_0024self__00241351.SendMessage("CommonAction", _0024self__00241351.random, SendMessageOptions.DontRequireReceiver);
								_0024self__00241351.random = -1;
							}
						}
						else
						{
							_0024self__00241351.random = -1;
						}
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
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

		internal RandomEventController _0024self__00241352;

		public _0024StartRandomEvent_00241349(RandomEventController self_)
		{
			_0024self__00241352 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__00241352);
		}
	}

	private int random;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual IEnumerator StartRandomEvent()
	{
		return new _0024StartRandomEvent_00241349(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
