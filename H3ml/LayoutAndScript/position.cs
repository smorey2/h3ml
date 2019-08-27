using H3ml.Script;

namespace H3ml.Layout
{
    partial struct position : IRect
    {
        int IRect.left => left;
        int IRect.top => top;
        int IRect.right => right;
        int IRect.bottom => bottom;
        int IRect.x => x;
        int IRect.y => y;
        int IRect.width => width;
        int IRect.height => height;
    }
}
