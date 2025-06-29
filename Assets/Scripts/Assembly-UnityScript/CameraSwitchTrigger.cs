using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CameraSwitchTrigger : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnTriggerEnter_0024936 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collider _0024collisionInfo_0024937;

			internal CameraSwitchTrigger _0024self__0024938;

			public _0024(Collider collisionInfo, CameraSwitchTrigger self_)
			{
				_0024collisionInfo_0024937 = collisionInfo;
				_0024self__0024938 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (((_0024self__0024938.useStartSwitch && _0024self__0024938.status.switches[_0024self__0024938.startSwitchNumber] == 1) || !_0024self__0024938.useStartSwitch) && ((_0024self__0024938.useStopSwitch && _0024self__0024938.status.switches[_0024self__0024938.stopSwitchNumber] != 1) || !_0024self__0024938.useStopSwitch) && _0024collisionInfo_0024937.gameObject.tag == "Player")
					{
						_0024self__0024938.v = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
						_0024self__0024938.h = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
						_0024self__0024938.cameraB.camera.enabled = true;
						_0024self__0024938.cameraA.camera.enabled = false;
						if (_0024self__0024938.cameraAisMain)
						{
							_0024self__0024938.cameraA.camera.farClipPlane = _0024self__0024938.cameraB.camera.farClipPlane;
							iTween.Stop(_0024self__0024938.gameObject);
							_0024self__0024938.cameraA.camera.fieldOfView = _0024self__0024938.cameraB.camera.fieldOfView;
						}
						if (_0024self__0024938.useActiveSwitch)
						{
							_0024self__0024938.status.switches[_0024self__0024938.activeSwitchNumber] = 1;
						}
						_0024self__0024938.cameraStatus.Switching(true);
						_0024self__0024938.cameraStatus.ChangeSwitchSync(true);
						_0024self__0024938.cameraStatus.subCameraNow = _0024self__0024938.cameraB.camera;
						if (_0024self__0024938.cameraAisMain)
						{
							_0024self__0024938.cameraATransform.position = _0024self__0024938.cameraBTransform.position;
						}
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_0271;
				case 2:
					_0024self__0024938.syncRotate = true;
					goto IL_0271;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0271:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024collisionInfo_0024939;

		internal CameraSwitchTrigger _0024self__0024940;

		public _0024OnTriggerEnter_0024936(Collider collisionInfo, CameraSwitchTrigger self_)
		{
			_0024collisionInfo_0024939 = collisionInfo;
			_0024self__0024940 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024collisionInfo_0024939, _0024self__0024940);
		}
	}

	[Serializable]
	internal sealed class _0024OnTriggerExit_0024941 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024v_temp_0024942;

			internal float _0024h_temp_0024943;

			internal Collider _0024collisionInfo_0024944;

			internal CameraSwitchTrigger _0024self__0024945;

			public _0024(Collider collisionInfo, CameraSwitchTrigger self_)
			{
				_0024collisionInfo_0024944 = collisionInfo;
				_0024self__0024945 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (((_0024self__0024945.useStartSwitch && _0024self__0024945.status.switches[_0024self__0024945.startSwitchNumber] == 1) || !_0024self__0024945.useStartSwitch) && ((_0024self__0024945.useStopSwitch && _0024self__0024945.status.switches[_0024self__0024945.stopSwitchNumber] != 1) || !_0024self__0024945.useStopSwitch) && _0024collisionInfo_0024944.gameObject.tag == "Player")
					{
						_0024collisionInfo_0024944.SendMessage("Rotatable", false);
						if (_0024self__0024945.cameraAisMain)
						{
							_0024self__0024945.cameraStatus.gameObject.transform.rotation = _0024self__0024945.cameraBTransform.rotation;
							_0024self__0024945.cameraStatus.gameObject.transform.position = _0024self__0024945.cameraBTransform.position;
							_0024self__0024945.cameraA.camera.farClipPlane = _0024self__0024945.firstClipPlane;
							iTween.ValueTo(_0024self__0024945.gameObject, iTween.Hash("from", _0024self__0024945.cameraA.camera.fieldOfView, "to", _0024self__0024945.firstFieldOfView, "time", 0.2f, "onupdate", "ChangeFieldOfView"));
						}
						_0024self__0024945.cameraA.camera.enabled = true;
						_0024self__0024945.cameraB.camera.enabled = false;
						if (_0024self__0024945.useActiveSwitch)
						{
							_0024self__0024945.status.switches[_0024self__0024945.activeSwitchNumber] = 0;
						}
						_0024self__0024945.syncRotate = false;
						if (_0024self__0024945.exitAheadY)
						{
							_0024self__0024945.cameraStatus.SetResetRotY(_0024collisionInfo_0024944.gameObject.transform.eulerAngles.y);
							_0024self__0024945.StartCoroutine_Auto(_0024self__0024945.cameraStatus.NowCameraReset());
						}
						_0024self__0024945.cameraStatus.Switching(false);
						_0024self__0024945.StartCoroutine_Auto(_0024self__0024945.EndSwitchSync());
						_0024self__0024945.v = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
						_0024self__0024945.h = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_03e3;
				case 2:
					_0024v_temp_0024942 = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, 1f);
					_0024h_temp_0024943 = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, 1f);
					result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 3:
					if (RuntimeServices.EqualityOperator(_0024self__0024945.v, _0024v_temp_0024942) && RuntimeServices.EqualityOperator(_0024self__0024945.h, _0024h_temp_0024943))
					{
						goto case 2;
					}
					_0024collisionInfo_0024944.SendMessage("Rotatable", true);
					goto IL_03e3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03e3:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024collisionInfo_0024946;

		internal CameraSwitchTrigger _0024self__0024947;

		public _0024OnTriggerExit_0024941(Collider collisionInfo, CameraSwitchTrigger self_)
		{
			_0024collisionInfo_0024946 = collisionInfo;
			_0024self__0024947 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024collisionInfo_0024946, _0024self__0024947);
		}
	}

	[Serializable]
	internal sealed class _0024EndSwitchSync_0024948 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CameraSwitchTrigger _0024self__0024949;

			public _0024(CameraSwitchTrigger self_)
			{
				_0024self__0024949 = self_;
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
					_0024self__0024949.cameraStatus.ChangeSwitchSync(false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CameraSwitchTrigger _0024self__0024950;

		public _0024EndSwitchSync_0024948(CameraSwitchTrigger self_)
		{
			_0024self__0024950 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024950);
		}
	}

	public bool cameraAisMain;

	public GameObject cameraA;

	public GameObject cameraB;

	public bool exitAheadY;

	public float exitRotX;

	public float exitRotY;

	public bool useStartSwitch;

	public int startSwitchNumber;

	public bool useStopSwitch;

	public int stopSwitchNumber;

	public bool useActiveSwitch;

	public int activeSwitchNumber;

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

	public virtual IEnumerator OnTriggerEnter(Collider collisionInfo)
	{
		return new _0024OnTriggerEnter_0024936(collisionInfo, this).GetEnumerator();
	}

	public virtual void OnTriggerStay(Collider collisionInfo)
	{
		if (((!useStartSwitch || status.switches[startSwitchNumber] != 1) && useStartSwitch) || ((!useStopSwitch || status.switches[stopSwitchNumber] == 1) && useStopSwitch) || !(collisionInfo.gameObject.tag == "Player"))
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
				cameraStatus.FixedRot(exitRotX, exitRotY);
			}
		}
	}

	public virtual IEnumerator OnTriggerExit(Collider collisionInfo)
	{
		return new _0024OnTriggerExit_0024941(collisionInfo, this).GetEnumerator();
	}

	public virtual IEnumerator EndSwitchSync()
	{
		return new _0024EndSwitchSync_0024948(this).GetEnumerator();
	}

	public virtual void ChangeFieldOfView(float fov)
	{
		cameraA.camera.fieldOfView = fov;
	}

	public virtual void SetSyncRotate()
	{
		syncRotate = true;
	}

	public virtual void Main()
	{
	}
}
