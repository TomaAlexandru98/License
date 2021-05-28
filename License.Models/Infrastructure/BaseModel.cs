using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Infrastructure
{
    public abstract class BaseModel<T> where T : class, IPoco
    {
        #region Public Members

        public T Poco { get; protected set; }

        #endregion

        #region Constructor

        protected BaseModel(T poco)
        {
            Initialize(poco);
        }

        #endregion

        #region Private Methods

        private void Initialize(T poco)
        {
            SetData(poco);
            Poco = poco;
        }

        #endregion

        #region Public Methods

        public virtual void SetData(T poco)
        {

        }

        #endregion
    }
}
