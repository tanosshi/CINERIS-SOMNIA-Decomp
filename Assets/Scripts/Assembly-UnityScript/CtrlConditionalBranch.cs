using System;

[Serializable]
public class CtrlConditionalBranch
{
	public int nextProcessNumber;

	public int elseNextProcessNumber;

	public GameFlagType flagType;

	public int switchNumber;

	public SwitchOperation switchIs;

	public int variableNumber;

	public VariableBranchType variableBranchType;

	public VariableValueType variableValueType;

	public int variableValueOrNumber;
}
