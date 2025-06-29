using UnityEngine;

public class DynamicBoneController : MonoBehaviour
{
	public bool useWind;

	public float windSpeed;

	public Vector3 minWindForce = Vector3.zero;

	public Vector3 maxWindForce = Vector3.zero;

	private DynamicBone[] bones;

	private int i;

	private Vector3 windVector = Vector3.zero;

	private void Start()
	{
		bones = GetComponents<DynamicBone>();
	}

	private void Update()
	{
		if (useWind)
		{
			windVector.x = Random.Range(minWindForce.x, maxWindForce.x);
			windVector.y = Random.Range(minWindForce.y, maxWindForce.y);
			windVector.z = Random.Range(minWindForce.z, maxWindForce.z);
		}
		else
		{
			windVector.x = 0f;
			windVector.y = 0f;
			windVector.z = 0f;
		}
		for (i = 0; i < bones.Length; i++)
		{
			bones[i].m_Force = Vector3.Lerp(bones[i].m_Force, windVector, windSpeed * Time.deltaTime);
		}
	}

	private void DynamicBoneOn()
	{
		for (i = 0; i < bones.Length; i++)
		{
			bones[i].enabled = true;
		}
	}

	private void DynamicBoneOff()
	{
		for (i = 0; i < bones.Length; i++)
		{
			bones[i].enabled = false;
		}
	}

	private void ChangeUseWind(int id)
	{
		if (id == 0)
		{
			useWind = false;
		}
		else
		{
			useWind = true;
		}
	}
}
