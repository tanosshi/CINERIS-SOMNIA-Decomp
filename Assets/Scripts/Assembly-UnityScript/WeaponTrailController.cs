using System;
using UnityEngine;
using Xft;

[Serializable]
public class WeaponTrailController : MonoBehaviour
{
	public XWeaponTrail weaponTrail;

	public virtual void ChangeWeaponTrail(float amount)
	{
		weaponTrail.MyColor.a = amount;
	}

	public virtual void Main()
	{
	}
}
