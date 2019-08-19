namespace H3ml.Script
{
    public interface IHistory
    {
        /// <summary>
        /// Returns the number of URLs in the history list
        /// </summary>
        int length { get; }
        /// <summary>
        /// Loads the previous URL in the history list
        /// </summary>
        void back();
        /// <summary>
        /// Loads the next URL in the history list
        /// </summary>
        void forward();
        /// <summary>
        /// Loads the next URL in the history list
        /// </summary>
        void go(object numberURL);
    }
}
