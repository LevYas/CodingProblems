namespace CodingProblems.Indices;

// 1024. Video Stitching
// You are given a series of video clips from a sporting event that lasted time seconds.
// These video clips can be overlapping with each other and have varying lengths.
// Each video clip is described by an array clips where clips[i] = [starti, endi] indicates
//      that the ith clip started at starti and ended at endi.
// We can cut these clips into segments freely.
// For example, a clip [0, 7] can be cut into segments [0, 1] + [1, 3] + [3, 7].
// Return the minimum number of clips needed so that we can cut the clips into segments
//      that cover the entire sporting event [0, time]. If the task is impossible, return -1.
// https://leetcode.com/problems/video-stitching/description/

public class VideoStitching
{
    public int CalcMinAmountOfClips(int[][] clips, int time)
    {
        // Build "timeline". Each time unit will contain all the clips that cover that unit
        List<int>[] timeUnits = new List<int>[101];

        for (int ti = 0; ti < timeUnits.Length; ti++)
            timeUnits[ti] = new List<int>();

        for (int i = 0; i < clips.Length; i++)
        {
            for (int unit = clips[i][0]; unit < clips[i][1]; unit++)
                timeUnits[unit].Add(i);
        }

        // Timeline is ready. Now, from each point we look for the farthest other clip
        int currentTime = 0;
        int currentClip = -1;
        int jumps = 0;

        while (currentTime < time)
        {
            // Getting all the clips in current point except the current one
            var otherClips = timeUnits[currentTime].Where(c => c != currentClip).ToList();

            if (!otherClips.Any())
                return -1;

            // Getting one with the longest reach
            currentClip = otherClips.OrderByDescending(c => clips[c][1]).FirstOrDefault();
            currentTime = clips[currentClip][1];
            jumps++;
        }

        return jumps;
    }
}
