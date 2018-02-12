using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    /// <summary>
    /// 运算符运算
    /// </summary>
    public abstract class OperatorOperation
    {
        protected object obj, obj2;
        public OperatorOperation(object o)
        {
            obj = o;
        }
        public OperatorOperation(object o,object o2)
        {
            obj = o;
            obj2 = o2;
        }
        public abstract bool IsTrue();
        public abstract bool IsTrue(object obj);
    }

    /// <summary>
    /// 相等
    /// </summary>
    public class EqOperation : OperatorOperation
    {

        public EqOperation(object o) : base(o) { }
        public EqOperation(object o,object o2) : base(o,o2) { }

        public override bool IsTrue()
        {
            return obj.Equals(obj2);
        }

        public override bool IsTrue(object obj)
        {
            return this.obj.Equals(obj);
        }
    }

    /// <summary>
    /// 不相等
    /// </summary>
    public class NotEqOperation : OperatorOperation
    {

        public NotEqOperation(object o) : base(o) { }
        public NotEqOperation(object o, object o2) : base(o, o2) { }

        public override bool IsTrue()
        {
            return !obj.Equals(obj2);
        }

        public override bool IsTrue(object obj)
        {
            return !this.obj.Equals(obj);
        }
    }

    /// <summary>
    /// 并且
    /// </summary>
    public class AndOperation : OperatorOperation
    {
        public AndOperation(object o) : base(o) { }
        public AndOperation(object o, object o2) : base(o, o2) { }

        public override bool IsTrue()
        {
            if (obj is OperatorOperation && obj2 is OperatorOperation)
                return ((OperatorOperation)obj).IsTrue() && ((OperatorOperation)obj2).IsTrue();
            return false;
        }

        public override bool IsTrue(object obj)
        {
            if (this.obj is OperatorOperation && obj is OperatorOperation)
                return ((OperatorOperation)this.obj).IsTrue() && ((OperatorOperation)obj).IsTrue();
            return false;
        }
    }

    /// <summary>
    /// 或
    /// </summary>
    public class OrOperation : OperatorOperation
    {
        public OrOperation(object o) : base(o) { }
        public OrOperation(object o, object o2) : base(o, o2) { }

        public override bool IsTrue()
        {
            if (obj is OperatorOperation && obj2 is OperatorOperation)
                return ((OperatorOperation)obj).IsTrue() || ((OperatorOperation)obj2).IsTrue();
            return false;
        }

        public override bool IsTrue(object obj)
        {
            if (this.obj is OperatorOperation && obj is OperatorOperation)
                return ((OperatorOperation)this.obj).IsTrue() || ((OperatorOperation)obj).IsTrue();
            return false;
        }
    }
}
