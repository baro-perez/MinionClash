namespace AlvaroPerez.MinionClash.Model.Units
{
    public readonly struct UnitClass
    {
        public enum Size
        {
            Small,
            Big,
        }

        public enum Shape
        {
            Cube,
            Sphere,
        }

        public enum Color
        {
            Red,
            Green,
            Blue,
        }

        public readonly Size size;
        public readonly Shape shape;
        public readonly Color color;

        public UnitClass(Size size, Shape shape, Color color)
        {
            this.size = size;
            this.shape = shape;
            this.color = color;
        }

        public override bool Equals(object obj)
        {
            return obj is UnitClass unitClass &&
                size == unitClass.size &&
                shape == unitClass.shape &&
                color == unitClass.color;
        }

        public override int GetHashCode()
        {
            var hashCode = 705553546;
            hashCode = hashCode * -1521134295 + size.GetHashCode();
            hashCode = hashCode * -1521134295 + shape.GetHashCode();
            hashCode = hashCode * -1521134295 + color.GetHashCode();
            return hashCode;
        }
    }
}
