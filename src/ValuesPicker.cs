using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickFromFile
{
    class ValuesPicker
    {

        private const string COUNT_GREATER_THEN_ALL_VALUES = "Total values to pick ({0}) is greater than all values found ({1}) in input file.";
        private readonly string[] allValues;
        private readonly Random random;


        private void validatePickCount(int count)
        {
            int allValuesCount = allValues.Length;
            if (count > allValuesCount)
                throw new ArgumentException(string.Format(COUNT_GREATER_THEN_ALL_VALUES, count, allValuesCount), "count");
        }

        public ValuesPicker(string[] values)
        {
            allValues = values;
            random = new Random();
        }

        public string[] Pick(int count, bool canRepeatValues)
        {
            validatePickCount(count);

            List<string> values = allValues.ToList();
            string[] pickedValues = new string[count];
            
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(values.Count);
                pickedValues[i] = values[index];
                if (!canRepeatValues)
                {
                    values.RemoveAt(index);
                }
                
            }

            return pickedValues;
        }
    }
}
