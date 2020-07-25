namespace ShapeClassLibrary
{
    public enum Colors
    {
        None,
        Red,
        Blue,
        Green,
        Yellow,
        Black,
        White,
        Grey,
    }
    public interface IPaper
    {
        public Colors Color { get; set; }
    }
}
