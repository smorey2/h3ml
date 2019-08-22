// https://www.w3schools.com/jsref/dom_obj_style.asp
namespace H3ml.Script
{
    /// <summary>
    /// Interface IStyle
    /// </summary>
    public interface IStyle
    {
        /// <summary>
        /// Sets or returns the alignment between the lines inside a flexible container when the items do not use all available space
        /// </summary>
        /// <value>The content of the align.</value>
        string alignContent { get; set; }
        string alignItems { get; set; }
        string alignSelf { get; set; }
        string animation { get; set; }
        string animationDelay { get; set; }
        string animationDirection { get; set; }
        string animationDuration { get; set; }
        string animationFillMode { get; set; }
        string animationIterationCount { get; set; }
        string animationName { get; set; }
        string animationTimingFunction { get; set; }
        string animationPlayState { get; set; }
        string background { get; set; }
        string backgroundAttachment { get; set; }
        string backgroundColor { get; set; }
        string backgroundImage { get; set; }
        string backgroundPosition { get; set; }
        string backgroundRepeat { get; set; }
        string backgroundClip { get; set; }
        string backgroundOrigin { get; set; }
        string backgroundSize { get; set; }
        string backfaceVisibility { get; set; }
        string border { get; set; }
        string borderBottom { get; set; }
    }
}
