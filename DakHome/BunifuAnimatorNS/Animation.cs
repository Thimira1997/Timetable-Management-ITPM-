using System.Drawing;

namespace BunifuAnimatorNS
{
    internal class Animation
    {
        internal PointF BlindCoeff;

        public Animation()
        {
        }

        public bool AnimateOnlyDifferences { get; internal set; }
    }
}