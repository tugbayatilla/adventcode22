namespace AdventOfCode22.Day6;

public class ElfCommSystem
{
    private const int ChunkSize = 4;

    public static int FindMarker(string buffer)
    {
        for (var i = 0; i <= buffer.Length - ChunkSize; i++)
        {
            var chunk = buffer.Substring(i, ChunkSize);
            if (AllCharsAreDifferent(chunk))
            {
                return i + ChunkSize;
            }
        }

        return 0;
    }

    private static bool AllCharsAreDifferent(string chunk)
    {
        for (int i = 0; i < chunk.Length; i++)
        {
            var restChunk = chunk.Clone().ToString().Remove(i, 1);
            if (restChunk.Contains(chunk[i]))
            {
                return false;
            }
        }

        return true;
    }
}