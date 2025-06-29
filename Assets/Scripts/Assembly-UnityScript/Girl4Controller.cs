using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Girl4Controller : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024FindTarget_00241127 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241128;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241128 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241128.enterFlag && !_0024self__00241128.exitFlag)
					{
						_0024self__00241128.nowFinding = true;
						if (_0024self__00241128.navagent.enabled)
						{
							_0024self__00241128.navagent.Stop();
						}
						if (_0024self__00241128.encounterFlag)
						{
							if (!_0024self__00241128.exitFlag)
							{
								_0024self__00241128.animator.CrossFade("Find", 0.2f, 0);
							}
							else
							{
								_0024self__00241128.animator.CrossFade("Walk", 0.2f, 0);
							}
						}
						_0024self__00241128.findCount = UnityEngine.Random.Range(_0024self__00241128.stopCountMin, _0024self__00241128.stopCountMax);
						result = (Yield(2, new WaitForSeconds(_0024self__00241128.findCount)) ? 1 : 0);
						break;
					}
					goto IL_01e7;
				case 2:
					_0024self__00241128.findCount = UnityEngine.Random.Range(_0024self__00241128.findCountMin, _0024self__00241128.findCountMax);
					_0024self__00241128.findFlag = false;
					_0024self__00241128.nowFinding = false;
					if (!(Vector3.Distance(_0024self__00241128.myTransform.position, _0024self__00241128.nowClearingPoint.position) > 1.2f))
					{
						_0024self__00241128.clearingCount = 0f;
					}
					else
					{
						if (_0024self__00241128.navagent.enabled)
						{
							_0024self__00241128.navagent.SetDestination(_0024self__00241128.nowClearingPoint.position);
						}
						if (_0024self__00241128.encounterFlag)
						{
							_0024self__00241128.animator.CrossFade("Walk", 0.2f, 0);
						}
					}
					goto IL_01e7;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241129;

		public _0024FindTarget_00241127(Girl4Controller self_)
		{
			_0024self__00241129 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241129);
		}
	}

	[Serializable]
	internal sealed class _0024AttackTarget_00241130 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024swingFlag_00241131;

			internal Girl4Controller _0024self__00241132;

			public _0024(bool swingFlag, Girl4Controller self_)
			{
				_0024swingFlag_00241131 = swingFlag;
				_0024self__00241132 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241132.nowAttacking = true;
					_0024self__00241132.rotateSpeedAttack = 20f;
					if (!_0024swingFlag_00241131)
					{
						_0024self__00241132.random = UnityEngine.Random.Range(0, 100);
					}
					else
					{
						_0024self__00241132.random = 1;
					}
					if (_0024self__00241132.random >= 10)
					{
						if (!_0024self__00241132.hideFlag)
						{
							_0024self__00241132.animator.SetBool("Attack", true);
							result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
							break;
						}
					}
					else
					{
						_0024self__00241132.random = UnityEngine.Random.Range(0, 100);
						if (!_0024self__00241132.hideFlag)
						{
							_0024self__00241132.animator.SetBool("Swing", true);
							result = (Yield(4, new WaitForSeconds(0.34f)) ? 1 : 0);
							break;
						}
					}
					goto case 1;
				case 2:
					if (_0024self__00241132.hideFlag)
					{
						goto case 1;
					}
					_0024self__00241132.animator.SetBool("Attack", false);
					result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 4:
					if (_0024self__00241132.hideFlag)
					{
						goto case 1;
					}
					if (_0024self__00241132.random <= 40)
					{
						_0024self__00241132.animator.SetBool("Attack", true);
					}
					_0024self__00241132.animator.SetBool("Swing", false);
					result = (Yield(5, new WaitForSeconds(0.86f)) ? 1 : 0);
					break;
				case 5:
					if (_0024self__00241132.hideFlag)
					{
						goto case 1;
					}
					if (_0024self__00241132.random <= 40)
					{
						_0024self__00241132.animator.SetBool("Attack", false);
						result = (Yield(6, new WaitForSeconds(3.6f)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
				case 6:
					_0024self__00241132.nowAttacking = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024swingFlag_00241133;

		internal Girl4Controller _0024self__00241134;

		public _0024AttackTarget_00241130(bool swingFlag, Girl4Controller self_)
		{
			_0024swingFlag_00241133 = swingFlag;
			_0024self__00241134 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024swingFlag_00241133, _0024self__00241134);
		}
	}

	[Serializable]
	internal sealed class _0024DashAttack_00241135 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024randomVoice_00241136;

			internal Girl4Controller _0024self__00241137;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241137 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241137.clearingCount = 9999f;
					_0024self__00241137.random = UnityEngine.Random.Range(0, 100);
					if (_0024self__00241137.random <= 70)
					{
						_0024self__00241137.random = UnityEngine.Random.Range(0, 100);
						if (_0024self__00241137.random >= 30)
						{
							_0024self__00241137.nowDashing = true;
							result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(8f, 12f))) ? 1 : 0);
							break;
						}
						if (!_0024self__00241137.nowAttacking)
						{
							_0024self__00241137.navagent.angularSpeed = _0024self__00241137.rotateSpeedNotice;
							_0024self__00241137.animator.SetBool("Walk", false);
							_0024self__00241137.animator.SetBool("Run", false);
							_0024self__00241137.animator.SetBool("Attack", false);
							_0024self__00241137.animator.SetBool("Swing", false);
							_0024self__00241137.nowDashAttacking = true;
							_0024self__00241137.dashAttackId = 0;
							_0024self__00241137.animator.CrossFade("DashStart", 0.2f, 0);
							_0024self__00241137.voice.enabled = false;
							if (_0024self__00241137.dashAttackVoices.Length != 0)
							{
								_0024self__00241137.voice.gameObject.audio.Stop();
								_0024randomVoice_00241136 = default(int);
								_0024randomVoice_00241136 = UnityEngine.Random.Range(0, _0024self__00241137.dashAttackVoices.Length);
								_0024self__00241137.voice.gameObject.audio.PlayOneShot(_0024self__00241137.dashAttackVoices[_0024randomVoice_00241136]);
								if (_0024randomVoice_00241136 == 0)
								{
									_0024self__00241137.animator.CrossFade("19_07", 0.1f, 5);
								}
								else
								{
									_0024self__00241137.animator.CrossFade("19_08", 0.1f, 5);
								}
							}
							result = (Yield(3, new WaitForSeconds(0.8f)) ? 1 : 0);
							break;
						}
						_0024self__00241137.clearingCount = UnityEngine.Random.Range(4f, 8f);
					}
					else
					{
						_0024self__00241137.clearingCount = UnityEngine.Random.Range(4f, 8f);
					}
					goto IL_02bc;
				case 2:
					_0024self__00241137.nowDashing = false;
					_0024self__00241137.clearingCount = UnityEngine.Random.Range(6f, 12f);
					goto IL_02bc;
				case 3:
					_0024self__00241137.dashAttackId = 1;
					goto IL_02bc;
				case 1:
					{
						result = 0;
						break;
					}
					IL_02bc:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241138;

		public _0024DashAttack_00241135(Girl4Controller self_)
		{
			_0024self__00241138 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241138);
		}
	}

	[Serializable]
	internal sealed class _0024DashAttackEnd_00241139 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241140;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241140 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.34f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241140.dashAttackId = 3;
					_0024self__00241140.animator.CrossFade("DashAttack", 0.2f, 0);
					result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241140.navagent.angularSpeed = 80f;
					_0024self__00241140.clearingCount = UnityEngine.Random.Range(8f, 12f);
					_0024self__00241140.dashAttackId = 0;
					_0024self__00241140.nowDashAttacking = false;
					_0024self__00241140.voice.enabled = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241141;

		public _0024DashAttackEnd_00241139(Girl4Controller self_)
		{
			_0024self__00241141 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241141);
		}
	}

	[Serializable]
	internal sealed class _0024StopMove_00241142 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241143;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241143 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241143.nowStopping = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241144;

		public _0024StopMove_00241142(Girl4Controller self_)
		{
			_0024self__00241144 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241144);
		}
	}

	[Serializable]
	internal sealed class _0024ChangeAudioTempFlag_00241145 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024id_00241146;

			internal Girl4Controller _0024self__00241147;

			public _0024(int id, Girl4Controller self_)
			{
				_0024id_00241146 = id;
				_0024self__00241147 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024id_00241146 == 0)
					{
						_0024self__00241147.audioTempFlagHit = true;
						result = (Yield(2, new WaitForSeconds(0.04f)) ? 1 : 0);
						break;
					}
					if (_0024id_00241146 == 1)
					{
						_0024self__00241147.audioTempFlagSwing = true;
						result = (Yield(3, new WaitForSeconds(0.04f)) ? 1 : 0);
						break;
					}
					if (_0024id_00241146 == 3)
					{
						_0024self__00241147.audioTempFlagDrag = true;
						result = (Yield(4, new WaitForSeconds(0.04f)) ? 1 : 0);
						break;
					}
					goto IL_00d6;
				case 2:
					_0024self__00241147.audioTempFlagHit = false;
					goto IL_00d6;
				case 3:
					_0024self__00241147.audioTempFlagSwing = false;
					goto IL_00d6;
				case 4:
					_0024self__00241147.audioTempFlagDrag = false;
					goto IL_00d6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00d6:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024id_00241148;

		internal Girl4Controller _0024self__00241149;

		public _0024ChangeAudioTempFlag_00241145(int id, Girl4Controller self_)
		{
			_0024id_00241148 = id;
			_0024self__00241149 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024id_00241148, _0024self__00241149);
		}
	}

	[Serializable]
	internal sealed class _0024SpawnEnter_00241150 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal Girl4Controller _0024self__00241151;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241151 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241151.encounterFlag)
					{
						if (!_0024self__00241151.status.nowEventing)
						{
							_0024self__00241151.random2 = UnityEngine.Random.Range(0, _0024self__00241151.spawnPointEnter.Length);
							goto case 2;
						}
						_0024self__00241151.status.switches[408] = 1;
					}
					goto IL_02e7;
				case 2:
					if (_0024self__00241151.status.nowEventing)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__00241151.encounterFlag = true;
					_0024self__00241151.clearingCount = 9999f;
					_0024self__00241151.findCount = 9999f;
					if (_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorEvent != null && !_0024self__00241151.status.nowChangeLeveling)
					{
						_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorEvent.SetActive(false);
					}
					if (_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorObject != null)
					{
						_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorObject.SendMessage("Open");
					}
					_0024self__00241151.myTransform.position = _0024self__00241151.spawnPointEnter[_0024self__00241151.random2].spawnTransform.position;
					_0024self__00241151.myTransform.rotation = _0024self__00241151.spawnPointEnter[_0024self__00241151.random2].spawnTransform.rotation;
					_0024self__00241151.enterFlag = true;
					_0024self__00241151.animator.CrossFade("Walk", 0.2f, 0);
					result = (Yield(3, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241151.enterFlag = false;
					_0024self__00241151.gameObject.collider.enabled = true;
					_0024self__00241151.navagent.enabled = true;
					_0024self__00241151.clearingCount = 0f;
					_0024self__00241151.findCount = UnityEngine.Random.Range(_0024self__00241151.findCountMin, _0024self__00241151.findCountMax);
					result = (Yield(4, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 4:
					if (_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorEvent != null)
					{
						_0024self__00241151.spawnPointEnter[_0024self__00241151.random2].doorEvent.SetActive(true);
					}
					goto IL_02e7;
				case 1:
					{
						result = 0;
						break;
					}
					IL_02e7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241152;

		public _0024SpawnEnter_00241150(Girl4Controller self_)
		{
			_0024self__00241152 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241152);
		}
	}

	[Serializable]
	internal sealed class _0024ChaseEnter_00241153 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal Girl4Controller _0024self__00241154;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241154 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241154.encounterFlag = true;
					_0024self__00241154.clearingCount = 9999f;
					_0024self__00241154.findCount = 9999f;
					if (!_0024self__00241154.specialWait)
					{
						_0024self__00241154.random2 = (int)UnityEngine.Random.Range(2f, 8f);
						result = (Yield(2, new WaitForSeconds(_0024self__00241154.random2)) ? 1 : 0);
					}
					else
					{
						result = (Yield(5, new WaitForSeconds(8f)) ? 1 : 0);
					}
					break;
				case 2:
					if (_0024self__00241154.hideArea)
					{
						result = (Yield(3, new WaitForSeconds(UnityEngine.Random.Range(2f, 4f))) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
				case 4:
					if (_0024self__00241154.status.nowChangeLeveling)
					{
						result = (Yield(4, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					if (_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorEvent != null && !_0024self__00241154.status.nowChangeLeveling)
					{
						_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorEvent.SetActive(false);
					}
					if (_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorObject != null)
					{
						_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorObject.SendMessage("Open");
					}
					_0024self__00241154.myTransform.position = _0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].spawnTransform.position;
					_0024self__00241154.myTransform.rotation = _0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].spawnTransform.rotation;
					_0024self__00241154.enterFlag = true;
					_0024self__00241154.animator.CrossFade("Walk", 0.2f, 0);
					result = (Yield(6, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 6:
					_0024self__00241154.enterFlag = false;
					_0024self__00241154.navagent.enabled = true;
					_0024self__00241154.findFlag = false;
					_0024self__00241154.nowFinding = false;
					if (!_0024self__00241154.hideFlag)
					{
						_0024self__00241154.gameObject.collider.enabled = true;
						_0024self__00241154.noticeFlag = true;
						_0024self__00241154.animator.SetBool("Find", true);
						_0024self__00241154.clearingCount = UnityEngine.Random.Range(2f, 4f);
					}
					else
					{
						_0024self__00241154.gameObject.collider.enabled = false;
						_0024self__00241154.clearingCount = 0f;
					}
					_0024self__00241154.findCount = UnityEngine.Random.Range(_0024self__00241154.findCountMin, _0024self__00241154.findCountMax);
					result = (Yield(7, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 7:
					if (_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorEvent != null)
					{
						_0024self__00241154.spawnPointEnter[(int)_0024self__00241154.status.variables[409]].doorEvent.SetActive(true);
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

		internal Girl4Controller _0024self__00241155;

		public _0024ChaseEnter_00241153(Girl4Controller self_)
		{
			_0024self__00241155 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024self__00241155);
		}
	}

	[Serializable]
	internal sealed class _0024StartHide_00241156 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241157;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241157 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241157.hideFlag = true;
					_0024self__00241157.gameObject.collider.enabled = false;
					_0024self__00241157.swordObject.collider.enabled = false;
					_0024self__00241157.animator.SetBool("Find", false);
					if (!_0024self__00241157.noticeFlag)
					{
						_0024self__00241157.hideCount = UnityEngine.Random.Range(24f, 40f);
						_0024self__00241157.hideFailureFlag = false;
						goto IL_0162;
					}
					_0024self__00241157.nowAttacking = false;
					_0024self__00241157.navagent.SetDestination(_0024self__00241157.hidePoint.position);
					_0024self__00241157.animator.CrossFade("Walk", 0.2f, 0);
					_0024self__00241157.hideFailureFlag = true;
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241157.animator.SetBool("Attack", false);
					_0024self__00241157.animator.SetBool("Swing", false);
					_0024self__00241157.animator.Play("Empty", 3);
					_0024self__00241157.animator.Play("Empty", 4);
					goto IL_0162;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0162:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241158;

		public _0024StartHide_00241156(Girl4Controller self_)
		{
			_0024self__00241158 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241158);
		}
	}

	[Serializable]
	internal sealed class _0024ExitEnd_00241159 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241160;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241160 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241160.enterFlag = true;
					_0024self__00241160.encounterFlag = false;
					_0024self__00241160.navagent.enabled = false;
					_0024self__00241160.exitPoint[_0024self__00241160.random2].doorObject.SendMessage("Open");
					result = (Yield(2, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241160.enterFlag = false;
					_0024self__00241160.noticeFlag = false;
					_0024self__00241160.findFlag = false;
					_0024self__00241160.hideFlag = false;
					_0024self__00241160.exitFlag = false;
					_0024self__00241160.nowFinding = false;
					_0024self__00241160.status.switches[390] = 0;
					_0024self__00241160.status.switches[408] = 0;
					_0024self__00241160.status.variables[60] = 180f;
					_0024self__00241160.status.variables[61] = 0f;
					_0024self__00241160.animator.SetBool("Find", false);
					_0024self__00241160.animator.SetBool("Walk", false);
					_0024self__00241160.animator.SetBool("Run", false);
					_0024self__00241160.animator.SetBool("Attack", false);
					_0024self__00241160.animator.SetBool("Swing", false);
					_0024self__00241160.animator.Play("Idle", 0);
					result = (Yield(3, new WaitForSeconds(UnityEngine.Random.Range(4f, 6f))) ? 1 : 0);
					break;
				case 3:
					_0024self__00241160.status.switches[410] = 1;
					_0024self__00241160.status.loadPermission = true;
					_0024self__00241160.status.savePermission = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241161;

		public _0024ExitEnd_00241159(Girl4Controller self_)
		{
			_0024self__00241161 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241161);
		}
	}

	[Serializable]
	internal sealed class _0024KillEnd_00241162 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241163;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241163 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00241163.animator.CrossFade("Idle", 0.4f, 0);
					result = (Yield(2, new WaitForSeconds(1.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00241163.animator.SetBool("Attack", true);
					result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00241163.animator.SetBool("Attack", false);
					result = (Yield(4, new WaitForSeconds(1.56f)) ? 1 : 0);
					break;
				case 4:
					_0024self__00241163.status.loadPermission = true;
					_0024self__00241163.status.savePermission = true;
					_0024self__00241163.swordObject.SendMessage("PlayerDead", SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Girl4Controller _0024self__00241164;

		public _0024KillEnd_00241162(Girl4Controller self_)
		{
			_0024self__00241164 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241164);
		}
	}

	[Serializable]
	internal sealed class _0024RecoverySaveLoadPermission_00241165 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Girl4Controller _0024self__00241166;

			public _0024(Girl4Controller self_)
			{
				_0024self__00241166 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					if (!_0024self__00241166.encounterFlag && !_0024self__00241166.noticeFlag)
					{
						_0024self__00241166.status.loadPermission = true;
						_0024self__00241166.status.savePermission = true;
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

		internal Girl4Controller _0024self__00241167;

		public _0024RecoverySaveLoadPermission_00241165(Girl4Controller self_)
		{
			_0024self__00241167 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241167);
		}
	}

	public float walkSpeed;

	public float walkSpeedNotice;

	public float runSpeed;

	public float dashAttackSpeed;

	public float rotateSpeed;

	public float rotateSpeedNotice;

	public float noticeDistanceMin;

	public float noticeDistanceMax;

	public float noticeAngle;

	public Transform[] spawnPoint;

	public SpawnPointEnter[] spawnPointEnter;

	public Transform[] clearingPoint;

	public float clearingCountMin;

	public float clearingCountMax;

	public float findCountMin;

	public float findCountMax;

	public float stopCountMin;

	public float stopCountMax;

	public GameObject swordObject;

	public AudioClip[] audioClips;

	public AudioClip[] dashAttackVoices;

	public bool hideArea;

	public Transform hidePoint;

	public ExitPoint[] exitPoint;

	public bool specialWait;

	private Animator animator;

	private NavMeshAgent navagent;

	private Transform myTransform;

	private Quaternion myRotation;

	private Vector3 forwardDirection;

	private GameObject target;

	private int random;

	private int random2;

	public bool encounterFlag;

	public bool noticeFlag;

	private Transform nowClearingPoint;

	private int nowClearingId;

	private float clearingCount;

	private float findCount;

	private bool findFlag;

	private bool nowFinding;

	private bool nowAttacking;

	private bool nowStopping;

	private bool nowSwingStopping;

	private bool nowDashing;

	private bool nowDashAttacking;

	private int dashAttackId;

	private float layerWeight;

	private bool audioTempFlagHit;

	private bool audioTempFlagSwing;

	private bool audioTempFlagDrag;

	private bool enterFlag;

	private bool hideFlag;

	private bool hideFailureFlag;

	private float hideCount;

	private bool exitFlag;

	private float rotateSpeedAttack;

	private float dashAttackSpeedTemp;

	private float swingTimer;

	private Player_Status status;

	private AutoPlayAudio voice;

	public Girl4Controller()
	{
		nowClearingId = -1;
	}

	public virtual void Awake()
	{
		animator = (Animator)GetComponent(typeof(Animator));
		navagent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
		voice = (AutoPlayAudio)GetComponentInChildren(typeof(AutoPlayAudio));
		myTransform = transform;
		rotateSpeedAttack = 20f;
		nowClearingPoint = clearingPoint[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)clearingPoint))];
	}

	public virtual void Start()
	{
		target = GameObject.FindWithTag("Player");
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		StartCoroutine_Auto(RecoverySaveLoadPermission());
	}

	public virtual void Update()
	{
		if (encounterFlag && !noticeFlag)
		{
			status.loadPermission = false;
			status.savePermission = false;
		}
		if (encounterFlag)
		{
			status.switches[411] = 1;
		}
		else
		{
			status.switches[411] = 0;
		}
		if (nowSwingStopping)
		{
			if (!(layerWeight >= 0.99f))
			{
				layerWeight = Mathf.Lerp(layerWeight, 1f, Time.deltaTime * 5f);
			}
			else
			{
				layerWeight = 1f;
			}
			animator.SetLayerWeight(3, layerWeight);
		}
		else
		{
			if (!(layerWeight <= 0.01f))
			{
				layerWeight = Mathf.Lerp(layerWeight, 0f, Time.deltaTime * 5f);
			}
			else
			{
				layerWeight = 0f;
			}
			animator.SetLayerWeight(3, layerWeight);
		}
	}

	public virtual void FixedUpdate()
	{
		if (enterFlag)
		{
			forwardDirection = transform.TransformDirection(Vector3.forward);
			transform.position += forwardDirection * Time.deltaTime * walkSpeed;
		}
		if (encounterFlag)
		{
			if (!nowDashAttacking)
			{
				voice.enabled = true;
			}
			if (hideFlag)
			{
				gameObject.collider.enabled = false;
			}
			if (!noticeFlag || hideFlag)
			{
				forwardDirection = transform.TransformDirection(Vector3.forward);
				navagent.speed = walkSpeed;
				navagent.angularSpeed = rotateSpeed;
				if (!hideFailureFlag)
				{
					if (hideFlag && !(hideCount > 0f))
					{
						if (!exitFlag)
						{
							exitFlag = true;
							ChaseExit();
						}
						navagent.SetDestination(exitPoint[random2].exitTransform.position);
						if (!(Vector3.Distance(myTransform.position, exitPoint[random2].exitTransform.position) > 0.04f))
						{
							float y = Mathf.LerpAngle(myTransform.eulerAngles.y, exitPoint[random2].exitTransform.eulerAngles.y, Time.deltaTime * 20f);
							Vector3 eulerAngles = myTransform.eulerAngles;
							float num = (eulerAngles.y = y);
							Vector3 vector = (myTransform.eulerAngles = eulerAngles);
							if (!(Mathf.Abs(myTransform.eulerAngles.y - exitPoint[random2].exitTransform.eulerAngles.y) > 0.01f))
							{
								StartCoroutine_Auto(ExitEnd());
							}
						}
						return;
					}
					if (hideFlag)
					{
						hideCount -= Time.deltaTime * 1f;
					}
					if (!findFlag)
					{
						if (!(clearingCount > 0f))
						{
							do
							{
								random = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)clearingPoint));
							}
							while (nowClearingId == random);
							nowClearingId = random;
							nowClearingPoint = clearingPoint[random];
							if (navagent.enabled)
							{
								navagent.SetDestination(nowClearingPoint.position);
							}
							animator.CrossFade("Walk", 0.2f, 0);
							clearingCount = UnityEngine.Random.Range(clearingCountMin, clearingCountMax);
						}
						else
						{
							clearingCount -= Time.deltaTime * 1f;
						}
						if (!(findCount > 0f))
						{
							findFlag = true;
						}
						else
						{
							findCount -= Time.deltaTime * 1f;
						}
						if (!(Vector3.Distance(myTransform.position, nowClearingPoint.position) > 1.2f))
						{
							random = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)clearingPoint));
							nowClearingPoint = clearingPoint[random];
							clearingCount = UnityEngine.Random.Range(clearingCountMin, clearingCountMax);
							animator.SetBool("Walk", false);
							animator.CrossFade("Idle", 0.2f, 0);
							findFlag = true;
						}
						if (hideFlag)
						{
							return;
						}
						if (!(Vector3.Distance(myTransform.position, target.transform.position) <= noticeDistanceMin))
						{
							if (!(Vector3.Angle(forwardDirection, target.transform.position - myTransform.position) > noticeAngle) && !(Vector3.Distance(myTransform.position, target.transform.position) > noticeDistanceMax) && !Physics.Linecast(myTransform.position + new Vector3(0f, 1.6f, 0f), target.transform.position + new Vector3(0f, 1.6f, 0f), -5))
							{
								NoticeTarget();
							}
						}
						else
						{
							NoticeTarget();
						}
						return;
					}
					if (!nowFinding)
					{
						StartCoroutine_Auto(FindTarget());
					}
					if (hideFlag)
					{
						return;
					}
					if (!(Vector3.Distance(myTransform.position, target.transform.position) <= noticeDistanceMin * 1.5f))
					{
						if (!(Vector3.Angle(forwardDirection, target.transform.position - myTransform.position) > noticeAngle * 1.5f) && !(Vector3.Distance(myTransform.position, target.transform.position) > noticeDistanceMax) && !Physics.Linecast(myTransform.position + new Vector3(0f, 1.6f, 0f), target.transform.position + new Vector3(0f, 1.6f, 0f), -5))
						{
							NoticeTarget();
						}
					}
					else
					{
						NoticeTarget();
					}
				}
				else if (!(Vector3.Distance(myTransform.position, hidePoint.position) > 0.02f))
				{
					float y2 = Mathf.LerpAngle(myTransform.eulerAngles.y, hidePoint.eulerAngles.y, Time.deltaTime * 20f);
					Vector3 eulerAngles2 = myTransform.eulerAngles;
					float num2 = (eulerAngles2.y = y2);
					Vector3 vector3 = (myTransform.eulerAngles = eulerAngles2);
					if (!exitFlag)
					{
						exitFlag = true;
						StartCoroutine_Auto(KillEnd());
					}
				}
			}
			else if (!nowDashAttacking)
			{
				forwardDirection = transform.TransformDirection(Vector3.forward);
				if (!nowAttacking)
				{
					navagent.angularSpeed = Mathf.Lerp(navagent.angularSpeed, rotateSpeedNotice, Time.deltaTime);
				}
				if (!(Vector3.Distance(myTransform.position, target.transform.position) >= 2f))
				{
					swingTimer += 1f * Time.deltaTime;
					navagent.speed = walkSpeedNotice;
					if (!nowAttacking)
					{
						if (!(swingTimer >= 3f))
						{
							StartCoroutine_Auto(AttackTarget(false));
						}
						else
						{
							StartCoroutine_Auto(AttackTarget(true));
						}
					}
					else if (!(Vector3.Distance(myTransform.position, target.transform.position) <= 1f) && !nowStopping)
					{
						if (!nowSwingStopping)
						{
							if (navagent.enabled)
							{
								navagent.SetDestination(target.transform.position);
							}
							animator.SetBool("Walk", true);
							animator.SetBool("Run", false);
						}
						else
						{
							animator.SetBool("Walk", false);
							animator.SetBool("Run", false);
						}
					}
					else if (!nowStopping && !nowSwingStopping)
					{
						nowStopping = true;
						nowDashing = false;
						if (navagent.enabled)
						{
							navagent.Stop();
						}
						animator.SetBool("Walk", false);
						animator.SetBool("Run", false);
						StartCoroutine_Auto(StopMove());
					}
					return;
				}
				swingTimer = 0f;
				if (!nowSwingStopping)
				{
					if (navagent.enabled)
					{
						navagent.SetDestination(target.transform.position);
					}
					if (!nowDashing)
					{
						animator.SetBool("Walk", true);
						animator.SetBool("Run", false);
						navagent.speed = walkSpeedNotice;
					}
					else
					{
						animator.SetBool("Walk", false);
						animator.SetBool("Run", true);
						navagent.speed = runSpeed;
					}
				}
				else
				{
					animator.SetBool("Walk", false);
					animator.SetBool("Run", false);
				}
				if (!(clearingCount > 0f))
				{
					StartCoroutine_Auto(DashAttack());
				}
				else
				{
					clearingCount -= Time.deltaTime;
				}
			}
			else if (dashAttackId == 0)
			{
				navagent.speed = 0f;
				if (navagent.enabled)
				{
					navagent.Stop();
				}
			}
			else if (dashAttackId == 1)
			{
				if (navagent.enabled)
				{
					navagent.SetDestination(target.transform.position);
				}
				navagent.speed = Mathf.Lerp(navagent.speed, dashAttackSpeed, Time.deltaTime * 32f);
				if (!(Vector3.Distance(myTransform.position, target.transform.position) >= 2f))
				{
					forwardDirection = transform.TransformDirection(Vector3.forward);
					if (navagent.enabled)
					{
						navagent.Stop();
					}
					dashAttackSpeedTemp = dashAttackSpeed;
					dashAttackId = 2;
					StartCoroutine_Auto(DashAttackEnd());
				}
			}
			else if (dashAttackId == 2)
			{
				if (!(Vector3.Distance(myTransform.position, target.transform.position) <= 1.8f))
				{
					navagent.angularSpeed = 10f;
					if (navagent.enabled)
					{
						navagent.SetDestination(target.transform.position);
					}
				}
				else
				{
					dashAttackSpeedTemp = 0f;
					if (navagent.enabled)
					{
						navagent.Stop();
					}
				}
			}
			else
			{
				if (dashAttackId != 3)
				{
					return;
				}
				dashAttackSpeedTemp = Mathf.Lerp(dashAttackSpeed, 0f, Time.deltaTime * 256f);
				if (!(Vector3.Distance(myTransform.position, target.transform.position) <= 1.8f))
				{
					if (navagent.enabled)
					{
						navagent.Move(forwardDirection * dashAttackSpeedTemp * Time.deltaTime);
					}
					return;
				}
				dashAttackSpeedTemp = 0f;
				if (navagent.enabled)
				{
					navagent.Stop();
				}
			}
		}
		else
		{
			voice.enabled = false;
		}
	}

	public virtual void LateUpdate()
	{
		if (nowAttacking && !nowSwingStopping)
		{
			myRotation = Quaternion.LookRotation(target.transform.position - myTransform.position);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, myRotation, Time.deltaTime * rotateSpeedAttack);
		}
	}

	public virtual IEnumerator FindTarget()
	{
		return new _0024FindTarget_00241127(this).GetEnumerator();
	}

	public virtual void NoticeTarget()
	{
		if (!enterFlag)
		{
			findFlag = false;
			nowFinding = false;
			noticeFlag = true;
			clearingCount = UnityEngine.Random.Range(2f, 4f);
			status.switches[390] = 1;
			status.switches[408] = 0;
			status.variables[61] = 3f;
			navagent.angularSpeed = 20f;
			animator.SetBool("Find", true);
			animator.CrossFade("Walk", 0.2f, 0);
		}
	}

	public virtual IEnumerator AttackTarget(bool swingFlag)
	{
		return new _0024AttackTarget_00241130(swingFlag, this).GetEnumerator();
	}

	public virtual IEnumerator DashAttack()
	{
		return new _0024DashAttack_00241135(this).GetEnumerator();
	}

	public virtual IEnumerator DashAttackEnd()
	{
		return new _0024DashAttackEnd_00241139(this).GetEnumerator();
	}

	public virtual IEnumerator StopMove()
	{
		return new _0024StopMove_00241142(this).GetEnumerator();
	}

	public virtual void SwingMove(int id)
	{
		if (id == 0)
		{
			nowSwingStopping = true;
			if (navagent.enabled)
			{
				navagent.Stop();
			}
			animator.SetBool("Walk", false);
			animator.SetBool("Run", false);
		}
		else
		{
			nowSwingStopping = false;
			rotateSpeedAttack = 2f;
			navagent.angularSpeed = 20f;
		}
	}

	public virtual void AudioPlaySyncAnimation(int num)
	{
		if (audioClips[num] != null && (num != 2 || !nowAttacking))
		{
			if (num == 0 && !audioTempFlagHit)
			{
				StartCoroutine_Auto(ChangeAudioTempFlag(num));
				audio.PlayOneShot(audioClips[num]);
			}
			else if (num == 1 && !audioTempFlagSwing)
			{
				StartCoroutine_Auto(ChangeAudioTempFlag(num));
				audio.PlayOneShot(audioClips[num]);
			}
			else if (num == 3 && !audioTempFlagDrag)
			{
				StartCoroutine_Auto(ChangeAudioTempFlag(num));
				audio.PlayOneShot(audioClips[num]);
			}
			else if (num == 2)
			{
				audio.PlayOneShot(audioClips[num]);
			}
			else
			{
				audio.PlayOneShot(audioClips[num]);
			}
		}
	}

	public virtual IEnumerator ChangeAudioTempFlag(int id)
	{
		return new _0024ChangeAudioTempFlag_00241145(id, this).GetEnumerator();
	}

	public virtual IEnumerator SpawnEnter()
	{
		return new _0024SpawnEnter_00241150(this).GetEnumerator();
	}

	public virtual IEnumerator ChaseEnter()
	{
		return new _0024ChaseEnter_00241153(this).GetEnumerator();
	}

	public virtual void SpawnStay()
	{
		if (!encounterFlag)
		{
			encounterFlag = true;
			clearingCount = 0f;
			findCount = UnityEngine.Random.Range(findCountMin, findCountMax);
			myTransform.position = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].position;
			myTransform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject.collider.enabled = true;
			navagent.enabled = true;
		}
	}

	public virtual void ChangeAttackTrigger(int flag)
	{
		if (!hideFlag)
		{
			if (flag == 1)
			{
				swordObject.collider.enabled = true;
			}
			else
			{
				swordObject.collider.enabled = false;
			}
		}
	}

	public virtual IEnumerator StartHide()
	{
		return new _0024StartHide_00241156(this).GetEnumerator();
	}

	public virtual void ChaseExit()
	{
		findFlag = false;
		findCount = 9999f;
		clearingCount = 9999f;
		animator.SetBool("Find", false);
		animator.SetBool("Walk", true);
		animator.CrossFade("Walk", 0.2f, 0);
		random2 = UnityEngine.Random.Range(0, exitPoint.Length);
	}

	public virtual IEnumerator ExitEnd()
	{
		return new _0024ExitEnd_00241159(this).GetEnumerator();
	}

	public virtual IEnumerator KillEnd()
	{
		return new _0024KillEnd_00241162(this).GetEnumerator();
	}

	public virtual void ChangeEncounterFlag(int flag)
	{
		if (flag == 0)
		{
			encounterFlag = false;
		}
		else
		{
			encounterFlag = true;
		}
	}

	public virtual void ChangeNoticeFlag(int flag)
	{
		if (flag == 0)
		{
			noticeFlag = false;
		}
		else
		{
			noticeFlag = true;
		}
	}

	public virtual void ChangeCollider(int flag)
	{
		if (flag == 0)
		{
			gameObject.collider.enabled = false;
		}
		else
		{
			gameObject.collider.enabled = true;
		}
	}

	public virtual void ChangeNavagent(int flag)
	{
		if (flag == 0)
		{
			navagent.enabled = false;
		}
		else
		{
			navagent.enabled = true;
		}
	}

	public virtual IEnumerator RecoverySaveLoadPermission()
	{
		return new _0024RecoverySaveLoadPermission_00241165(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
