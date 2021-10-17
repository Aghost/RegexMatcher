using System;
using System.Collections.Generic;
using static System.Console;

namespace Matcher.App
{
    class Program
    {
        static void Main(string[] args) {
            WriteLine(Solution.isMatch("", "a*b*"));
            WriteLine(Solution.isMatch("banaantjeaaaaa", "b.....tjea*a"));
            WriteLine(Solution.isMatch("aardappel", "aardappel"));
            WriteLine(Solution.isMatch("aardappe", "aard*a*b"));
            WriteLine(Solution.isMatch("aaaabbbbbccc", "a*ab*bbbbc"));
        }
    }

    public class Solution
    {
        public static bool isMatch(string s, string p) {
            bool[][] bArr = new bool[s.Length + 1][];

            for (int i = 0; i < bArr.Length; i++) {
                bArr[i] = new bool[p.Length + 1];
            }

            bArr[0][0] = true;

            for (int i = 1; i < bArr[0].Length; i++) {
                if (p[i - 1] == '*') {
                    bArr[0][i] = bArr[0][i - 2];
                }
            }

            for (int i = 1; i < bArr.Length; i++) {
                for (int j = 1; j < bArr[0].Length; j++) {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) {
                        bArr[i][j] = bArr[i - 1][j - 1];
                    } else if (p[j - 1] == '*') {
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

    }
}
