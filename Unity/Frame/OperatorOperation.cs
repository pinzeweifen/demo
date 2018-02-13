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
        public AndOperation(OperatorOperation o) : base(o) { }
        public AndOperation(OperatorOperation o, OperatorOperation o2) : base(o, o2) { }

        public override bool IsTrue()
        {
            return (obj as OperatorOperation).IsTrue() && (obj2 as OperatorOperation).IsTrue();
        }

        public override bool IsTrue(object obj)
        {
            if (obj is OperatorOperation)
                return (this.obj as OperatorOperation).IsTrue() && (obj as OperatorOperation).IsTrue();
            return false;
        }
    }

    /// <summary>
    /// 或
    /// </summary>
    public class OrOperation : OperatorOperation
    {
        public OrOperation(OperatorOperation o) : base(o) { }
        public OrOperation(OperatorOperation o, OperatorOperation o2) : base(o, o2) { }

        public override bool IsTrue()
        {
            return (obj as OperatorOperation).IsTrue() || (obj2 as OperatorOperation).IsTrue();
        }

        public override bool IsTrue(object obj)
        {
            if (obj is OperatorOperation)
                return (this.obj as OperatorOperation).IsTrue() || (obj as OperatorOperation).IsTrue();
            return false;
        }
    }
}
