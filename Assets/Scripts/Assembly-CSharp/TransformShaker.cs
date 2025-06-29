using UnityEngine;

public class TransformShaker : MonoBehaviour
{
	public Shaker position;

	public Shaker rotation;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private void Awake()
	{
		initialPosition = base.transform.localPosition;
		initialRotation = base.transform.localRotation;
	}

	private void Update()
	{
		position.Update(Time.deltaTime);
		rotation.Update(Time.deltaTime);
		base.transform.localPosition = initialPosition + position.Position;
		base.transform.localRotation = rotation.YawPitch * initialRotation;
	}

	public void Reshake()
	{
		position.Reset();
		rotation.Reset();
	}
}
