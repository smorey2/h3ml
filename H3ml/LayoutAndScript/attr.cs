using H3ml.Script;

namespace H3ml.Layout
{
    public class attr : IAttr
    {
        bool IAttr.isId => throw new System.NotImplementedException();
        string IAttr.name => throw new System.NotImplementedException();
        string IAttr.value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        bool IAttr.specified => throw new System.NotImplementedException();
    }
}
