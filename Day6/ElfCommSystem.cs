namespace AdventOfCode22.Day6;

public class ElfCommSystem
{
    private const int ChunkSize = 4;

    public static int FindMarker(string buffer)
    {
        if (buffer.Length < 4) return 0;

        int markerIndex = 0;
        for (var i = 0; i <= buffer.Length - ChunkSize; i++)
        {
            var chunk = buffer.Substring(i, ChunkSize);
            if (AllCharsAreDifferent(chunk))
            {
                markerIndex = i + ChunkSize;
                break;
            }
        }

        return markerIndex;
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