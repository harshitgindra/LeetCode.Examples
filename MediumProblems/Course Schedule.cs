namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/course-schedule
    /// </summary>
    public class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Create adjacency list representation of the graph
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Build the graph: for each prerequisite pair [a,b], add an edge from b to a
            // (meaning b must be taken before a)
            foreach (var prereq in prerequisites)
            {
                int course = prereq[0];
                int prerequisite = prereq[1];
                graph[prerequisite].Add(course);
            }

            // Array to track visited nodes in current DFS path (for cycle detection)
            bool[] visited = new bool[numCourses];

            // Array to track nodes that have been fully processed
            bool[] completed = new bool[numCourses];

            // Check each course for cycles
            for (int i = 0; i < numCourses; i++)
            {
                if (!completed[i] && HasCycle(graph, i, visited, completed))
                {
                    return false; // Cycle detected, cannot finish all courses
                }
            }

            return true; // No cycles found, can finish all courses
        }

        // DFS to detect cycles in the graph
        private bool HasCycle(List<int>[] graph, int course, bool[] visited, bool[] completed)
        {
            // If this node is already in our current path, we found a cycle
            if (visited[course])
            {
                return true;
            }

            // If we've already processed this node and found no cycles, skip it
            if (completed[course])
            {
                return false;
            }

            // Mark the current node as visited in current path
            visited[course] = true;

            // Recursively check all adjacent nodes (courses that depend on this one)
            foreach (int nextCourse in graph[course])
            {
                if (HasCycle(graph, nextCourse, visited, completed))
                {
                    return true; // Propagate cycle detection
                }
            }

            // Mark the current node as not visited in current path (backtracking)
            visited[course] = false;

            // Mark this node as fully processed (no cycles found)
            completed[course] = true;

            return false; // No cycles found
        }
    }
}