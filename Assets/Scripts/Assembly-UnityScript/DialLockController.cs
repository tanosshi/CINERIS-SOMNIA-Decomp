using System;
using UnityEngine;

[Serializable]
public class DialLockController : MonoBehaviour
{
	public Transform dial1;

	public Transform dial2;

	public Transform dial3;

	public Transform dial4;

	public GameObject dial1Material;

	public GameObject dial2Material;

	public GameObject dial3Material;

	public GameObject dial4Material;

	public float dialSpeed;

	public AudioClip dialAudio;

	public float scrollSpeed;

	public float fadeSpeed;

	public float maxAlpha;

	private Player_Status status;

	private bool nowDial;

	private int cursorId;

	private bool cursorFlag;

	private bool dialFlag;

	private bool minusFlag;

	private float dialTemp;

	private float offsetY;

	private float alpha1;

	private float alpha2;

	private float alpha3;

	private float alpha4;

	private float emission1;

	private float emission2;

	private float emission3;

	private float emission4;

	public DialLockController()
	{
		cursorFlag = true;
	}

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
		float num = status.variables[84];
		if (num == 0f)
		{
			float z = 0f;
			Vector3 localEulerAngles = dial1.localEulerAngles;
			float num2 = (localEulerAngles.z = z);
			Vector3 vector = (dial1.localEulerAngles = localEulerAngles);
		}
		else if (num == 1f)
		{
			float z2 = -36f;
			Vector3 localEulerAngles2 = dial1.localEulerAngles;
			float num3 = (localEulerAngles2.z = z2);
			Vector3 vector3 = (dial1.localEulerAngles = localEulerAngles2);
		}
		else if (num == 2f)
		{
			float z3 = -72f;
			Vector3 localEulerAngles3 = dial1.localEulerAngles;
			float num4 = (localEulerAngles3.z = z3);
			Vector3 vector5 = (dial1.localEulerAngles = localEulerAngles3);
		}
		else if (num == 3f)
		{
			float z4 = -108f;
			Vector3 localEulerAngles4 = dial1.localEulerAngles;
			float num5 = (localEulerAngles4.z = z4);
			Vector3 vector7 = (dial1.localEulerAngles = localEulerAngles4);
		}
		else if (num == 4f)
		{
			float z5 = -144f;
			Vector3 localEulerAngles5 = dial1.localEulerAngles;
			float num6 = (localEulerAngles5.z = z5);
			Vector3 vector9 = (dial1.localEulerAngles = localEulerAngles5);
		}
		else if (num == 5f)
		{
			float z6 = -180f;
			Vector3 localEulerAngles6 = dial1.localEulerAngles;
			float num7 = (localEulerAngles6.z = z6);
			Vector3 vector11 = (dial1.localEulerAngles = localEulerAngles6);
		}
		else if (num == 6f)
		{
			float z7 = -216f;
			Vector3 localEulerAngles7 = dial1.localEulerAngles;
			float num8 = (localEulerAngles7.z = z7);
			Vector3 vector13 = (dial1.localEulerAngles = localEulerAngles7);
		}
		else if (num == 7f)
		{
			float z8 = -252f;
			Vector3 localEulerAngles8 = dial1.localEulerAngles;
			float num9 = (localEulerAngles8.z = z8);
			Vector3 vector15 = (dial1.localEulerAngles = localEulerAngles8);
		}
		else if (num == 8f)
		{
			float z9 = -288f;
			Vector3 localEulerAngles9 = dial1.localEulerAngles;
			float num10 = (localEulerAngles9.z = z9);
			Vector3 vector17 = (dial1.localEulerAngles = localEulerAngles9);
		}
		else if (num == 9f)
		{
			float z10 = -324f;
			Vector3 localEulerAngles10 = dial1.localEulerAngles;
			float num11 = (localEulerAngles10.z = z10);
			Vector3 vector19 = (dial1.localEulerAngles = localEulerAngles10);
		}
		float num12 = status.variables[85];
		if (num12 == 0f)
		{
			float z11 = 0f;
			Vector3 localEulerAngles11 = dial2.localEulerAngles;
			float num13 = (localEulerAngles11.z = z11);
			Vector3 vector21 = (dial2.localEulerAngles = localEulerAngles11);
		}
		else if (num12 == 1f)
		{
			float z12 = -36f;
			Vector3 localEulerAngles12 = dial2.localEulerAngles;
			float num14 = (localEulerAngles12.z = z12);
			Vector3 vector23 = (dial2.localEulerAngles = localEulerAngles12);
		}
		else if (num12 == 2f)
		{
			float z13 = -72f;
			Vector3 localEulerAngles13 = dial2.localEulerAngles;
			float num15 = (localEulerAngles13.z = z13);
			Vector3 vector25 = (dial2.localEulerAngles = localEulerAngles13);
		}
		else if (num12 == 3f)
		{
			float z14 = -108f;
			Vector3 localEulerAngles14 = dial2.localEulerAngles;
			float num16 = (localEulerAngles14.z = z14);
			Vector3 vector27 = (dial2.localEulerAngles = localEulerAngles14);
		}
		else if (num12 == 4f)
		{
			float z15 = -144f;
			Vector3 localEulerAngles15 = dial2.localEulerAngles;
			float num17 = (localEulerAngles15.z = z15);
			Vector3 vector29 = (dial2.localEulerAngles = localEulerAngles15);
		}
		else if (num12 == 5f)
		{
			float z16 = -180f;
			Vector3 localEulerAngles16 = dial2.localEulerAngles;
			float num18 = (localEulerAngles16.z = z16);
			Vector3 vector31 = (dial2.localEulerAngles = localEulerAngles16);
		}
		else if (num12 == 6f)
		{
			float z17 = -216f;
			Vector3 localEulerAngles17 = dial2.localEulerAngles;
			float num19 = (localEulerAngles17.z = z17);
			Vector3 vector33 = (dial2.localEulerAngles = localEulerAngles17);
		}
		else if (num12 == 7f)
		{
			float z18 = -252f;
			Vector3 localEulerAngles18 = dial2.localEulerAngles;
			float num20 = (localEulerAngles18.z = z18);
			Vector3 vector35 = (dial2.localEulerAngles = localEulerAngles18);
		}
		else if (num12 == 8f)
		{
			float z19 = -288f;
			Vector3 localEulerAngles19 = dial2.localEulerAngles;
			float num21 = (localEulerAngles19.z = z19);
			Vector3 vector37 = (dial2.localEulerAngles = localEulerAngles19);
		}
		else if (num12 == 9f)
		{
			float z20 = -324f;
			Vector3 localEulerAngles20 = dial2.localEulerAngles;
			float num22 = (localEulerAngles20.z = z20);
			Vector3 vector39 = (dial2.localEulerAngles = localEulerAngles20);
		}
		float num23 = status.variables[86];
		if (num23 == 0f)
		{
			float z21 = 0f;
			Vector3 localEulerAngles21 = dial3.localEulerAngles;
			float num24 = (localEulerAngles21.z = z21);
			Vector3 vector41 = (dial3.localEulerAngles = localEulerAngles21);
		}
		else if (num23 == 1f)
		{
			float z22 = -36f;
			Vector3 localEulerAngles22 = dial3.localEulerAngles;
			float num25 = (localEulerAngles22.z = z22);
			Vector3 vector43 = (dial3.localEulerAngles = localEulerAngles22);
		}
		else if (num23 == 2f)
		{
			float z23 = -72f;
			Vector3 localEulerAngles23 = dial3.localEulerAngles;
			float num26 = (localEulerAngles23.z = z23);
			Vector3 vector45 = (dial3.localEulerAngles = localEulerAngles23);
		}
		else if (num23 == 3f)
		{
			float z24 = -108f;
			Vector3 localEulerAngles24 = dial3.localEulerAngles;
			float num27 = (localEulerAngles24.z = z24);
			Vector3 vector47 = (dial3.localEulerAngles = localEulerAngles24);
		}
		else if (num23 == 4f)
		{
			float z25 = -144f;
			Vector3 localEulerAngles25 = dial3.localEulerAngles;
			float num28 = (localEulerAngles25.z = z25);
			Vector3 vector49 = (dial3.localEulerAngles = localEulerAngles25);
		}
		else if (num23 == 5f)
		{
			float z26 = -180f;
			Vector3 localEulerAngles26 = dial3.localEulerAngles;
			float num29 = (localEulerAngles26.z = z26);
			Vector3 vector51 = (dial3.localEulerAngles = localEulerAngles26);
		}
		else if (num23 == 6f)
		{
			float z27 = -216f;
			Vector3 localEulerAngles27 = dial3.localEulerAngles;
			float num30 = (localEulerAngles27.z = z27);
			Vector3 vector53 = (dial3.localEulerAngles = localEulerAngles27);
		}
		else if (num23 == 7f)
		{
			float z28 = -252f;
			Vector3 localEulerAngles28 = dial3.localEulerAngles;
			float num31 = (localEulerAngles28.z = z28);
			Vector3 vector55 = (dial3.localEulerAngles = localEulerAngles28);
		}
		else if (num23 == 8f)
		{
			float z29 = -288f;
			Vector3 localEulerAngles29 = dial3.localEulerAngles;
			float num32 = (localEulerAngles29.z = z29);
			Vector3 vector57 = (dial3.localEulerAngles = localEulerAngles29);
		}
		else if (num23 == 9f)
		{
			float z30 = -324f;
			Vector3 localEulerAngles30 = dial3.localEulerAngles;
			float num33 = (localEulerAngles30.z = z30);
			Vector3 vector59 = (dial3.localEulerAngles = localEulerAngles30);
		}
		float num34 = status.variables[87];
		if (num34 == 0f)
		{
			float z31 = 0f;
			Vector3 localEulerAngles31 = dial4.localEulerAngles;
			float num35 = (localEulerAngles31.z = z31);
			Vector3 vector61 = (dial4.localEulerAngles = localEulerAngles31);
		}
		else if (num34 == 1f)
		{
			float z32 = -36f;
			Vector3 localEulerAngles32 = dial4.localEulerAngles;
			float num36 = (localEulerAngles32.z = z32);
			Vector3 vector63 = (dial4.localEulerAngles = localEulerAngles32);
		}
		else if (num34 == 2f)
		{
			float z33 = -72f;
			Vector3 localEulerAngles33 = dial4.localEulerAngles;
			float num37 = (localEulerAngles33.z = z33);
			Vector3 vector65 = (dial4.localEulerAngles = localEulerAngles33);
		}
		else if (num34 == 3f)
		{
			float z34 = -108f;
			Vector3 localEulerAngles34 = dial4.localEulerAngles;
			float num38 = (localEulerAngles34.z = z34);
			Vector3 vector67 = (dial4.localEulerAngles = localEulerAngles34);
		}
		else if (num34 == 4f)
		{
			float z35 = -144f;
			Vector3 localEulerAngles35 = dial4.localEulerAngles;
			float num39 = (localEulerAngles35.z = z35);
			Vector3 vector69 = (dial4.localEulerAngles = localEulerAngles35);
		}
		else if (num34 == 5f)
		{
			float z36 = -180f;
			Vector3 localEulerAngles36 = dial4.localEulerAngles;
			float num40 = (localEulerAngles36.z = z36);
			Vector3 vector71 = (dial4.localEulerAngles = localEulerAngles36);
		}
		else if (num34 == 6f)
		{
			float z37 = -216f;
			Vector3 localEulerAngles37 = dial4.localEulerAngles;
			float num41 = (localEulerAngles37.z = z37);
			Vector3 vector73 = (dial4.localEulerAngles = localEulerAngles37);
		}
		else if (num34 == 7f)
		{
			float z38 = -252f;
			Vector3 localEulerAngles38 = dial4.localEulerAngles;
			float num42 = (localEulerAngles38.z = z38);
			Vector3 vector75 = (dial4.localEulerAngles = localEulerAngles38);
		}
		else if (num34 == 8f)
		{
			float z39 = -288f;
			Vector3 localEulerAngles39 = dial4.localEulerAngles;
			float num43 = (localEulerAngles39.z = z39);
			Vector3 vector77 = (dial4.localEulerAngles = localEulerAngles39);
		}
		else if (num34 == 9f)
		{
			float z40 = -324f;
			Vector3 localEulerAngles40 = dial4.localEulerAngles;
			float num44 = (localEulerAngles40.z = z40);
			Vector3 vector79 = (dial4.localEulerAngles = localEulerAngles40);
		}
	}

	public virtual void Update()
	{
		float num = status.variables[84];
		if (num == 0f)
		{
			float z = Mathf.LerpAngle(dial1.localEulerAngles.z, 0f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles = dial1.localEulerAngles;
			float num2 = (localEulerAngles.z = z);
			Vector3 vector = (dial1.localEulerAngles = localEulerAngles);
		}
		else if (num == 1f)
		{
			float z2 = Mathf.LerpAngle(dial1.localEulerAngles.z, 324f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles2 = dial1.localEulerAngles;
			float num3 = (localEulerAngles2.z = z2);
			Vector3 vector3 = (dial1.localEulerAngles = localEulerAngles2);
		}
		else if (num == 2f)
		{
			float z3 = Mathf.LerpAngle(dial1.localEulerAngles.z, 288f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles3 = dial1.localEulerAngles;
			float num4 = (localEulerAngles3.z = z3);
			Vector3 vector5 = (dial1.localEulerAngles = localEulerAngles3);
		}
		else if (num == 3f)
		{
			float z4 = Mathf.LerpAngle(dial1.localEulerAngles.z, 252f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles4 = dial1.localEulerAngles;
			float num5 = (localEulerAngles4.z = z4);
			Vector3 vector7 = (dial1.localEulerAngles = localEulerAngles4);
		}
		else if (num == 4f)
		{
			float z5 = Mathf.LerpAngle(dial1.localEulerAngles.z, 216f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles5 = dial1.localEulerAngles;
			float num6 = (localEulerAngles5.z = z5);
			Vector3 vector9 = (dial1.localEulerAngles = localEulerAngles5);
		}
		else if (num == 5f)
		{
			float z6 = Mathf.LerpAngle(dial1.localEulerAngles.z, 180f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles6 = dial1.localEulerAngles;
			float num7 = (localEulerAngles6.z = z6);
			Vector3 vector11 = (dial1.localEulerAngles = localEulerAngles6);
		}
		else if (num == 6f)
		{
			float z7 = Mathf.LerpAngle(dial1.localEulerAngles.z, 144f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles7 = dial1.localEulerAngles;
			float num8 = (localEulerAngles7.z = z7);
			Vector3 vector13 = (dial1.localEulerAngles = localEulerAngles7);
		}
		else if (num == 7f)
		{
			float z8 = Mathf.LerpAngle(dial1.localEulerAngles.z, 108f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles8 = dial1.localEulerAngles;
			float num9 = (localEulerAngles8.z = z8);
			Vector3 vector15 = (dial1.localEulerAngles = localEulerAngles8);
		}
		else if (num == 8f)
		{
			float z9 = Mathf.LerpAngle(dial1.localEulerAngles.z, 72f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles9 = dial1.localEulerAngles;
			float num10 = (localEulerAngles9.z = z9);
			Vector3 vector17 = (dial1.localEulerAngles = localEulerAngles9);
		}
		else if (num == 9f)
		{
			float z10 = Mathf.LerpAngle(dial1.localEulerAngles.z, 36f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles10 = dial1.localEulerAngles;
			float num11 = (localEulerAngles10.z = z10);
			Vector3 vector19 = (dial1.localEulerAngles = localEulerAngles10);
		}
		float num12 = status.variables[85];
		if (num12 == 0f)
		{
			float z11 = Mathf.LerpAngle(dial2.localEulerAngles.z, 0f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles11 = dial2.localEulerAngles;
			float num13 = (localEulerAngles11.z = z11);
			Vector3 vector21 = (dial2.localEulerAngles = localEulerAngles11);
		}
		else if (num12 == 1f)
		{
			float z12 = Mathf.LerpAngle(dial2.localEulerAngles.z, -36f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles12 = dial2.localEulerAngles;
			float num14 = (localEulerAngles12.z = z12);
			Vector3 vector23 = (dial2.localEulerAngles = localEulerAngles12);
		}
		else if (num12 == 2f)
		{
			float z13 = Mathf.LerpAngle(dial2.localEulerAngles.z, -72f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles13 = dial2.localEulerAngles;
			float num15 = (localEulerAngles13.z = z13);
			Vector3 vector25 = (dial2.localEulerAngles = localEulerAngles13);
		}
		else if (num12 == 3f)
		{
			float z14 = Mathf.LerpAngle(dial2.localEulerAngles.z, -108f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles14 = dial2.localEulerAngles;
			float num16 = (localEulerAngles14.z = z14);
			Vector3 vector27 = (dial2.localEulerAngles = localEulerAngles14);
		}
		else if (num12 == 4f)
		{
			float z15 = Mathf.LerpAngle(dial2.localEulerAngles.z, -144f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles15 = dial2.localEulerAngles;
			float num17 = (localEulerAngles15.z = z15);
			Vector3 vector29 = (dial2.localEulerAngles = localEulerAngles15);
		}
		else if (num12 == 5f)
		{
			float z16 = Mathf.LerpAngle(dial2.localEulerAngles.z, -180f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles16 = dial2.localEulerAngles;
			float num18 = (localEulerAngles16.z = z16);
			Vector3 vector31 = (dial2.localEulerAngles = localEulerAngles16);
		}
		else if (num12 == 6f)
		{
			float z17 = Mathf.LerpAngle(dial2.localEulerAngles.z, -216f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles17 = dial2.localEulerAngles;
			float num19 = (localEulerAngles17.z = z17);
			Vector3 vector33 = (dial2.localEulerAngles = localEulerAngles17);
		}
		else if (num12 == 7f)
		{
			float z18 = Mathf.LerpAngle(dial2.localEulerAngles.z, -252f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles18 = dial2.localEulerAngles;
			float num20 = (localEulerAngles18.z = z18);
			Vector3 vector35 = (dial2.localEulerAngles = localEulerAngles18);
		}
		else if (num12 == 8f)
		{
			float z19 = Mathf.LerpAngle(dial2.localEulerAngles.z, -288f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles19 = dial2.localEulerAngles;
			float num21 = (localEulerAngles19.z = z19);
			Vector3 vector37 = (dial2.localEulerAngles = localEulerAngles19);
		}
		else if (num12 == 9f)
		{
			float z20 = Mathf.LerpAngle(dial2.localEulerAngles.z, -324f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles20 = dial2.localEulerAngles;
			float num22 = (localEulerAngles20.z = z20);
			Vector3 vector39 = (dial2.localEulerAngles = localEulerAngles20);
		}
		float num23 = status.variables[86];
		if (num23 == 0f)
		{
			float z21 = Mathf.LerpAngle(dial3.localEulerAngles.z, 0f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles21 = dial3.localEulerAngles;
			float num24 = (localEulerAngles21.z = z21);
			Vector3 vector41 = (dial3.localEulerAngles = localEulerAngles21);
		}
		else if (num23 == 1f)
		{
			float z22 = Mathf.LerpAngle(dial3.localEulerAngles.z, -36f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles22 = dial3.localEulerAngles;
			float num25 = (localEulerAngles22.z = z22);
			Vector3 vector43 = (dial3.localEulerAngles = localEulerAngles22);
		}
		else if (num23 == 2f)
		{
			float z23 = Mathf.LerpAngle(dial3.localEulerAngles.z, -72f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles23 = dial3.localEulerAngles;
			float num26 = (localEulerAngles23.z = z23);
			Vector3 vector45 = (dial3.localEulerAngles = localEulerAngles23);
		}
		else if (num23 == 3f)
		{
			float z24 = Mathf.LerpAngle(dial3.localEulerAngles.z, -108f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles24 = dial3.localEulerAngles;
			float num27 = (localEulerAngles24.z = z24);
			Vector3 vector47 = (dial3.localEulerAngles = localEulerAngles24);
		}
		else if (num23 == 4f)
		{
			float z25 = Mathf.LerpAngle(dial3.localEulerAngles.z, -144f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles25 = dial3.localEulerAngles;
			float num28 = (localEulerAngles25.z = z25);
			Vector3 vector49 = (dial3.localEulerAngles = localEulerAngles25);
		}
		else if (num23 == 5f)
		{
			float z26 = Mathf.LerpAngle(dial3.localEulerAngles.z, -180f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles26 = dial3.localEulerAngles;
			float num29 = (localEulerAngles26.z = z26);
			Vector3 vector51 = (dial3.localEulerAngles = localEulerAngles26);
		}
		else if (num23 == 6f)
		{
			float z27 = Mathf.LerpAngle(dial3.localEulerAngles.z, -216f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles27 = dial3.localEulerAngles;
			float num30 = (localEulerAngles27.z = z27);
			Vector3 vector53 = (dial3.localEulerAngles = localEulerAngles27);
		}
		else if (num23 == 7f)
		{
			float z28 = Mathf.LerpAngle(dial3.localEulerAngles.z, -252f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles28 = dial3.localEulerAngles;
			float num31 = (localEulerAngles28.z = z28);
			Vector3 vector55 = (dial3.localEulerAngles = localEulerAngles28);
		}
		else if (num23 == 8f)
		{
			float z29 = Mathf.LerpAngle(dial3.localEulerAngles.z, -288f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles29 = dial3.localEulerAngles;
			float num32 = (localEulerAngles29.z = z29);
			Vector3 vector57 = (dial3.localEulerAngles = localEulerAngles29);
		}
		else if (num23 == 9f)
		{
			float z30 = Mathf.LerpAngle(dial3.localEulerAngles.z, -324f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles30 = dial3.localEulerAngles;
			float num33 = (localEulerAngles30.z = z30);
			Vector3 vector59 = (dial3.localEulerAngles = localEulerAngles30);
		}
		float num34 = status.variables[87];
		if (num34 == 0f)
		{
			float z31 = Mathf.LerpAngle(dial4.localEulerAngles.z, 0f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles31 = dial4.localEulerAngles;
			float num35 = (localEulerAngles31.z = z31);
			Vector3 vector61 = (dial4.localEulerAngles = localEulerAngles31);
		}
		else if (num34 == 1f)
		{
			float z32 = Mathf.LerpAngle(dial4.localEulerAngles.z, -36f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles32 = dial4.localEulerAngles;
			float num36 = (localEulerAngles32.z = z32);
			Vector3 vector63 = (dial4.localEulerAngles = localEulerAngles32);
		}
		else if (num34 == 2f)
		{
			float z33 = Mathf.LerpAngle(dial4.localEulerAngles.z, -72f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles33 = dial4.localEulerAngles;
			float num37 = (localEulerAngles33.z = z33);
			Vector3 vector65 = (dial4.localEulerAngles = localEulerAngles33);
		}
		else if (num34 == 3f)
		{
			float z34 = Mathf.LerpAngle(dial4.localEulerAngles.z, -108f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles34 = dial4.localEulerAngles;
			float num38 = (localEulerAngles34.z = z34);
			Vector3 vector67 = (dial4.localEulerAngles = localEulerAngles34);
		}
		else if (num34 == 4f)
		{
			float z35 = Mathf.LerpAngle(dial4.localEulerAngles.z, -144f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles35 = dial4.localEulerAngles;
			float num39 = (localEulerAngles35.z = z35);
			Vector3 vector69 = (dial4.localEulerAngles = localEulerAngles35);
		}
		else if (num34 == 5f)
		{
			float z36 = Mathf.LerpAngle(dial4.localEulerAngles.z, -180f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles36 = dial4.localEulerAngles;
			float num40 = (localEulerAngles36.z = z36);
			Vector3 vector71 = (dial4.localEulerAngles = localEulerAngles36);
		}
		else if (num34 == 6f)
		{
			float z37 = Mathf.LerpAngle(dial4.localEulerAngles.z, -216f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles37 = dial4.localEulerAngles;
			float num41 = (localEulerAngles37.z = z37);
			Vector3 vector73 = (dial4.localEulerAngles = localEulerAngles37);
		}
		else if (num34 == 7f)
		{
			float z38 = Mathf.LerpAngle(dial4.localEulerAngles.z, -252f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles38 = dial4.localEulerAngles;
			float num42 = (localEulerAngles38.z = z38);
			Vector3 vector75 = (dial4.localEulerAngles = localEulerAngles38);
		}
		else if (num34 == 8f)
		{
			float z39 = Mathf.LerpAngle(dial4.localEulerAngles.z, -288f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles39 = dial4.localEulerAngles;
			float num43 = (localEulerAngles39.z = z39);
			Vector3 vector77 = (dial4.localEulerAngles = localEulerAngles39);
		}
		else if (num34 == 9f)
		{
			float z40 = Mathf.LerpAngle(dial4.localEulerAngles.z, -324f, dialSpeed * Time.deltaTime);
			Vector3 localEulerAngles40 = dial4.localEulerAngles;
			float num44 = (localEulerAngles40.z = z40);
			Vector3 vector79 = (dial4.localEulerAngles = localEulerAngles40);
		}
		if (nowDial)
		{
			switch (cursorId)
			{
			case 0:
				alpha1 += fadeSpeed * Time.deltaTime;
				emission1 += fadeSpeed * Time.deltaTime;
				alpha2 -= fadeSpeed * Time.deltaTime;
				emission2 -= fadeSpeed * Time.deltaTime;
				alpha3 -= fadeSpeed * Time.deltaTime;
				emission3 -= fadeSpeed * Time.deltaTime;
				alpha4 -= fadeSpeed * Time.deltaTime;
				emission4 -= fadeSpeed * Time.deltaTime;
				dial1Material.renderer.material.SetFloat("_RevealSize", 1f);
				dial2Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial3Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial4Material.renderer.material.SetFloat("_RevealSize", -1f);
				break;
			case 1:
				alpha2 += fadeSpeed * Time.deltaTime;
				emission2 += fadeSpeed * Time.deltaTime;
				alpha1 -= fadeSpeed * Time.deltaTime;
				emission1 -= fadeSpeed * Time.deltaTime;
				alpha3 -= fadeSpeed * Time.deltaTime;
				emission3 -= fadeSpeed * Time.deltaTime;
				alpha4 -= fadeSpeed * Time.deltaTime;
				emission4 -= fadeSpeed * Time.deltaTime;
				dial1Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial2Material.renderer.material.SetFloat("_RevealSize", 1f);
				dial3Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial4Material.renderer.material.SetFloat("_RevealSize", -1f);
				break;
			case 2:
				alpha3 += fadeSpeed * Time.deltaTime;
				emission3 += fadeSpeed * Time.deltaTime;
				alpha1 -= fadeSpeed * Time.deltaTime;
				emission1 -= fadeSpeed * Time.deltaTime;
				alpha2 -= fadeSpeed * Time.deltaTime;
				emission2 -= fadeSpeed * Time.deltaTime;
				alpha4 -= fadeSpeed * Time.deltaTime;
				emission4 -= fadeSpeed * Time.deltaTime;
				dial1Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial2Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial3Material.renderer.material.SetFloat("_RevealSize", 1f);
				dial4Material.renderer.material.SetFloat("_RevealSize", -1f);
				break;
			case 3:
				alpha4 += fadeSpeed * Time.deltaTime;
				emission4 += fadeSpeed * Time.deltaTime;
				alpha1 -= fadeSpeed * Time.deltaTime;
				emission1 -= fadeSpeed * Time.deltaTime;
				alpha2 -= fadeSpeed * Time.deltaTime;
				emission2 -= fadeSpeed * Time.deltaTime;
				alpha3 -= fadeSpeed * Time.deltaTime;
				emission3 -= fadeSpeed * Time.deltaTime;
				dial1Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial2Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial3Material.renderer.material.SetFloat("_RevealSize", -1f);
				dial4Material.renderer.material.SetFloat("_RevealSize", 1f);
				break;
			}
			if (status.variables[80] == status.variables[84] && status.variables[81] == status.variables[85] && status.variables[82] == status.variables[86] && status.variables[83] == status.variables[87])
			{
				status.switches[540] = 1;
				EndDial();
				return;
			}
			if (cInput.GetAxisRaw("Horizontal") == 0f && cInput.GetAxisRaw("J_Horizontal") == 0f && cInput.GetAxisRaw("DPad_Horizontal") == 0f && cInput.GetAxisRaw("Vertical") == 0f && cInput.GetAxisRaw("J_Vertical") == 0f && cInput.GetAxisRaw("DPad_Vertical") == 0f)
			{
				cursorFlag = false;
			}
			if ((cInput.GetAxisRaw("Horizontal") >= 0.1f || cInput.GetAxisRaw("J_Horizontal") >= 0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") < 0.1f)) && !cursorFlag)
			{
				cursorFlag = true;
				cursorId++;
				if (cursorId >= 4)
				{
					cursorId = 3;
				}
			}
			else if ((cInput.GetAxisRaw("Horizontal") <= -0.1f || cInput.GetAxisRaw("J_Horizontal") <= -0.1f || !(cInput.GetAxisRaw("DPad_Horizontal") > -0.1f)) && !cursorFlag)
			{
				cursorFlag = true;
				cursorId--;
				if (cursorId <= -1)
				{
					cursorId = 0;
				}
			}
			else if ((cInput.GetAxisRaw("Vertical") >= 0.1f || cInput.GetAxisRaw("J_Vertical") >= 0.1f || !(cInput.GetAxisRaw("DPad_Vertical") < 0.1f)) && !cursorFlag)
			{
				cursorFlag = true;
				switch (cursorId)
				{
				case 0:
					status.variables[84] = status.variables[84] + 1f;
					break;
				case 1:
					status.variables[85] = status.variables[85] + 1f;
					break;
				case 2:
					status.variables[86] = status.variables[86] + 1f;
					break;
				case 3:
					status.variables[87] = status.variables[87] + 1f;
					break;
				}
				if (!(status.variables[84] < 10f))
				{
					status.variables[84] = 0f;
				}
				if (!(status.variables[85] < 10f))
				{
					status.variables[85] = 0f;
				}
				if (!(status.variables[86] < 10f))
				{
					status.variables[86] = 0f;
				}
				if (!(status.variables[87] < 10f))
				{
					status.variables[87] = 0f;
				}
				audio.PlayOneShot(dialAudio);
			}
			else if ((cInput.GetAxisRaw("Vertical") <= -0.1f || cInput.GetAxisRaw("J_Vertical") <= -0.1f || !(cInput.GetAxisRaw("DPad_Vertical") > -0.1f)) && !cursorFlag)
			{
				cursorFlag = true;
				switch (cursorId)
				{
				case 0:
					status.variables[84] = status.variables[84] - 1f;
					break;
				case 1:
					status.variables[85] = status.variables[85] - 1f;
					break;
				case 2:
					status.variables[86] = status.variables[86] - 1f;
					break;
				case 3:
					status.variables[87] = status.variables[87] - 1f;
					break;
				}
				if (!(status.variables[84] > -1f))
				{
					status.variables[84] = 9f;
				}
				if (!(status.variables[85] > -1f))
				{
					status.variables[85] = 9f;
				}
				if (!(status.variables[86] > -1f))
				{
					status.variables[86] = 9f;
				}
				if (!(status.variables[87] > -1f))
				{
					status.variables[87] = 9f;
				}
				audio.PlayOneShot(dialAudio);
			}
			else if ((SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Sprint") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("Pause") || SingletonMonoBehaviour<NsInput>.Instance.GetButtonDown("J_Pause")) && !cursorFlag)
			{
				EndDial();
			}
		}
		else
		{
			alpha1 -= fadeSpeed * Time.deltaTime;
			emission1 -= fadeSpeed * Time.deltaTime;
			alpha2 -= fadeSpeed * Time.deltaTime;
			emission2 -= fadeSpeed * Time.deltaTime;
			alpha3 -= fadeSpeed * Time.deltaTime;
			emission3 -= fadeSpeed * Time.deltaTime;
			alpha4 -= fadeSpeed * Time.deltaTime;
			emission4 -= fadeSpeed * Time.deltaTime;
		}
		offsetY += scrollSpeed * Time.deltaTime;
		ValueBrake();
		dial1Material.renderer.material.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha1));
		dial2Material.renderer.material.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha2));
		dial3Material.renderer.material.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha3));
		dial4Material.renderer.material.SetColor("_FlowColor", new Color(1f, 1f, 1f, alpha4));
		dial1Material.renderer.material.SetFloat("_Emission", emission1);
		dial2Material.renderer.material.SetFloat("_Emission", emission2);
		dial3Material.renderer.material.SetFloat("_Emission", emission3);
		dial4Material.renderer.material.SetFloat("_Emission", emission4);
		dial1Material.renderer.material.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
		dial2Material.renderer.material.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
		dial3Material.renderer.material.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
		dial4Material.renderer.material.SetTextureOffset("_FlowMap", new Vector2(0f, offsetY));
	}

	public virtual void StartDial()
	{
		offsetY = 0f;
		nowDial = true;
	}

	public virtual void EndDial()
	{
		status.switches[539] = 1;
		nowDial = false;
	}

	public virtual void ValueBrake()
	{
		if (!(alpha1 < maxAlpha))
		{
			alpha1 = maxAlpha;
		}
		if (!(alpha2 < maxAlpha))
		{
			alpha2 = maxAlpha;
		}
		if (!(alpha3 < maxAlpha))
		{
			alpha3 = maxAlpha;
		}
		if (!(alpha4 < maxAlpha))
		{
			alpha4 = maxAlpha;
		}
		if (!(alpha1 > 0f))
		{
			alpha1 = 0f;
		}
		if (!(alpha2 > 0f))
		{
			alpha2 = 0f;
		}
		if (!(alpha3 > 0f))
		{
			alpha3 = 0f;
		}
		if (!(alpha4 > 0f))
		{
			alpha4 = 0f;
		}
		if (!(emission1 < 1f))
		{
			emission1 = 1f;
		}
		if (!(emission2 < 1f))
		{
			emission2 = 1f;
		}
		if (!(emission3 < 1f))
		{
			emission3 = 1f;
		}
		if (!(emission4 < 1f))
		{
			emission4 = 1f;
		}
		if (!(emission1 > 0f))
		{
			emission1 = 0f;
		}
		if (!(emission2 > 0f))
		{
			emission2 = 0f;
		}
		if (!(emission3 > 0f))
		{
			emission3 = 0f;
		}
		if (!(emission4 > 0f))
		{
			emission4 = 0f;
		}
		if (!(offsetY < 1f))
		{
			offsetY = 0f;
		}
		if (!(offsetY > -1f))
		{
			offsetY = 0f;
		}
	}

	public virtual void Dial(Transform obj)
	{
		dialFlag = true;
		dialTemp = obj.localEulerAngles.z;
	}

	public virtual void Main()
	{
	}
}
