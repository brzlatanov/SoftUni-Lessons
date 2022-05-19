namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullname, int age)
        {
            this.FullName = fullname;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }
        [MyRange(10, 99)]
        public int Age { get; set; }
    }
}