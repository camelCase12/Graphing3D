using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Backend
{
    public class ShapeSorter
    {
        int[] sortArrayUsingTracker(double[] input)
        {
            int[] tracker = new int[input.Length];
            for (int i = 0; i < tracker.Length; i++)
            {
                tracker[i] = i;
            }
            double[] temp = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                temp[i] = input[i];
            }
            while (!isSorted(temp))
            {
                for (int i = 1; i < temp.Length; i++)
                {
                    if (temp[i - 1] > temp[i])
                    {
                        double tempElement = temp[i - 1];
                        temp[i - 1] = temp[i];
                        temp[i] = tempElement;
                        int tempTrackerElement = tracker[i - 1];
                        tracker[i - 1] = tracker[i];
                        tracker[i] = tempTrackerElement;
                    }
                }
            }
            return tracker;
        }

        Boolean isSorted(double[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (!(input[i - 1] <= input[i]))
                { // if any two consecutive elements are not ordered
                    return false;
                }
            }
            return true;
        }
    }
}
