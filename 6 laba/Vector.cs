using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Vector
    {

        private readonly int _lowRange;
        private readonly int _highRange;

        public readonly Hashtable _vector;

        public int LowRange
        {
            get { return _lowRange; }
        }

        public int HighRange
        {
            get { return _highRange; }
        }

        public Vector(int lowRange, int highRange)
        {
            _vector = new Hashtable();
            _lowRange = lowRange;
            _highRange = highRange;
            for (var i = _lowRange; i <= _highRange; i++)
                _vector[i] = 0;
        }

        public int this[int index]
        {
            get
            {
                if (index < _lowRange || index > _highRange)
                    throw new IndexOutOfRangeException("Значение индекса за пределами диапазона");
                return (int)_vector[index];
            }
            set
            {
                if (index < _lowRange || index > _highRange)
                    throw new IndexOutOfRangeException("Значение индекса за пределами диапазона");
                _vector[index] = value;
            }
        }


        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.LowRange != vector2.LowRange || vector1.HighRange != vector2.HighRange)
                throw new NotSupportedException("Операция сложения векторов с разными границами не поддерживается");
            var vector = new Vector(vector1.LowRange, vector1.HighRange);
            for (var i = vector1.LowRange; i <= vector1.HighRange; i++)
                vector[i] = vector1[i] + vector2[i];
            return vector;
        }


        public static Vector operator -(Vector vector1, Vector vector2)
        {
            if (vector1.LowRange != vector2.LowRange || vector1.HighRange != vector2.HighRange)
                throw new NotSupportedException("Операция вычитания векторов с разными границами не поддерживается");
            var vector = new Vector(vector1.LowRange, vector1.HighRange);
            for (var i = vector1.LowRange; i <= vector1.HighRange; i++)
                vector[i] = vector1[i] - vector2[i];
            return vector;
        }

        public static Vector operator *(Vector vector1, int scalar)
        {
            var vector = new Vector(vector1.LowRange, vector1.HighRange);
            for (var i = vector1.LowRange; i <= vector1.HighRange; i++)
                vector[i] = vector1[i] * scalar;
            return vector;
        }



        public static Vector operator /(Vector vector1, int scalar)
        {
            var vector = new Vector(vector1.LowRange, vector1.HighRange);
            for (var i = vector1.LowRange; i <= vector1.HighRange; i++)
                vector[i] = vector1[i] / scalar;
            return vector;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = _lowRange; i <= _highRange; i++)
                stringBuilder.AppendFormat("[{0}]{1}  ", i, _vector[i]);
            return stringBuilder.ToString();
        }

        public Vector multiplication(int scalar)
        {
            var vector = new Vector(this.LowRange, this.HighRange);
            for (var i = this.LowRange; i <= this.HighRange; i++)
                vector[i] = this[i] * scalar;
            return vector;
        }

        public Vector division(int scalar)
        {
            var vector = new Vector(this.LowRange, this.HighRange);
            for (var i = this.LowRange; i <= this.HighRange; i++)
                vector[i] = this[i] / scalar;
            return vector;
        }

        public Vector Change(int Z, ref int count)
        {
            for (int i = this.LowRange; i <= this.HighRange; i++)
            {
                if (this[i] > Z)
                {
                    this[i] = Z;
                    count++;
                }
            }
            return this;
        }
    }
}
