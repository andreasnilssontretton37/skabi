//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace skabi.data.DomainModel
{
    public partial class Carbrand
    {
        #region Primitive Properties
    
        public virtual int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (Carbrand1 != null && Carbrand1.id != value)
                    {
                        Carbrand1 = null;
                    }
                    _id = value;
                }
            }
        }
        private int _id;
    
        public virtual string brand_name
        {
            get;
            set;
        }
    
        public virtual int brandclicks
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Carbrand Carbrands1
        {
            get { return _carbrands1; }
            set
            {
                if (!ReferenceEquals(_carbrands1, value))
                {
                    var previousValue = _carbrands1;
                    _carbrands1 = value;
                    FixupCarbrands1(previousValue);
                }
            }
        }
        private Carbrand _carbrands1;
    
        public virtual Carbrand Carbrand1
        {
            get { return _carbrand1; }
            set
            {
                if (!ReferenceEquals(_carbrand1, value))
                {
                    var previousValue = _carbrand1;
                    _carbrand1 = value;
                    FixupCarbrand1(previousValue);
                }
            }
        }
        private Carbrand _carbrand1;
    
        public virtual ICollection<Carmodel> Carmodels
        {
            get
            {
                if (_carmodels == null)
                {
                    var newCollection = new FixupCollection<Carmodel>();
                    newCollection.CollectionChanged += FixupCarmodels;
                    _carmodels = newCollection;
                }
                return _carmodels;
            }
            set
            {
                if (!ReferenceEquals(_carmodels, value))
                {
                    var previousValue = _carmodels as FixupCollection<Carmodel>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCarmodels;
                    }
                    _carmodels = value;
                    var newValue = value as FixupCollection<Carmodel>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCarmodels;
                    }
                }
            }
        }
        private ICollection<Carmodel> _carmodels;

        #endregion

        #region Association Fixup
    
        private void FixupCarbrands1(Carbrand previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.Carbrand1, this))
            {
                previousValue.Carbrand1 = null;
            }
    
            if (Carbrands1 != null)
            {
                Carbrands1.Carbrand1 = this;
            }
        }
    
        private void FixupCarbrand1(Carbrand previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.Carbrands1, this))
            {
                previousValue.Carbrands1 = null;
            }
    
            if (Carbrand1 != null)
            {
                Carbrand1.Carbrands1 = this;
                if (id != Carbrand1.id)
                {
                    id = Carbrand1.id;
                }
            }
        }
    
        private void FixupCarmodels(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Carmodel item in e.NewItems)
                {
                    item.Carbrand = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Carmodel item in e.OldItems)
                {
                    if (ReferenceEquals(item.Carbrand, this))
                    {
                        item.Carbrand = null;
                    }
                }
            }
        }

        #endregion

    }
}
