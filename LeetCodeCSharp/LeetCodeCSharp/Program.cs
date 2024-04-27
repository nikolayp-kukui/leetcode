// See https://aka.ms/new-console-template for more information

public class Solution
{
    public static void Main()
    {

    }

    public static int LengthOfLongestSubstringPasses_Faster_83(string s)
    {
        Dictionary<char, int> chars = new();

        int max = 0;
        int localMax = 0;
        int startingIndex = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (chars.TryGetValue(ch, out int prevIndex))
            {
                if (startingIndex > prevIndex)
                {
                    localMax++;

                    if (localMax > max)
                        max = localMax;
                }
                else
                {
                    if (localMax > max)
                        max = localMax;

                    localMax = i - prevIndex;
                    startingIndex = prevIndex + 1;
                }
            }
            else
            {
                localMax++;

                if (localMax > max)
                    max = localMax;
            }

            chars[ch] = i;
        }

        return max;
    }

    public int LengthOfLongestSubstringPassingSlow(string s)
    {
        Dictionary<char, int> chars = new();

        int max = 0;
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (chars.ContainsKey(ch))
            {
                if (result > max)
                    max = result;

                result = 0;
                i = chars[ch];
                chars.Clear();
            }
            else
            {
                result++;
                chars[ch] = i;

                if (result > max)
                    max = result;
            }
        }

        return max;
    }

    public string LongestSubstring_MisreadTheAssignment(string s)
    {
        Dictionary<char, int> chars2 = new();

        List<(int, int)> result = new();
        result.Add((0, 1));
        int resultInd = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            if (chars2.ContainsKey(ch))
            {
                int ind = chars2[ch];
                chars2[ch] = i;
                result.Add((i, 1));
            }
            else
            {
                chars2[ch] = i;
                result[resultInd] = (result[resultInd].Item1, result[resultInd].Item2 + 1);
            }
        }

        (int, int) winning = result.MaxBy(x => x.Item2);
        return s.Substring(winning.Item1, winning.Item2);
    }
}