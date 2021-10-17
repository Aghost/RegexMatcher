using System;

namespace Matcher.Business
{
    public static class LevenshteinAlgo
    {
        public static int LevenshteinDistance(string s_from, string s_to) {
            if (s_from.Length == 0) { return s_to.Length ;}
            if (s_to.Length == 0) { return s_from.Length ;}

            int n = s_from.Length;
            int m = s_to.Length;

            int[,] d = new int[n+1, m+1];

            for (int i = 0; i <= n; d[i,0] = i++) { }
            for (int j = 0; j <= m; d[0,j] = j++) { }

            for (int i = 1; i <= n; i++ ) {
                for (int j = 1; j <= m; j++) {
                    // current_square = check lowest of (above value, left value, aboveleft + ((current_char_to == current_char_from)) ? 0 : 1)
                    d[i,j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i , j - 1] + 1), d[i - 1, j - 1] + ((s_to[j - 1] == s_from[i - 1]) ? 0 : 1));
                }
            }

            return d[n,m];
        }
    }
}
