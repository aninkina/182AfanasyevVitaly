using System;

namespace Task03
{
    public class PartTimeEmployee : Employee
    {
        decimal workingDays;
        
        public PartTimeEmployee(string name, decimal basepay, 
                  decimal workingDays) : base(name, basepay)
        {
            this.workingDays = workingDays;
        }
        
        public override decimal CalculatePay()
        {
            return basepay * workingDays / 25;
        }
    }
}
