using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Course_Schedule_II
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            HashSet<int> coursesTaken = new HashSet<int>();

            if (prerequisites == null || prerequisites.Length == 0)
            {
                for (int i = 0; i < numCourses; i++)
                {
                    coursesTaken.Add(i);
                }
            }
            else
            {
                try
                {
                    int index = 0;
                    var dict = prerequisites
                        .ToDictionary(x => ++index, y => y);

                    foreach (var item in dict)
                    {
                        HashSet<int> prereqCovered = new HashSet<int>() { item.Key };
                        coursesTaken = NextCourse(item, dict, coursesTaken, prereqCovered);
                        coursesTaken.Add(item.Value[0]);
                    }

                    if (coursesTaken.Count != numCourses)
                    {
                        for (int i = 0; i < numCourses; i++)
                        {
                            coursesTaken.Add(i);
                        }
                    }
                }
                catch
                {
                    coursesTaken = new HashSet<int>();
                }
            }

            return coursesTaken.ToArray();
        }

        private HashSet<int> NextCourse(KeyValuePair<int, int[]> course,
            Dictionary<int, int[]> prerequisites,
            HashSet<int> coursesTaken,
            HashSet<int> prereqCovered)
        {
            foreach (var item in
                prerequisites
                    .Where(x => x.Value[0] == course.Value[0] && x.Key != course.Key))
            {
                if (prereqCovered.Add(item.Key))
                {
                    coursesTaken = NextCourse(item, prerequisites, coursesTaken, prereqCovered);
                }
                else
                {
                    throw new Exception();
                }
            }

            coursesTaken.Add(course.Value[1]);
            return coursesTaken;
        }

        [Test(Description = "https://leetcode.com/problems/course-schedule-ii/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Course Schedule II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int numCourses, int[][] prerequisites) Input) item)
        {
            var response = FindOrder(item.Input.numCourses, item.Input.prerequisites);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int numCourses, int[][] prerequisites) Input)> Input
        {
            get
            {
                return new List<(int Output, (int numCourses, int[][] prerequisites) Input)>()
                {
                    (4, (3, new int[][]
                    {
                        new int[]{2,0},
                        new int[]{2,1},
                    })),
                    (4, (4, new int[][]
                    {
                        new int[]{1,0},
                        new int[]{2,0},
                        new int[]{3,1},
                        new int[]{3,2},
                    })),
                };
            }
        }
    }
}
