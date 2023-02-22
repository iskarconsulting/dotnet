using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Join
{
    public class Left
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class Right
    {
        public int Id { get; set; }
        public int LeftId { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var left = new List<Left>
            {
                new Left { Id = 0, Value = "Left Zero" },
                new Left { Id = 1, Value = "Left One" },
                new Left { Id = 2, Value = "Left Two" },
                new Left { Id = 3, Value = "Left Three" },
                new Left { Id = 4, Value = "Left Four" }
            };

            var right = new List<Right>
            {
                new Right { Id = 0, LeftId = 2, Value = "Right Zero" },
                new Right { Id = 1, LeftId = 4, Value = "Right One" },
                new Right { Id = 2, LeftId = 4, Value = "Right Two" },
                new Right { Id = 3, LeftId = 6, Value = "Right Three" }
            };

            var composite = left.Join(right, l => l.Id, r => r.LeftId, (l, r) => new {
                leftId = l.Id,
                rightId = r.Id,
                leftValue = l.Value,
                rightValue = r.Value
            });
            
            // Pretty print the composite object as JSON to the console.
            JsonSerializerOptions options = new JsonSerializerOptions {
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(composite, options));
        }
    }
}
