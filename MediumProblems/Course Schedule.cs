namespace LeetCode.MediumProblems
{
    public class Course_Schedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses < 2)
            {
                return true;
            }
            else
            {
                int[] arry = new int[numCourses];

                for (var i = 0; i < numCourses; i++)
                {
                    arry[i] = 2;
                    if (!Check(arry, i, prerequisites))
                    {
                        return false;
                    }

                    arry[i] = 1;
                }

                return true;
            }
        }


        private bool Check(int[] arry, int currCourse, int[][] prerequisites)
        {
            foreach (var item in prerequisites.Where(x => x[0] == currCourse))
            {
                if (arry[item[1]] == 1)
                {
                    return true;
                }
                else if (arry[item[1]] == 2)
                {
                    return false;
                }
                else
                {
                    arry[item[1]] = 2;
                    if (!Check(arry, item[1], prerequisites))
                    {
                        return false;
                    }

                    arry[item[1]] = 1;
                }
            }

            return true;
        }

        // private bool CheckPreReq(int course, int[][] dict, HashSet<int> pendingCourses)
        // {
        //     if (pendingCourses.Add(course))
        //     {
        //         foreach (var item in dict.Where(x => x[1] == course))
        //         {
        //             if (!CheckPreReq(item[0], dict, pendingCourses))
        //             {
        //                 return false;
        //             }
        //         }
        //     }
        //     else
        //     {
        //         return false;
        //     }
        //
        //     return true;
        // }
    }
}