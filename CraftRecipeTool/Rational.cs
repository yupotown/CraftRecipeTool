using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftRecipeTool
{
    /// <summary>
    /// 有理数 n / m
    /// </summary>
    public class Rational
    {
        public Rational()
        {
            Set(1, 1);
        }

        public Rational(int n)
        {
            Set(n, 1);
        }

        public Rational(int n, int m)
        {
            Set(n, m);
        }

        /// <summary>
        /// 分子
        /// </summary>
        public int N
        {
            get { return n; }
            set
            {
                n = value;
                reduce();
            }
        }

        /// <summary>
        /// 分母
        /// </summary>
        public int M
        {
            get { return m; }
            set
            {
                m = value;
                reduce();
            }
        }

        /// <summary>
        /// 値を設定する。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public void Set(int n, int m)
        {
            this.n = n;
            this.m = m;
            reduce();
        }

        /// <summary>
        /// 切り上げした整数を取得する。
        /// </summary>
        /// <returns></returns>
        public int RoundUp()
        {
            if (n > 0 && n % m != 0)
            {
                return n / m + 1;
            }
            else
            {
                return n / m;
            }
        }

        #region overload

        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.N * b.M + b.N * a.M, a.M * b.M);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational(a.N * b.M - b.N * a.M, a.M * b.M);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.N * b.N, a.M * b.M);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.N * b.M, a.M * b.N);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.N == b.N && a.M == b.M;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return a.N != b.N || a.M != b.M;
        }

        public static bool operator <(Rational a, Rational b)
        {
            return a.N * b.M < a.M * b.N;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a.N * b.M > a.M * b.N;
        }

        public static bool operator <=(Rational a, Rational b)
        {
            return a.N * b.M <= a.M * b.N;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            return a.N * b.M >= a.M * b.N;
        }

        public static explicit operator int(Rational a)
        {
            return a.N / a.M;
        }

        public static explicit operator double(Rational a)
        {
            return (double)a.N / a.M;
        }

        public static implicit operator Rational(int a)
        {
            return new Rational(a);
        }

        #endregion

        public override bool Equals(object obj)
        {
            var rhs = obj as Rational;
            if (rhs == null) return false;
            return this == rhs;
        }

        public override int GetHashCode()
        {
            return n.GetHashCode() ^ m.GetHashCode();
        }

        public override string ToString()
        {
            if (m == 1)
            {
                return n.ToString();
            }
            else
            {
                return string.Format("{0}/{1}", n, m);
            }
        }

        private int n, m;

        private void reduce()
        {
            if (n == 0)
            {
                m = 1;
            }
            else
            {
                if (m < 0)
                {
                    n *= -1;
                    m *= -1;
                }
                int g = gcd(Math.Abs(n), m);
                n /= g;
                m /= g;
            }
        }

        private int gcd(int a, int b)
        {
            if (a < b) return gcd(b, a);
            if (b == 0) return a;
            return gcd(b, a % b);
        }
    }
}
