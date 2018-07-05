using System;
using System.Collections.Generic;

namespace BrownianMotion.Components
{
    internal class RandomData
    {
        public event EventHandler SampleGeneratedEvent;

        private jp.takel.PseudoRandom.MersenneTwister _rng;
        private float _prev;
        private List<int> _samples;

        public RandomData()
        {
            _rng = new jp.takel.PseudoRandom.MersenneTwister((uint)DateTime.Now.Ticks);
            _prev = 0;
        }

        public List<int> Samples { get { return _samples; } }
        public void Generate(Entity specs)
        {
            _samples = new List<int>(specs.count + 1);
            for(int i = 0; i < specs.count; i++)
            {
                _prev += _rng.Next(specs.min, specs.max);
                _samples.Add((int)_prev + specs.offset);

                //notify sample has been updated
                //used for update progress bar
                SampleGeneratedEvent?.Invoke(i, null);
            }
        }
    }

    internal class Entity
    {
        public int count { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int offset { get; set; }
    }
}
