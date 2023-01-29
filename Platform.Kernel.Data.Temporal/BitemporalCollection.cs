using System.Linq.Expressions;

namespace Platform.Kernel.Data.Temporal
{
    public class BitemporalCollection<TValueType> : IBitemporalMarker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalCollection{TValueType}"/> class.
        /// </summary>
        public BitemporalCollection()
        {
            Items = new Dictionary<string, BitemporalProperty<TValueType>>();
        }


        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        private Dictionary<string, BitemporalProperty<TValueType>> Items { get; set; }

        public IEnumerable<string> FindMatch(Expression<Func<TValueType, object>> property, object propertyValue)
        {
            var func = property.Compile();

            return Items.Where(item => func(item.Value.CurrentValue) != null && func(item.Value.CurrentValue).Equals(propertyValue)).Select(c => c.Key);
        }

        /// <summary>
        /// Finds the match.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">propertyName</exception>
        //public List<string> FindMatch<TProperty>(Expression<Func<TValueType, TProperty>> property, object propertyValue)
        //{
        //    var memberExpression = property.Body as MemberExpression;
        //    if (memberExpression == null)
        //    {
        //        throw new ArgumentNullException("property");
        //    }
        //    return FindMatch(memberExpression.Member.Name, propertyValue);
        //}

        /// <summary>
        /// Finds the keys of any collection member who has a property name matching the given property value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">propertyName
        /// or
        /// propertyValue</exception>
        /// <exception cref="System.Exception">Cannot find values on Bitemporal properties or collections.</exception>
        private List<string> FindMatch(string propertyName, object propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            if (propertyValue == null)
            {
                throw new ArgumentNullException("propertyValue");
            }

            string propertyValueString = propertyValue.ToString();
            Type valueTypeType = typeof(TValueType);
            if (valueTypeType.IsClass)
            {
                var pi = valueTypeType.GetProperty(propertyName);
                if (pi.PropertyType.GetInterface("IBitemporalMarker") != null)
                {
                    // TODO - not massively important but figure an effient way to enable this
                    throw new Exception("Cannot find values on Bitemporal properties or collections.");
                }

                if (pi.PropertyType != propertyValue.GetType())
                {
                    throw new Exception(string.Format("Property value type mismatch. Expected {0}, found {1}", pi.PropertyType.ToString(), propertyValue.GetType().ToString()));
                }

                return (from item in Items
                        where pi.GetValue(item.Value.CurrentValue, null).ToString() == propertyValueString
                        select item.Key).ToList();
            }
            else
            {
                return (from item in Items
                        where item.Value.CurrentValue.ToString() == propertyValueString
                        select item.Key).ToList();
            }
        }

        /// <summary>
        /// Sets the specified pay element.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Set(string key, TValueType item, bool continuous = false)
        {
            var now = Interval.FromNow();
            Set(key, item, now, now, continuous);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        /// <param name="transactionInterval">The transaction interval.</param>
        public void Set(string key, TValueType value, Interval effectiveInterval, Interval transactionInterval, bool continuous = false)
        {
            if (Items.ContainsKey(key))
            {
                Items[key].AddTemporal(new BitemporalValue<TValueType>(value, effectiveInterval, transactionInterval, continuous));
            }
            else
            {
                var bt = new BitemporalProperty<TValueType>();
                bt.AddTemporal(new BitemporalValue<TValueType>(value, effectiveInterval, transactionInterval, continuous));
                Items.Add(key, bt);
            }
        }

        /// <summary>
        /// Sets the specified pay element.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Set(string key, TValueType value, Interval effectiveInterval, bool continuous = false)
        {
            Set(key, value, effectiveInterval, Interval.FromNow(), continuous);
        }

        /// <summary>
        /// Values the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TValueType Value(string key)
        {
            return Value(key, Interval.Now);
        }

        /// <summary>
        /// Returns the value valid on specified date as currently known.
        /// </summary>
        /// <param name="effectiveOn">The effective on date.</param>
        /// <returns></returns>
        public TValueType Value(string key, DateTimeOffset effectiveOn)
        {
            return Value(Get(key, effectiveOn));
        }

        /// <summary>
        /// Returns the value valid on specified date as known on given date.
        /// </summary>
        /// <param name="effectiveOn">The effective on date</param>
        /// <param name="knownOn">The known on date</param>
        /// <returns></returns>
        public TValueType Value(string key, DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            return Value(Get(key, effectiveOn, knownOn));
        }

        /// <summary>
        /// Values the specified bitemporal value.
        /// </summary>
        /// <param name="bitemporalValue">The bitemporal value.</param>
        /// <returns></returns>
        public TValueType Value(BitemporalValue<TValueType> bitemporalValue)
        {
            return bitemporalValue == null ? default(TValueType) : bitemporalValue.Value;
        }

        /// <summary>
        /// Returns the bitemporal valid as currently known.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get(string key)
        {
            return Get(key, Interval.Now);
        }

        /// <summary>
        /// Returns the bitemporal valid on specified date as currently known.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get(string key, DateTimeOffset effectiveOn)
        {
            if (Items.ContainsKey(key))
            {
                return Items[key].Get(effectiveOn);
            }
            return default(BitemporalValue<TValueType>);
        }

        /// <summary>
        /// Returns the bitemporal valid on specified date as known on given date.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="effectiveOn">The effective on date</param>
        /// <param name="knownOn">The known on date.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get(string key, DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            if (Items.ContainsKey(key))
            {
                return Items[key].Get(effectiveOn, knownOn);
            }
            return default(BitemporalValue<TValueType>);
        }

        /// <summary>
        /// Returns whether or not this property has a known value currently valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue(string key)
        {
            return HasValue(key, Interval.Now);
        }

        /// <summary>
        /// Returns whether or not this property has a value valid on given date.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns>
        ///   <c>true</c> if [has value on] [the specified valid on]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue(string key, DateTimeOffset effectiveOn)
        {
            if (Items.ContainsKey(key))
            {
                return Items[key].HasValue(effectiveOn);
            }
            return false;
        }

        /// <summary>
        /// Returns whether or not this property had a value valid on given date as known on specified date.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <param name="knownOn">The known on.</param>
        /// <returns>
        ///   <c>true</c> if [has value on] [the specified valid on]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue(string key, DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            if (Items.ContainsKey(key))
            {
                return Items[key].HasValue(effectiveOn, knownOn);
            }
            return false;
        }


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        public List<BitemporalValue<TValueType>> GetList()
        {
            return GetList(Interval.Now);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns></returns>
        public List<BitemporalValue<TValueType>> GetList(DateTimeOffset effectiveOn)
        {
            var list = new List<BitemporalValue<TValueType>>();
            foreach (var item in Items)
            {
                var bt = item.Value.Get(effectiveOn);
                if (bt != default(BitemporalValue<TValueType>))
                {
                    list.Add(bt);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <param name="knownOn">The known on.</param>
        /// <returns></returns>
        public List<BitemporalValue<TValueType>> GetList(DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            var list = new List<BitemporalValue<TValueType>>();
            foreach (var item in Items)
            {
                var bt = item.Value.Get(effectiveOn, knownOn);
                if (bt != default(BitemporalValue<TValueType>))
                {
                    list.Add(bt);
                }
            }
            return list;
        }

        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return Items.ContainsKey(key);
        }
    }
}