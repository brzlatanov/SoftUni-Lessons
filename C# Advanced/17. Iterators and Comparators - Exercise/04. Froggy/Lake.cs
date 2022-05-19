using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake: IEnumerable<int>
    {
        private int[] lakeList = new int[]{};

        public Lake(int[] input)
        {
            lakeList = input;
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lakeList.Length; i+=2)
            {
                yield return lakeList[i];
            }
        }
        public IEnumerator<int> SecondEnumerator()
        {
            if (lakeList.Length % 2!= 0)
            {
                for (int i = lakeList.Length - 2; i >= 0; i -= 2)
                {
                    yield return lakeList[i];
                }
            }
            else
            {
                for (int i = lakeList.Length - 1; i >= 0; i -= 2)
                {
                    yield return lakeList[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       

        
    }
}
