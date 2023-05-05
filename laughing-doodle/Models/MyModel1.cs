using laughing_doodle.Contracts;

namespace laughing_doodle.Models
{
    public class MyModel1 : IMyModel
    {
        public string MyValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
