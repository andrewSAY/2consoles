using System;
using Domain.Exceptions;

namespace Domain
{
    public class PowerCalculator : IPowerCalculator
    {       
        public int CalculateCube(int value)
        {
            try
            {
                return checked((int)Math.Pow((double)value, 3.0));
            }
            catch (OverflowException)
            {
                throw new OperationResultBiggerPossibleException(value, "power by 3 calculation");
            }
        }

        public int CalculateSquare(int value)
        {
            try
            {
                return checked((int)Math.Pow((double)value, 2.0));
            }
            catch (OverflowException)
            {
                throw new OperationResultBiggerPossibleException(value, "power by 2 calculation");
            }
        }
    }
}
