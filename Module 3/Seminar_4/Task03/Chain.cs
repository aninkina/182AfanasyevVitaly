using System;
using System.Collections.Generic;

namespace Task03
{
    public delegate void ChainLenChanged(double r);
    public delegate void ChainCapacityChanged(double r);
    
    public class Chain
    {
        double len;
        int n;
        List<Bead> beads;

        public event ChainLenChanged ChainLenChangedEvent;
        public event ChainCapacityChanged ChainCapacityChangedEvent;
        
        public double Len 
        { 
            get => len; 
            set 
            { 
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Length of a line must be a positive number.");
                len = value;
                OnChainLenChanged((int)(Len / N));
            }
        }
        
        public int N
        {
            get => n;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Number of beads must be a positive number.");
                CreateBeads(value);
                n = value;
                OnChainCapacityChanged((int)(Len / N));
            }
        }
        
        public Chain(double len, int n)
        {
            Len = len;
            N = n;
        }

        private void CreateBeads(int n)
        {
            beads = new List<Bead>();
            for (int i = 0; i < n; ++i)
            {
                beads.Add(new Bead((int)(Len / n)));
                ChainLenChangedEvent += beads[i].ChangeRadius;
                ChainCapacityChangedEvent += beads[i].ChangeRadius;
            }
        }

        protected virtual void OnChainLenChanged(double r)
        {
            ChainLenChangedEvent?.Invoke(r); 
        }

        protected virtual void OnChainCapacityChanged(double r)
        {
            ChainCapacityChangedEvent?.Invoke(r); 
        }

        public override string ToString()
        {
            return $"Number of beads: {N}, Length: {Len:F2}, Bead radius: {beads[0].Radius}";
        }
    }
}
