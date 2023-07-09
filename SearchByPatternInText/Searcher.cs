using System;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string? text, string? pattern, bool overlap)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentException("Pattern cannot be null or empty.");
            }

            List<int> positions = new List<int>();

            int index = 0;
            while (index < text.Length)
            {
                int position = text.IndexOf(pattern, index);
                if (position == -1)
                {
                    break;
                }

                positions.Add(position + 1);

                if (overlap)
                {
                    index = position + 1;
                }
                else
                {
                    index = position + pattern.Length;
                }
            }

            return positions.ToArray();
        }
    }
}
