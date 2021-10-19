using System;

namespace Matcher.Business
{
    public static class LevenshteinAlgo
    {
        public static int LevenshteinDistance(string s_from, string s_to) {
            if (s_from.Length == 0) { return s_to.Length ;}
            if (s_to.Length == 0) { return s_from.Length ;}

            int from_len = s_from.Length;
            int to_len = s_to.Length;

            int[][] d = new int[from_len + 1][];

            for (int i = 0; i < d.Length; i++) { d[i] = new int[to_len + 1]; }

            for (int i = 0; i <= from_len; d[i][0] = i++) { }
            for (int j = 0; j <= to_len; d[0][j] = j++) { }

            for (int i = 1; i <= from_len; i++ ) {
                for (int j = 1; j <= to_len; j++) {
                    // current_square = check lowest of (above value, left value, aboveleft + ((current_char_to == current_char_from)) ? 0 : 1)
                    d[i][j] = Math.Min(
                            Math.Min(d[i - 1][j] + 1, d[i][j - 1] + 1),
                            d[i - 1][j - 1] + ((s_to[j - 1] == s_from[i - 1]) ? 0 : 1));
                }
            }

            return d[from_len][to_len];
        }
    }
}
