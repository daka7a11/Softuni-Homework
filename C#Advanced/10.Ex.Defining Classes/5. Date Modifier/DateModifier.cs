using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierExercise
{
    public class DateModifier
    {
        public int GetDayDifference(string startDateInput, string endDateInput)
        {
            DateTime startDate = DateTime.Parse(startDateInput);
            DateTime endDate = DateTime.Parse(endDateInput);
            return (int)(endDate - startDate).TotalDays;
        }
    }
}
