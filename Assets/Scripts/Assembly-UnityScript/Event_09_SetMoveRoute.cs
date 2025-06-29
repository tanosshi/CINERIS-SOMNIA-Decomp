using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Event_09_SetMoveRoute : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024SetMoveRoute_00241084 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal int _0024i_00241085;

			internal int _0024num_00241086;

			internal Event_09_SetMoveRoute _0024self__00241087;

			public _0024(int num, Event_09_SetMoveRoute self_)
			{
				_0024num_00241086 = num;
				_0024self__00241087 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024i_00241085 = default(int);
					if (_0024self__00241087.state[_0024num_00241086].targetType == AnimationTargetType.Tag)
					{
						_0024self__00241087.state[_0024num_00241086].target = GameObject.FindWithTag(_0024self__00241087.state[_0024num_00241086].tagName);
					}
					if (!_0024self__00241087.state[_0024num_00241086].waitForCompletion)
					{
						_0024self__00241087.SendMessage("ExitCommandProcessing");
					}
					_0024i_00241085 = 0;
					goto IL_1247;
				case 2:
					if (_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].changeAnimation)
					{
						_0024self__00241087.state[_0024num_00241086].target.SendMessage("SetAnimationFadeTime", 0.2f, SendMessageOptions.DontRequireReceiver);
						_0024self__00241087.state[_0024num_00241086].target.SendMessage("AnimationManager", _0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].animationId, SendMessageOptions.DontRequireReceiver);
					}
					if (_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].changePosition)
					{
						if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].usePath)
						{
							if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].useSpeed)
							{
								if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].orientToPath)
								{
									iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
									{
										{
											"x",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
										},
										{
											"y",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
										},
										{
											"z",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
										},
										{ "orienttopath", false },
										{
											"time",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
										},
										{
											"easetype",
											iTween.EaseType.linear
										}
									});
								}
								else
								{
									iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
									{
										{
											"x",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
										},
										{
											"y",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
										},
										{
											"z",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
										},
										{ "orienttopath", true },
										{
											"time",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
										},
										{
											"looktime",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
										},
										{
											"easetype",
											iTween.EaseType.linear
										}
									});
								}
							}
							else if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].useEaseInOut)
							{
								if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].orientToPath)
								{
									iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
									{
										{
											"x",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
										},
										{
											"y",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
										},
										{
											"z",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
										},
										{ "orienttopath", false },
										{
											"speed",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].speed
										},
										{
											"easetype",
											iTween.EaseType.linear
										},
										{ "oncomplete", "MoveComplete" },
										{ "oncompletetarget", _0024self__00241087.gameObject }
									});
								}
								else
								{
									iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
									{
										{
											"x",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
										},
										{
											"y",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
										},
										{
											"z",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
										},
										{ "orienttopath", true },
										{
											"speed",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].speed
										},
										{
											"looktime",
											_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
										},
										{
											"easetype",
											iTween.EaseType.linear
										},
										{ "oncomplete", "MoveComplete" },
										{ "oncompletetarget", _0024self__00241087.gameObject }
									});
								}
							}
							else if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].orientToPath)
							{
								iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
								{
									{
										"x",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
									},
									{
										"y",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
									},
									{
										"z",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
									},
									{ "orienttopath", false },
									{
										"speed",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].speed
									},
									{
										"easetype",
										iTween.EaseType.easeInOutQuad
									},
									{ "oncomplete", "MoveComplete" },
									{ "oncompletetarget", _0024self__00241087.gameObject }
								});
							}
							else
							{
								iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
								{
									{
										"x",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.x
									},
									{
										"y",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.y
									},
									{
										"z",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition.z
									},
									{ "orienttopath", true },
									{
										"speed",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].speed
									},
									{
										"looktime",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
									},
									{
										"easetype",
										iTween.EaseType.easeInOutQuad
									},
									{ "oncomplete", "MoveComplete" },
									{ "oncompletetarget", _0024self__00241087.gameObject }
								});
							}
						}
						else if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].useSpeed)
						{
							if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].orientToPath)
							{
								iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
								{
									{
										"path",
										iTweenPath.GetPath(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].pathName)
									},
									{ "orienttopath", false },
									{
										"time",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
									},
									{
										"easetype",
										iTween.EaseType.linear
									}
								});
							}
							else
							{
								iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
								{
									{
										"path",
										iTweenPath.GetPath(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].pathName)
									},
									{ "orienttopath", true },
									{
										"time",
										_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
									},
									{
										"easetype",
										iTween.EaseType.linear
									}
								});
							}
						}
						else if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].orientToPath)
						{
							iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
							{
								{
									"path",
									iTweenPath.GetPath(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].pathName)
								},
								{ "orienttopath", false },
								{
									"speed",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
								},
								{
									"easetype",
									iTween.EaseType.linear
								},
								{ "oncomplete", "MoveComplete" },
								{ "oncompletetarget", _0024self__00241087.gameObject }
							});
						}
						else
						{
							iTween.MoveTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
							{
								{
									"path",
									iTweenPath.GetPath(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].pathName)
								},
								{ "orienttopath", true },
								{
									"speed",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime
								},
								{
									"easetype",
									iTween.EaseType.linear
								},
								{ "oncomplete", "MoveComplete" },
								{ "oncompletetarget", _0024self__00241087.gameObject }
							});
						}
					}
					if (_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].changeRotation)
					{
						iTween.RotateTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
						{
							{
								"x",
								_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantRotation.x
							},
							{
								"y",
								_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantRotation.y
							},
							{
								"z",
								_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantRotation.z
							},
							{
								"time",
								_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
							},
							{
								"easetype",
								iTween.EaseType.linear
							}
						});
					}
					if (_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].changeLookAhead)
					{
						if (_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].lookTarget == null)
						{
							iTween.LookTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
							{
								{
									"lookTarget",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].constantPosition
								},
								{
									"time",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
								},
								{ "axis", "y" },
								{
									"easetype",
									iTween.EaseType.easeInOutQuad
								}
							});
						}
						else
						{
							iTween.LookTo(_0024self__00241087.state[_0024num_00241086].target, new Hash
							{
								{
									"lookTarget",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].lookTarget.transform.position
								},
								{
									"time",
									_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime
								},
								{ "axis", "y" },
								{
									"easetype",
									iTween.EaseType.easeInOutQuad
								}
							});
						}
					}
					if (!_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].useSpeed)
					{
						result = (((_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime < _0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime) ? Yield(4, new WaitForSeconds(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].rotationTime)) : Yield(3, new WaitForSeconds(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].positionTime))) ? 1 : 0);
						break;
					}
					goto IL_1201;
				case 5:
					if (_0024self__00241087.speedMoveFlag)
					{
						_0024self__00241087.speedMoveFlag = false;
						goto case 3;
					}
					goto IL_1201;
				case 3:
				case 4:
					_0024i_00241085++;
					goto IL_1247;
				case 1:
					{
						result = 0;
						break;
					}
					IL_1247:
					if (_0024i_00241085 < _0024self__00241087.state[_0024num_00241086].route.Length)
					{
						result = (Yield(2, new WaitForSeconds(_0024self__00241087.state[_0024num_00241086].route[_0024i_00241085].startWaitTime)) ? 1 : 0);
						break;
					}
					if (_0024self__00241087.state[_0024num_00241086].waitForCompletion)
					{
						_0024self__00241087.SendMessage("ExitCommandProcessing");
					}
					YieldDefault(1);
					goto case 1;
					IL_1201:
					result = (Yield(5, new WaitForEndOfFrame()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024num_00241088;

		internal Event_09_SetMoveRoute _0024self__00241089;

		public _0024SetMoveRoute_00241084(int num, Event_09_SetMoveRoute self_)
		{
			_0024num_00241088 = num;
			_0024self__00241089 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024num_00241088, _0024self__00241089);
		}
	}

	public CtrlSetMoveRoute[] state;

	private bool speedMoveFlag;

	public virtual IEnumerator SetMoveRoute(int num)
	{
		return new _0024SetMoveRoute_00241084(num, this).GetEnumerator();
	}

	public virtual void MoveComplete()
	{
		speedMoveFlag = true;
	}

	public virtual void Main()
	{
	}
}
