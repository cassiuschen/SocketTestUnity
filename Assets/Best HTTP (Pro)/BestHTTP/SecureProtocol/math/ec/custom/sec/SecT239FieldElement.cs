/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Math.EC.Custom.Sec
{
    internal class SecT239FieldElement
        : ECFieldElement
    {
        protected ulong[] x;

        public SecT239FieldElement(BigInteger x)
        {
            if (x == null || x.SignValue < 0)
                throw new ArgumentException("value invalid for SecT239FieldElement", "x");

            this.x = SecT239Field.FromBigInteger(x);
        }

        public SecT239FieldElement()
        {
            this.x = Nat256.Create64();
        }

        protected internal SecT239FieldElement(ulong[] x)
        {
            this.x = x;
        }

        public override bool IsOne
        {
            get { return Nat256.IsOne64(x); }
        }

        public override bool IsZero
        {
            get { return Nat256.IsZero64(x); }
        }

        public override bool TestBitZero()
        {
            return (x[0] & 1L) != 0L;
        }

        public override BigInteger ToBigInteger()
        {
            return Nat256.ToBigInteger64(x);
        }

        public override string FieldName
        {
            get { return "SecT239Field"; }
        }

        public override int FieldSize
        {
            get { return 239; }
        }

        public override ECFieldElement Add(ECFieldElement b)
        {
            ulong[] z = Nat256.Create64();
            SecT239Field.Add(x, ((SecT239FieldElement)b).x, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement AddOne()
        {
            ulong[] z = Nat256.Create64();
            SecT239Field.AddOne(x, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement Subtract(ECFieldElement b)
        {
            // Addition and Subtraction are the same in F2m
            return Add(b);
        }

        public override ECFieldElement Multiply(ECFieldElement b)
        {
            ulong[] z = Nat256.Create64();
            SecT239Field.Multiply(x, ((SecT239FieldElement)b).x, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement MultiplyMinusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
        {
            return MultiplyPlusProduct(b, x, y);
        }

        public override ECFieldElement MultiplyPlusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
        {
            ulong[] ax = this.x, bx = ((SecT239FieldElement)b).x;
            ulong[] xx = ((SecT239FieldElement)x).x, yx = ((SecT239FieldElement)y).x;

            ulong[] tt = Nat256.CreateExt64();
            SecT239Field.MultiplyAddToExt(ax, bx, tt);
            SecT239Field.MultiplyAddToExt(xx, yx, tt);

            ulong[] z = Nat256.Create64();
            SecT239Field.Reduce(tt, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement Divide(ECFieldElement b)
        {
            return Multiply(b.Invert());
        }

        public override ECFieldElement Negate()
        {
            return this;
        }

        public override ECFieldElement Square()
        {
            ulong[] z = Nat256.Create64();
            SecT239Field.Square(x, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
        {
            return SquarePlusProduct(x, y);
        }

        public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
        {
            ulong[] ax = this.x;
            ulong[] xx = ((SecT239FieldElement)x).x, yx = ((SecT239FieldElement)y).x;

            ulong[] tt = Nat256.CreateExt64();
            SecT239Field.SquareAddToExt(ax, tt);
            SecT239Field.MultiplyAddToExt(xx, yx, tt);

            ulong[] z = Nat256.Create64();
            SecT239Field.Reduce(tt, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement SquarePow(int pow)
        {
            if (pow < 1)
                return this;

            ulong[] z = Nat256.Create64();
            SecT239Field.SquareN(x, pow, z);
            return new SecT239FieldElement(z);
        }

        public override ECFieldElement Invert()
        {
            return new SecT239FieldElement(
                AbstractF2mCurve.Inverse(239, new int[] { 158 }, ToBigInteger()));
        }

        public override ECFieldElement Sqrt()
        {
            return SquarePow(M - 1);
        }

        public virtual int Representation
        {
            get { return F2mFieldElement.Tpb; }
        }

        public virtual int M
        {
            get { return 239; }
        }

        public virtual int K1
        {
            get { return 158; }
        }

        public virtual int K2
        {
            get { return 0; }
        }

        public virtual int K3
        {
            get { return 0; }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecT239FieldElement);
        }

        public override bool Equals(ECFieldElement other)
        {
            return Equals(other as SecT239FieldElement);
        }

        public virtual bool Equals(SecT239FieldElement other)
        {
            if (this == other)
                return true;
            if (null == other)
                return false;
            return Nat256.Eq64(x, other.x);
        }

        public override int GetHashCode()
        {
            return 23900158 ^ Arrays.GetHashCode(x, 0, 4);
        }
    }
}

#endif
