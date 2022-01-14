using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Runs basic comparisons against the two parameters passed into it
/// The Comparison Depends on the Condition passed as the third paremeter.
/// Condtion
/// {
///     Or,
///     And,
///     GreaterThan,
///     LessThan,
///     Equal,
///     GreaterOrEqual,
///     LessOrEqual,
///     EqualString
/// }
/// </summary>
/// <returns>boolean</returns>
public class ComparisonOperator
    {

    public enum Condition
    {
        Or,
        And,
        GreaterThan,
        LessThen,
        Equal,
        GreaterOrEqual,
        LessOrEqual,
        EqualString
    }
    public Condition condition;


    public int ToInt(object a)
    {
        return (int)a;
    }

    public float ToFloat(object a)
    {
        return (float)a;
    }

    public decimal ToDecimal(object a)
    {
        return (decimal)a;
    }

    public double ToDouble(object a)
    {
        return (double)a;
    }

    /// <summary>
    /// Checks if param.a is greater than param.b
    /// </summary>
    /// <returns>boolean</returns>
    public bool GreaterThan(object a, object b)
    {
        if ((float)a > (float)b) return true;
        return false;
    }

    /// <summary>
    /// Checks if param.a is less than param.b (Converts params to float)
    /// </summary>
    /// <returns>boolean</returns>
    public bool LessThan(object a, object b)
    {
        if ((float)a < (float)b) return true;
        return false;
    }


    /// <summary>
    /// Checks if param.a is greater than or equal to param.b (Converts params to float)
    /// </summary>
    /// <returns>boolean</returns>
    public bool GreaterOrEqual(object a, object b)
    {
        if ((float)a >= (float)b) return true;
        return false;
    }

    /// <summary>
    /// Checks if param.a is less than or equal to param.b (Converts params to float)
    /// </summary>
    /// <returns>boolean</returns>
    public bool LessOrEqual(object a, object b)
    {
        if ((float)a <= (float)b) return true;
        return false;
    }

    /// <summary>
    /// Checks if param.a is equal to param.b  (Converts params to float)
    /// </summary>
    /// <returns>boolean</returns>
    public bool Equal(object a, object b)
    {
        if ((float)a == (float)b) return true;
        return false;
    }

    /// <summary>
    /// Checks if param.a is equal to param.b  (Converts params to string)
    /// </summary>
    /// <returns>boolean</returns>
    public bool EqualString(object a, object b)
    {
        if (a.ToString() == b.ToString()) return true;
        return false;
    }

    /// <summary>
    /// If param.a or param.b is true execute child block
    /// </summary>
    /// <returns>boolean</returns>
    public bool Or(object a, object b)
    {
        if ((bool)a || (bool)b) return true;
        return false;
    }

    /// <summary>
    /// If param.a and param.b is true execute child block
    /// </summary>
    /// <returns>boolean</returns>
    public bool And(object a, object b)
    {
        if ((bool)a && (bool)b) return true;
        return false;
    }

    public bool RunCondition(object a, object b, Condition conditionToCheck)
    {
        condition = conditionToCheck;
        return ConditionCheck(a, b);
    }

    public bool ConditionCheck(object a, object b)
    {
        switch (condition)
        {
            case Condition.And:
                return And(a, b);

            case Condition.Or:
                return Or(a, b);

            case Condition.Equal:
                return Equal(a, b);

            case Condition.GreaterThan:
                return GreaterThan(a, b);

            case Condition.LessThen:
                return LessThan(a, b);

            case Condition.GreaterOrEqual:
                return GreaterOrEqual(a, b);

            case Condition.LessOrEqual:
                return LessOrEqual(a, b);

            case Condition.EqualString:
                return EqualString(a, b);

            default: return false;
        }
    }

}

