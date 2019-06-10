using System;
namespace Task01
{
    public class MyComplex 
    {
        public double re, im;
        
        public MyComplex(double xre, double xim)
        { re = xre; im = xim; }

        public static MyComplex operator --(MyComplex mc)
        { 
            return new MyComplex(mc.re - 1, mc.im - 1);  
        }
        
        public static MyComplex operator ++(MyComplex mc)
        { 
            return new MyComplex(mc.re + 1, mc.im + 1);  
        }
        
        public static MyComplex operator +(MyComplex mc1, MyComplex mc2)
        { 
            return new MyComplex(mc1.re + mc2.re, mc1.im + mc2.im);  
        }
        
        public static MyComplex operator -(MyComplex mc1, MyComplex mc2)
        { 
            return new MyComplex(mc1.re - mc2.re, mc1.im - mc2.im);  
        }
        
        public static MyComplex operator *(MyComplex mc1, MyComplex mc2)
        {
            double re = mc1.re * mc2.re - mc1.im * mc2.im;
            double im = mc1.im * mc2.re + mc1.re * mc2.im;
            return new MyComplex(re, im);  
        }
        
        public static MyComplex operator /(MyComplex mc1, MyComplex mc2)
        {
            double re = (mc1.re * mc2.re + mc1.im * mc2.im) / (mc2.re * mc2.re + mc2.im * mc2.im);
            double im = (mc1.im * mc2.re - mc1.re * mc2.im) / (mc2.re * mc2.re + mc2.im * mc2.im);
            return new MyComplex(re, im);  
        }
        
        public static bool operator ==(MyComplex mc1, MyComplex mc2)
        {
            return (mc1.re == mc2.re) && (mc1.im == mc2.im);
        }
        
        public static bool operator !=(MyComplex mc1, MyComplex mc2)
        {
            return (mc1.re != mc2.re) || (mc1.im != mc2.im);
        }
        
        public double Mod() { return Math.Abs(re*re+im*im); }
        
        public static bool operator true(MyComplex f) 
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }
        
        public static bool operator false(MyComplex f) 
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }

        public override string ToString()
        {
            string imStr = (im == 0 ? "" : (im > 0 ? $" + {(im == 1 ? "" : $"{im}"):G3}I" : $" - {(-im == 1 ? "" : $"{-im}"):G3}I"));
            return $"{re:G3}{imStr}";
        }

        public override bool Equals(object obj)
        {
            var complex = obj as MyComplex;
            return complex != null &&
                   re == complex.re &&
                   im == complex.im;
        }

        public override int GetHashCode()
        {
            var hashCode = -196947237;
            hashCode = hashCode * -1521134295 + re.GetHashCode();
            hashCode = hashCode * -1521134295 + im.GetHashCode();
            return hashCode;
        }
    }
}
