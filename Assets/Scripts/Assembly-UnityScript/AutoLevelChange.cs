using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AutoLevelChange : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024LevelChange_0024920 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AutoLevelChange _0024self__0024921;

			public _0024(AutoLevelChange self_)
			{
				_0024self__0024921 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__0024921.untilTime)) ? 1 : 0);
					break;
				case 2:
					Application.LoadLevel(_0024self__0024921.levelName);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AutoLevelChange _0024self__0024922;

		public _0024LevelChange_0024920(AutoLevelChange self_)
		{
			_0024self__0024922 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024922);
		}
	}

	public float untilTime;

	public string levelName;

	public virtual void Start()
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
		StartCoroutine_Auto(LevelChange());
	}

	public virtual IEnumerator LevelChange()
	{
		return new _0024LevelChange_0024920(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
