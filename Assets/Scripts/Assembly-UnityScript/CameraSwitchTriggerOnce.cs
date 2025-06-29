using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CameraSwitchTriggerOnce : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnTriggerEnter_0024951 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collider _0024collisionInfo_0024952;

			internal CameraSwitchTriggerOnce _0024self__0024953;

			public _0024(Collider collisionInfo, CameraSwitchTriggerOnce self_)
			{
				_0024collisionInfo_0024952 = collisionInfo;
				_0024self__0024953 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (((_0024self__0024953.useStartSwitch && _0024self__0024953.status.switches[_0024self__0024953.startSwitchNumber] == 1) || !_0024self__0024953.useStartSwitch) && ((_0024self__0024953.useStopSwitch && _0024self__0024953.status.switches[_0024self__0024953.stopSwitchNumber] != 1) || !_0024self__0024953.useStopSwitch) && _0024collisionInfo_0024952.gameObject.tag == "Player" && _0024self__0024953.enterFlag)
					{
						_0024self__0024953.v = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
						_0024self__0024953.h = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
						_0024self__0024953.cameraB.camera.enabled = true;
						_0024self__0024953.cameraA.camera.enabled = false;
						if (_0024self__0024953.cameraAisMain)
						{
							_0024self__0024953.cameraA.camera.farClipPlane = _0024self__0024953.cameraB.camera.farClipPlane;
							iTween.Stop(_0024self__0024953.gameObject);
							_0024self__0024953.cameraA.camera.fieldOfView = _0024self__0024953.cameraB.camera.fieldOfView;
						}
						_0024self__0024953.cameraStatus.Switching(true);
						_0024self__0024953.cameraStatus.ChangeSwitchSync(true);
						_0024self__0024953.cameraStatus.subCameraNow = _0024self__0024953.cameraB.camera;
						if (_0024self__0024953.cameraAisMain)
						{
							_0024self__0024953.cameraATransform.position = _0024self__0024953.cameraBTransform.position;
						}
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_0255;
				case 2:
					_0024self__0024953.syncRotate = true;
					goto IL_0255;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0255:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024collisionInfo_0024954;

		internal CameraSwitchTriggerOnce _0024self__0024955;

		public _0024OnTriggerEnter_0024951(Collider collisionInfo, CameraSwitchTriggerOnce self_)
		{
			_0024collisionInfo_0024954 = collisionInfo;
			_0024self__0024955 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024collisionInfo_0024954, _0024self__0024955);
		}
	}

	[Serializable]
	internal sealed class _0024OnTriggerExit_0024956 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024v_temp_0024957;

			internal float _0024h_temp_0024958;

			internal Collider _0024collisionInfo_0024959;

			internal CameraSwitchTriggerOnce _0024self__0024960;

			public _0024(Collider collisionInfo, CameraSwitchTriggerOnce self_)
			{
				_0024collisionInfo_0024959 = collisionInfo;
				_0024self__0024960 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (((_0024self__0024960.useStartSwitch && _0024self__0024960.status.switches[_0024self__0024960.startSwitchNumber] == 1) || !_0024self__0024960.useStartSwitch) && ((_0024self__0024960.useStopSwitch && _0024self__0024960.status.switches[_0024self__0024960.stopSwitchNumber] != 1) || !_0024self__0024960.useStopSwitch) && _0024collisionInfo_0024959.gameObject.tag == "Player" && !_0024self__0024960.enterFlag && !_0024self__0024960.cameraA.camera.enabled)
					{
						_0024collisionInfo_0024959.SendMessage("Rotatable", false);
						if (_0024self__0024960.cameraAisMain)
						{
							_0024self__0024960.cameraA.camera.farClipPlane = _0024self__0024960.firstClipPlane;
							iTween.ValueTo(_0024self__0024960.gameObject, iTween.Hash("from", _0024self__0024960.cameraA.camera.fieldOfView, "to", _0024self__0024960.firstFieldOfView, "time", 0.2f, "onupdate", "ChangeFieldOfView"));
						}
						_0024self__0024960.cameraA.camera.enabled = true;
						_0024self__0024960.cameraB.camera.enabled = false;
						_0024self__0024960.cameraStatus.FixedRot(_0024self__0024960.exitRotX, _0024self__0024960.exitRotY);
						_0024self__0024960.syncRotate = false;
						_0024self__0024960.cameraStatus.Switching(false);
						_0024self__0024960.StartCoroutine_Auto(_0024self__0024960.EndSwitchSync());
						_0024self__0024960.v = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
						_0024self__0024960.h = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_0359;
				case 2:
					_0024v_temp_0024957 = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
					_0024h_temp_0024958 = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
					result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 3:
					if (RuntimeServices.EqualityOperator(_0024self__0024960.v, _0024v_temp_0024957) && RuntimeServices.EqualityOperator(_0024self__0024960.h, _0024h_temp_0024958))
					{
						goto case 2;
					}
					_0024collisionInfo_0024959.SendMessage("Rotatable", true);
					goto IL_0359;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0359:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024collisionInfo_0024961;

		internal CameraSwitchTriggerOnce _0024self__0024962;

		public _0024OnTriggerExit_0024956(Collider collisionInfo, CameraSwitchTriggerOnce self_)
		{
			_0024collisionInfo_0024961 = collisionInfo;
			_0024self__0024962 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024collisionInfo_0024961, _0024self__0024962);
		}
	}

	[Serializable]
	internal sealed class _0024EndSwitchSync_0024963 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CameraSwitchTriggerOnce _0024self__0024964;

			public _0024(CameraSwitchTriggerOnce self_)
			{
				_0024self__0024964 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.8f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024964.cameraStatus.ChangeSwitchSync(false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CameraSwitchTriggerOnce _0024self__0024965;

		public _0024EndSwitchSync_0024963(CameraSwitchTriggerOnce self_)
		{
			_0024self__0024965 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024965);
		}
	}

	public bool enterFlag;

	public bool cameraAisMain;

	public GameObject cameraA;

	public GameObject cameraB;

	public float exitRotX;

	public float exitRotY;

	public bool useStartSwitch;

	public int startSwitchNumber;

	public bool useStopSwitch;

	public int stopSwitchNumber;

	private Camera_Controller cameraStatus;

	private bool syncRotate;

	private object v;

	private object h;

	private Transform cameraATransform;

	private Transform cameraBTransform;

	private float firstClipPlane;

	private float firstFieldOfView;

	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		cameraStatus = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent("Camera_Controller");
		if (cameraAisMain)
		{
			cameraA = GameObject.FindWithTag("MainCamera");
			firstClipPlane = cameraA.camera.farClipPlane;
			firstFieldOfView = cameraA.camera.fieldOfView;
		}
		cameraATransform = cameraA.transform;
		cameraBTransform = cameraB.transform;
	}

	public virtual void Update()
	{
		if (((!useStartSwitch || status.switches[startSwitchNumber] != 1) && useStartSwitch) || ((!useStopSwitch || status.switches[stopSwitchNumber] == 1) && useStopSwitch) || !cameraB.camera.enabled || !enterFlag)
		{
			return;
		}
		if (!(Time.timeSinceLevelLoad > 1f))
		{
			if (cameraAisMain)
			{
				cameraATransform.position = cameraBTransform.position;
				cameraATransform.rotation = cameraBTransform.rotation;
			}
			else
			{
				cameraStatus.gameObject.transform.rotation = cameraBTransform.rotation;
				cameraStatus.gameObject.transform.position = cameraBTransform.position;
			}
		}
		if (cameraA.camera.enabled)
		{
			cameraA.camera.enabled = false;
		}
		cameraStatus.gameObject.camera.enabled = false;
		if (syncRotate)
		{
			float num = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
			float num2 = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
			if (!RuntimeServices.EqualityOperator(v, num) || !RuntimeServices.EqualityOperator(h, num2))
			{
				cameraStatus.gameObject.transform.rotation = cameraBTransform.rotation;
				cameraStatus.gameObject.transform.position = cameraBTransform.position;
			}
		}
	}

	public virtual IEnumerator OnTriggerEnter(Collider collisionInfo)
	{
		return new _0024OnTriggerEnter_0024951(collisionInfo, this).GetEnumerator();
	}

	public virtual IEnumerator OnTriggerExit(Collider collisionInfo)
	{
		return new _0024OnTriggerExit_0024956(collisionInfo, this).GetEnumerator();
	}

	public virtual IEnumerator EndSwitchSync()
	{
		return new _0024EndSwitchSync_0024963(this).GetEnumerator();
	}

	public virtual void ChangeFieldOfView(float fov)
	{
		cameraA.camera.fieldOfView = fov;
	}

	public virtual void Main()
	{
	}
}
