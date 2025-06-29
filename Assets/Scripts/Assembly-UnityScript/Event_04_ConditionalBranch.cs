using System;
using UnityEngine;

[Serializable]
public class Event_04_ConditionalBranch : MonoBehaviour
{
	public CtrlConditionalBranch[] state;

	private Player_Status status;

	private int valueTemp;

	private int i;

	public virtual void Start()
	{
		status = (Player_Status)GameObject.Find("StatusObjects(Clone)").GetComponent(typeof(Player_Status));
	}

	public virtual void ConditionalBranch(int num)
	{
		if (state[num].flagType == GameFlagType.Switch)
		{
			if (status.switches[state[num].switchNumber] == (int)state[num].switchIs)
			{
				SendMessage("JumpToNumber", state[num].nextProcessNumber);
			}
			else
			{
				SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
			}
		}
		else
		{
			if (state[num].variableValueType == VariableValueType.Constant)
			{
				valueTemp = state[num].variableValueOrNumber;
			}
			else
			{
				valueTemp = (int)status.variables[state[num].variableValueOrNumber];
			}
			switch (state[num].variableBranchType)
			{
			case VariableBranchType.EqualTo:
				if (status.variables[state[num].variableNumber] == (float)valueTemp)
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			case VariableBranchType.GreaterThanOrEqualTo:
				if (!(status.variables[state[num].variableNumber] < (float)valueTemp))
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			case VariableBranchType.LessThanOrEqualTo:
				if (!(status.variables[state[num].variableNumber] > (float)valueTemp))
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			case VariableBranchType.GreaterThan:
				if (!(status.variables[state[num].variableNumber] <= (float)valueTemp))
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			case VariableBranchType.LessThan:
				if (!(status.variables[state[num].variableNumber] >= (float)valueTemp))
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			case VariableBranchType.NotEqualTo:
				if (status.variables[state[num].variableNumber] != (float)valueTemp)
				{
					SendMessage("JumpToNumber", state[num].nextProcessNumber);
				}
				else
				{
					SendMessage("JumpToNumber", state[num].elseNextProcessNumber);
				}
				break;
			}
		}
		SendMessage("ExitCommandProcessing");
	}

	public virtual void Main()
	{
	}
}
