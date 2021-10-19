using System;

namespace Matcher.Business
{
    public class SimpleRegex
    {
        public static bool IsMatch(string s, string p) {
            // DYNAMIC
            // Create 2d "truth" table
            bool[][] bArr = new bool[s.Length + 1][];

            for (int i = 0; i < bArr.Length; i++) {
                bArr[i] = new bool[p.Length + 1];
            }

            // Set "" == "" to true
            bArr[0][0] = true;

            // if previous == '*', set current bool to previous previous value
            for (int i = 1; i < bArr[0].Length; i++) {
                if (p[i - 1] == '*') {
                    bArr[0][i] = bArr[0][i - 2];
                }
            }

            // loop over truth table (skip first row)
            // if we encounter a '.' or char is the same, current bool = previous(j-1, i-1) result
            // if we encounter a '*', then current bool = previous(j - 2) character's result and
            //      if previous previous character was a '.' or it was equal to previous character:
            //          current character = true if current character is true, or previous(i-1) character was true
            // else the current character is false.

            for (int i = 1; i < bArr.Length; i++) {
                for (int j = 1; j < bArr[0].Length; j++) {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) {
                        bArr[i][j] = bArr[i - 1][j - 1];
                    }

                    else if (p[j - 1] == '*') {
                        bArr[i][j] = bArr[i][j - 2];

                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1]) {
                            bArr[i][j] = bArr[i][j] | bArr[i - 1][j];
                        }

                    } else {
                        bArr[i][j] = false;
                    }
                }
            }

            return bArr[s.Length][p.Length];
        }

        // Recursive
        public static bool IsMatchRecursive(string s, string p) {
            return IsMatchR(s, p, 0, 0);
        }

        public static bool IsMatchR(string s, string p, int i, int j) {
            // len check
            if (j >= p.Length) return i >= s.Length && j >= p.Length;

            if (j + 1 < p.Length && p[j + 1] == '*') {
                while (i < s.Length && (s[i] == p[j] || p[j] == '.')) {
                    if (IsMatchR(s, p, i, j + 2)) {
                        return true;
                    }
                    i++;
                }
                return IsMatchR(s, p, i, j + 2);
            } else if (i < s.Length && (s[i] == p[j] || p[j] == '.')) {
                return IsMatchR(s, p, i + 1, j + 1);
            }

            return false;
        }

    }
}
