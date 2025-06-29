using System;
using UnityEngine;

[Serializable]
public class Event_03_ControlVariables : MonoBehaviour
{
	public CtrlVariable[] state;

	private Player_Status status;

	private int valueTemp;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void ControlVariables(int num)
	{
		if (state[num].variables.Length != 0)
		{
			for (i = 0; i < state[num].variables.Length; i++)
			{
				switch (state[num].variables[i].operand)
				{
				case VariableOperand.Constant:
					valueTemp = state[num].variables[i].value;
					break;
				case VariableOperand.Variable:
					valueTemp = (int)status.variables[state[num].variables[i].value];
					break;
				case VariableOperand.Random:
					valueTemp = UnityEngine.Random.Range(state[num].variables[i].randomRangeMin, state[num].variables[i].randomRangeMax + 1);
					break;
				}
				switch (state[num].variables[i].operation)
				{
				case VariableOperation.Set:
					status.variables[state[num].variables[i].variableNumber] = valueTemp;
					break;
				case VariableOperation.Add:
					status.variables[state[num].variables[i].variableNumber] = status.variables[state[num].variables[i].variableNumber] + (float)valueTemp;
					break;
				case VariableOperation.Sub:
					status.variables[state[num].variables[i].variableNumber] = status.variables[state[num].variables[i].variableNumber] - (float)valueTemp;
					break;
				case VariableOperation.Mul:
					status.variables[state[num].variables[i].variableNumber] = status.variables[state[num].variables[i].variableNumber] * (float)valueTemp;
					break;
				case VariableOperation.Div:
					status.variables[state[num].variables[i].variableNumber] = status.variables[state[num].variables[i].variableNumber] / (float)valueTemp;
					break;
				case VariableOperation.Mod:
					status.variables[state[num].variables[i].variableNumber] = status.variables[state[num].variables[i].variableNumber] % (float)valueTemp;
					break;
				}
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
