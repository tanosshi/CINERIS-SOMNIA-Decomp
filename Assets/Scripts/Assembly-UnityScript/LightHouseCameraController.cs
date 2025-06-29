using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class LightHouseCameraController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Stop_00241228 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_0024551_00241229;

			internal Vector3 _0024_0024552_00241230;

			internal LightHouseCameraController _0024self__00241231;

			public _0024(LightHouseCameraController self_)
			{
				_0024self__00241231 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00241231.nowStop)
					{
						_0024self__00241231.nowStop = true;
						_0024self__00241231.systemObject.SendMessage("CommonAction", (object)0);
						_0024self__00241231.mainCamera.FixedRot(29.13004f, -325.8283f);
						_0024self__00241231.mainCamera.Switching(false);
						_0024self__00241231.mainCamera.ChangeSwitchSync(false);
						_0024self__00241231.mainCamera.camera.fieldOfView = 60f;
						result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
						break;
					}
					goto IL_013f;
				case 2:
				{
					float num = (_0024_0024551_00241229 = _0024self__00241231.targetTransform.position.y + _0024self__00241231.height);
					Vector3 vector = (_0024_0024552_00241230 = _0024self__00241231.myTransform.position);
					float num2 = (_0024_0024552_00241230.y = _0024_0024551_00241229);
					Vector3 vector2 = (_0024self__00241231.myTransform.position = _0024_0024552_00241230);
					_0024self__00241231.nowStop = false;
					goto IL_013f;
				}
				case 1:
					{
						result = 0;
						break;
					}
					IL_013f:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LightHouseCameraController _0024self__00241232;

		public _0024Stop_00241228(LightHouseCameraController self_)
		{
			_0024self__00241232 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00241232);
		}
	}

	public GameObject target;

	public float height;

	public float speed;

	public float cameraHeight;

	public float camSpeed;

	public bool smoothed;

	public GameObject systemObject;

	public Transform directionLObject;

	public Transform directionLTransform1;

	public Transform directionLTransform2;

	private Transform myTransform;

	private Transform targetTransform;

	private Vector3 lookAtPoint;

	private Camera_Controller mainCamera;

	private bool nowStop;

	private Player_Status status;

	public LightHouseCameraController()
	{
		camSpeed = 2f;
		smoothed = true;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		myTransform = transform;
		targetTransform = target.transform;
		mainCamera = (Camera_Controller)GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera_Controller));
	}

	public virtual void Update()
	{
		if (gameObject.camera.enabled)
		{
			status.switches[109] = 1;
			mainCamera.transform.position = gameObject.transform.position;
			mainCamera.transform.rotation = gameObject.transform.rotation;
		}
		else
		{
			status.switches[109] = 0;
		}
		if (Vector3.Distance(targetTransform.position, directionLTransform2.position) <= 1.25f || !myTransform.gameObject.camera.enabled)
		{
			float y = Mathf.Lerp(myTransform.position.y, targetTransform.position.y + height, speed * Time.deltaTime);
			Vector3 position = myTransform.position;
			float num = (position.y = y);
			Vector3 vector = (myTransform.position = position);
			directionLObject.position = directionLTransform1.position;
		}
		else
		{
			directionLObject.position = directionLTransform2.position;
		}
		if (!(myTransform.position.y - targetTransform.position.y < 4.9142f))
		{
			StartCoroutine_Auto(Stop());
		}
	}

	public virtual void LateUpdate()
	{
		lookAtPoint = targetTransform.position;
		lookAtPoint.y = targetTransform.position.y + cameraHeight;
		if (myTransform.position.y - height <= targetTransform.position.y || !myTransform.gameObject.camera.enabled)
		{
			LookAtMe();
		}
	}

	public virtual void LookAtMe()
	{
		if (smoothed)
		{
			Quaternion to = Quaternion.LookRotation(lookAtPoint - myTransform.position);
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, to, Time.deltaTime * camSpeed);
		}
		else
		{
			transform.LookAt(lookAtPoint);
		}
	}

	public virtual IEnumerator Stop()
	{
		return new _0024Stop_00241228(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
