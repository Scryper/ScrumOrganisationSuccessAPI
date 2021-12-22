namespace Domain
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected bool Equals(Technology other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Technology) obj);
        }
    }
}