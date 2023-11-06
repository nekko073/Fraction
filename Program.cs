using System;

namespace DemoExercise
{
    class Vector2D 
    { 
        public float x {  get; set; }
        public float y { get; set; }

        public Vector2D (float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator *(Vector2D v, float n)
        {
            return new Vector2D(v.x * n, v.y * n);  
        }

        public static Vector2D operator /(Vector2D v, float n)
        {
            if (n == 0)
            {
                throw new ArgumentException("Cannot devide by 0");
            }
            return new Vector2D(v.x / n, v.y / n);  
        }
    }
    class Fraction
    {
        int num { get; set; }
        int den { get; set; }

        public Fraction(int num, int den)
        {
            if (den == 0)
            {
                throw new ArithmeticException("Denominator cannot be zero.");
            }

            int gcd = Gcd(num, den);
            this.num = num / gcd;
            this.den = den / gcd;
        }

        // overload above method
        public Fraction(int num)
        {
            this.num = num;
            this.den = 1;
        }

        public Fraction(Fraction f)
        {
            this.num = f.num;
            this.den = f.den;
        }

        public Fraction()
        {
            this.num = 0;
            this.den = 1;
        }

        private int Gcd(int num, int den)
        {
            if (num * den == 0)
            {
                return num + den;
            }

            if (num == den)
            {
                return num;
            }

            if (num > den) return Gcd(num % den, den);
            return Gcd(num, den % num);
        }

        public Fraction Add(Fraction b)
        {
            Fraction rt = new Fraction(this);
            int num = rt.num * b.den + rt.den * b.num;
            int den = rt.den * b.den;

            int gcd = Gcd(num, den);
            rt.num = num / gcd;
            rt.den = den / gcd;

            return rt;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction rt = new Fraction();
            int num = a.num * b.den + a.den * b.num;
            int den = a.den * b.den;

            int gcd = rt.Gcd(num, den);
            rt.num = num / gcd;
            rt.den = den / gcd;
            return rt;
        }

        public static implicit operator Fraction(int n)
        {
            return new Fraction(n);
        }

        public static implicit operator float(Fraction f)
        {
            return f.num / f.den;
        }
    }

    class Program
    {
        static void Main()
        {
            Fraction a = 10;
            Fraction c = new Fraction(a);
            Fraction k = a + c;
            Vector2D vec1 = new Vector2D(2, 3);
            Vector2D vec2 = new Vector2D(5, 1);

            Vector2D resultAdd = vec1 + vec2;   

            Console.WriteLine(resultAdd.x +","+ resultAdd.y);
        }
    }
}