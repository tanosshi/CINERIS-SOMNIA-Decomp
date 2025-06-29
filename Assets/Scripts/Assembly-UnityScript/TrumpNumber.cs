using System;
using UnityEngine;

[Serializable]
public class TrumpNumber : MonoBehaviour
{
	private Player_Status status;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void TrumpNumber()
	{
		do
		{
			status.variables[80] = UnityEngine.Random.Range(0, 10);
		}
		while (status.variables[80] != 3f && status.variables[80] != 4f && status.variables[80] != 5f && status.variables[80] != 7f);
		do
		{
			status.variables[81] = UnityEngine.Random.Range(0, 10);
		}
		while (status.variables[81] != 1f && status.variables[81] != 3f && status.variables[81] != 8f);
		do
		{
			status.variables[82] = UnityEngine.Random.Range(0, 10);
		}
		while (status.variables[82] != 2f && status.variables[82] != 7f && status.variables[82] != 8f && status.variables[82] != 9f);
		do
		{
			status.variables[83] = UnityEngine.Random.Range(0, 10);
		}
		while (status.variables[83] != 2f && status.variables[83] != 5f && status.variables[83] != 6f);
	}

	public virtual void Main()
	{
	}
}
