using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Camera_Controller : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024FixedRotForce_0024966 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024x_0024967;

			internal float _0024y_0024968;

			internal Camera_Controller _0024self__0024969;

			public _0024(float x, float y, Camera_Controller self_)
			{
				_0024x_0024967 = x;
				_0024y_0024968 = y;
				_0024self__0024969 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024969.isSwitchSync = true;
					_0024self__0024969.RotX = _0024x_0024967;
					_0024self__0024969.RotY = _0024y_0024968;
					result = (Yield(2, new WaitForSeconds(0.8f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024969.isSwitchSync = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024x_0024970;

		internal float _0024y_0024971;

		internal Camera_Controller _0024self__0024972;

		public _0024FixedRotForce_0024966(float x, float y, Camera_Controller self_)
		{
			_0024x_0024970 = x;
			_0024y_0024971 = y;
			_0024self__0024972 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024x_0024970, _0024y_0024971, _0024self__0024972);
		}
	}

	[Serializable]
	internal sealed class _0024NowCameraReset_0024973 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024resetRotYPrev_0024974;

			internal Camera_Controller _0024self__0024975;

			public _0024(Camera_Controller self_)
			{
				_0024self__0024975 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024975.nowCameraReset = true;
					_0024resetRotYPrev_0024974 = _0024self__0024975.resetRotY;
					goto case 2;
				case 2:
					_0024self__0024975.RotX = Mathf.Lerp(_0024self__0024975.RotX, 0f, 4f * Time.deltaTime);
					_0024self__0024975.RotY = Mathf.LerpAngle(_0024self__0024975.RotY, _0024self__0024975.resetRotY, 4f * Time.deltaTime);
					if (Vector2.Angle(new Vector2(Mathf.Cos(_0024self__0024975.RotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024975.RotY * ((float)Math.PI / 180f))), new Vector2(Mathf.Cos(_0024self__0024975.resetRotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024975.resetRotY * ((float)Math.PI / 180f)))) > 1f && _0024self__0024975.resetRotY == _0024resetRotYPrev_0024974)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__0024975.RotX = 0f;
					_0024self__0024975.RotY = _0024self__0024975.resetRotY;
					_0024self__0024975.nowCameraReset = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Camera_Controller _0024self__0024976;

		public _0024NowCameraReset_0024973(Camera_Controller self_)
		{
			_0024self__0024976 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024self__0024976);
		}
	}

	[Serializable]
	internal sealed class _0024FixedRotFromWorld_0024977 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024resetRotYPrev_0024978;

			internal float _0024rot_0024979;

			internal Camera_Controller _0024self__0024980;

			public _0024(float rot, Camera_Controller self_)
			{
				_0024rot_0024979 = rot;
				_0024self__0024980 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024980.resetRotY = _0024rot_0024979;
					_0024self__0024980.nowCameraReset = true;
					_0024resetRotYPrev_0024978 = _0024self__0024980.resetRotY;
					goto case 2;
				case 2:
					_0024self__0024980.RotY = Mathf.LerpAngle(_0024self__0024980.RotY, _0024self__0024980.resetRotY, 4f * Time.deltaTime);
					if (Vector2.Angle(new Vector2(Mathf.Cos(_0024self__0024980.RotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024980.RotY * ((float)Math.PI / 180f))), new Vector2(Mathf.Cos(_0024self__0024980.resetRotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024980.resetRotY * ((float)Math.PI / 180f)))) > 0.2f && _0024self__0024980.resetRotY == _0024resetRotYPrev_0024978)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__0024980.RotY = _0024self__0024980.resetRotY;
					_0024self__0024980.nowCameraReset = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024rot_0024981;

		internal Camera_Controller _0024self__0024982;

		public _0024FixedRotFromWorld_0024977(float rot, Camera_Controller self_)
		{
			_0024rot_0024981 = rot;
			_0024self__0024982 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024rot_0024981, _0024self__0024982);
		}
	}

	[Serializable]
	internal sealed class _0024FixedRotFromPlayer_0024983 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024resetRotYPrev_0024984;

			internal float _0024rot_0024985;

			internal Camera_Controller _0024self__0024986;

			public _0024(float rot, Camera_Controller self_)
			{
				_0024rot_0024985 = rot;
				_0024self__0024986 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024986.resetRotY = _0024self__0024986.playerTransform.localEulerAngles.y + _0024rot_0024985;
					_0024self__0024986.nowCameraReset = true;
					_0024resetRotYPrev_0024984 = _0024self__0024986.resetRotY;
					goto case 2;
				case 2:
					_0024self__0024986.RotY = Mathf.LerpAngle(_0024self__0024986.RotY, _0024self__0024986.resetRotY, 2f * Time.deltaTime);
					if (Vector2.Angle(new Vector2(Mathf.Cos(_0024self__0024986.RotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024986.RotY * ((float)Math.PI / 180f))), new Vector2(Mathf.Cos(_0024self__0024986.resetRotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024986.resetRotY * ((float)Math.PI / 180f)))) > 0.2f && _0024self__0024986.resetRotY == _0024resetRotYPrev_0024984)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__0024986.RotY = _0024self__0024986.resetRotY;
					_0024self__0024986.nowCameraReset = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024rot_0024987;

		internal Camera_Controller _0024self__0024988;

		public _0024FixedRotFromPlayer_0024983(float rot, Camera_Controller self_)
		{
			_0024rot_0024987 = rot;
			_0024self__0024988 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024rot_0024987, _0024self__0024988);
		}
	}

	[Serializable]
	internal sealed class _0024FixedRotFromPlayerFast_0024989 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024resetRotYPrev_0024990;

			internal float _0024rot_0024991;

			internal Camera_Controller _0024self__0024992;

			public _0024(float rot, Camera_Controller self_)
			{
				_0024rot_0024991 = rot;
				_0024self__0024992 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024992.resetRotY = _0024self__0024992.playerTransform.localEulerAngles.y + _0024rot_0024991;
					_0024self__0024992.nowCameraReset = true;
					_0024resetRotYPrev_0024990 = _0024self__0024992.resetRotY;
					goto case 2;
				case 2:
					_0024self__0024992.RotY = Mathf.LerpAngle(_0024self__0024992.RotY, _0024self__0024992.resetRotY, 8f * Time.deltaTime);
					if (Vector2.Angle(new Vector2(Mathf.Cos(_0024self__0024992.RotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024992.RotY * ((float)Math.PI / 180f))), new Vector2(Mathf.Cos(_0024self__0024992.resetRotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024992.resetRotY * ((float)Math.PI / 180f)))) > 1f && _0024self__0024992.resetRotY == _0024resetRotYPrev_0024990)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__0024992.RotY = _0024self__0024992.resetRotY;
					_0024self__0024992.nowCameraReset = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024rot_0024993;

		internal Camera_Controller _0024self__0024994;

		public _0024FixedRotFromPlayerFast_0024989(float rot, Camera_Controller self_)
		{
			_0024rot_0024993 = rot;
			_0024self__0024994 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024rot_0024993, _0024self__0024994);
		}
	}

	[Serializable]
	internal sealed class _0024FixedRotFromPlayerAuto_0024995 : GenericGenerator<WaitForEndOfFrame>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
		{
			internal float _0024resetRotYPrev_0024996;

			internal float _0024rot_0024997;

			internal Camera_Controller _0024self__0024998;

			public _0024(float rot, Camera_Controller self_)
			{
				_0024rot_0024997 = rot;
				_0024self__0024998 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(Mathf.Abs(_0024self__0024998.playerTransform.localEulerAngles.y - _0024self__0024998.RotY) <= 180f))
					{
						_0024rot_0024997 *= -1f;
					}
					if (!(_0024self__0024998.playerTransform.localEulerAngles.y - _0024self__0024998.RotY < 0f))
					{
						_0024self__0024998.resetRotY = _0024self__0024998.playerTransform.localEulerAngles.y - _0024rot_0024997;
					}
					else
					{
						_0024self__0024998.resetRotY = _0024self__0024998.playerTransform.localEulerAngles.y + _0024rot_0024997;
					}
					_0024self__0024998.nowCameraReset = true;
					_0024resetRotYPrev_0024996 = _0024self__0024998.resetRotY;
					goto case 2;
				case 2:
					_0024self__0024998.RotY = Mathf.LerpAngle(_0024self__0024998.RotY, _0024self__0024998.resetRotY, 2f * Time.deltaTime);
					if (Vector2.Angle(new Vector2(Mathf.Cos(_0024self__0024998.RotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024998.RotY * ((float)Math.PI / 180f))), new Vector2(Mathf.Cos(_0024self__0024998.resetRotY * ((float)Math.PI / 180f)), Mathf.Sin(_0024self__0024998.resetRotY * ((float)Math.PI / 180f)))) > 0.2f && _0024self__0024998.resetRotY == _0024resetRotYPrev_0024996)
					{
						result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
						break;
					}
					_0024self__0024998.RotY = _0024self__0024998.resetRotY;
					_0024self__0024998.nowCameraReset = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024rot_0024999;

		internal Camera_Controller _0024self__00241000;

		public _0024FixedRotFromPlayerAuto_0024995(float rot, Camera_Controller self_)
		{
			_0024rot_0024999 = rot;
			_0024self__00241000 = self_;
		}

		public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
		{
			return new _0024(_0024rot_0024999, _0024self__00241000);
		}
	}

	public GameObject Player;

	public float Distance;

	public float SensitivityX;

	public float SensitivityY;

	public float JSensitivityX;

	public float JSensitivityY;

	public float Width;

	public float Height;

	public float cameraEscapeDistance;

	public float cameraEscapeHeight;

	public bool smoothed;

	public float smoothFactor;

	public float maxRot;

	public float RotX;

	public float RotY;

	public bool selectRoom;

	private float toCameraDistance;

	private float widthDistance;

	private Vector3 playerTarget;

	private Vector3 cameraRight;

	private bool isSwitching;

	private bool isSwitchSync;

	private bool nowCameraReset;

	public bool dontControll;

	public Camera subCameraNow;

	private Transform myTransform;

	private Transform playerTransform;

	private Player_Status status;

	private float firstSmoothFactor;

	private float firstWidth;

	private float firstFieldOfView;

	private float resetRotX;

	private float resetRotY;

	private bool nowCameraEscape;

	private GameObject lookAtTarget;

	public Camera_Controller()
	{
		Distance = 3f;
		SensitivityX = 200f;
		SensitivityY = 200f;
		JSensitivityX = 140f;
		JSensitivityY = 140f;
		Height = 1.4f;
		cameraEscapeDistance = 0.4f;
		cameraEscapeHeight = 1.9f;
		smoothFactor = 4f;
		maxRot = 39f;
		dontControll = true;
	}

	public virtual void Awake()
	{
		toCameraDistance = Distance;
		myTransform = transform;
		playerTransform = Player.transform;
		firstSmoothFactor = smoothFactor;
		firstWidth = Width;
		firstFieldOfView = gameObject.camera.fieldOfView;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void Update()
	{
		if (!isSwitching)
		{
			if (!dontControll)
			{
				if (SensitivityX != status.mouseSensitivity)
				{
					SensitivityX = status.mouseSensitivity;
					SensitivityY = status.mouseSensitivity;
				}
				if (JSensitivityX != status.stickSensitivity)
				{
					JSensitivityX = status.stickSensitivity;
					JSensitivityY = status.stickSensitivity;
				}
				if (!isSwitchSync && !nowCameraReset)
				{
					RotX -= (SensitivityX * Mathf.Clamp(cInput.GetAxis("Mouse Y"), -1f, 1f) + JSensitivityX * Mathf.Clamp(cInput.GetAxis("J_Mouse Y"), -1f, 1f)) * Time.deltaTime;
					RotY += (SensitivityY * Mathf.Clamp(cInput.GetAxis("Mouse X"), -1f, 1f) + JSensitivityY * Mathf.Clamp(cInput.GetAxis("J_Mouse X"), -1f, 1f)) * Time.deltaTime;
					if (Application.isEditor)
					{
						if (Input.GetKey(KeyCode.Keypad6))
						{
							RotY += SensitivityY * Time.deltaTime;
						}
						if (Input.GetKey(KeyCode.Keypad4))
						{
							RotY -= SensitivityY * Time.deltaTime;
						}
						if (Input.GetKey(KeyCode.Keypad8))
						{
							RotX -= SensitivityX * Time.deltaTime;
						}
						if (Input.GetKey(KeyCode.Keypad2))
						{
							RotX += SensitivityX * Time.deltaTime;
						}
					}
					if ((cInput.GetButton("Camera Reset") || cInput.GetButton("J_Camera Reset")) && !selectRoom)
					{
						resetRotY = playerTransform.localEulerAngles.y;
						StartCoroutine_Auto(NowCameraReset());
					}
				}
			}
			if (!(0f - maxRot <= RotX))
			{
				RotX = 0f - maxRot;
			}
			if (!(maxRot >= RotX))
			{
				RotX = maxRot;
			}
			RotY %= 360f;
			if (!(RotY >= 0f))
			{
				RotY = 360f + RotY;
			}
			Quaternion quaternion = Quaternion.Euler(RotX, RotY, 0f);
			RaycastHit hitInfo = default(RaycastHit);
			cameraRight = myTransform.TransformDirection(Vector3.right);
			cameraRight.Normalize();
			if (Physics.Linecast(new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z) + new Vector3(0f, Height, 0f), new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z) + new Vector3(0f, Height, 0f) + cameraRight * (Width + 0.2f), -5))
			{
				if (!(Width < 0f))
				{
					widthDistance = 0f;
				}
				else
				{
					widthDistance = 0f + Width;
				}
			}
			else
			{
				widthDistance = Width;
			}
			if (Vector3.Distance(new Vector3(playerTransform.position.x, 0f, playerTransform.position.z), new Vector3(myTransform.position.x, 0f, myTransform.position.z)) > cameraEscapeDistance || isSwitchSync)
			{
				if (nowCameraEscape)
				{
					RotX = resetRotX;
				}
				nowCameraEscape = false;
				playerTarget = playerTransform.position + new Vector3(0f, Height, 0f) + cameraRight * widthDistance;
			}
			else
			{
				if (!nowCameraEscape)
				{
					resetRotX = RotX;
				}
				nowCameraEscape = true;
				RotX = maxRot;
				playerTarget = playerTransform.position + new Vector3(0f, cameraEscapeHeight, 0f) + cameraRight * widthDistance;
			}
			if (Physics.Linecast(playerTarget, myTransform.position, out hitInfo, -5))
			{
				if (!(Vector3.Distance(hitInfo.point, playerTarget) < Distance))
				{
					toCameraDistance = Distance;
				}
				else
				{
					toCameraDistance = Vector3.Distance(hitInfo.point, playerTarget);
				}
			}
			else if (Physics.Linecast(playerTarget, playerTarget - quaternion * (Vector3.forward * Distance), out hitInfo, -5))
			{
				if (!(Vector3.Distance(hitInfo.point, playerTarget) < Distance))
				{
					toCameraDistance = Distance;
				}
				else
				{
					toCameraDistance = Vector3.Distance(hitInfo.point, playerTarget);
				}
			}
			else
			{
				toCameraDistance = Mathf.Lerp(toCameraDistance, Distance, smoothFactor * Time.deltaTime);
			}
			if (smoothed)
			{
				myTransform.position = Vector3.Slerp(myTransform.position, playerTarget - quaternion * (Vector3.forward * toCameraDistance), smoothFactor * Time.deltaTime);
				if (!(myTransform.position.y >= playerTransform.position.y))
				{
					float y = Mathf.Lerp(myTransform.position.y, playerTransform.position.y + 0.01f, smoothFactor * Time.deltaTime);
					Vector3 position = myTransform.position;
					float num = (position.y = y);
					Vector3 vector = (myTransform.position = position);
				}
				if (lookAtTarget == null)
				{
					myTransform.rotation = Quaternion.Slerp(myTransform.rotation, quaternion, smoothFactor * Time.deltaTime);
				}
				else
				{
					LookAtTarget();
				}
			}
			else
			{
				myTransform.position = playerTarget - quaternion * (Vector3.forward * toCameraDistance);
				if (!(myTransform.position.y >= playerTransform.position.y))
				{
					float y2 = playerTransform.position.y + 0.01f;
					Vector3 position2 = myTransform.position;
					float num2 = (position2.y = y2);
					Vector3 vector3 = (myTransform.position = position2);
				}
				myTransform.rotation = quaternion;
			}
		}
		else
		{
			playerTarget = playerTransform.position + new Vector3(0f, Height, 0f) + cameraRight * widthDistance;
		}
	}

	public virtual void LookAtTarget()
	{
		if (smoothed)
		{
			Quaternion to = Quaternion.LookRotation(lookAtTarget.transform.position - myTransform.position);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, to, Time.deltaTime * smoothFactor);
		}
		else
		{
			transform.LookAt(lookAtTarget.transform.position);
		}
	}

	public virtual void ChangeLookAtTarget(GameObject target)
	{
		lookAtTarget = target;
	}

	public virtual void StopLookAtTarget()
	{
		lookAtTarget = null;
	}

	public virtual void Switching(bool info)
	{
		if (info)
		{
			isSwitching = true;
		}
		else
		{
			isSwitching = false;
		}
	}

	public virtual void ChangeSwitchSync(bool info)
	{
		if (info)
		{
			isSwitchSync = true;
			iTween.Stop(gameObject);
			smoothFactor = firstSmoothFactor / 2f;
			Width = 0f;
			return;
		}
		isSwitchSync = false;
		iTween.ValueTo(gameObject, iTween.Hash("from", smoothFactor, "to", firstSmoothFactor, "time", 2.4f, "onupdate", "ChangeSmoothFactor"));
		Width = firstWidth;
	}

	public virtual void EndSwitch()
	{
		isSwitching = false;
		isSwitchSync = false;
		iTween.ValueTo(gameObject, iTween.Hash("from", smoothFactor, "to", firstSmoothFactor, "time", 2.4f, "onupdate", "ChangeSmoothFactor"));
		Width = firstWidth;
	}

	public virtual bool ShowSwitching()
	{
		return isSwitching;
	}

	public virtual void DontControllCamera(bool info)
	{
		if (info)
		{
			dontControll = true;
		}
		else
		{
			dontControll = false;
		}
	}

	public virtual void ChangeDistance(float dist)
	{
		Distance = dist;
	}

	public virtual void ChangeWidth(float wid)
	{
		Width = wid;
	}

	public virtual void ChangeSmoothFactor(float factorValue)
	{
		smoothFactor = factorValue;
	}

	public virtual void FixedRot(float x, float y)
	{
		RotX = x;
		RotY = y;
	}

	public virtual void FixedRotX(float x)
	{
		RotX = x;
	}

	public virtual void FixedRotY(float y)
	{
		RotY = y;
	}

	public virtual IEnumerator FixedRotForce(float x, float y)
	{
		return new _0024FixedRotForce_0024966(x, y, this).GetEnumerator();
	}

	public virtual float ShowRotX()
	{
		return RotX;
	}

	public virtual float ShowRotY()
	{
		return RotY;
	}

	public virtual IEnumerator NowCameraReset()
	{
		return new _0024NowCameraReset_0024973(this).GetEnumerator();
	}

	public virtual void SetResetRotY(float amount)
	{
		resetRotY = amount;
	}

	public virtual IEnumerator FixedRotFromWorld(float rot)
	{
		return new _0024FixedRotFromWorld_0024977(rot, this).GetEnumerator();
	}

	public virtual IEnumerator FixedRotFromPlayer(float rot)
	{
		return new _0024FixedRotFromPlayer_0024983(rot, this).GetEnumerator();
	}

	public virtual IEnumerator FixedRotFromPlayerFast(float rot)
	{
		return new _0024FixedRotFromPlayerFast_0024989(rot, this).GetEnumerator();
	}

	public virtual IEnumerator FixedRotFromPlayerAuto(float rot)
	{
		return new _0024FixedRotFromPlayerAuto_0024995(rot, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
