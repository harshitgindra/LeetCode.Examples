using System;
using System.Linq;

namespace Leetcode.Problems.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/richest-customer-wealth/
    /// </summary>
    public class Richest_Customer_Wealth
    {
        public int MaximumWealth(int[][] accounts) {
        
            int ret = 0;
            if(accounts != null && accounts.Length > 0){
                foreach(var account in accounts){
                    ret = Math.Max(ret, account.Sum());
                }
            }
        
            return ret;
        }
    }
}