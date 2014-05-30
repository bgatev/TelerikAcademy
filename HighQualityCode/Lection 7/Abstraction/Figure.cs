namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
        }

        public virtual double CalcPerimeter()
        {
            throw new NotImplementedException("Must override this method");
        }

        public virtual double CalcSurface()
        {
            throw new NotImplementedException("Must override this method");
        }
    }
}
